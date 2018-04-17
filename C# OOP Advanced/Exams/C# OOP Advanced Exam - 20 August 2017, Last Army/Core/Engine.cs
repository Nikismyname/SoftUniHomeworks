using System;

public class Engine : IEngine
{
    private const string EndCommand = "Enough! Pull back!";

    private IReader reader;
    private IWriter writer;
    private GameController gameController;

    public Engine(IReader reader, IWriter writer, GameController gameController)
    {
        this.reader = reader;
        this.writer = writer;
        this.gameController = gameController;
    }

    public void Run()
    {
        string input;
        while((input = reader.ReadLine()) != EndCommand)
        {
            this.gameController.ParseCommand(input);
        }

        this.gameController.GenerateReport();
        Console.WriteLine(writer.GetStorredMessage().Trim());
    }
}

