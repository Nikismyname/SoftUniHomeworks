using System;
using System.Linq;
using System.Reflection;

public class SoldierFactory : ISoldierFactory
{
    public ISoldier CreateSoldier(string soldierTypeName, string name, int age, double experience, double endurance)
    {
        var type = Assembly.GetExecutingAssembly().GetTypes().FirstOrDefault(x => x.Name == soldierTypeName);
        var constructorArgs = new object[] { name, age, experience,endurance};
        var result = (ISoldier)Activator.CreateInstance(type, constructorArgs);
        return result;
    }
}
