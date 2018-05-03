using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace template
{
    class ParametricFormObj
    {
        ParametricFormObj()
        {

        }

        public V2 platvlak(V2 vector1, V2 vector2)
        {
            V2 Answere = new V2(0,0);
            float l = (vector2.X - vector1.X) / vector2.X;
            float X = vector1.X + l * vector2.X;
            float Y = vector1.Y + (vector2.Y * (vector1.Y - vector2.Y)) / vector2.X;
            Answere.X = X;
            Answere.Y = Y;
            return Answere;    
        }

        public V2 circle(V2 positie, float straal, double a)
        {
            V2 result = new V2(0,0);
            float x = positie.X + straal * (float)Math.Cos(a);
            float y = positie.Y + straal * (float)Math.Sin(a);
            result.X = x;
            result.Y = y;
            return result;
        }

     /*   void Sphere(Ray ray) // van buiten naar binnen
        {
            V3 c = this.pos - ray.O;
            float t = dot(c, ray.D);
            V3 q = c - t * ray.D;
            float p2 = dot(q * q);
            if (p2 > sphere.r2)
                return;
            t -= Math.Sqrt(sphere.r2 - p2);
            if ((t < ray.t) && (t > 0))
                ray.t = t;
        }
        */
    }
}
