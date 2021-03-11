using System;

namespace Task_3
{
    /// <summary>
    /// Окружность
    /// </summary>
    public class Circle : Shape
    {
        public double Radius { get; set; }

        public Point Center { get; set; }

        public Circle(Point center, double radius)
        {
            this.Center = center;
            this.Radius = radius;
        }

        public override double X { get => this.Center.X; }

        public override double Y { get => this.Center.Y; }

        public override double Area { get => 0; }

        public double Length { get => 2 * Math.PI * this.Radius; } // длина окружности
    }
}
