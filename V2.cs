using System;

public class V2 :IEquatable<V2>
{
    private static V2 zeroVector = new V2(0f, 0f);
    private static V2 unitVector = new V2(1f, 1f);
    private static V2 unitXVector = new V2(1f, 0f);
    private static V2 unitYVector = new V2(0f, 1f);

    public float X;
    public float Y;

    public V2(float x, float y)
	{
        X = x;
        Y = y;
	}

    public V2(float value)
    {
        X = value;
        Y = value;
    }
    public static V2 Zero
    {
        get { return zeroVector; }
    }

    public static V2 One
    {
        get { return unitVector; }
    }

    public static V2 UnitX
    {
        get { return unitXVector; }
    }

    public static V2 UnitY
    {
        get { return unitYVector; }
    }

    public static V2 Add(V2 value1, V2 value2)
    {
        value1.X += value2.X;
        value1.Y += value2.Y;
        return value1;
    }

    public static float Distance(V2 value1, V2 value2)
    {
        float v1 = value1.X - value2.X, v2 = value1.Y - value2.Y;
        return (float)Math.Sqrt((v1 * v1) + (v2 * v2));
    }

    public static float DistanceSquared(V2 value1, V2 value2)
    {
        float v1 = value1.X - value2.X, v2 = value1.Y - value2.Y;
        return (v1 * v1) + (v2 * v2);
    }

    public static V2 Divide(V2 value1, V2 value2)
    {
        value1.X /= value2.X;
        value1.Y /= value2.Y;
        return value1;
    }

    public static V2 Divide(V2 value1, float divider)
    {
        float factor = 1 / divider;
        value1.X *= factor;
        value1.Y *= factor;
        return value1;
    }

    public static float Dot(V2 value1, V2 value2)
    {
        return (value1.X * value2.X) + (value1.Y * value2.Y);
    }

    public override bool Equals(object obj)
    {
        if (obj is V2)
        {
            return Equals((V2)this);
        }

        return false;
    }

    public bool Equals(V2 other)
    {
        return (X == other.X) && (Y == other.Y);
    }

    /*  public static V2 Reflect(V2 vector, V2 normal)
    {
        V2 result;
        float val = 2.0f * ((vector.X * normal.X) + (vector.Y * normal.Y));
        result.X = vector.X - (normal.X * val);
        result.Y = vector.Y - (normal.Y * val);
        return result;
    }*/

    public override int GetHashCode()
    {
        return X.GetHashCode() + Y.GetHashCode();
    }

    public float Length()
    {
        return (float)Math.Sqrt((X * X) + (Y * Y));
    }

    public float LengthSquared()
    {
        return (X * X) + (Y * Y);
    }

    public static V2 Max(V2 value1, V2 value2)
    {
        return new V2(value1.X > value2.X ? value1.X : value2.X,
                            value1.Y > value2.Y ? value1.Y : value2.Y);
    }

    public static V2 Min(V2 value1, V2 value2)
    {
        return new V2(value1.X < value2.X ? value1.X : value2.X,
                            value1.Y < value2.Y ? value1.Y : value2.Y);
    }

    public static V2 Multiply(V2 value1, V2 value2)
    {
        value1.X *= value2.X;
        value1.Y *= value2.Y;
        return value1;
    }

    public static V2 Multiply(V2 value1, float scaleFactor)
    {
        value1.X *= scaleFactor;
        value1.Y *= scaleFactor;
        return value1;
    }

    public void Normalize()
    {
        float val = 1.0f / (float)Math.Sqrt((X * X) + (Y * Y));
        X *= val;
        Y *= val;
    }

    public static V2 Normalize(V2 value)
    {
        float val = 1.0f / (float)Math.Sqrt((value.X * value.X) + (value.Y * value.Y));
        value.X *= val;
        value.Y *= val;
        return value;
    }

    public static bool operator ==(V2 value1, V2 value2)
    {
        return value1.X == value2.X && value1.Y == value2.Y;
    }

    public static bool operator !=(V2 value1, V2 value2)
    {
        return value1.X != value2.X || value1.Y != value2.Y;
    }

    public static V2 operator +(V2 value1, V2 value2)
    {
        value1.X += value2.X;
        value1.Y += value2.Y;
        return value1;
    }


    public static V2 operator -(V2 value1, V2 value2)
    {
        value1.X -= value2.X;
        value1.Y -= value2.Y;
        return value1;
    }


    public static V2 operator *(V2 value1, V2 value2)
    {
        value1.X *= value2.X;
        value1.Y *= value2.Y;
        return value1;
    }


    public static V2 operator *(V2 value, float scaleFactor)
    {
        value.X *= scaleFactor;
        value.Y *= scaleFactor;
        return value;
    }


    public static V2 operator *(float scaleFactor, V2 value)
    {
        value.X *= scaleFactor;
        value.Y *= scaleFactor;
        return value;
    }


    public static V2 operator /(V2 value1, V2 value2)
    {
        value1.X /= value2.X;
        value1.Y /= value2.Y;
        return value1;
    }


    public static V2 operator /(V2 value1, float divider)
    {
        float factor = 1 / divider;
        value1.X *= factor;
        value1.Y *= factor;
        return value1;
    }
}