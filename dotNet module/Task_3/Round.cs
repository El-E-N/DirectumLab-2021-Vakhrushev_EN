using System;

namespace Task_3
{
    /// <summary>
    /// Круг
    /// </summary>
    public class Round : Circle
    {
        public Round(Point center, double r)
            : base(center, r) { }

        public override double Area { get => Math.PI * this.Radius * this.Radius; }
    }
}