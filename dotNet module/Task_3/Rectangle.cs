namespace Task_3
{
    /// <summary>
    /// Прямоугольник
    /// </summary>
    public class Rectangle : Polygon
    {
        public Rectangle()
            : base(4) { }

        public Rectangle(Point[] coords)
            : base(coords) { }
    }
}
