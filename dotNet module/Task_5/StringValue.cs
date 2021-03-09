﻿namespace Task_5
{
    /// <summary>
    /// Свой класс String
    /// </summary>
    public class StringValue
    {
        public string Value { get; private set; }

        public StringValue(string value)
        {
            this.Value = value;
        }

        public override bool Equals(object obj) => ((StringValue)obj).Value == this.Value;

        public override int GetHashCode() => this.Value.GetHashCode();

        public static bool operator ==(StringValue str1, StringValue str2) => str1.Equals(str2);

        public static bool operator !=(StringValue str1, StringValue str2) => !str1.Equals(str2);
    }
}
