using System;
using System.Drawing;
using OpenTK;

namespace template
{
    public class Camera
    {
        public float width = 256;
        public float height = 256;
        public float schermxy = 1;
        public float schermz = 2;
        public Vector3 linksboven;
        public Vector3 rechtsboven;
        public Vector3 linksonder;

        public Camera(Vector3 position, Vector3 richting)
        {
            Vector3 pos = position;
            Vector3 direction = richting;
            linksboven = new Vector3(-schermxy, schermxy, schermz);
            rechtsboven = new Vector3(schermxy, schermxy, schermz);
            linksonder = new Vector3(-schermxy, -schermxy, schermz);  
        }

        
    }
}
