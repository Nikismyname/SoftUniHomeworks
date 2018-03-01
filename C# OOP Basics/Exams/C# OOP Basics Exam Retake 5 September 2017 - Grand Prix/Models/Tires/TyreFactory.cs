using System.Collections.Generic;

public static class TyreFactory
{
    public static Tyre Get(List<string> commandArgs)
    {
        var tyreType = commandArgs[0];
        var tyreHardness = double.Parse(commandArgs[1]);
        var grip = 0d;
        if (tyreType == "Ultrasoft")
            grip = double.Parse(commandArgs[2]);

        if (tyreType == "Ultrasoft")
        {
            return new UltrasoftTyre(tyreHardness, grip);
        }
        else if (tyreType == "Hard")
        {
            return new HardTyre(tyreHardness);
        }
        else
        {
            return null;
        }
    }
}

