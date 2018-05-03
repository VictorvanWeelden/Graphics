using System;
//using System.IO;
using OpenTK.Graphics.OpenGL;

namespace Template {

class Game
{
	// member variables
	public Surface screen;
      //  Surface Map;
       // float[,] h;
        double i = 0, j = 0;
        
        
        int x, y;
        int e = 250;
        int f = 210;
        

        int CreateColor(int red, int green, int blue)
        {
            return (red << 16) + (green << 8) + blue;
        }

        int TX(V2 a)
        {
          return x =  (int) (e + (a.X * Math.Cos(i) - a.Y *  Math.Sin(i)));
        }
        int TY(V2 a)
        {
            return y = (int)(f + (a.X * Math.Sin(i) + a.Y * Math.Cos(i)));
        } 
            
	// initialize
	public void Init()
	{
          /*  Map = new Surface("../../assets/heighmap.png");
            h = new float[128,128];
            for(int y = 0; y < 128; y++)
            {
                for (int x = 0; x < 128; x++)
                {
                    h[x, y] = ((float)(Map.pixels[x + y * 128] & 255)) / 256;
                }
            }
	*/}
	// tick: renders one frame
	public void Tick()
	{
        //int location = x + y * width;
        //int pixel = screen.pixels[location];
            screen.Clear(CreateColor(255, 10, 10));
            i = i  + 0.03 * Math.Sin(j = j - 0.03) - 0.03;
            
        }

        public void RenderGl()
        {
            GL.Color3(1f, 0f, 0f);
            GL.Begin(PrimitiveType.Triangles);
            GL.Vertex3(-0.5f, -0.5f, 0);
            GL.Vertex3(0.5f, -0.5f, 0);
            GL.Vertex3(-.5f, .5f, 0);
            GL.End();
        //    var m = Matrix4.CreatePerspectiveFieldOfView(1.6f, 1.3f, 0.1f, 1000);
        }
}

} // namespace Template
  /// old scrips
  ///screen.Print( "Hello World", 2, 2, 0xf00fff );
  ///screen.Line(2, 20, 160, 20, 0xff0000);
  ///screen.Bar(x1, y1, x1, y1, 0xffffff);
  ///

