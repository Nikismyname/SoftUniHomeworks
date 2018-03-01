using System.Collections.Generic;

public static class DriverFactory
{
    public static Driver Get(List<string> commandArgs, Car car)
    {
        var type = commandArgs[0];
        var name = commandArgs[1];

        if (type == "Aggressive")
        {
            return new AggressiveDriver(name, car);
        }
        else if (type == "Endurance")
        {
            return  new EnduranceDriver(name, car);
        }
        else
        {
            return null;
        }
    }
}

