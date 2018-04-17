namespace Last_Army
{
    class LastArmyMain
    {
        //13:33 - 15:02 structure + reflection
        //15:02 - 16:14 IO zero tests 100/100 IO
        //16:14 - 
        static void Main()
        {
            var writer = new ConsoleWriter();
            var reader = new ConsoleReader();
            var gameController = new GameController(writer);
            var engine = new Engine(reader,writer, gameController);
            engine.Run();
        }
    }
}