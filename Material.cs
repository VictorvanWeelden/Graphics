using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTK;

namespace template
{
    public class Material
    {
        public float Versprijding;
        public Func<Vector3, Vector3> Glimmend;
        public Func<Vector3, Vector3> Reflectie;
        public Func<Vector3, Vector3> Mat;
    }

    public delegate void Action<A, B, C>(A a, B b, C c);

    static class Materiaalen {
        public static Vector3 D = new Vector3(0.3f);
        public static Vector3 A = new Vector3(0.7f);
        public static Vector3 Een = new Vector3(1f);
        public static Vector3 Nul = new Vector3(0f);
        public static Material Glansend = new Material()
        {
            Versprijding = 30,
            Reflectie = pos => Een,
            Glimmend = pos => Een,
            Mat = pos => Een
        };
        public static Material Dambord = new Material()
        {
            Versprijding = 50,
            Mat = positie => DambordRekenenMat(positie),
            Reflectie = positie => DambordRekenenRefl(positie),
            Glimmend = positie => Een
        };

        static Vector3 DambordRekenenMat(Vector3 positie)
        {
            int a = (int)positie.Z; //(int)Math.Floor(positie.Z); is Sneller dan een math.floor
            int b = (int)positie.X;//(int)Math.Floor(positie.X); krijgt misschien een rare randje bij positie 0 maar dat is maar heel klein
            if ((a+ b) % 2 != 0)
                return Een;
            else
                return Nul;                 
        }
        static Vector3 DambordRekenenRefl(Vector3 positie)
        {
            int a = (int)positie.Z; //(int)Math.Floor(positie.Z);
            int b = (int)positie.X; //(int)Math.Floor(positie.X);
            if ((a + b) % 2 != 0)
                return D;
            else
                return A;
        }
    }
}
