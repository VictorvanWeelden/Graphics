using System.Collections.Generic;
using OpenTK;

namespace template
{
    public class Scene
    {
        
             
        //stores a list of primitives and light sources. It implements a scene-level Intersect
        //method, which loops over the primitives and returns the closest intersection.

        //position and color of the lightsource
        public Vector3 lightPositie = new Vector3(1f, 10f, 5f); 
        public Vector3 lightKleur = new Vector3(100f, 100f, 100f);

        //positions and colors of the primitives
        public Vector3 sphere1Positie = new Vector3(-3f, 0f, 6f);
        public Vector3 sphere2Positie = new Vector3(0f, 0f, 7f);
        public Vector3 sphere3Positie = new Vector3(3f, 0f, 6f);
        public Vector3 kleur1 = new Vector3(0.1f, 1f, 0.1f);
        public Vector3 kleur2 = new Vector3(0.1f, 1f, 1f);
        public Vector3 kleur3 = new Vector3(1f, 0.1f, 0.1f);
        public Vector3 kleur4 = new Vector3(0.5f, 0.5f, 0.5f);
        public int radius = 1;

        public float maxintersectDist = 100; //arbitrary number to make sure intersect distances are not infinite

        public List<Primitive> primitieven;

        public Scene()
        {
            //create the light and the primitives and make a list of the primitives
            Light light = new Light(lightPositie, lightKleur);

            Sphere sphere1 = new Sphere(radius, sphere1Positie, new Material(kleur1, 0f));
            Sphere sphere2 = new Sphere(radius, sphere2Positie, new Material(kleur2, 1f));
            Sphere sphere3 = new Sphere(radius, sphere3Positie, new Material(kleur3, 0.75f));
            Plane plane = new Plane(new Vector3(-5, -1, 10), new Vector3(5, -1, 10), new Vector3(-5, -1, 0), -1);
            primitieven = new List<Primitive> { plane, sphere1, sphere2, sphere3} ;
            
        }

        public Intersection IntersectMethod(Ray ray)
        {
            Intersection nearestintersection = null;
            foreach (Primitive p in primitieven )
            {
                Intersection intersection = p.Intersection(ray); // the intersection method of either the sphere or the plane
                
                //if there is a valid intersection and it is smaller than the currect nearest intersection (or there is no nearest intersection yet),
                //it becomes the nearest intersection.
                if (intersection != null && intersection.distance < maxintersectDist && (nearestintersection == null || intersection.distance < nearestintersection.distance)) // er is een positief en niet oneindig ver snijpunt
                {
                        
                    nearestintersection = intersection;
                    
                }
            }
            return nearestintersection;
        }

        
        
    }
}
