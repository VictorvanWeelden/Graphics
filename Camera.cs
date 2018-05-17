using System;
using System.Drawing;
using OpenTK;

namespace template
{
    public class Camera
    {
        public Vector3 pos;
        public Vector3 direction;
        public float width = 256;
        public float height = 256;
        public Vector3 P0 = new Vector3(-1, 1, 1);
        public Vector3 P1 = new Vector3(1, 1, 1);
        public Vector3 P2 = new Vector3(-1, -1, 1);
        Material m = new Material(new Vector3(0, 0, 0));
        

        public Camera(Vector3 position, Vector3 richting)
        {
            pos = position;
            direction = richting;
            Plane scherm = new Plane(P0, P1, P2, 1, m);
            
            
        }

        public float Screencentre()
        {
            return pos.X ;
        }
    }
}
