using System;
using System.Drawing;
using OpenTK;
using OpenTK.Input;

namespace template
{
    public class Camera
    {
        public float width = 256;
        public float height = 256;
        public float schermxy = 1f;
        public float schermz = 1.5f;
        public Vector3 linksboven;
        public Vector3 rechtsboven;
        public Vector3 linksonder;
        public double FOV = 60;
        public float horrichting = 0f;
        public float verrichting = 0f;
        public Vector3 richting = new Vector3(0,0,1);
        public Vector3 pos;
        public Vector3 Up { get { return linksboven - linksonder; }}
        Vector3 centrum;
        public Vector3 Right { get { return rechtsboven - linksboven; } }

        public Camera(Vector3 position)
        {
            pos = position;
            centrum = pos + (richting * schermz);
            double hoek = FOV * Math.PI / 180;
            schermxy = schermz * (float)Math.Tan(hoek/2);


            linksboven = (richting*schermz) + new Vector3(-schermxy,schermxy,0);
            rechtsboven = (richting*schermz) + new Vector3(schermxy,schermxy,0);
            linksonder = (richting*schermz) + new Vector3(-schermxy,-schermxy,0);

            
        }
        public void Fov(Key key)
        {
            if(key == Key.O)
            { FOV += 1; }
            if(key == Key.P)
            { FOV -= 1; }
            double hoek = FOV * Math.PI / 180;
            schermxy = schermz * (float)Math.Tan(hoek / 2);
            linksboven = (richting * schermz) + new Vector3(-schermxy, schermxy, 0);
            rechtsboven = (richting * schermz) + new Vector3(schermxy, schermxy, 0);
            linksonder = (richting * schermz) + new Vector3(-schermxy, -schermxy, 0);
        }

        public void MoveCamera(Vector3 xyz)
        {
            pos += xyz;
            centrum = pos + (richting*schermz);
            richting = Vector3.Normalize(centrum - pos);
            linksboven += xyz;
            rechtsboven += xyz;
            linksonder += xyz;

        }

        public void TurnCamera(Key key)
        {
            if (key == Key.Right)
            { centrum += (Right * 0.1f); }
            if (key == Key.Left)
            { centrum -= (Right * 0.1f); }
            if (key == Key.Up)
            { centrum += (Up * 0.1f); }
            if (key == Key.Down)
            { centrum -= (Up * 0.1f); }


            richting = Vector3.Normalize(centrum - pos);
            linksboven = (pos + richting*schermz) - (Right/2) + (Up/2);
            rechtsboven = (pos + richting*schermz) + (Right/2) + (Up/2);
            linksonder = (pos+ richting*schermz) - (Right/2) - (Up/2);




            //float centrex = pos.X + richting * Math.Sin(hoek);


            /*horrichting += (float)(horgraden * Math.PI / 180);
            verrichting += (float)(vertgraden * Math.PI / 180);
            richting = Vector3.Normalize( pos + schermz  * new Vector3((float)(Math.Sin(horrichting) * 
                Math.Cos(verrichting)), (float)(Math.Sin(horrichting) * Math.Sin(verrichting)), (float)(Math.Cos(horrichting))));
            var u = Vector3.Cross(up, richting);
            var v = Vector3.Cross(u, richting);
            var w = new Vector3(pos + (richting * schermz));

            linksboven = new Vector3(w - u - v);
            rechtsboven = new Vector3(w + u - v);
            linksonder = new Vector3(w - u + v);*/

        }
        
    }
}
