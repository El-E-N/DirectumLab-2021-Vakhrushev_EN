namespace Task_3
{
    /// <summary>
    /// Треугольник
    /// </summary>
    public class Triangle : Polygon
    {
        public Point Vertice1 { get; }

        public Point Vertice2 { get; }

        public Point Vertice3 { get; }

        public override double Area { get => this.GetArea(this.Vertice1, this.Vertice2, this.Vertice3); }

        public override double Perimeter { get => this.GetPerimeter(this.Vertice1, this.Vertice2, this.Vertice3); }

        public override double X { get => this.Vertice1.X; }

        public override double Y { get => this.Vertice1.Y; }

        public Triangle(Point p1, Point p2, Point p3)
        {
            this.Vertice1 = p1;
            this.Vertice2 = p2;
            this.Vertice3 = p3;
        }
    }
}
