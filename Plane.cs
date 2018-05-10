﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace template
{
    class Plane : Primitive
    {
        V3 lb;
        V3 rb;
        V3 lo;
        V3 n;
        V3 p;
        float d;

        public Plane(V3 linksboven, V3 rechtsboven, V3 linksonder, float D)
        {
            lb = linksboven;
            rb = rechtsboven;
            lo = linksonder;
            d = D;
        }

        void PlaneIntersect(Ray ray)
        {
            n = new V3(lb.X, rb.Y, lo.Z);
            float t = (V3.Dot(ray.O, n) + d) / (V3.Dot(ray.D, n));
            V3 p = ray.O + (t * ray.D);
        }

    }
}
