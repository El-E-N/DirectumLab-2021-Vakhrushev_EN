using System;

namespace Task_3
{
    /// <summary>
    /// Окружность
    /// </summary>
    public class Circle : Shape
    {
        public double Radius { get; set; }

        public Circle(Point coord, double r)
            : base(1)
        {
            this.Vertices = new Point[1] { coord };
            this.Radius = r;
        }

        public double Length { get => 2 * Math.PI * this.Radius; } // длина окружности
    }
}
