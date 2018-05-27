using System;
using OpenTK;
namespace template
{
    public class Sphere : Primitive
    {
        float radius;
        Vector3 positie;
        Vector3 c;
        float t;
        Vector3 q;
        float p;

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

        public override void Intersection(Ray ray)
        {
            //ray.D = ray richting, ray.O = ray origin, ray.T = ray lengte, positie = middelpunt sphere
            c = positie - ray.O; //Code aangepast naar voorbeeld uit hoorcollege
            t = Dot(c, ray.D);
            q = c - t * ray.D;
            p = Vector3.Dot(q, q);
            if (p > Math.Pow(radius, 2)) return;
            t -= (float)Math.Sqrt((Math.Pow(radius,2) - p));
            if ((t < ray.T) && (t > 0))
            { ray.T = t; }

            normal = ((ray.D * ray.T) - positie) / radius;                    
        }
        
    }
}
