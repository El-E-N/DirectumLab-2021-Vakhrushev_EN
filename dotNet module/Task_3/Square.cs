using System;

namespace Task_3
{
    /// <summary>
    /// Квадрат
    /// </summary>
    public class Square : Polygon
    {
        public Point Vertice1 { get; set; }

        public Point Vertice2 { get; set; }

        public Point Vertice3 { get; set; }

        public Point Vertice4 { get; set; }

        public override double Area
        {
            get
            {
                if (this.EqualityOfAllSides())
                {
                    if (this.CheckOnPythagoras(this.Vertice1, this.Vertice2, this.Vertice3) && this.CheckOnPythagoras(this.Vertice2, this.Vertice3, this.Vertice4))
                        return this.GetArea(this.Vertice1, this.Vertice2, this.Vertice3, this.Vertice4);
                    else
                        Console.WriteLine("Углы квадрата не прямые!");
                }
                else
                    Console.WriteLine("Все стороны квадрата не равны!");
                return 0;
            }
        }

        public double Perimeter
        {
            get
            {
                if (this.EqualityOfAllSides())
                {
                    if (this.CheckOnPythagoras(this.Vertice1, this.Vertice2, this.Vertice3) && this.CheckOnPythagoras(this.Vertice2, this.Vertice3, this.Vertice4))
                        return this.GetPerimeter(this.Vertice1, this.Vertice2, this.Vertice3, this.Vertice4);
                    else
                        Console.WriteLine("Углы квадрата не прямые!");
                }
                else
                    Console.WriteLine("Все стороны квадрата не равны!");
                return 0;
            }
        }

        public Square(Point[] verts)
        {
            if (verts.Length == 4)
            {
                // если все стороны равны
                if (this.EqualityOfAllSides())
                {
                    // углы прямые по теореме Пифагора
                    if (this.CheckOnPythagoras(verts[0], verts[1], verts[2]) && this.CheckOnPythagoras(verts[1], verts[2], verts[3]))
                    {
                        this.Vertice1 = verts[0];
                        this.Vertice2 = verts[1];
                        this.Vertice3 = verts[2];
                        this.Vertice4 = verts[3];
                    }
                    else
                        Console.WriteLine("Углы квадрата не прямые!");
                }
                else
                    Console.WriteLine("Все стороны квадрата не равны!");
            }
            else
                Console.WriteLine("Нужно ввести координаты четырех вершин квадрата!");
        }

        private bool EqualityOfAllSides() =>
            this.GetLengthOfSide(this.Vertice1, this.Vertice2) == this.GetLengthOfSide(this.Vertice2, this.Vertice3)
                    && this.GetLengthOfSide(this.Vertice2, this.Vertice3) == this.GetLengthOfSide(this.Vertice3, this.Vertice4)
                    && this.GetLengthOfSide(this.Vertice3, this.Vertice4) == this.GetLengthOfSide(this.Vertice1, this.Vertice4);
    }
}
