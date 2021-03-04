using System;

namespace Task_3
{
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

        public Circle(Point coord, double r)
            : base(1)
        {
            this.Coordinates = new Point[1] { coord };
            this.Radius = r;
        }

        public virtual double Area() => Math.PI * this.Radius * this.Radius; // площадь

        public double Length() => 2 * Math.PI * this.Radius; // длина окружности
    }
}
