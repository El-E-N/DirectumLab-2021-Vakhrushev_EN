using System;

namespace Task_5
{
    /// <summary>
    /// Комплексное число
    /// </summary>
    public class Complex : IComparable
    { 
        public double Re { get; set; }

        public double Im { get; set; }

        public override bool Equals(object obj)
        {
            if (obj is Complex complex)
                return complex.Re == this.Re && complex.Im == this.Im;
            throw new ArgumentException();
        }

        public override int GetHashCode() => this.Re.GetHashCode() ^ this.Im.GetHashCode();

        /// <summary>
        /// Сравнение по модулю
        /// </summary>
        /// <param name="complex">комплексное число</param>
        /// <returns>-1 - если меньше, 1 - если больше, 0 - если равны</returns>
        public int CompareTo(object complex)
        {
            if (complex is Complex compl)
            {
                if (this.Module < compl.Module)
                    return -1;
                else if (this.Module > compl.Module)
                    return 1;
                return 0;
            }
            throw new ArgumentException();
        }

        private double Module { get => Math.Sqrt((this.Re * this.Re) + (this.Im * this.Im)); }
    }
}
