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
            raytracer = new Raytracer();
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


	// tick: renders one frame
	public void Tick()
	{
            screen.Clear(CreateColor(0, 0, 0));
            //RenderGl();
            raytracer.Render();
            
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
}

}
