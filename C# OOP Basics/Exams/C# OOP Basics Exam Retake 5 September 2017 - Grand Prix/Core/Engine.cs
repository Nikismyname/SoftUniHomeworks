using System;
using System.Linq;

public class Engine
{
    public void Run()
    {
        var raceTower = new RaceTower();

        var laps = int.Parse(Console.ReadLine());
        var length = int.Parse(Console.ReadLine());

        raceTower.SetTrackInfo(laps,length);

        while(raceTower.GetCurrentLap != laps)
        {
            var tokens = Console.ReadLine().Split().ToList();
            var command = tokens[0];
            tokens.RemoveAt(0);

            switch (command)
            {
                case "RegisterDriver":
                   raceTower.RegisterDriver(tokens);
                    break;
                case "Leaderboard":
                    Console.WriteLine(raceTower.GetLeaderboard());
                    break;
                case "CompleteLaps":
                    var result = raceTower.CompleteLaps(tokens);
                    if (!string.IsNullOrWhiteSpace(result))
                        Console.WriteLine(result);
                    break;
                case "Box":
                    raceTower.DriverBoxes(tokens);
                    break;
                case "ChangeWeather":
                    raceTower.ChangeWeather(tokens);
                    break;
            }
        }

        Console.WriteLine(raceTower.GetWinner());
    }
}

