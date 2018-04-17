using System.Collections.Generic;
using System.Linq;

class WareHouse : IWareHouse
{
    private Dictionary<string, int> ammunitions;
    private IAmmunitionFactory ammunitionFactory;
    private const int Zero = 0;

    public WareHouse()
    {
        this.ammunitions = new Dictionary<string, int>();
        this.ammunitionFactory = new AmmunitionFactory();
    }

    public void AddAmmunition(string name, int quantity)
    {
        if (ammunitions.ContainsKey(name))
        {
            this.ammunitions[name] += quantity;
        }
        else
        {
            this.ammunitions.Add(name, quantity);
        }
    }

    public void EquipArmy(IArmy army)
    {
        foreach (var soldier in army.Soldiers)
        {
            this.TryEquipSoldier(soldier);
        }
    }

    public bool TryEquipSoldier(ISoldier soldier)
    {
        bool equipt = true;
        var itemsToEquip = soldier.Weapons.Where(x => x.Value == null).Select(x=>x.Key).ToList();

        foreach (var item in itemsToEquip)
        {
            if(this.ammunitions.ContainsKey(item) && this.ammunitions[item] > Zero)
            {
                this.ammunitions[item]--;
                soldier.Weapons[item] = ammunitionFactory.CreateAmmunition(item);
            }
            else
            {
                equipt = false;
            }
        }
        return equipt;
    }
}

