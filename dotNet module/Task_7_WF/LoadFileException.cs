using System;

/// <summary>
/// Ошибка с загрузкой файла
/// </summary>
public class LoadFileException : Exception
{
    public Exception SpecificError { get; }

    public LoadFileException(string message, Exception ex)
        : base(message, ex) { }
}
