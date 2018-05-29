using System;
using OpenTK;

namespace template
{
    public class Plane : Primitive
    {
        Vector3 n;
        float d;
        Vector3 lb;

        public Plane(Vector3 linksboven, Vector3 rechtsboven, Vector3 linksonder, float D)
        {
            lb = linksboven;
            Vector3 rb = rechtsboven;
            Vector3 lo = linksonder;
            d = D;
            Vector3 dir = Vector3.Cross(rb - lb, lo - lb);
            n = Vector3.Normalize(dir);
            normal = n;
        }

        public override Intersection Intersection(Ray ray)
        {
            // afstand van origin ray tot snijpunt is het dotproduct van de origin en de normal / ...
            //... het dotproduct van de richting van de ray en de normal
            float t = (Vector3.Dot(ray.O, n) + d) / (Vector3.Dot(ray.D, n));
            if (t > 0)
            {
                Vector3 intersectionPoint = ray.O + (ray.D * t);
                int F = (((int)(2 * (intersectionPoint.X - lb.X)) + ((int)(intersectionPoint.Z - lb.Z)))) & 1;
                
                if (F == 1)
                { return new Intersection(this, -normal, t, new Material(Vector3.Zero, 0f), intersectionPoint); }
                return new Intersection(this, -normal, t, new Material(Vector3.One, 0.5f), intersectionPoint); 
                

            }
            return null;
        }
    }
}
