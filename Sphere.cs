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

        public static float Dot(Vector3 vector1, Vector3 vector2)
        {
            return vector1.X * vector2.X + vector1.Y * vector2.Y + vector1.Z * vector2.Z;
        }

        public override Intersection Intersection(Ray ray)
        {
            //ray.D = ray richting, ray.O = ray origin, ray.T = ray lengte, positie = middelpunt sphere
            Vector3 c = positie - ray.O; //Code aangepast naar voorbeeld uit hoorcollege
            float t = Dot(c, ray.D);
            Vector3 q = c - t * ray.D;
            float p = Vector3.Dot(q, q);
            if (p > Math.Pow(radius, 2)) return null;
            t -= (float)Math.Sqrt((Math.Pow(radius,2) - p));
            if ((t > 0))
            {
                normal = ((ray.D * t) - positie) / radius;

                return new Intersection(this, normal, t, material);
            }
            return null;
                     
        }
        
    }
}
