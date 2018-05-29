using OpenTK;

namespace template
{
    public class Material
    {
        //materials have a color and can be reflective to an arbitrary extent
        public Vector3 kleur;
        public float pMirror = 0f;

        public Material(Vector3 k, float persentagemirror)
        {
            kleur = k;
            if(persentagemirror != 0f)
            { pMirror = persentagemirror; }
        }


    }
}
