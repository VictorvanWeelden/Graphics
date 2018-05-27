using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTK;

namespace template
{
    public class Raytracer
    {
        public Vector3 cameraPosition = new Vector3(0, 0, 1);
        Vector3 cameraRichting = new Vector3(0, 0, 1); // Deze waarde maakt niets uit for some reason.
        float c;
        public Camera camera;
        Vector3 richting;
        Vector3 richtingnorm;
        Template.Surface screen;
        Ray r;
        public float t;
        Scene scene;
        public float Width;
        public float Height;
        public float HalfHeight;
        Vector3 I;
        Vector3 N;
        Vector3 l;
        Vector3 L;
        float dist;
        float attenuation;
        Vector3 black = new Vector3(0, 0, 0);
        public Vector2[] eindpunten;
        public Vector3 P2_P0;
        public Vector3 P1_P0;
        Material m;

        public Raytracer(Template.Surface screen, Scene scene, int width, int height)
        {
            this.screen = screen;
            camera = new Camera(cameraPosition, cameraRichting);
            richting = new Vector3();
            richtingnorm = new Vector3();
            this.scene = scene;
            Width = width;
            Height = height;
            eindpunten = new Vector2[(int)Width];
            HalfHeight = Height / 2;
            P2_P0 = camera.ScreenWidth();
            P1_P0 = camera.ScreenHeight();                 
        }

        int CreateColor(float R, float B, float G)
        {
            return ((int)(R * 255) << 16) + ((int)(B * 255) << 8) + ((int)G * 255);
        }

        public void Render()
        {
            /*uses the camera to loop over the pixels of the screen plane and to
            generate a ray for each pixel, which is then used to find the nearest intersection.The result is
            then visualized by plotting a pixel.*/

            for (float i = 0; i < Width; i++)
            {
                for (float j = 0; j < Height; j++)
                {
                    /*Vector3 richting  = linkerbovenhoek + (i/het aantal pixels in de breedte van het scherm * (rechtsboven - linksboven)
                    + (j/ pixels in hoogte van het scherm *(linksonder - linksboven) - camerapositie)*/
                    richting = (camera.P0 + (i / camera.width * (P1_P0) + ((Height-j) / camera.height * (P2_P0)) - cameraPosition));
                    richtingnorm = Vector3.Normalize(richting);    
                    r = new Ray(cameraPosition, richtingnorm);
                    screen.Plot((int)i, (int)j, CreateColor(Trace(r).X, Trace(r).Y, Trace(r).Z)); // teken de pixel

                    if (j == HalfHeight && i%10 == 0) // bewaar snijpunten voor de debug in vector2 array eindpunten
                    {
                        eindpunten[(int)i] = new Vector2(I.X, I.Z);
                    }
                    
                }             
            }
           
           // camera.schermz += 0.001f; aanpassen scherm positie
          //  P2_P0 = camera.ScreenWidth();
          //  P1_P0 = camera.ScreenHeight();
        }
        
        Vector3 Trace(Ray ray)
        {
            scene.IntersectMethod(ray); 
            t = scene.rayt; // de lengte van de ray
            m = scene.material;
           
            I = ray.O + (t * ray.D); // het snijpunt van de ray
            
            N = scene.normal; // de normal van primitieve tov de ray
            if(I.Z == ray.O.Z) //als er geen snijpunt is teken zwart
            {
                return black;
            }

            return DirectIllumination(I, N) * m.kleur;
        }

        Vector3 DirectIllumination(Vector3 I, Vector3 N)
        {
            l = scene.lightPositie;
            L = l - I;

            dist = (float)Math.Sqrt(L.X * L.X + L.Y * L.Y + L.Z * L.Z);
            L =  L * (1.0f / dist);
            if(!IsVisible(I, L, dist))
                return black;            
            
            attenuation = 1 / (dist * dist);
            return scene.lightKleur * Vector3.Dot(N, L) * attenuation;
        }

        bool IsVisible(Vector3 a, Vector3 b, float d)
        {
            
            c = Vector3.Dot(a, b);
            if (d * c < 0)
            {
                return true;
                
            }
            else return false;                    
        }
    }
}
