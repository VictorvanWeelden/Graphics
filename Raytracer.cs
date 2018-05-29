using System;
using OpenTK;

namespace template
{
    public class Raytracer
    {
        Vector3 I; //intersection
        public Vector3 cameraPosition;
        public Camera camera;
        Template.Surface screen;
        Scene scene;
        public float Width; //the number of pixels that will be drawn and primary rays that will be shot are Width * Height
        public float Height;
        public Vector2[] eindpunten; //storing some intersections of primary rays to use in the debug output
        public int maxRecursie = 5; //the limit to the number of recursions. This is necessary because we have several reflective surfaces (and it is mandatory to the assignment)

        public Raytracer(Template.Surface screen, Scene scene, int width, int height)
        {
            this.screen = screen;
            camera = new Camera(cameraPosition);
            this.scene = scene;
            Width = width;
            Height = height;
            eindpunten = new Vector2[(int)Width];
        }

        int CreateColor(float R, float G, float B) //calculating a usable color value from three floats ranging from 0 to 1 representing the red, green and blue colors.
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
                    //the direction of a ray passing through point (i,j)
                    Vector3 richting = (camera.linksboven + (i / camera.width * (camera.rechtsboven - camera.linksboven) + ((Height-j) / camera.height * (camera.linksonder - camera.linksboven)) - camera.pos));
                    //the normal of this direction
                    Vector3 richtingnorm = Vector3.Normalize(richting);    
                    Ray r = new Ray(camera.pos, richtingnorm); //the ray
                    Vector3 color = Trace(r, 0); //using Trace() to determine a color
                    //drawing this color at point (i,j) on the screen
                    screen.Plot(i, (int)Height - j, CreateColor(MathHelper.Clamp(color.X, 0, 1), MathHelper.Clamp(color.Y, 0, 1), MathHelper.Clamp(color.Z, 0, 1))); // teken de pixel

                    if (j == Height/2 && i%10 == 0) // saving intersections for debug output
                    {
                        eindpunten[i] = new Vector2(I.X, I.Z);

                    }                   
                }             
            }
        }
        
        Vector3 Trace(Ray ray, int Nrecursion)
        {
            if (Nrecursion >= maxRecursie) //stop after the max number of recursions
                return Vector3.Zero;
            Intersection intersection = scene.IntersectMethod(ray); // create an intersection for ray
            if (intersection == null) // if there is no intersection we will see the 'sky'
                return new Vector3(0.5f,0.5f,1f);
           
            Material m = intersection.material;
            
            I = intersection.intersectionPoint;            

            Vector3 N = intersection.normal; 
            

            if(m.pMirror != 0f) // partly reflective mirror or fully reflective mirror
            {
                Ray r = new Ray(I, Reflect(ray.D, N)); //shoot a new reflected ray from the intersection
                Intersection recursion = scene.IntersectMethod(r);
                //we will draw any reflected ray in the y=0 plane in the debug
                if (recursion == null && I.Y == 0 && r.D.Y == 0) 
                { screen.Line((int)Xtrans(I.X), (int)Ytrans(I.Z), (int)Xtrans((r.D.X * 10)), (int)Ytrans((r.D.Z * 10)), 0xffff00); }
                if (recursion != null && I.Y == 0 && recursion.intersectionPoint.Y == 0)
                { screen.Line((int)Xtrans(I.X), (int)Ytrans(I.Z), (int)Xtrans(recursion.intersectionPoint.X), (int)Ytrans((recursion.intersectionPoint.Z)), 0xffff00); }

                if(m.pMirror == 1f) // full reflective mirror
                { return Trace(r, Nrecursion + 1) * m.kleur; }

                return (1 - m.pMirror) * DirectIllumination(I, N) * m.kleur + m.pMirror * Trace(r, Nrecursion + 1) * m.kleur; // partly reflective mirror
            }
            if(ShadowRay(I)) //if there is an obstacle between the intersection and the lightsource, return black(shadow)
            { return Vector3.Zero; }

            return DirectIllumination(I, N) * m.kleur;   //return the color * the illumination            
        }

        bool ShadowRay(Vector3 I)
        {
            //if the ray from I to the lightsourse intersects with anything, this means the light is obstructed
            Vector3 p = scene.lightPositie - I;
            float l = (float)Math.Sqrt((p.X * p.X) + (p.Y * p.Y) + (p.Z * p.Z));
            Vector3 d = new Vector3(p.X / l, p.Y / l, p.Z / l);
            Ray shadowRay = new Ray(I + (Vector3.Multiply(d,0.01f)), d);
            Intersection shadow = scene.IntersectMethod(shadowRay);
            //if there is an intersection, draw the shadow ray in the debug output (white lines)
            if(shadow != null)
            { screen.Line((int)Xtrans(I.X), (int)Ytrans(I.Z), (int)Xtrans(shadow.intersectionPoint.X), (int)Ytrans((shadow.intersectionPoint.Z)), 0xf0f0f0); }
            if (shadow != null && shadow.distance < l)
                return true;
            return false;
            
        }

        Vector3 Reflect(Vector3 D, Vector3 N) //determines the direction of a secondary ray
        {
            return D - 2 * N * (Vector3.Dot(D, N));
        }

        Vector3 DirectIllumination(Vector3 I, Vector3 N) //determines the color and the intensity of the light from the lightsource that reaches the intersection
        {
            Vector3 l = scene.lightPositie;
            Vector3 L = l- I;

            float dist = (float)Math.Sqrt(L.X * L.X + L.Y * L.Y + L.Z * L.Z);
            L *= 1.0f / dist;  //unit vector
            float attenuation = 1 / (dist * dist);                
            return scene.lightKleur * Vector3.Dot(N, L) * attenuation;
        }

        //turn scene coordinates into display screen coordinates
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
