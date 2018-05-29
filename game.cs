using System;
using template;
using OpenTK.Input;


namespace Template {

public class Game
{
	    // member variables
	    public Surface screen; // the display screen
        public Raytracer raytracer; 
        public Scene scene = new Scene();
        public int size = 256; //the width and height of both the output and the debug screen
        int xpositieDebug; //positions used to draw the circles in the debug window
        int ypositieDebug;

        int CreateColorf(float R, float B, float G) //turns a vector3 of floats ranging from 0 to 1 into a useable color value
        {
            return ((int)(R * 255) << 16) + ((int)(B * 255) << 8) + ((int)(G * 255));
        }

        // initialize
        public void Init()
	    {
            screen = new Surface(2 * size, size);
            raytracer = new Raytracer(screen, scene, size, size);
	    }

	// tick: renders one frame
	    public void Tick()
	    {
            screen.Clear(CreateColorf(0, 0, 0)); //clear screen
            Input(); //check for input
            Debug(); // draw the debug output
            raytracer.Render(); //render the scene
            
        }

        public void Input()
        {
            var state = Keyboard.GetState();
            //move the camera
            if (state[Key.W]) { raytracer.camera.MoveCamera(new OpenTK.Vector3(0, 0, 0.1f));} //forward
            if (state[Key.A]) { raytracer.camera.MoveCamera(new OpenTK.Vector3(-0.1f, 0, 0)); } //left
            if (state[Key.S]) { raytracer.camera.MoveCamera(new OpenTK.Vector3(0, 0, -0.1f)); } //backward
            if (state[Key.D]) { raytracer.camera.MoveCamera(new OpenTK.Vector3(0.1f, 0, 0)); } //richt
            if (state[Key.Q]) { raytracer.camera.MoveCamera(new OpenTK.Vector3(0, 0.1f, 0)); } // up
            if (state[Key.E]) { raytracer.camera.MoveCamera(new OpenTK.Vector3(0, -0.1f, 0)); } //down
            //turn the camera
            if (state[Key.Up]) { raytracer.camera.TurnCamera(Key.Up); } //up
            if (state[Key.Down]) { raytracer.camera.TurnCamera(Key.Down); } //down
            if (state[Key.Left]) { raytracer.camera.TurnCamera(Key.Left); } //left
            if (state[Key.Right]) { raytracer.camera.TurnCamera(Key.Right); } //right
            //Change the FOV
            if(state[Key.O]) { raytracer.camera.Fov(Key.O); } //increase
            if (state[Key.P]) { raytracer.camera.Fov(Key.P); } //decrease

        }

        public void Debug()
        {
            screen.Plot(((int)Xtrans(raytracer.camera.pos.X)), ((int)Ytrans(raytracer.camera.pos.Z)), 0xffffff); //draw the camera position.
            
            for (int i = 0; i < raytracer.eindpunten.Length; i++) //draw primary rays
            {

                screen.Line(((int)Xtrans(raytracer.camera.pos.X)), ((int)Ytrans(raytracer.camera.pos.Z)), ((int)Xtrans(raytracer.eindpunten[i].X)), ((int)Ytrans((raytracer.eindpunten[i].Y))), 0xff00ff);

            }
            //draw the screen position
            screen.Line((int)Xtrans(raytracer.camera.linksboven.X), (int)Ytrans(raytracer.camera.linksboven.Z), ((int)Xtrans(raytracer.camera.rechtsboven.X)), (int)Ytrans(raytracer.camera.rechtsboven.Z), 0xffffff);




            //draw circles to represent the spheres
            double hoek;
            float r = scene.radius * (screen.height/10);
            for(double i = 0.0; i < 360.0; i += 0.1) 
            {
                hoek = i * Math.PI / 180;
                xpositieDebug = (int)(Xtrans((int)scene.sphere1Positie.X) + r * Math.Cos(hoek));
                ypositieDebug = (int)(Ytrans((int)scene.sphere1Positie.Z) + r * Math.Sin(hoek));
                screen.Plot(xpositieDebug, ypositieDebug, CreateColorf(scene.kleur1.X, scene.kleur1.Y, scene.kleur1.Z));
            }
            for (double i = 0.0; i < 360.0; i += 0.1)
            {
                hoek = i * Math.PI / 180;
                xpositieDebug = (int)(Xtrans((int)scene.sphere2Positie.X) + r * Math.Cos(hoek));
                ypositieDebug = (int)(Ytrans((int)scene.sphere2Positie.Z) + r * Math.Sin(hoek));
                screen.Plot(xpositieDebug, ypositieDebug, CreateColorf(scene.kleur2.X, scene.kleur2.Y, scene.kleur2.Z));
            }
            for (double i = 0.0; i < 360.0; i += 0.1)
            {
                hoek = i * Math.PI / 180;
                xpositieDebug = (int)(Xtrans((int)scene.sphere3Positie.X) + r * Math.Cos(hoek));
                ypositieDebug = (int)(Ytrans((int)scene.sphere3Positie.Z) + r * Math.Sin(hoek));
                screen.Plot(xpositieDebug, ypositieDebug, CreateColorf(scene.kleur3.X, scene.kleur3.Y, scene.kleur3.Z));
            }
        }

        //transform a scene coordinate into a display screen coordinate
        public float Xtrans(float x) 
        {
            return x * (screen.width/20) + (screen.width * 3/4);
        }

        public float Ytrans(float y)
        {
            return screen.height - (y * (screen.height / 10));
        }
    }

}
