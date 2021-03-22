using System;

/// <summary>
/// Ошибка с загрузкой файла
/// </summary>
public class LoadFileException : Exception
{
    public LoadFileException(string message, Exception innerException)
        : base(message, innerException) { }
}
