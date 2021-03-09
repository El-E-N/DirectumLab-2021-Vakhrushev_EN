using System;

namespace Task_3
{
    public class Program
    {
        public static void Main(string[] args)
        {     
            var point1 = new Point(1, 2);
            var point2 = new Point(-1, -2);
            var point3 = new Point(0, 1);
            var point4 = new Point(-1, 2);
            var point5 = new Point(1, -2);
            var point6 = new Point(-1, 0);
            var point7 = new Point(1, 0);
            var arrayTriangle = new Point[3] { point1, point2, point4 };
            var arrayRectangle = new Point[4] { point1, point4, point2, point5 };
            var arraySquare = new Point[4] { point1, point4, point6, point7 };

            var circle = new Circle(point1, 2);
            var round = new Round(point2, 3);
            var ring = new Ring(point3, 3, 4);
            var triangle = new Triangle(arrayTriangle);
            var rectangle = new Rectangle(arrayRectangle);
            var square = new Square(arraySquare);

            Console.WriteLine("circle: length = " + circle.Length);
            Console.WriteLine("round: area = " + round.Area + ", length = " + round.Length);
            Console.WriteLine("ring: area = " + ring.Area + ", lengthMin = " + ring.LengthMin + ", lengthMax = " + ring.LengthMax);
            Console.WriteLine("triangle: area = " + triangle.Area + ", Perimeter = " + triangle.Perimeter);
            Console.WriteLine("rectangle: area = " + rectangle.Area + ", Perimeter = " + rectangle.Perimeter);
            Console.WriteLine("square: area = " + square.Area + ", Perimeter = " + square.Perimeter);
        }
    }
}
