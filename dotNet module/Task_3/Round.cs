using System;

namespace Task_3
{
    /// <summary>
    /// Круг
    /// </summary>
    public class Round : Circle
    {
        public Round()
            : base() { }

        public Round(Point coord, double r)
            : base(coord, r) { }

        public override double Area() => Math.PI * this.Radius * this.Radius;
    }
}
