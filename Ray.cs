using OpenTK;

namespace template
{
    public class Ray
    {
        //saving the origin and direction of any ray. the length of the ray can be calculated without storing it here
        public Vector3 O;
        public Vector3 D;
        
        public Ray(Vector3 o, Vector3 d)
        {
            O = o;
            D = d;
        }
    }
}
