using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTK;

namespace template
{
    class Raytracer
    {
        Vector3 cameraPosition = new Vector3(0, 0, 0);
        Vector3 cameraRichting = new Vector3(0, 0, 1);
        //Ray ray = new Ray(new Vector3(0), new Vector3(0,0,1), 1);
        Scene scene = new Scene();
        float c;
        Camera camera;
        Vector3 richting;
        Template.Surface screen = new Template.Surface(100, 100);
        

        public Raytracer()
        {
            
            camera = new Camera(cameraPosition, cameraRichting);
            richting = new Vector3();     
        }
        int CreateColor(float R, float B, float G)
        {
            return ((int)R * 255) << 16 + ((int)B * 255) << 8 + ((int)G * 255);
        }

        public void Render()
        {
            /*uses the camera to loop over the pixels of the screen plane and to
            generate a ray for each pixel, which is then used to find the nearest intersection.The result is
            then visualized by plotting a pixel.*/
            

            for (float i = 0; i < 256; i++)
               
            {
                for (float j = 0; j < 256; j++)
                {
                    richting = (i /camera.width  * (camera.P1 - camera.P0) + j/camera.height * (camera.P2-camera.P0)) - cameraPosition;
                    Ray r = new Ray(cameraPosition, richting);
                    screen.Plot((int)i, (int)j, CreateColor(Trace(r).X, Trace(r).Y, Trace(r).Z));

                }
            }

        }

        Vector3 Trace(Ray ray)
        {
           scene.IntersectMethod(ray);
            Vector3 I = scene.intersection;
            Vector3 N = scene.normal;
            if(I == null)
            {
                return new Vector3(0, 0, 0);
            }
            return DirectIllumination(I,N)/* *material.diffuseColor*/;

        }

        Vector3 DirectIllumination(Vector3 I, Vector3 N)
        {
            Vector3 l = scene.light.positie;
            Vector3 L = l- I;
            float dist = (float)Math.Sqrt(L.X * L.X + L.Y * L.Y + L.Z * L.Z);
            L *= 1 / dist;
            if (!IsVisible(I, L, dist))
                return new Vector3(0, 0, 0);
            float attenuation = 1 / (dist * dist);
            return scene.light.kleur * Vector3.Dot(N, L) * attenuation;
        }

        bool IsVisible(Vector3 a, Vector3 b, float d)
        {
            c = a.X * b.X + a.Y * b.Y + a.Z * b.Z;
            if (c > 0)
                return true;
            else return false;
                    
        }
    }
}
