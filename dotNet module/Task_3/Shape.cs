namespace Task_3
{
    /// <summary>
    /// Фигура
    /// </summary>
    public class Shape
    {
        public Shape(int count)
        {
            this.Coordinates = new Point[count];
        }

        public Shape(Point[] coords)
        {
            this.Coordinates = coords;
        }

        public Point[] Coordinates { get; set; }
    }
}
