﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace template
{
    class Camera
    {
        float x = 0;
        float y = 0;
        float z = 0;

        public Camera(V3 position, V3 richting)
        {
            position = new V3(0, 0, 0);
            richting = new V3(0, 0, 1);
            Plane scherm = new Plane(new V3(0), new V3(2,0,0), new V3(0,2,0), 3);
        }

        public float Screencentre()
        {
            return x;
        }
    }
}
