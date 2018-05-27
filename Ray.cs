using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTK;

namespace template
{
    public class Ray
    {
        public Vector3 O;
        public Vector3 D;
        private float T;
        
        public Ray(Vector3 o, Vector3 d)
        {
            O = o;
            D = d;
        }
    }
}
