using System;
using OpenTK;
namespace template
{
    public class Sphere : Primitive
    {
        float radius;
        Vector3 positie;

        public Sphere(float r, Vector3 p, Material m) //create sphere
        {
            radius = r;
            positie = p;
            material = m;
        }
        

        public override Intersection Intersection(Ray ray)
        {
            
            Vector3 c = positie - ray.O; //Code adapted from lecture slides
            float t = Vector3.Dot(c, ray.D);
            Vector3 q = c - t * ray.D;
            float p = Vector3.Dot(q, q);
            if (p > Math.Pow(radius, 2)) return null;
            t -= (float)Math.Sqrt((Math.Pow(radius,2) - p));
            if ((t > 0))
            {
                normal = ((ray.D * t) - positie) / radius;
                Vector3 intersectionPoint = ray.O + (ray.D * t);

                return new Intersection(this, normal, t, material, intersectionPoint);
                
            }
            return null;
                     
        }
        
    }
}
