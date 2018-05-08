using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace template
{
    public class Ray
    {
        public V3 O;
        public V3 D;
        public float T;

        public Ray(V3 o, V3 d, float t)
        {
            O = o;
            D = d;
            T = t;
        }
    }
}
