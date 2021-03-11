using System;

namespace Task_3
{
    /// <summary>
    /// Кольцо
    /// </summary>
    public class Ring : Shape
    {
        public Ring(Point center, double r1, double r2)
        {
            this.Center = center;
            this.RadiusMin = r1;
            this.RadiusMax = r2;
        }

        public Point Center { get; set; }

        public double RadiusMin { get; set; } = 0;

        public double RadiusMax { get; set; } = 0;

        public override double Area { get => Math.PI * ((this.RadiusMax * this.RadiusMax) - (this.RadiusMin * this.RadiusMin)); }

        /// <summary>
        /// Длина меньшей окружности
        /// </summary>
        /// <returns></returns>
        public double LengthMin { get => 2 * Math.PI * this.RadiusMin; }

        /// <summary>
        /// Длина большей окружности
        /// </summary>
        /// <returns></returns>
        public double LengthMax { get => 2 * Math.PI * this.RadiusMax; }

        public override double X { get => this.Center.X; }

        public override double Y { get => this.Center.Y; }
    }
}