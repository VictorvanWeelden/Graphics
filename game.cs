using System;
//using System.IO;
using OpenTK.Graphics.OpenGL;
using template;

namespace Template {

public class Game
{
	// member variables
	public Surface screen;
        public Raytracer raytracer;
        public Scene scene = new Scene();
        public int size = 256;

        
        public int CreateColor(int red, int green, int blue)
        {
            return (red << 16) + (green << 8) + blue;
        }

        int CreateColorf(float R, float B, float G)
        {
            return ((int)(R * 255) << 16) + ((int)(B * 255) << 8) + ((int)G * 255);
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
            screen.Clear(CreateColor(0, 0, 0));
            raytracer.Render();
            Debug();
        }

    public void Debug()
        {
            screen.Plot(((int)Xtrans(raytracer.cameraPosition.X)), ((int)Ytrans(raytracer.cameraPosition.Z)), 0xffffff);
            screen.Line(((int)Xtrans(raytracer.camera.P0.X)), ((int)Ytrans(raytracer.camera.P0.Z)), ((int)Xtrans(raytracer.camera.P1.X)), ((int)Ytrans(raytracer.camera.P1.Z)), 0xffffff);

            for (int i = 0; i<raytracer.eindpunten.Length; i++)
            {
                screen.Line(((int)Xtrans(raytracer.cameraPosition.X)), ((int)Ytrans(raytracer.cameraPosition.Z)), ((int)Xtrans(raytracer.eindpunten[i].X)), ((int)Ytrans(raytracer.eindpunten[0].Y)), 0xffffff);
                
            }

            float r = scene.radius * (screen.height/10);
            for(double i = 0.0; i < 360.0; i += 0.1)
            {
                double hoek = i * Math.PI / 180;
                int x = (int)(Xtrans((int)scene.sphere1Positie.X) + r * Math.Cos(hoek));
                int y = (int)(Ytrans((int)scene.sphere1Positie.Z) + r * Math.Sin(hoek));
                screen.Plot(x, y, CreateColorf(scene.kleur1.X, scene.kleur1.Y, scene.kleur1.Z));
            }
            for (double i = 0.0; i < 360.0; i += 0.1)
            {
                double hoek = i * Math.PI / 180;
                int x = (int)(Xtrans((int)scene.sphere2Positie.X) + r * Math.Cos(hoek));
                int y = (int)(Ytrans((int)scene.sphere2Positie.Z) + r * Math.Sin(hoek));
                screen.Plot(x, y, CreateColorf(scene.kleur2.X, scene.kleur2.Y, scene.kleur2.Z));
            }
            for (double i = 0.0; i < 360.0; i += 0.1)
            {
                double hoek = i * Math.PI / 180;
                int x = (int)(Xtrans((int)scene.sphere3Positie.X) + r * Math.Cos(hoek));
                int y = (int)(Ytrans((int)scene.sphere3Positie.Z) + r * Math.Sin(hoek));
                screen.Plot(x, y, CreateColorf(scene.kleur3.X, scene.kleur3.Y, scene.kleur3.Z));
            }
        }

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
