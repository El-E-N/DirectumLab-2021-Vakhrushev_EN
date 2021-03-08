using System;

namespace Task_3
{
    /// <summary>
    /// Полигон.
    /// </summary>
    /// <remarks>Многоугольник создан для добавления к Shape новых методов для дальнешего удобства.</remarks>>
    public class Polygon : Shape
    {
        public Polygon(int count)
            : base(count) { }

        public Polygon(Point[] coords)
            : base(coords) { }

        protected double GetLengthOfSide(Point p1, Point p2) => Math.Sqrt(((p1.X - p2.X) * (p1.X - p2.X)) + ((p1.Y - p2.Y) * (p1.Y - p2.Y)));

        /// <summary>
        /// Вычислить площадь полигона
        /// </summary>
        /// <returns>Площадь.</returns>
        /// <remarks>Вычисляется методом Гаусса.</remarks>
        public double Area() 
        {
            double sum = 0;
            for (int i = 0; i < this.Vertices.Length - 1; i++)
                sum += this.Vertices[i].X * this.Vertices[i + 1].Y;
            sum += this.Vertices[this.Vertices.Length - 1].X * this.Vertices[0].Y;
            for (int i = 0; i < this.Vertices.Length - 1; i++)
                sum -= this.Vertices[i + 1].X * this.Vertices[i].Y;
            sum -= this.Vertices[0].X * this.Vertices[this.Vertices.Length - 1].Y;
            return Math.Abs(sum) / 2.0;
        }

        public double Perimeter()
        {
            double sum = 0;
            for (int i = 0; i < this.Vertices.Length - 1; i++)
                sum += GetLengthOfSide(this.Vertices[i], this.Vertices[i + 1]);
            sum += GetLengthOfSide(this.Vertices[this.Vertices.Length - 1], this.Vertices[0]);
            return sum;
        }
    }
}
