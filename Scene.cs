using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace template
{
    class Scene
    {
        //stores a list of primitives and light sources. It implements a scene-level Intersect
        //method, which loops over the primitives and returns the closest intersection.

        V3 lightPositie = new V3(0, 0, 0);
        V3 lightKleur = new V3(1, 1, 0);
        V3 sphere1Positie = new V3(3, 0, 3);
        V3 sphere2Positie = new V3(5, 0, 3);
        V3 sphere3Positie = new V3(8, 0, 3);
        int radius = 1;

        public Scene()
        {
            Light light = new Light(lightPositie, lightKleur);
            Sphere sphere1 = new Sphere(radius, sphere1Positie);
            Sphere sphere2 = new Sphere(radius, sphere2Positie);
            Sphere sphere3 = new Sphere(radius, sphere3Positie);
            Plane plane = new Plane(new V3(0,-1,0), new V3(10,-1,0), new V3(0,-1,10), 1); //Ik snap niet echt wat D hier moet zijn, kloppen de hoeken zo?
   
        }

        public void IntersectMethod()
        {

        }
    }
}
