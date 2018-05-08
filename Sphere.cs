using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace template
{
    class Sphere : Primitive
    {
        float radius;
        V3 positie;

        public Sphere(float r, V3 p) //creat sphere
        {
            radius = r;
            positie = p;
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
