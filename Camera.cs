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
        public float schermz = 1.5f;
        public Vector3 linksboven;
        public Vector3 rechtsboven;
        public Vector3 linksonder;
        public float horrichting = 0f;
        public float verrichting = 0f;
        public Vector3 richting = Vector3.Zero;
        public Vector3 pos;

        public Camera(Vector3 position)
        {
            pos = position;
            linksboven = new Vector3(position.X - schermxy, position.Y + schermxy, position.Z + schermz);
            rechtsboven = new Vector3(position.X + schermxy, position.Y + schermxy, position.Z + schermz);
            linksonder = new Vector3(position.X -schermxy, position.Y -schermxy, position.Z + schermz);
            TurnCamera(50, 50);
        }

        public void MoveCamera(Vector3 xyz)
        {
            pos += xyz;
            linksboven += xyz;
            rechtsboven += xyz;
            linksonder += xyz;
        }

        public void TurnCamera(float horgraden, float vertgraden)
        {
            horrichting += horgraden;
            verrichting += vertgraden;
            richting = pos + (float)Math.Sqrt((schermz * schermz) + (double)(schermxy * schermxy)) * new Vector3((float)(Math.Sin(verrichting) * Math.Cos(horrichting)), (float)(Math.Sin(verrichting) * Math.Sin(horrichting)), (float)(Math.Cos(verrichting)));

        }
        
    }
}
