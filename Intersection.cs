using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTK;

namespace template
{
    public class Intersection
        //stores the result of an intersection. Apart from the intersection distance,
        //you will at least want to store the nearest primitive, but perhaps also the normal at the intersection point.
    {
        public Vector3 intersectionPoint;
        public Primitive nearestPrimitive;
        public Vector3 normal;
        public float distance;
        public Material material;

        public Intersection(Primitive p, Vector3 n, float d, Material m, Vector3 i)// dit werkt niet want het doet niks!!!!
        {
            nearestPrimitive = p;
            normal = n;
            distance = d;
            material = p.material;
            intersectionPoint = i;
        }
    }
}
