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
        public Scene scene = new Scene();
        public int size = 256;
        

        
        //Surface Map;
        //float[] vertexData;
        //int VBO;

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
            screen.Plot((Xtrans((int)raytracer.cameraPosition.X)), (Ytrans((int)raytracer.cameraPosition.Z)), 0xffffff);
            screen.Line((Xtrans(-1)), (Ytrans(2)), (Xtrans(1)), (Ytrans(2)), 0xffffff);
            //float radius = 30;
            float r = scene.radius * (screen.height/10);
            for(double i = 0.0; i < 360.0; i += 0.1)
            {
                double hoek = i * Math.PI / 180;
                int x = (int)(Xtrans((int)scene.sphere1Positie.X) + r * Math.Cos(hoek));
                int y = (int)(Ytrans((int)scene.sphere1Positie.Z) + r * Math.Sin(hoek));
                screen.Plot(x, y, 0xffffff);
            }
            for (double i = 0.0; i < 360.0; i += 0.1)
            {
                double hoek = i * Math.PI / 180;
                int x = (int)(Xtrans((int)scene.sphere2Positie.X) + r * Math.Cos(hoek));
                int y = (int)(Ytrans((int)scene.sphere2Positie.Z) + r * Math.Sin(hoek));
                screen.Plot(x, y, 0xffffff);
            }
            for (double i = 0.0; i < 360.0; i += 0.1)
            {
                double hoek = i * Math.PI / 180;
                int x = (int)(Xtrans((int)scene.sphere3Positie.X) + r * Math.Cos(hoek));
                int y = (int)(Ytrans((int)scene.sphere3Positie.Z) + r * Math.Sin(hoek));
                screen.Plot(x, y, 0xffffff);
            }
        }

    public int Xtrans(int x)
        {
            return x * (screen.width/20) + (screen.width * 3/4);
        }

    public int Ytrans(int y)
        {
            return screen.height - y * (screen.height / 10);
        }

        /* public void RenderGl()
         {

             GL.Color3(1f, 0f, 0f);
             GL.Begin(PrimitiveType.Triangles);
             GL.Vertex3(-0.5f, -0.5f, 0);
             GL.Vertex3(0.5f, -0.5f, 0);
             GL.Vertex3(-.5f, .5f, 0);
             GL.End();
           //  var m = Matrix4.CreatePerspectiveFieldOfView(1.6f, 1.3f, 0.1f, 1000);
         }*/
        /*void RenderGl()
        {
            GL.BindBuffer(BufferTarget.ArrayBuffer, VBO);
            GL.DrawArrays(PrimitiveType.Triangles, 0, 127 * 127 * 2 * 3);
        }*/
        //from init.
        //Map = new Surface("../../assets/heightmap.png");
        /*vertexData = new float[127* 127 * 2 * 3* 3];
        for (int y = 0; y < 128; y++)
        {
            for (int x = 0; x < 128; x++)
            {
                vertexData[x * y] = 0f;
                vertexData[x * y * 2] = ((float)(Map.pixels[x + y * 128] & 255)) / 256;
            }
        }
        VBO = GL.GenBuffer();
        GL.BindBuffer(BufferTarget.ArrayBuffer, VBO);
        GL.BufferData<float>(BufferTarget.ArrayBuffer, (IntPtr)(vertexData.Length * 4), vertexData, BufferUsageHint.StaticDraw);
        GL.EnableClientState(ArrayCap.VertexArray);
        GL.VertexPointer(3, VertexPointerType.Float, 12, 0);*/
    }

}
