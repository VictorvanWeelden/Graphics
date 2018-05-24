﻿using System;
using OpenTK;

namespace template
{
    public class Plane : Primitive
    {
        Vector3 lb;
        Vector3 rb;
        Vector3 lo;
        Vector3 n;
        Vector3 p;
        //Vector3 p;
        float d;
        float t;
        Material materiaal;

        public Plane(Vector3 linksboven, Vector3 rechtsboven, Vector3 linksonder, float D, Material m)
        {
            lb = linksboven;
            rb = rechtsboven;
            lo = linksonder;
            d = D;
            materiaal = m;
        }

        public override float Intersection(Ray ray)
        {
            n = new Vector3(lb.X, rb.Y, lo.Z);
            t = (Vector3.Dot(ray.O, n) + d) / (Vector3.Dot(ray.D, n));
            p = ray.O + (t * ray.D);

            normal = new Vector3(lb.X, rb.Y, lo.Z);
            ray.T = t;
            return ray.T;
            
        }
        public override void Normal(Vector3 position)
        {
            base.Normal(position);
            normal = position;
        }

    }
}
