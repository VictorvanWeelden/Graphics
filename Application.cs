﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace template
{
    class Application
    {
        Raytracer raytracer = new Raytracer();

        public Application()
        {
            raytracer.Render();
        }
    }
}
