using System;
using OpenTK;

namespace template
{
    public abstract class Primitive
    {
        Vector3 positie;
        //Vector3 kleur;
        public Material material;
        public Vector3 normal;

        public Primitive()
        {
            //Material material = new Material(kleur);
        }

        void Beweeg(Vector3 nieuwPositie) // moves the position of the objects in the scene
        {
            positie += nieuwPositie;
        }

        void Beweegnaar(Vector3 nieuwPositie) // set sphere at position
        {
            positie = nieuwPositie;
        }

        /*public Vector3 Normal(Vector3 i) // return the normal vector of the input vector
        {
            return (float)Math.Sqrt(i.X * i.X + i.Y * i.Y + i.Z * i.Z);
        }

        double CosinusHoek(Vector3 a, Vector3 b) // retrieves the cosinus angle from the 2 vectors
        {
            return (double)(a.X * b.X + a.Y + b.Y + a.Z * b.Z) / (Normal(a) * Normal(b));
        }*/

        abstract public float Intersection(Ray ray);
        

       
    }
}
