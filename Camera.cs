using System;
using OpenTK;
using OpenTK.Input;

namespace template
{
    public class Camera
    {
        public float width = 256; //display screen width in pixels
        public float height = 256; //display screen height
        public float schermxy = 1f; //the width of the screen/2
        public float schermz = 1.5f; //the distance between the camera and the screen
        public Vector3 linksboven; //P0 of the screen
        public Vector3 rechtsboven; // P1 of the screen
        public Vector3 linksonder; //P2 of the screen
        public double FOV = 90; //The field of view in degrees, adjustable here or using the O and P buttons while running
        public Vector3 richting = new Vector3(0,0,1); //the camera direction, initially towards positive Z
        public Vector3 pos; //the position of the camera
        public Vector3 Up { get { return linksboven - linksonder; }} // the vertical vector of the screen
        public Vector3 Right { get { return rechtsboven - linksboven; } } //the horizontal vector of the screen
        Vector3 centrum; //the center of the screen
        public Camera(Vector3 position)
        {
            pos = position;
            centrum = pos + (richting * schermz);
            double hoek = FOV * Math.PI / 180; //converting from degrees to radians
            schermxy = schermz * (float)Math.Tan(hoek/2); 


            linksboven = (richting*schermz) + new Vector3(-schermxy,schermxy,0);
            rechtsboven = (richting*schermz) + new Vector3(schermxy,schermxy,0);
            linksonder = (richting*schermz) + new Vector3(-schermxy,-schermxy,0);

            
        }
        public void Fov(Key key)
        {
            if(key == Key.O) //pressing O increases FOV, pressing P decreases it
            { FOV += 1; }
            if(key == Key.P)
            { FOV -= 1; }
            double hoek = FOV * Math.PI / 180;
            schermxy = schermz * (float)Math.Tan(hoek / 2);
            linksboven = (richting * schermz) + new Vector3(-schermxy, schermxy, 0); //recalculate the screen dimensions using the new FOV
            rechtsboven = (richting * schermz) + new Vector3(schermxy, schermxy, 0);
            linksonder = (richting * schermz) + new Vector3(-schermxy, -schermxy, 0);
        }

        public void MoveCamera(Vector3 xyz) //add a vector to all points
        {
            pos += xyz;
            centrum = pos + (richting*schermz);
            richting = Vector3.Normalize(centrum - pos);
            linksboven += xyz;
            rechtsboven += xyz;
            linksonder += xyz;

        }

        public void TurnCamera(Key key) // turn the camera left right up or down depending on a key press, sadly the screen does not rotate but only moves in a circle
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

         

        }
        
    }
}
