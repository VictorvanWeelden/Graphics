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
        public float schermxy = 2;
        public float schermz = 2;
        public Vector3 P0;
        public Vector3 P1;
        public Vector3 P2;
        
        Material m = new Material(new Vector3(1,1,1));
        //public Plane scherm;

        public Camera(Vector3 position, Vector3 richting)
        {
            pos = position;
            direction = richting;
            P0 = new Vector3(-schermxy, schermxy, schermz);
            P1 = new Vector3(schermxy, schermxy, schermz);
            P2 = new Vector3(-schermxy, -schermxy, schermz);
            //scherm = new Plane(P0, P1, P2, 1, m);           
        }

        public Vector3 ScreenWidth()
        {
            P0 = new Vector3(-schermxy, schermxy, schermz);
            P2 = new Vector3(-schermxy, -schermxy, schermz);
            return P2 - P0;
        }
        public Vector3 ScreenHeight()
        {
            P0 = new Vector3(-schermxy, schermxy, schermz);
            P1 = new Vector3(schermxy, schermxy, schermz);
            return P1 - P0;
        }
    }
}
