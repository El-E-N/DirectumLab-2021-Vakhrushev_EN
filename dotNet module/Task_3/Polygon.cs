using System;

namespace Task_3
{
    /// <summary>
    /// Полигон.
    /// </summary>
    /// <remarks>Многоугольник создан для добавления к Shape новых методов для дальнешего удобства.</remarks>>
    public class Polygon : Shape
    {
        protected double GetLengthOfSide(Point p1, Point p2) => Math.Sqrt(((p1.X - p2.X) * (p1.X - p2.X)) + ((p1.Y - p2.Y) * (p1.Y - p2.Y)));

        /// <summary>
        /// Вычислить площадь полигона
        /// </summary>
        /// <returns>Площадь.</returns>
        /// <remarks>Вычисляется методом Гаусса.</remarks>
        public double GetArea(params Point[] vertices)
        {
            double sum = 0;
            for (int i = 0; i < vertices.Length - 1; i++)
                sum += vertices[i].X * vertices[i + 1].Y;
            sum += vertices[vertices.Length - 1].X * vertices[0].Y;
            for (int i = 0; i < vertices.Length - 1; i++)
                sum -= vertices[i + 1].X * vertices[i].Y;
            sum -= vertices[0].X * vertices[vertices.Length - 1].Y;
            return Math.Abs(sum) / 2.0;
        }

        public double GetPerimeter(params Point[] vertices)
        {
            double sum = 0;
            for (int i = 0; i < vertices.Length - 1; i++)
                sum += this.GetLengthOfSide(vertices[i], vertices[i + 1]);
            sum += this.GetLengthOfSide(vertices[vertices.Length - 1], vertices[0]);
            return sum;
        }

        protected bool CheckOnPythagoras(Point p1, Point p2, Point p3) => Math.Round(Math.Pow(this.GetLengthOfSide(p1, p2), 2)
            + Math.Pow(this.GetLengthOfSide(p2, p3), 2), 5) == Math.Round(Math.Pow(this.GetLengthOfSide(p1, p3), 2), 5);
    }
}
