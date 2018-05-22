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
        //Vector3 p;
        float d;
        Material materiaal;

        public Plane(Vector3 linksboven, Vector3 rechtsboven, Vector3 linksonder, float D, Material m)
        {
            lb = linksboven;
            rb = rechtsboven;
            lo = linksonder;
            d = D;
            materiaal = m;
        }

        public override void Intersect(Ray ray)
        {
            base.Intersect(ray);
            n = new Vector3(lb.X, rb.Y, lo.Z);
            float t = (Vector3.Dot(ray.O, n) + d) / (Vector3.Dot(ray.D, n));
            Vector3 p = ray.O + (t * ray.D);

            normal = new Vector3(lb.X, rb.Y, lo.Z);
        }
        public override void Normal(Vector3 position)
        {
            base.Normal(position);
            normal = position;
        }

        float FindIntersection(Ray ray)
        {
            Vector3 ray_richting = ray.D;
            float lengte = Vector3.Dot(ray_richting, normal);
            if (lengte == 0)
                return -1;
            float lengtee = 5;
                return lengtee;
        }

    }
}
