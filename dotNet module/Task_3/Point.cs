namespace Task_3
{
    /// <summary>
    /// Координата точки на плоскости
    /// </summary>
    public struct Point
    {
        public Point(double x, double y)
        {
            this.X = x;
            this.Y = y;
        }

        public double X { get; private set; }

        public double Y { get; private set; }
    }
}
