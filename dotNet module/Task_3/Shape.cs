namespace Task_3
{
    /// <summary>
    /// Фигура
    /// </summary>
    public class Shape
    {
        public Shape(double x = 0, double y = 0)
        {
            this.X = x;
            this.Y = y;
        }

        public double X { get; set; }

        public double Y { get; set; }

        public virtual double Area { get => 0; }
    }
}
