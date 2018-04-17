
using System.Collections.Generic;
using System.Linq;

class Army : IArmy
{
    private List<ISoldier> soldiers;

    public IReadOnlyList<ISoldier> Soldiers => soldiers;

    public Army()
    {
        this.soldiers = new List<ISoldier>();
    }

    public void AddSoldier(ISoldier soldier)
    {
        this.soldiers.Add(soldier);
    }

    public void RegenerateTeam(string soldierType)
    {
        var soldiersToRegenerato = this.soldiers.Where(x => x.GetType().Name == soldierType).ToList();

        foreach (var soldier in soldiersToRegenerato)
        {
            soldier.Regenerate();
        }
    }
}

