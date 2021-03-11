namespace Task_3
{
    /// <summary>
    /// Треугольник
    /// </summary>
    public class Triangle : Polygon
    {
        public Point Vertice1 { get; set; }

        public Point Vertice2 { get; set; }

        public Point Vertice3 { get; set; }

        public override double Area { get => this.GetArea(this.Vertice1, this.Vertice2, this.Vertice3); }

        public override double Perimeter { get => this.GetPerimeter(this.Vertice1, this.Vertice2, this.Vertice3); }

        public override double X { get => this.Vertice1.X; }

        public override double Y { get => this.Vertice1.Y; }

        public Triangle(Point[] verts)
        {
            if (verts.Length == 3)
            {
                this.Vertice1 = verts[0];
                this.Vertice2 = verts[1];
                this.Vertice3 = verts[2];
            }
            else
                System.Console.WriteLine("Нужно ввести координаты трех вершин треугольника!");
        }
    }
}
