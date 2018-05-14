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

        V3 lightPositie = new V3(-1f, 0f, 0f);
        V3 lightKleur = new V3(1f, 1f, 0.1f);
        V3 sphere1Positie = new V3(3f, 0f, 3f);
        V3 sphere2Positie = new V3(5f, 0f, 3f);
        V3 sphere3Positie = new V3(8f, 0f, 3f);
        V3 kleur1 = new V3(0.1f, 0.1f, 1f);
        V3 kleur2 = new V3(0.5f, 0.5f, 0.1f);
        V3 kleur3 = new V3(1f, 0.1f, 0.1f);
        V3 kleur4 = new V3(1f, 0.1f, 0.1f);
        int radius = 1;

        public Scene()
        {
            Light light = new Light(lightPositie, lightKleur);
            Sphere sphere1 = new Sphere(radius, sphere1Positie, kleur1);
            Sphere sphere2 = new Sphere(radius, sphere2Positie, kleur2);
            Sphere sphere3 = new Sphere(radius, sphere3Positie, kleur3);
            Plane plane = new Plane(new V3(0,-1,0), new V3(10,-1,0), new V3(0,-1,10), 1, kleur4); //Ik snap niet echt wat D hier moet zijn, kloppen de hoeken zo?
   
        }

        public void IntersectMethod()
        {

        }
    }
}
