using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace template
{
    class Ray
    {
        V3 O;
        V3 D;
        float T;

        public Ray(V3 o, V3 d, float t)
        {
            O = o;
            D = d;
            T = t;
        }
    }
}
