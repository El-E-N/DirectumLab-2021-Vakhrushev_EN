namespace Task_3
{
    /// <summary>
    /// Квадрат
    /// </summary>
    public class Square : Polygon
    {
        public Square()
            : base(4) { }

        public Square(Point[] coords)
            : base(coords) { }
    }
}
