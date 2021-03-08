namespace Task_3
{
    /// <summary>
    /// Фигура
    /// </summary>
    public class Shape
    {
        public Shape(int count)
        {
            this.Vertices = new Point[count];
        }

        public Shape(Point[] coords)
        {
            this.Vertices = coords;
        }

        public Point[] Vertices { get; set; }
    }
}
