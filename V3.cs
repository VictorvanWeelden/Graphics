using System;
using System.ComponentModel;
using System.Text;

namespace template
{
    class V3 : IEquatable<V3>
    {

        public float X;
        public float Y;
        public float Z;


        private static V3 zero = new V3(0f, 0f, 0f);
        private static V3 one = new V3(1f, 1f, 1f);
        private static V3 unitX = new V3(1f, 0f, 0f);
        private static V3 unitY = new V3(0f, 1f, 0f);
        private static V3 unitZ = new V3(0f, 0f, 1f);
        private static V3 up = new V3(0f, 1f, 0f);
        private static V3 down = new V3(0f, -1f, 0f);
        private static V3 right = new V3(1f, 0f, 0f);
        private static V3 left = new V3(-1f, 0f, 0f);
        private static V3 forward = new V3(0f, 0f, -1f);
        private static V3 backward = new V3(0f, 0f, 1f);
        public V3(float x, float y, float z)
        {
            this.X = x;
            this.Y = y;
            this.Z = z;
        }


        public V3(float value)
        {
            this.X = value;
            this.Y = value;
            this.Z = value;
        }


        public V3(V2 value, float z)
        {
            this.X = value.X;
            this.Y = value.Y;
            this.Z = z;
        }

        public static V3 Zero
        {
            get { return zero; }
        }

        public static V3 One
        {
            get { return one; }
        }

        public static V3 UnitX
        {
            get { return unitX; }
        }

        public static V3 UnitY
        {
            get { return unitY; }
        }

        public static V3 UnitZ
        {
            get { return unitZ; }
        }

        public static V3 Up
        {
            get { return up; }
        }

        public static V3 Down
        {
            get { return down; }
        }

        public static V3 Right
        {
            get { return right; }
        }

        public static V3 Left
        {
            get { return left; }
        }

        public static V3 Forward
        {
            get { return forward; }
        }

        public static V3 Backward
        {
            get { return backward; }
        }

        public static V3 Add(V3 value1, V3 value2)
        {
            value1.X += value2.X;
            value1.Y += value2.Y;
            value1.Z += value2.Z;
            return value1;
        }

      /*  public static float Distance(V3 vector1, V3 vector2)
        {
            float result;
            result = vector1.X * vector1.Y + vector1 (vector1, ref vector2, out result);
            return (float)Math.Sqrt(result);
        }

        public static float DistanceSquared(V3 value1, V3 value2)
        {
            float result;
            DistanceSquared(ref value1, ref value2, out result);
            return result;
        }
        */
        public static V3 Divide(V3 value1, V3 value2)
        {
            value1.X /= value2.X;
            value1.Y /= value2.Y;
            value1.Z /= value2.Z;
            return value1;
        }

        public static V3 Divide(V3 value1, float value2)
        {
            float factor = 1 / value2;
            value1.X *= factor;
            value1.Y *= factor;
            value1.Z *= factor;
            return value1;
        }

        public static float Dot(V3 vector1, V3 vector2)
        {
            return vector1.X * vector2.X + vector1.Y * vector2.Y + vector1.Z * vector2.Z;
        }

        public override bool Equals(object obj)
        {
            return (obj is V3) ? this == (V3)obj : false;
        }

        public bool Equals(V3 other)
        {
            return this == other;
        }

        public override int GetHashCode()
        {
            return (int)(this.X + this.Y + this.Z);
        }

        /* public float Length()
         {
             float result;
             DistanceSquared(ref this, ref zero, out result);
             return (float)Math.Sqrt(result);
         }

         public float LengthSquared()
         {
             float result;
             DistanceSquared(ref this, ref zero, out result);
             return result;
         }*/

        public static V3 Multiply(V3 value1, V3 value2)
        {
            value1.X *= value2.X;
            value1.Y *= value2.Y;
            value1.Z *= value2.Z;
            return value1;
        }

        public static V3 Multiply(V3 value1, float scaleFactor)
        {
            value1.X *= scaleFactor;
            value1.Y *= scaleFactor;
            value1.Z *= scaleFactor;
            return value1;
        }

        public static bool operator ==(V3 value1, V3 value2)
        {
            return value1.X == value2.X
                && value1.Y == value2.Y
                && value1.Z == value2.Z;
        }

        public static bool operator !=(V3 value1, V3 value2)
        {
            return !(value1 == value2);
        }

        public static V3 operator +(V3 value1, V3 value2)
        {
            value1.X += value2.X;
            value1.Y += value2.Y;
            value1.Z += value2.Z;
            return value1;
        }

        public static V3 operator -(V3 value)
        {
            value = new V3(-value.X, -value.Y, -value.Z);
            return value;
        }

        public static V3 operator -(V3 value1, V3 value2)
        {
            value1.X -= value2.X;
            value1.Y -= value2.Y;
            value1.Z -= value2.Z;
            return value1;
        }

        public static V3 operator *(V3 value1, V3 value2)
        {
            value1.X *= value2.X;
            value1.Y *= value2.Y;
            value1.Z *= value2.Z;
            return value1;
        }

        public static V3 operator *(V3 value, float scaleFactor)
        {
            value.X *= scaleFactor;
            value.Y *= scaleFactor;
            value.Z *= scaleFactor;
            return value;
        }

        public static V3 operator *(float scaleFactor, V3 value)
        {
            value.X *= scaleFactor;
            value.Y *= scaleFactor;
            value.Z *= scaleFactor;
            return value;
        }

        public static V3 operator /(V3 value1, V3 value2)
        {
            value1.X /= value2.X;
            value1.Y /= value2.Y;
            value1.Z /= value2.Z;
            return value1;
        }

        public static V3 operator /(V3 value, float divider)
        {
            float factor = 1 / divider;
            value.X *= factor;
            value.Y *= factor;
            value.Z *= factor;
            return value;
        }
    }


}
