using System;
using System.Linq;
using System.Reflection;

public class MissionFactory : IMissionFactory
{
    public IMission CreateMission(string difficultyLevel, double neededPoints)
    {
        var type = Assembly.GetExecutingAssembly().GetTypes().FirstOrDefault(x => x.Name == difficultyLevel);
        var result = (IMission)Activator.CreateInstance(type, new object[] { neededPoints});
        return result;
    }
}

