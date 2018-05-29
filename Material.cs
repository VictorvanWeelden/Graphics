using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTK;

namespace template
{
    public class Material
    {
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
