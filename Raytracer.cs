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
        public Vector3 cameraPosition;
        public Camera camera;
        Template.Surface screen;
        Scene scene;
        public float Width;
        public float Height;
        public Vector2[] eindpunten;
        public int maxRecursie = 5;

        public Raytracer(Template.Surface screen, Scene scene, int width, int height)
        {
            this.screen = screen;
            camera = new Camera(cameraPosition);
        
            
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
                    Vector3 richting = (camera.linksboven + (i / camera.width * (camera.rechtsboven - camera.linksboven) + ((Height-j) / camera.height * (camera.linksonder - camera.linksboven)) - camera.pos));
                    Vector3 richtingnorm = Vector3.Normalize(richting);    
                    Ray r = new Ray(camera.pos, richtingnorm);
                    Vector3 color = Trace(r, 0);
                    screen.Plot(i, (int)Height - j, CreateColor(MathHelper.Clamp(color.X, 0, 1), MathHelper.Clamp(color.Y, 0, 1), MathHelper.Clamp(color.Z, 0, 1))); // teken de pixel

                    if (j == Height/2 && i%10 == 0) // bewaar snijpunten voor de debug in vector2 array eindpunten
                    {
                        eindpunten[i] = new Vector2(I.X, I.Z);

                    }                   
                }             
            }
        }
        
        Vector3 Trace(Ray ray, int Nrecursion)
        {
            if (Nrecursion >= maxRecursie)
                return Vector3.Zero;
            Intersection intersection = scene.IntersectMethod(ray);
            if (intersection == null)
                return new Vector3(0.5f,0.5f,1f);
           
            Material m = intersection.material;
            
            I = intersection.intersectionPoint; //ray.O + (t * ray.D); // het snijpunt van de ray           

            Vector3 N = intersection.normal; // de normal van primitieve tov de ray
            /*if (I.Z == ray.O.Z) //als er geen snijpunt is teken zwart
            {
                return black;
            }*/

            if(m.pMirror != 0f) // partly reflective mirror or fully reflective mirror
            {
                Ray r = new Ray(I, Reflect(ray.D, N));
                Intersection recursion = scene.IntersectMethod(r);
                if (recursion == null && I.Y == 0 && r.D.Y == 0)
                { screen.Line((int)Xtrans(I.X), (int)Ytrans(I.Z), (int)Xtrans((r.D.X * 10)), (int)Ytrans((r.D.Z * 10)), 0xffff00); }
                if (recursion != null && I.Y == 0 && recursion.intersectionPoint.Y == 0)
                { screen.Line((int)Xtrans(I.X), (int)Ytrans(I.Z), (int)Xtrans(recursion.intersectionPoint.X), (int)Ytrans((recursion.intersectionPoint.Z)), 0xffff00); }

                if(m.pMirror == 1f) // full reflective mirror
                { return Trace(r, Nrecursion + 1) * m.kleur; }

                return (1 - m.pMirror) * DirectIllumination(I, N) * m.kleur + m.pMirror * Trace(r, Nrecursion + 1) * m.kleur; // partly reflective mirror
            }
            if(ShadowRay(I))
            { return Vector3.Zero; }

            return DirectIllumination(I, N) * m.kleur;                        
        }

        bool ShadowRay(Vector3 I)
        {
            Vector3 p = scene.lightPositie - I;
            float l = (float)Math.Sqrt((p.X * p.X) + (p.Y * p.Y) + (p.Z * p.Z));
            Vector3 d = new Vector3(p.X / l, p.Y / l, p.Z / l);
            Ray shadowRay = new Ray(I + (Vector3.Multiply(d,0.01f)), d);
            Intersection shadow = scene.IntersectMethod(shadowRay);
            //if(shadow == null)
            //{ screen.Line((int)Xtrans(I.X), (int)Ytrans(I.Z), (int)Xtrans((shadowRay.D.X * 10)), (int)Ytrans((shadowRay.D.Z * 10)), 0xf0f0f0); }
            if(shadow != null)
            { screen.Line((int)Xtrans(I.X), (int)Ytrans(I.Z), (int)Xtrans(shadow.intersectionPoint.X), (int)Ytrans((shadow.intersectionPoint.Z)), 0xf0f0f0); }
            if (shadow != null && shadow.distance < l)
                return true;
            return false;
            
        }

        Vector3 Reflect(Vector3 D, Vector3 N)
        {
            return D - 2 * N * (Vector3.Dot(D, N));
        }

        Vector3 DirectIllumination(Vector3 I, Vector3 N)
        {
            Vector3 l = scene.lightPositie;
            Vector3 L = l- I;

            float dist = (float)Math.Sqrt(L.X * L.X + L.Y * L.Y + L.Z * L.Z);
            L *= 1.0f / dist;  //unit vector
            float attenuation = 1 / (dist * dist);                
            return scene.lightKleur * Vector3.Dot(N, L) * attenuation;
        }

        
        public float Xtrans(float x)
        {
            return x * (screen.width / 20) + (screen.width * 3 / 4);
        }

        public float Ytrans(float y)
        {
            return screen.height - (y * (screen.height / 10));
        }
    }
}
