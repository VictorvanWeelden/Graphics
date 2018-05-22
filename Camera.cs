using System;
using System.Drawing;
using OpenTK;

namespace template
{
    public class Camera
    {
        public Vector3 pos = new Vector3(0,0,0);
        public Vector3 direction = new Vector3(0, 0, 1);
        public Vector3 Rechts = new Vector3(0, 0, 0);
        public Vector3 Neer = new Vector3(0, 0, 0);
        public float width = 256;
        public float height = 256;
        public Vector3 P0 = new Vector3(-1, 1, 2);
        public Vector3 P1 = new Vector3(1, 1, 2);
        public Vector3 P2 = new Vector3(-1, -1, 1);
        Material m = new Material();
        public Plane scherm;    

        public Camera(Vector3 position, Vector3 richting, Vector3 rechts, Vector3 neer)
        {
            pos = position;
            direction = richting;
            Rechts = rechts;
            Neer = neer;
          //  scherm = new Plane(P0, P1, P2, 1, m);            
        }

        public float Screencentre()
        {
            return pos.X ;
        }
    }
}
