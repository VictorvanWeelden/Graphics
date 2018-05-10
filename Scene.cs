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
        V3 sphereVector = new V3(1, 1, 1);

        public Scene()
        {
            Light light = new Light(lightPositie, lightKleur);
            Sphere sphere = new Sphere(3, sphereVector);
            Plane plane = new Plane();
   
        }

        public void IntersectMethod()
        {

        }
    }
}
