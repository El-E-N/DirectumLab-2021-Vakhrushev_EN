using System;

namespace Task_3
{
    /// <summary>
    /// Многоугольник создан для добавления к Shape новых методов для дальнешего удобства.
    /// </summary>
    public class Polygon : Shape
    {
        public Polygon(int count)
            : base(count) { }

        public Polygon(Point[] coords)
            : base(coords) { }

        protected double LengthOfSide(Point p1, Point p2) => Math.Sqrt(((p1.X - p2.X) * (p1.X - p2.X)) + ((p1.Y - p2.Y) * (p1.Y - p2.Y)));

        /// <summary>
        /// методом Гаусса
        /// </summary>
        /// <returns></returns>
        public double Area() 
        {
            double sum = 0;
            for (int i = 0; i < this.Coordinates.Length - 1; i++)
                sum += this.Coordinates[i].X * this.Coordinates[i + 1].Y;
            sum += this.Coordinates[this.Coordinates.Length - 1].X * this.Coordinates[0].Y;
            for (int i = 0; i < this.Coordinates.Length - 1; i++)
                sum -= this.Coordinates[i + 1].X * this.Coordinates[i].Y;
            sum -= this.Coordinates[0].X * this.Coordinates[this.Coordinates.Length - 1].Y;
            return Math.Abs(sum) / 2.0;
        }

        public double Perimetr()
        {
            double sum = 0;
            for (int i = 0; i < this.Coordinates.Length - 1; i++)
                sum += LengthOfSide(this.Coordinates[i], this.Coordinates[i + 1]);
            sum += LengthOfSide(this.Coordinates[this.Coordinates.Length - 1], this.Coordinates[0]);
            return sum;
        }
    }
}
