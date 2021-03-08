using System;

namespace Task_3
{
    /// <summary>
    /// Круг
    /// </summary>
    public class Round : Circle
    {
        public Round(Point coord, double r)
            : base(coord, r) { }

        public double Area { get => Math.PI * this.Radius * this.Radius; }
    }
}
