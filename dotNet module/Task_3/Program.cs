using System;

namespace Task_3
{
    public struct Point
    {
        public double x;
        public double y;

        /*public double this[int c]
        {
            get
            {
                if (c == 0)
                    return this.x;
                return this.y;
            }
            set
            {
                if (c == 0)
                    this.x = value;
                else
                    this.y = value;
            }
        }*/
    }

    public class Shape
    {
        private Point[] coordinates;

        public Shape(int count)
        {
            coordinates = new Point[count];
        }

        public Shape(Point[] coords)
        {
            coordinates = coords;
        }

        public Point[] Coordinates
        {
            get => this.coordinates;
            set 
            {
                this.coordinates = value;
            }
        }
    }

    /// <summary>
    /// Окружность
    /// </summary>
    public class Circle : Shape
    {
        private double radius = 0;

        public double R
        {
            get => this.radius;
            set
            {
                this.radius = value;
            }
        }

        public Circle() 
            : base(1)
        {
            this.radius = 0;
        }

        public Circle(Point[] coords, double r) 
            : base(coords)
        {
            this.radius = r;
        }

        public virtual double Square() => 0;

        public double Length() => 2 * Math.PI * this.radius;
    }

    public class Round : Circle
    {
        public Round()
            : base() { }
        public Round(Point[] coords, double r)
            : base(coords, r) { }

        public override double Square() => Math.PI * this.R * this.R;
    }

    public class Ring : Shape
    {
        private double radiusMin;
        private double radiusMax;

        public Ring()
            : base(1)
        {
            (radiusMin, radiusMax) = (0, 0);
        }

        public Ring(Point[] coords, double r1, double r2)
            : base(coords)
        {
            this.radiusMin = r1;
            this.radiusMax = r2;
        }

        public double RadiusMin
        {
            get => this.radiusMin;
            set
            {
                this.radiusMin = value;
            }
        }

        public double RadiusMax
        {
            get => this.radiusMax;
            set
            {
                this.radiusMax = value;
            }
        }

        public double Square() => Math.PI * (this.radiusMax * this.radiusMax - this.radiusMin * this.radiusMin);

        public double LengthMin() => 2 * Math.PI * this.radiusMin;

        public double LengthMax() => 2 * Math.PI * this.radiusMax;
    }

    public class Triangle : Shape
    {
        public Triangle()
            : base(3) { }

        public Triangle(Point[] coords)
            : base(coords) { }

        public double Square()
        {
            double sqr = Math.Abs((this.Coordinates[0].x - this.Coordinates[2].x) * (this.Coordinates[1].y - this.Coordinates[2].y)
                - (this.Coordinates[0].y - this.Coordinates[2].y) * (this.Coordinates[1].x - this.Coordinates[2].x)) / 2;
            return sqr;
        }

        private double Length(Point p1, Point p2)
        {
            return Math.Sqrt((p1.x - p2.x) * (p1.x - p2.x) + (p1.y - p2.y) * (p1.y - p2.y));
        }

        public double Perimetr()
        {
            return Length(Coordinates[0], Coordinates[1])+ Length(Coordinates[0], Coordinates[2]) + Length(Coordinates[1], Coordinates[2]);
        }
    }

    class Rectangle : Shape
    {
        public Rectangle()
            : base(4) { }

        public Rectangle(Point[] coords)
            : base(coords) { }

        public double Square()
        {
            var c = this.Coordinates;
            return 1 / 2 * Math.Abs(c[0].x * c[1].y ); // доделать
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }
}
