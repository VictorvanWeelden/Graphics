using System;
using System.Drawing;
using OpenTK;

namespace template
{
    public class Camera
    {
        float x = 0;
        float y = 0;
        float z = 0;
        public float width = 256;
        public float height = 256;
        public Vector3 P0 = new Vector3(-1, 1, 1);
        public Vector3 P1 = new Vector3(1, 1, 1);
        public Vector3 P2 = new Vector3(-1, -1, 1);
        Material m = new Material(new Vector3(0, 0, 0));
        

        public Camera(Vector3 position, Vector3 richting)
        {
            position = new Vector3 (0, 0, 0);
            richting = new Vector3(0, 0, 1);
            Plane scherm = new Plane(P0, P1, P2, 1, m);
            
            
        }

        public float Screencentre()
        {
            return x;
        }
    }
}
