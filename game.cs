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
