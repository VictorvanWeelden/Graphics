using OpenTK;

namespace template
{
    public abstract class Primitive
    {
        //the default primitive class. The plane and the sphere are based on this.
        Vector3 positie; 
        public Material material;
        public Vector3 normal;

        public Primitive()
        {
        }
        
        abstract public Intersection Intersection(Ray ray);
        

       
    }
}
