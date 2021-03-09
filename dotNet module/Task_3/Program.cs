using System;

namespace Task_3
{
    public class Program
    {
        public static void Main(string[] args)
        {    
            Point point1 = new Point(1, 2);
            Point point2 = new Point(-1, -2);
            Point point3 = new Point(0, 1);
            Point point4 = new Point(-1, 2);
            Point point5 = new Point(1, -2);
            Point point6 = new Point(-1, 0);
            Point point7 = new Point(1, 0);
            Point[] arrayTriangle = new Point[3] { point1, point2, point4 };
            Point[] arrayRectangle = new Point[4] { point1, point4, point2, point5 };
            Point[] arraySquare = new Point[4] { point1, point4, point6, point7 };

            Circle circle = new Circle(point1, 2);
            Round round = new Round(point2, 3);
            Ring ring = new Ring(point3, 3, 4);
            Triangle triangle = new Triangle(arrayTriangle);
            Rectangle rectangle = new Rectangle(arrayRectangle);
            Rectangle square = new Rectangle(arraySquare);

            Console.WriteLine("circle: length = " + circle.Length);
            Console.WriteLine("round: area = " + round.Area + ", length = " + round.Length);
            Console.WriteLine("ring: area = " + ring.Area + ", lengthMin = " + ring.LengthMin + ", lengthMax = " + ring.LengthMax);
            Console.WriteLine("triangle: area = " + triangle.Area() + ", Perimetr = " + triangle.Perimeter());
            Console.WriteLine("rectangle: area = " + rectangle.Area() + ", Perimetr = " + rectangle.Perimeter());
            Console.WriteLine("square: area = " + square.Area() + ", Perimetr = " + square.Perimeter());
        }
    }
}
