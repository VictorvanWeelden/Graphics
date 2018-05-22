using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTK;

namespace template
{
    public class Scene
    {
        //stores a list of primitives and light sources. It implements a scene-level Intersect
        //method, which loops over the primitives and returns the closest intersection.

        Vector3 lightPositie = new Vector3(-1f, 0f, 0f);
        Vector3 lightKleur = new Vector3(1f, 1f, 0.1f);
        Vector3 sphere1Positie = new Vector3(-3f, 0f, 8f);
        Vector3 sphere2Positie = new Vector3(0f, 0f, 8f);
        Vector3 sphere3Positie = new Vector3(3f, 0f, 8f);
        Vector3 kleur1 = new Vector3(0.1f, 0.1f, 1f);
        Vector3 kleur2 = new Vector3(0.5f, 0.5f, 0.1f);
        Vector3 kleur3 = new Vector3(1f, 0.1f, 0.1f);
        Vector3 kleur4 = new Vector3(1f, 0.1f, 0.1f);
        public float intersectDist = 100;
        public Material material;
        public Vector3 intersection;
        public Vector3 normal;
        public Light light;
       
        int radius = 1;
        List<Primitive> primitieven;
        List<Vector3> [] intersecties = new List<Vector3>[3];
        List<float>[] floats = new List<float>[2];

        public Scene()
        {
            light = new Light(lightPositie, lightKleur);
            Sphere sphere1 = new Sphere(radius, sphere1Positie, new Material());
            Sphere sphere2 = new Sphere(radius, sphere2Positie, new Material());
            Sphere sphere3 = new Sphere(radius, sphere3Positie, new Material());
            Plane plane = new Plane(new Vector3(0,-1,0), new Vector3(10,-1,0), new Vector3(0,-1,10), 1, new Material());
            primitieven = new List<Primitive>();
            primitieven.Add(sphere1);
            primitieven.Add(sphere2);
            primitieven.Add(sphere3);
            primitieven.Add(plane);
   
        }


        public void IntersectMethod(Ray ray)
        {           
            foreach (Primitive p in primitieven )
            {
                p.Intersect(ray);
            }
            
        }
    }

    public class Intersect
    {
        public Primitive Objecten;
        public Ray ray;
        public float afstand;
    }
}
