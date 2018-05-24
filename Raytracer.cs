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
        public Vector4[,] opslagplaatsen;
        Vector3 I;
        Vector3 N;
        Vector3 l;
        Vector3 L;
        float dist;
        float attenuation;
        Vector3 black = new Vector3(0, 0, 0);
        public Vector2[] eindpunten;

        public Raytracer(Template.Surface screen, Scene scene, int width, int height)
        {
            this.screen = screen;
            camera = new Camera(cameraPosition, cameraRichting);
            richting = new Vector3();
            richtingnorm = new Vector3();
            this.scene = scene;
            Width = (float)width;
            Height = (float)height;
            opslagplaatsen = new Vector4[width, height];
            eindpunten = new Vector2[(int)Width];
                 
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
                    richting = -(camera.P0 + (i / camera.width * (camera.P1 - camera.P0) + j / camera.height * (camera.P2 - camera.P0)) - cameraPosition);
                    richtingnorm = Vector3.Multiply(richting, (1 / ((float)Math.Sqrt((richting.X * richting.X) + (richting.Y * richting.Y) + (richting.Z * richting.Z)))));
                    float normlengte = (float)Math.Sqrt((richting.X * richtingnorm.X) + (richtingnorm.Y * richtingnorm.Y) + (richtingnorm.Z * richtingnorm.Z));
                    r = new Ray(cameraPosition, richtingnorm);
                    
                    screen.Plot((int)i, (int)j, CreateColor(Trace(r).X, Trace(r).Y, Trace(r).Z));

                    if (j == Height - 1)
                    {
                        eindpunten[(int)i] = new Vector2(t * -r.D.X, t * -r.D.Z +1);
                        
                        
                    }
                    
                }               
            }
            //cameraPosition.Y += .5f;
        }

        Vector3 Trace(Ray ray)
        {
            t = scene.IntersectMethod(ray);
            I = t*ray.D;
            N = scene.NormalMethod(ray);
            if(I == black)
            {
                return black;
            }
            return DirectIllumination(I, N);// * scene.ColorMethod(ray);
        }

        Vector3 DirectIllumination(Vector3 I, Vector3 N)
        {
            
            l = scene.lightPositie;
            L = l- I;
            dist = (float)Math.Sqrt(L.X * L.X + L.Y * L.Y + L.Z * L.Z);
            L *= 1 / dist;
          //  if(!IsVisible(I, L, dist))
           //     return new Vector3(0, 0, 0);
            
            attenuation = 1 / (dist * dist);
            return scene.lightKleur * Vector3.Dot(N, L) * attenuation;
        }

        bool IsVisible(Vector3 a, Vector3 b, float d)
        {
            c = a.X * b.X + a.Y * b.Y + a.Z * b.Z;
            if (d * c > 0)
                return true;
            else return false;                    
        }
    }
}
