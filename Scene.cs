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

        public Vector3 lightPositie = new Vector3(0f, 1f, 1f);
        public Vector3 lightKleur = new Vector3(1f, 1f, 1f);
        public Vector3 sphere1Positie = new Vector3(-3f, 0f, 8f);
        public Vector3 sphere2Positie = new Vector3(0f, 0f, 8f);
        public Vector3 sphere3Positie = new Vector3(3f, 0f, 8f);
        public Vector3 kleur1 = new Vector3(0.1f, 0.1f, 1f);
        public Vector3 kleur2 = new Vector3(1f, 1f, 1f);
        public Vector3 kleur3 = new Vector3(1f, 0.1f, 0.1f);
        public Vector3 kleur4 = new Vector3(0.5f, 0.5f, 0.5f);
        public float maxintersectDist = 1000;
        public Vector3 normal;
        public Light light;
        public Vector3 kleur = new Vector3();
        public Material material;

        public int radius = 1;
        public List<Primitive> primitieven;
        List<Vector3> [] intersecties = new List<Vector3>[3];
        List<float>[] floats = new List<float>[2];

        public Scene()
        {
            light = new Light(lightPositie, lightKleur);

            Sphere sphere1 = new Sphere(radius, sphere1Positie, new Material(kleur1));
            Sphere sphere2 = new Sphere(radius, sphere2Positie, new Material(kleur2));
            Sphere sphere3 = new Sphere(radius, sphere3Positie, new Material(kleur3));
            Plane plane = new Plane(new Vector3(0,-1,0), new Vector3(10,-1,0), new Vector3(0,-1,10), 1, new Material(kleur4));
            primitieven = new List<Primitive> {plane, sphere1, sphere2, sphere3} ;
            
        }

        public Intersection IntersectMethod(Ray ray)
        {
            Intersection nearestintersection = null;
            foreach (Primitive p in primitieven )
            {
                Intersection intersection = p.Intersection(ray); // de intersection van de desbetreffende vorm (plane/sphere)
                
                if (intersection != null && intersection.distance < maxintersectDist && (nearestintersection == null || intersection.distance < nearestintersection.distance)) // er is een positief en niet oneindig ver snijpunt
                {
                        
                        normal = p.normal;
                        material = p.material;
                        nearestintersection = new Intersection(p,normal,intersection.distance,material);

                        
                    
                }
            }
            return nearestintersection;
        }

        
        
    }
}
