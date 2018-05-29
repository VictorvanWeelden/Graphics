using OpenTK;

namespace template
{
    public class Light
    {

        // a light only has a position and a color
        public Vector3 positie;
        public Vector3 kleur;

        public Light(Vector3 pos, Vector3 color)
        {
            positie = pos;
            kleur = color;
        }
    }
}
