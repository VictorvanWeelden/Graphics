using OpenTK;

namespace template
{
    public class Intersection
    {
        public Vector3 intersectionPoint; //Intersection location
        public Primitive nearestPrimitive; //the primitive of which the color should be drawn
        public Vector3 normal; //the normal of the sphere in relation to the ray
        public float distance; //the distance from the ray origin to the intersection
        public Material material;

        public Intersection(Primitive p, Vector3 n, float d, Material m, Vector3 i)
        {
            nearestPrimitive = p;
            normal = n;
            distance = d;
            material = m;
            intersectionPoint = i;
        }
    }
}
