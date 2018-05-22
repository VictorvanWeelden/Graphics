using System;
//using System.IO;
using OpenTK.Graphics.OpenGL;
using template;

namespace Template {

class Game
{
	// member variables
	public Surface screen;
        public Raytracer raytracer;
        public int size = 256;
        
        int CreateColor(int red, int green, int blue)
        {
            return (red << 16) + (green << 8) + blue;
        }
            
	// initialize
	public void Init()
	{
            screen = new Surface(2 * size, size);
            raytracer = new Raytracer(screen);
	}

	// tick: renders one frame
	public void Tick()
	{
            screen.Clear(CreateColor(0, 0, 0));
            //RenderGl();
            raytracer.Render();
            Debug();
        }

    public void Debug()
        {
            screen.Plot(((int)raytracer.cameraPosition.X + (screen.width * 3 / 4)), (screen.height - (int)raytracer.cameraPosition.Z * (screen.height / 10)), 0xffffff);
            screen.Line(((-1 * (screen.width / 20)) + (screen.width * 3 / 4)), (screen.height - 2 * (screen.height / 10)), ((1 * (screen.width / 20)) + (screen.width * 3 / 4)), (screen.height - 2 * (screen.height / 10)), 0xffffff);
            float radius = 30;
            for(double i = 0.0; i < 360.0; i += 0.1)
            {
                double hoek = i * Math.PI / 180;
                int x = (int)(150 + radius * Math.Cos(hoek));
                int y = (int)(150 + radius * Math.Sin(hoek));
                screen.Plot(x, y, 0xffffff);
            }
        }  
    }
}
