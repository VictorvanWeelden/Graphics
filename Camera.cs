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
        public float schermxy = 1;
        public float schermz = 2.5f;
        public Vector3 linksboven;
        public Vector3 rechtsboven;
        public Vector3 linksonder;
        public float horrichting = 0f;
        public float verrichting = 0f;
        public Vector3 richting = new Vector3(0,0,1);
        public Vector3 pos;
        public Vector3 up = new Vector3(0, 1, 0);
        Vector3 centrum;
        public Vector3 right;

        public Camera(Vector3 position)
        {
            pos = position;
            centrum = pos + (richting * schermz);

            linksboven = richting + new Vector3(-1,1,0);
            rechtsboven = richting +new Vector3(1,1,0);
            linksonder = richting + new Vector3(-1,-1,0);
            right = rechtsboven - linksboven;
            up = linksonder - linksboven;

            
        }

        public void MoveCamera(Vector3 xyz)
        {
            pos += xyz;
            centrum = pos + richting;
            richting = Vector3.Normalize(centrum - pos);
            linksboven += xyz;
            rechtsboven += xyz;
            linksonder += xyz;
            right = rechtsboven - linksboven;
            up = linksonder - linksboven;
            
        }

        public void TurnCamera(Key key)
        {
            if (key == Key.Right)
            { centrum += right * 0.1f; }
            if (key == Key.Left)
            { centrum -= right * 0.1f; }
            if (key == Key.Up)
            { centrum += up * 0.1f; }
            if (key == Key.Down)
            { centrum -= up * 0.1f; }


            richting = Vector3.Normalize(centrum - pos);
            linksboven = richting - right + up;
            rechtsboven = richting + right + up;
            linksonder = richting - right - up;
            right = rechtsboven - linksboven;
            up = linksonder - linksboven;


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
