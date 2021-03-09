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

        public override bool Equals(object obj) => ((Complex)obj).Re == this.Re && ((Complex)obj).Im == this.Im;

        public override int GetHashCode() => this.Re.GetHashCode() + this.Im.GetHashCode();

        /// <summary>
        /// Сравнение по модулю
        /// </summary>
        /// <param name="complex">комплексное число</param>
        /// <returns>-1 - если меньше, 1 - если больше, 0 - если равны</returns>
        public int CompareTo(object complex)
        {
            if (Math.Sqrt((this.Re * this.Re) + (this.Im * this.Im)) 
                < Math.Sqrt((((Complex)complex).Re * ((Complex)complex).Re) + (((Complex)complex).Im * ((Complex)complex).Im)))
                return -1;
            else if (Math.Sqrt((this.Re * this.Re) + (this.Im * this.Im))
                > Math.Sqrt((((Complex)complex).Re * ((Complex)complex).Re) + (((Complex)complex).Im * ((Complex)complex).Im)))
                return 1;
            return 0;
        }
    }
}
