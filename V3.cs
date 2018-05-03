using System;


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
        X = x;
        Y = y;
        Z = z;
    }

    public V3(float value)
    {
        X = value;
        Y = value;
        Z = value;
    }

    public V3(V2 value, float z)
    {
        X = value.X;
        Y = value.Y;
        Z = z;
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

        public static float Distance(V3 vector1, V3 vector2)
    {
        float v1 = vector1.X - vector2.X, v2 = vector1.Y - vector2.Y, v3 = vector1.Z - vector2.Z;
        float result = (v1 * v1) + (v2 * v2) + (v3 * v3);
        return (float)Math.Sqrt(result);
    }
    
    public static float DistanceSquared(V3 vector1, V3 vector2)
    {
        float v1 = vector1.X - vector2.X, v2 = vector1.Y - vector2.Y, v3 = vector1.Z - vector2.Z;
        float result = (v1 * v1) + (v2 * v2) + (v3 * v3);
        return result;
    }
    
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

        public float Length()
        {
            return (float)Math.Sqrt((X * X) + (Y * Y) + (Z * Z));
        }

        public float LengthSquared()
        {
            float result = ((X * X) + (Y * Y) + (Z * Z));
            return result;
        }
    /* public static V3 Reflect(V3 vector, V3 normal)
    {
        V3 result;
        float val = 2.0f * ((vector.X * normal.X) + (vector.Y * normal.Y) + (vector.Z * normal.Z));
        result.X = vector.X - (normal.X * val);
        result.Y = vector.Y - (normal.Y * val);
        result.Z = vector.Z - (normal.Z * val);
        return result;
    }*/

    public void Normalize()
    {
        float val = 1.0f / (float)Math.Sqrt((X * X) + (Y * Y) + (Z * Z));
        X *= val;
        Y *= val;
        Z *= val;
    }

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