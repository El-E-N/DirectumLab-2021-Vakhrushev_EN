using System;

namespace Task_3
{
    /// <summary>
    /// Координаты точки на плоскости
    /// </summary>
    public struct Point
    {
        public double x;
        public double y;
    }

    /// <summary>
    /// Фигура
    /// </summary>
    public class Shape
    {
        public Shape(int count)
        {
            this.Coordinates = new Point[count];
        }

        public Shape(Point[] coords)
        {
            this.Coordinates = coords;
        }

        public Point[] Coordinates { get; set; }
    }

    /// <summary>
    /// Окружность
    /// </summary>
    public class Circle : Shape
    {
        public double Radius { get; set; }

        public Circle() 
            : base(1)
        {
            this.Radius = 0;
        }

        public Circle(Point[] coords, double r) 
            : base(coords)
        {
            this.Radius = r;
        }

        public virtual double Area() => 0; // площадь

        public double Length() => 2 * Math.PI * this.Radius; // длина окружности
    }

    /// <summary>
    /// Круг
    /// </summary>
    public class Round : Circle
    {
        public Round()
            : base() { }
        public Round(Point[] coords, double r)
            : base(coords, r) { }

        public override double Area() => Math.PI * this.Radius * this.Radius;
    }

    /// <summary>
    /// Кольцо
    /// </summary>
    public class Ring : Shape
    {
        public Ring()
            : base(1)
        {
            (RadiusMin, RadiusMax) = (0, 0);
        }

        public Ring(Point[] coords, double r1, double r2)
            : base(coords)
        {
            this.RadiusMin = r1;
            this.RadiusMax = r2;
        }

        public double RadiusMin { get; set; }

        public double RadiusMax { get; set; }

        public double Area() => Math.PI * (this.RadiusMax * this.RadiusMax - this.RadiusMin * this.RadiusMin);

        public double LengthMin() => 2 * Math.PI * this.RadiusMin; // Длина меньшей окружности

        public double LengthMax() => 2 * Math.PI * this.RadiusMax; // Длина большей окружности
    }

    /// <summary>
    /// Многоугольник создан для добавления к Shape новых методов для дальнешего удобства. 
    /// abstract, так как не записан универсальный подсчет площади и периметра многоугольника
    /// </summary>
    public abstract class Polygon : Shape
    {
        public Polygon(int count)
            : base(count) { }

        public Polygon(Point[] coords)
            : base(coords) { }

        protected double LengthOfSide(Point p1, Point p2) => Math.Sqrt((p1.x - p2.x) * (p1.x - p2.x) + (p1.y - p2.y) * (p1.y - p2.y));

        public virtual double Area() => 0;

        public virtual double Perimetr() => 0;
    }

    /// <summary>
    /// Треугольник
    /// </summary>

    public class Triangle : Polygon
    {
        public Triangle()
            : base(3) { }

        public Triangle(Point[] coords)
            : base(coords) { }

        public override double Area() => Math.Abs((this.Coordinates[0].x - this.Coordinates[2].x) * (this.Coordinates[1].y - this.Coordinates[2].y)
                - (this.Coordinates[0].y - this.Coordinates[2].y) * (this.Coordinates[1].x - this.Coordinates[2].x)) / 2;

        public override double Perimetr() => LengthOfSide(Coordinates[0], Coordinates[1]) + LengthOfSide(Coordinates[0], Coordinates[2]) + LengthOfSide(Coordinates[1], Coordinates[2]);
    }

    /// <summary>
    /// Прямоугольник
    /// </summary>
    class Rectangle : Polygon
    {
        public Rectangle()
            : base(4) { }

        public Rectangle(Point[] coords)
            : base(coords) { }

        private double Mult(int a, int b) => Coordinates[a].x * Coordinates[b].y; // просто для сокращения кода в Square

        public override double Area() => 1 / 2 * Math.Abs(Mult(0, 1) + Mult(1, 2) + Mult(2, 3) + Mult(3, 0)
                - Mult(1, 0) - Mult(2, 1) - Mult(3, 2) - Mult(0, 3)); // Методом Гаусса

        public override double Perimetr() => LengthOfSide(Coordinates[0], Coordinates[1]) + LengthOfSide(Coordinates[1], Coordinates[2])
            + LengthOfSide(Coordinates[2], Coordinates[3]) + LengthOfSide(Coordinates[3], Coordinates[0]);
    }

    /// <summary>
    /// Квадрат
    /// </summary>
    public class Square : Polygon
    {
        public Square()
            : base(4) { }

        public Square(Point[] coords)
            : base(coords) { }

        private double Mult(int a, int b) => Coordinates[a].x * Coordinates[b].y; // просто для сокращения кода в Square

        public override double Area() => LengthOfSide(Coordinates[0], Coordinates[1]) * LengthOfSide(Coordinates[0], Coordinates[1]);

        public override double Perimetr() => 4 * LengthOfSide(Coordinates[0], Coordinates[1]);
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }
}
