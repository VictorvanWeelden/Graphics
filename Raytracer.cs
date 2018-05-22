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
        Vector3 cameraRichting = new Vector3(0, 0, 1);
        public Vector3 Rechts = new Vector3(0, 0, 0);
        public Vector3 Neer = new Vector3(0, 0, 0);
        //Ray ray = new Ray(new Vector3(0), new Vector3(0,0,1), 1);
        float c;
        int Width = 256;
        int Height = 256;
        float aspectRatio;
        Camera camera;
        Vector3 richting;
        Vector3 Y = new Vector3(0, 1, 0);
        Template.Surface screen;
        Ray r;
        Vector3 light_pos = new Vector3(2, 3, 1);
        Vector3 light_color = new Vector3(1, 0.4f, 0.5f);
        Scene scene;
        float littleTotheRight;
        float littleTotheUp;

        public Raytracer(Template.Surface screen)
        {
            this.screen = screen;
            
            richting = new Vector3(0,0,0);
            Light light = new Light(light_pos, light_color);
            scene = new Scene();
            aspectRatio = (Width / Height);
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

            camera = new Camera(cameraPosition, look_at(richting, cameraPosition), RechtsVector(Y, look_at(richting, cameraPosition)), NeerVector(RechtsVector(Y, look_at(richting, cameraPosition)), cameraRichting));

            for (float i = 0; i < Width; i++)
            {
                for (float j = 0; j < Height; j++)
                {
                    // no-anti-aliasing
                
                    if(Width > Height)
                    {
                        littleTotheRight = (i + 0.5f) / Width * aspectRatio -((Width - Height)/Height);
                        littleTotheUp = ((Height - j)+ 0.5f)/Height;
                    }
                    else if(Height > Width)
                    {
                        littleTotheRight = (i + 0.5f)/ Width;
                        littleTotheUp = (((Height- j) + 0.5f) / Height)/ aspectRatio - (((Height - Width)/Width)/2);

                    }
                    else
                    {
                        littleTotheRight = (i + 0.5f) / Width;
                        littleTotheUp = ((Height - j) + 0.5f)/ Height;
                    }
                    richting = (i / camera.width * (camera.P1 - camera.P0) + j / camera.height * (camera.P2 - camera.P0)) - cameraPosition;
                    r = new Ray(cameraPosition, richting);
                    screen.Plot((int)i, (int)j, CreateColor(Trace(r).X, Trace(r).Y, Trace(r).Z));
                }
            }
        }

        Vector3 look_at(Vector3 richting, Vector3 camera)
        {
            return -Vector3.Normalize(camera - richting);
        }

        Vector3 RechtsVector(Vector3 Y, Vector3 camerarichting)
        {
            return Vector3.Normalize(Vector3.Cross(Y, camerarichting));
        }

        Vector3 NeerVector(Vector3 Rechts, Vector3 camerarichting)
        {
            return Vector3.Cross(Rechts, camerarichting);
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
