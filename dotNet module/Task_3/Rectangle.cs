using System;

namespace Task_3
{
    /// <summary>
    /// Прямоугольник
    /// </summary>
    public class Rectangle : Polygon
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
        /// Конструктор прямоугольника, создающегося на координатах двух противоположных вершин
        /// </summary>
        /// <param name="p1">Левая верхняя вершина</param>
        /// <param name="p3">Правая нижняя вершина</param>
        public Rectangle(Point p1, Point p3)
        {
            this.Vertice1 = p1;
            this.Vertice3 = p3;
            this.Vertice2 = new Point(p1.X, p3.Y);
            this.Vertice4 = new Point(p3.X, p1.Y);
        }
    }
}
