using System;

namespace template
{
    public class Primitive
    {
        V3 positie;

        public Primitive()
        {
           
        }

        void Beweeg(V3 nieuwPositie) // moves the position of the objects in the scene
        {
            positie += nieuwPositie;
        }

        void Beweegnaar(V3 nieuwPositie) // set sphere at position
        {
            positie = nieuwPositie;
        }

        float Normal(V3 i) // return the normal vector of the input vector
        {
            return (float)Math.Sqrt(i.X * i.X + i.Y * i.Y + i.Z * i.Z);
        }

        double CosinusHoek(V3 a, V3 b) // retrieves the cosinus angle from the 2 vectors
        {
            return (double)(a.X * b.X + a.Y + b.Y + a.Z * b.Z) / (Normal(a) * Normal(b));
        }
    }
}
