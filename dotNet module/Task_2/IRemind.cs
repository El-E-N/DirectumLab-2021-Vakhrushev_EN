using System;

namespace Task_2
{
    /// <summary>
    /// интерфейс напоминания
    /// </summary>
    public interface IRemind
    {
        public DateTime EventTime { get; set; }
    }
}
