using System;
using OpenTK;

namespace template
{
    public class Plane : Primitive
    {
        Vector3 lb;
        Vector3 rb;
        Vector3 lo;
        Vector3 n;
        Vector3 p;
        //Vector3 p;
        float d;
        float t;
        Vector3 dir;
        Material materiaal;

        public Plane(Vector3 linksboven, Vector3 rechtsboven, Vector3 linksonder, float D, Material m)
        {
            lb = linksboven;
            rb = rechtsboven;
            lo = linksonder;
            d = D;
            materiaal = m;
            dir = Vector3.Cross(rb - lb, lo - lb);
            n = Vector3.Normalize(dir);
            Normal(n);

        }

        public override float Intersection(Ray ray)
        {
            t = (Vector3.Dot(ray.O, n) + d) / (Vector3.Dot(ray.D, n));
            p = ray.O + (t * ray.D);
            
            ray.T = t;
            return ray.T;
            
        }

        public override Vector3 Normal(Vector3 n)
        {
            return n;
        }

    }
}
