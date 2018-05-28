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
        Vector3 I;
        public Vector3 cameraPosition = new Vector3(0, 0, 1);
        public Camera camera;
        Template.Surface screen;
        Scene scene;
        public float Width;
        public float Height;
        public Vector2[] eindpunten;

        public Raytracer(Template.Surface screen, Scene scene, int width, int height)
        {
            this.screen = screen;
            Vector3 cameraRichting = new Vector3(0, 0, -1);
            camera = new Camera(cameraPosition, cameraRichting);
            
            this.scene = scene;
            Width = width;
            Height = height;
            eindpunten = new Vector2[(int)Width];
        }

        int CreateColor(float R, float G, float B)
        {
            return ((int)(R * 255) << 16) + ((int)(G * 255) << 8) + ((int)(B * 255));
        }

        public void Render()
        {
            /*uses the camera to loop over the pixels of the screen plane and to
            generate a ray for each pixel, which is then used to find the nearest intersection.The result is
            then visualized by plotting a pixel.*/

            for (int i = 0; i < Width; i++)
            {
                for (int j = 0; j < Height; j++)
                {
                    //Vector3 richting  = linkerbovenhoek + (i/het aantal pixels in de breedte van het scherm * (rechtsboven - linksboven) ...
                    // ... + (j/ pixels in hoogte van het scherm *(linksonder - linksboven) - camerapositie)
                    Vector3 richting = (camera.linksboven + (i / camera.width * (camera.rechtsboven - camera.linksboven) + ((Height-j) / camera.height * (camera.linksonder - camera.linksboven)) - cameraPosition));
                    Vector3 richtingnorm = Vector3.Normalize(richting);    
                    Ray r = new Ray(cameraPosition, richtingnorm);
                    Vector3 color = Trace(r);
                    screen.Plot(i, (int)Height - j, CreateColor(color.X, color.Y, color.Z)); // teken de pixel

                    if (j == Height/2 && i%5 == 0) // bewaar snijpunten voor de debug in vector2 array eindpunten
                    {
                        eindpunten[i] = new Vector2(I.X, I.Z);

                    }
                    
                }             
            }
           
           // camera.schermz += 0.001f; aanpassen scherm positie
          //  P2_P0 = camera.ScreenWidth();
          //  P1_P0 = camera.ScreenHeight();
        }
        
        Vector3 Trace(Ray ray)
        {
            Intersection intersection = scene.IntersectMethod(ray);
            if (intersection == null)
                return Vector3.Zero;
           
            Material m = intersection.material;
            
            I = intersection.intersectionPoint; //ray.O + (t * ray.D); // het snijpunt van de ray
            

            Vector3 N = intersection.normal; // de normal van primitieve tov de ray
            /*if (I.Z == ray.O.Z) //als er geen snijpunt is teken zwart
            {
                return black;
            }*/
            return DirectIllumination(I, N) * m.kleur;
            
            
        }

        Vector3 DirectIllumination(Vector3 I, Vector3 N)
        {
            Vector3 l = scene.lightPositie;
            Vector3 L = l- I;

            float dist = (float)Math.Sqrt(L.X * L.X + L.Y * L.Y + L.Z * L.Z);
            L *= 1.0f / dist;  //unit vector
            if(!IsVisible(I, L, dist))
               return Vector3.Zero;


            float attenuation = 1 / (dist * dist);
                //1 / (dist * dist);
            float dot = Vector3.Dot(N, L);
            return scene.lightKleur * Vector3.Dot(N, L) * attenuation;
        }

        bool IsVisible(Vector3 I, Vector3 L, float d)
        {
            
            float c = Vector3.Dot(I, L);
            if (d * c < 0)  //uit mn hoofd moet dit > 0 zijn maar dat werkt niet
            {
                return true;
                
            }
            else return false;                    
        }
    }
}
