using System;
using System.IO;

namespace Test.Utils;

public class ConsoleReader {
    private StringWriter _stringWriter;
    private TextWriter _originalOutput;

    public ConsoleReader() {
        _stringWriter = new StringWriter();
        _originalOutput = Console.Out;
        Console.SetOut(_stringWriter);
    }

    public string GetOutput() => _stringWriter.ToString();

    public void Dispose() {
        Console.SetOut(_originalOutput);
        _stringWriter.Dispose();
    }
}