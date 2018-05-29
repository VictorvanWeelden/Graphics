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
        public bool isMirror = false;

        public Material(Vector3 k, bool mirror)
        {
            kleur = k;
            if(mirror)
            { isMirror = true; }
        }


    }
}
