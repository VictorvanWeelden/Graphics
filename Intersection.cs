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

        public Intersection(Primitive p, Vector3 n, float d, Material m)// dit werkt niet want het doet niks!!!!
        {
            Primitive nearestPrimitive = p;
            Vector3 normal = n;
            float distance = d;
            Material material = p.material;
            intersectionPoint = d * n;
        }
    }
}
