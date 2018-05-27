using System;
using System.Drawing;
using OpenTK;

namespace template
{
    public class Camera
    {
        public Vector3 pos;
        private Vector3 direction;
        public float width = 256;
        public float height = 256;
        public float schermxy = 1;
        public float schermz = 2;
        public Vector3 linksboven;
        public Vector3 rechtsboven;
        public Vector3 linksonder;
        
        Material m = new Material(new Vector3(1,1,1));
        //public Plane scherm;

        public Camera(Vector3 position, Vector3 richting)
        {
            pos = position;
            direction = richting;
            linksboven = new Vector3(-schermxy, schermxy, schermz);
            rechtsboven = new Vector3(schermxy, schermxy, schermz);
            linksonder = new Vector3(-schermxy, -schermxy, schermz);
            //scherm = new Plane(P0, P1, P2, 1, m);           
        }

        
    }
}
