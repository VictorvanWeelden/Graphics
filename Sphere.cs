using System;

namespace template
{
    public class Sphere : Primitive
    {
        float radius;
        V3 positie;
        V3 kleur;

        public Sphere(float r, V3 p, V3 k) //create sphere
        {
            radius = r;
            positie = p;
            kleur = k;
        }

        void SphereIntersect(Ray ray)
        {
            V3 c = this.positie - ray.O; //sphere intersection code from lecture (modified to work in C# with our variables)
            float t = c.dot(c, ray.D);
            V3 q = c - t * ray.D;
            float p = q.dot(q, q);
            if (p > Math.Pow(this.radius, 2)) return;
            t -= (float)Math.Sqrt(this.radius - p);
            if ((t < ray.T) && (t > 0)) ray.T = t;
        }
    }
}
