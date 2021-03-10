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
            if (obj is Complex)
                return ((Complex)obj).Re == this.Re && ((Complex)obj).Im == this.Im;
            throw new InvalidCastException();
        }

        public override int GetHashCode() => this.Re.GetHashCode() ^ this.Im.GetHashCode();

        /// <summary>
        /// Сравнение по модулю
        /// </summary>
        /// <param name="complex">комплексное число</param>
        /// <returns>-1 - если меньше, 1 - если больше, 0 - если равны</returns>
        public int CompareTo(object complex)
        {
            if (complex is Complex)
            {
                if (this.Module < ((Complex)complex).Module)
                    return -1;
                else if (this.Module > ((Complex)complex).Module)
                    return 1;
                return 0;
            }
            throw new InvalidCastException();
        }

        private double Module { get => Math.Sqrt((this.Re * this.Re) + (this.Im * this.Im)); }
    }
}
