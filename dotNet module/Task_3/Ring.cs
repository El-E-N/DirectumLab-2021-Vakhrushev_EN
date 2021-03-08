using System;

namespace Task_3
{
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

        public Ring(Point coord, double r1, double r2)
            : base(1)
        {
            this.Vertices = new Point[1] { coord };
            this.RadiusMin = r1;
            this.RadiusMax = r2;
        }

        public double RadiusMin { get; set; }

        public double RadiusMax { get; set; }

        public double Area { get => Math.PI * ((this.RadiusMax * this.RadiusMax) - (this.RadiusMin * this.RadiusMin)); }

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
    }
}
