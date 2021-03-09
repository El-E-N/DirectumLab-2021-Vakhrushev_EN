namespace Task_3
{
    /// <summary>
    /// Координата точки на плоскости
    /// </summary>
    public struct Point
    {
        public Point(double x = 0, double y = 0)
        {
            this.X = x;
            this.Y = y;
        }

        public double X { get; private set; }

        public double Y { get; private set; }
    }
}
