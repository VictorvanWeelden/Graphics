using OpenTK;

namespace template
{
    public class Plane : Primitive
    {
        Vector3 n; //normal to the plane
        float d; // distance from the origin
        Vector3 lb; //P0 of the plane

        public Plane(Vector3 linksboven, Vector3 rechtsboven, Vector3 linksonder, float D)
        {
            lb = linksboven;
            Vector3 rb = rechtsboven; //p1
            Vector3 lo = linksonder;//p2
            d = D;
            Vector3 dir = Vector3.Cross(rb - lb, lo - lb);
            n = Vector3.Normalize(dir);
            normal = n;
        }

        public override Intersection Intersection(Ray ray)
        {
            // the distance from the ray origin to the intersection is the dot product of the origin and the normal divided by
            // the dot product of the ray direction and the normal
            float t = (Vector3.Dot(ray.O, n) + d) / (Vector3.Dot(ray.D, n));
            if (t > 0) //t must be positive for an intersection to be visible
            {
                Vector3 intersectionPoint = ray.O + (ray.D * t); //intersection = origin + (direction * length)

                //drawing a checkerboard pattern. 
                int F = (((int)(2 * (intersectionPoint.X - lb.X)) + ((int)(intersectionPoint.Z - lb.Z)))) & 1;
                if (F == 1)
                { return new Intersection(this, normal, t, new Material(Vector3.Zero, 0f), intersectionPoint); }
                return new Intersection(this, normal, t, new Material(Vector3.One, 0.5f), intersectionPoint); 
                

            }
            return null;
        }
    }
}
