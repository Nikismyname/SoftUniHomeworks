using System;
using System.Text;

class ConsoleWriter : IWriter
{
    private StringBuilder sb;

    public ConsoleWriter()
    {
        this.sb = new StringBuilder();
    }

    public string GetStorredMessage()
    {
        return sb.ToString().Trim();
    }

    public void StoreMessage(string message)
    {
        this.sb.AppendLine(message);
    }

    public void WriteLine(string output)
    {
        Console.WriteLine(output);
    }
}
