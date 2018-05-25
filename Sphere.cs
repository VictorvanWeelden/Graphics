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

        public override float Intersection(Ray ray)
        {
            
            c = this.positie - ray.O; //sphere intersection code from lecture (modified to work in C# with our variables)
            t = Dot(c, ray.D);
            q = c - t * ray.D;
            p = Dot(q, q);
            if (p > Math.Pow(this.radius, 2)) return 0f;
            t -= (float)Math.Sqrt(this.radius - p);
            if ((t < ray.T) && (t > 0)) ray.T = t;

            normal = ((ray.D * ray.T) - positie) / radius;
            return ray.T;           
        }
        
    }
}
