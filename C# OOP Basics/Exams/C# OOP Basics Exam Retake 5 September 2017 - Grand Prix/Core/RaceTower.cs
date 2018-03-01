using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

class RaceTower
{
    private int lapsNumber;
    private int trackLength;
    private List<Driver> drivers;
    private List<Driver> failedDrivers;
    private int currentLap;
    private string weather;

    public RaceTower()
    {
        this.drivers = new List<Driver>();
        this.failedDrivers = new List<Driver>();

        currentLap = 0;
        weather = "Sunny";
    }

    public void SetTrackInfo(int lapsNumber, int trackLength)
    {
        this.lapsNumber = lapsNumber;
        this.trackLength = trackLength;
    }

    public void RegisterDriver(List<string> commandArgs)
    {
        try
        {
            var hp = int.Parse(commandArgs[2]);
            var fuelAmount = double.Parse(commandArgs[3]);

            Tyre tyre = TyreFactory.Get(commandArgs.Skip(4).Take(3).ToList());

            if (tyre == null)
                throw new ArgumentException();

            var car = new Car(hp, fuelAmount, tyre);

            if (car == null)
                throw new ArgumentException();    

            Driver driver = DriverFactory.Get(commandArgs.Take(2).ToList(), car);

            if (driver == null)
                throw new ArgumentException();

            this.drivers.Add(driver);
        }
        catch
        {

        }
    }

    public void DriverBoxes(List<string> commandArgs)
    {
        var reason = commandArgs[0];
        var driverName = commandArgs[1];
        
        var driver = this.drivers.SingleOrDefault(x=>x.Name == driverName);

        driver.ChangeTotalTime( 20);

        if(reason == "ChangeTyres")
        {
            var tyreType = commandArgs[2];
            var tyreHardness = double.Parse(commandArgs[3]);            

            var tyre = TyreFactory.Get(commandArgs.Skip(2).Take(3).ToList());

            if (tyre != null)
                driver.Car.ChangeTyre(tyre);
        }

        if(reason == "Refuel")
        {
            var amount = double.Parse(commandArgs[2]);
            driver.Car.Refuel(amount);
        }
    }

    public string CompleteLaps(List<string> commandArgs)
    {
        var numberOfLaps = int.Parse(commandArgs[0]);

        if(currentLap + numberOfLaps > lapsNumber)
        {
            return $"There is no time! On lap {currentLap}.";
        }
        var sb = new StringBuilder();

        for (int i = 0; i < numberOfLaps; i++)
        {
            currentLap++;

            foreach (var driver in this.drivers.Where(x=>x.OutOfRace == false))
            {
                if (driver.RunLap(trackLength))
                {
                    failedDrivers.Add(driver);
                }
            }
            OvertakeLogic(sb);
        }

        return sb.ToString().Trim();
    }

    public string GetLeaderboard()
    {
        var sb = new StringBuilder();
        sb.AppendLine($"Lap {currentLap}/{lapsNumber}");
        var posNumber = 1;
        foreach (var driver in this.drivers.Where(x=>x.OutOfRace==false).OrderBy(x=>x.TotalTime))
        {
            sb.AppendLine($"{posNumber++} {driver.Name} {driver.TotalTime:f3}");
        }
        foreach (var driver in this.failedDrivers.AsEnumerable().Reverse())
        {
            sb.AppendLine($"{posNumber++} {driver.Name} {driver.OutOfRaceReason}");
        }
        return sb.ToString().Trim();
    }

    public void ChangeWeather(List<string> commandArgs)
    {
        this.weather = commandArgs[0];
    }


    public string GetWinner()
    {
        var winningDriver = drivers.Where(x=>x.OutOfRace==false).OrderBy(x => x.TotalTime).First();
        return $"{winningDriver.Name} wins the race for {winningDriver.TotalTime:f3} seconds.";
    }

    public int GetCurrentLap => currentLap;

    private void OvertakeLogic(StringBuilder sb)
    {
        // maybe shouldn't filter out avarii 
        var dr = this.drivers.Where(x => x.OutOfRace == false).OrderByDescending(x => x.TotalTime).ToArray();
        for (int i = 0; i < dr.Length - 1; i++)
        {

            var interval = dr[i].TotalTime - dr[i + 1].TotalTime;

            if (dr[i].GetType().Name == "AggressiveDriver" &&
                dr[i].Car.Tyre.GetType().Name == "UltrasoftTyre" &&
                interval <= 3)
            {
                if (weather == "Foggy")
                {
                    failedDrivers.Add(dr[i]);
                    dr[i].Crash();
                    continue;
                }
                else
                {
                    Overtake(dr[i], dr[i + 1], 3d, sb);
                    i += 1;
                    continue;
                }
            }

            if (dr[i].GetType().Name == "EnduranceDriver" &&
                dr[i].Car.Tyre.GetType().Name == "HardTyre" &&
                interval <= 3)
            {
                if (weather == "Rainy")
                {
                    failedDrivers.Add(dr[i]);
                    dr[i].Crash();
                    continue;
                }
                else
                {
                    Overtake(dr[i], dr[i + 1], 3d, sb);
                    i += 1;
                    continue;
                }
            }

            if (interval <= 2)
            {
                Overtake(dr[i], dr[i + 1], 2d, sb);
                i += 1;
                continue;
            }
        }
    }

    private void Overtake(Driver driver1, Driver driver2, double interval, StringBuilder sb)
    {
        driver1.ChangeTotalTime (- interval);
        driver2.ChangeTotalTime ( interval);
        sb.AppendLine($"{driver1.Name} has overtaken {driver2.Name} on lap {currentLap}.");
    }
}

