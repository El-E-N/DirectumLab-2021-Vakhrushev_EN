namespace Task_3
{
    /// <summary>
    /// Треугольник
    /// </summary>
    public class Triangle : Polygon
    {
        public Triangle()
            : base(3) { }

        public Triangle(Point[] coords)
            : base(coords) { }
    }
}
