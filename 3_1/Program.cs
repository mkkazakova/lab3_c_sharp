using System;

struct Vector
{
    public double X;
    public double Y;
    public double Z;

    // Конструктор структуры
    public Vector(double x, double y, double z)
    {
        X = x;
        Y = y;
        Z = z;
    }

    // Сложение векторов
    public static Vector operator +(Vector v1, Vector v2)
    {
        return new Vector(v1.X + v2.X, v1.Y + v2.Y, v1.Z + v2.Z);
    }

    // Умножения вектора на число
    public static Vector operator *(Vector v, double scalar)
    {
        return new Vector(v.X * scalar, v.Y * scalar, v.Z * scalar);
    }

    public static Vector operator *(double scalar, Vector v)
    



    // Умножение векторов (векторное)
    public static Vector operator *(Vector v1, Vector v2)
    {
        return new Vector(v1.Y * v2.Z - v1.Z * v2.Y, v1.Z * v2.X - v1.X * v2.Z, v1.X * v2.Y - v1.Y * v2.X);
    }

    // Переопределение оператора сравнения по длине от начала координат
    public static bool operator >(Vector v1, Vector v2)
    {
        double length1 = Math.Sqrt(v1.X * v1.X + v1.Y * v1.Y + v1.Z * v1.Z);
        double length2 = Math.Sqrt(v2.X * v2.X + v2.Y * v2.Y + v2.Z * v2.Z);

        return length1 > length2;
    }

    public static bool operator <(Vector v1, Vector v2)
    {
        double length1 = Math.Sqrt(v1.X * v1.X + v1.Y * v1.Y + v1.Z * v1.Z);
        double length2 = Math.Sqrt(v2.X * v2.X + v2.Y * v2.Y + v2.Z * v2.Z);

        return length1 < length2;
    }
    public static bool operator >=(Vector v1, Vector v2)
    {
        return !(v1 < v2);
    }

    public static bool operator <=(Vector v1, Vector v2)
    {
        return !(v1 > v2);
    }

    public static bool operator ==(Vector v1, Vector v2)
    {
        return v1.X == v2.X && v1.Y == v2.Y && v1.Z == v2.Z;
    }

    public static bool operator !=(Vector v1, Vector v2)
    {
        return !(v1 == v2);
    }

}

class Program
{
    static void Main(string[] args)
    {
        Vector v1 = new Vector(1, 2, 3);
        Vector v2 = new Vector(4, 5, 6);
        Vector v3 = v1 + v2; // Сложение векторов
        Vector v4 = v1 * 2; // Умножение вектора на число
        Vector v5 = v2;
        Vector v6 = v1 * v2 * v2;

        Console.WriteLine($"v1: {v1.X}, {v1.Y}, {v1.Z}");
        Console.WriteLine($"v2: {v2.X}, {v2.Y}, {v2.Z}");
        Console.WriteLine($"v3: {v3.X}, {v3.Y}, {v3.Z}");
        Console.WriteLine($"v4: {v4.X}, {v4.Y}, {v4.Z}");
        Console.WriteLine($"v5: {v5.X}, {v5.Y}, {v5.Z}");
        Console.WriteLine($"v6: {v6.X}, {v6.Y}, {v6.Z}");

        Console.WriteLine($"v1 > v2: {v1 > v2}"); // Сравнение векторов по длине
        Console.WriteLine($"v1 < v2: {v1 < v2}");
        Console.WriteLine($"v1 >= v2: {v1 >= v2}");
        Console.WriteLine($"v5 <= v2: {v5 <= v2}");
        Console.WriteLine($"v2 == v5: {v2 == v5}"); 
        Console.WriteLine($"v5 != v2: {v5 != v2}");
    }
}
