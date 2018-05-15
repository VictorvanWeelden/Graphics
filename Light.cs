using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTK;

namespace template
{
    public class Light
    {
        public Vector3 positie;
        public Vector3 kleur;

        public Light(Vector3 positie, Vector3 kleur)
        {
            positie = new Vector3(1, 1, 0);
            kleur = new Vector3(0, 0, 1);
        }
    }
}
