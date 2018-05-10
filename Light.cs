using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace template
{
    class Light
    {
        public Light(V3 positie, V3 kleur)
        {
            positie = new V3(1, 1, 0);
            kleur = new V3(0, 0, 1);
        }
    }
}
