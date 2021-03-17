namespace Task_6
{
    public class MyClassWithToString
    {
        public MyClassWithToString(string name, int sum)
        {
            this.Name = name;
            this.Sum = sum;
        }

        public string Name { get; set; }

        public int Sum { get; set; }

        public override string ToString() => $"У пользователя {this.Name} на счету {this.Sum} руб.";
    }
}
