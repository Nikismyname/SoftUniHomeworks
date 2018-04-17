using System;
using System.Linq;
using System.Reflection;

public class AmmunitionFactory : IAmmunitionFactory
{
    public IAmmunition CreateAmmunition(string ammunitionName)
    {
        var type = Assembly.GetExecutingAssembly().GetTypes().FirstOrDefault(x => x.Name == ammunitionName);
        var ammunition = (IAmmunition)Activator.CreateInstance(type,new object[] { ammunitionName});
        return ammunition;
    }
}