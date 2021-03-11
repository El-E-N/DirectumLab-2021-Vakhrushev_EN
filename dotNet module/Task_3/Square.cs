using System;

namespace Task_3
{
    /// <summary>
    /// Квадрат
    /// </summary>
    public class Square : Polygon
    {
        public Point Vertice1 { get; }

        public Point Vertice2 { get; }

        public Point Vertice3 { get; }

        public Point Vertice4 { get; }

        public override double Area { get => this.GetArea(this.Vertice1, this.Vertice2, this.Vertice3, this.Vertice4); }

        public override double Perimeter { get => this.GetPerimeter(this.Vertice1, this.Vertice2, this.Vertice3, this.Vertice4); }

        public override double X { get => this.Vertice1.X; }

        public override double Y { get => this.Vertice1.Y; }

        /// <summary>
        /// Конструктор квадрата
        /// </summary>
        /// <param name="p">Левая верхняя вершина</param>
        /// <param name="side">Длина стороны</param>
        public Square(Point p, double side)
        {
            if (side >= 0)
            {
                this.Vertice1 = p;
                this.Vertice2 = new Point(p.X + side, p.Y);
                this.Vertice3 = new Point(p.X + side, p.Y + side);
                this.Vertice4 = new Point(p.X, p.Y + side);
            }
            else
                Console.WriteLine("Длина стороны квадрата не должна быть отрицательной!");
        }
    }
}
