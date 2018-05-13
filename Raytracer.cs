using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace template
{
    class Raytracer
    {
        V3 cameraPosition = new V3(0, 0, 0);
        V3 cameraRichting = new V3(0, 0, 1);

        public Raytracer()
        {
            Scene scene = new Scene();
            Camera camera = new Camera(cameraPosition, cameraRichting);
            Ray ray = new Ray(cameraPosition, cameraRichting, 1);
        }

        public void Render()
        {
            /*uses the camera to loop over the pixels of the screen plane and to
            generate a ray for each pixel, which is then used to find the nearest intersection.The result is
            then visualized by plotting a pixel.*/

            for (float i = 0; i < 256; i++)
            {
                for (float j = 0; j < 256; j++)
                {
                     
                }
            }

        }
    }
}
