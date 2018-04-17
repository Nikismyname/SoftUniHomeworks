using System.Collections.Generic;
using System.Linq;

public class GameController
{
    private const string SoldierCommandConst = "Soldier";
    private const string WareHouseCommandConst = "WareHouse";
    private const string MissionCommandConst = "Mission";
    private const string RegenerateCommandConst = "Regenerate";

    private IArmy army;
    private IWareHouse wareHouse;
    private MissionController missionControllerField;
    private IWriter writer;
    private ISoldierFactory soldierFactory;
    private IMissionFactory missionFactory;


    public GameController(IWriter writer)
    {
        this.army = new Army();
        this.wareHouse = new WareHouse();
        this.missionControllerField = new MissionController(army, wareHouse);
        this.writer = writer;
        this.soldierFactory = new SoldierFactory();
        this.missionFactory = new MissionFactory();
    }

    public void ParseCommand(string command)
    {
        string[] tokens = command.Split();
        if(tokens[0] == SoldierCommandConst)
        {
            this.ParseSoldierCommand(tokens.Skip(1).ToList());
        }

        if(tokens[0] == WareHouseCommandConst)
        {
            this.WarehouseCommand(tokens.Skip(1).ToList());
        }

        if(tokens[0] == MissionCommandConst)
        {
            this.MissionCommand(tokens.Skip(1).ToList());
        }
    }

    private void MissionCommand(List<string> tokens)
    {
        string type = tokens[0];
        double scoreToComplete = double.Parse(tokens[1]);
        var mission = this.missionFactory.CreateMission(type,scoreToComplete);
        this.writer.StoreMessage(this.missionControllerField.PerformMission(mission).Trim());
    }

    private void WarehouseCommand(List<string> tokens)
    {
        var name = tokens[0];
        var count = int.Parse(tokens[1]);
        this.wareHouse.AddAmmunition(name, count);
    }

    private void ParseSoldierCommand(List<string> tokens)
    {
        if(tokens[0] == RegenerateCommandConst)
        {
            string soldierType = tokens[1];
            foreach (var soldier in this.army.Soldiers.Where(x=>x.GetType().Name == soldierType))
            {
                soldier.Regenerate();
            }
        }
        else
        {
            string type = tokens[0];
            string name = tokens[1];
            int age = int.Parse(tokens[2]);
            double experience = double.Parse(tokens[3]);
            double endurance = double.Parse(tokens[4]);
            var soldier = soldierFactory.CreateSoldier(type,name,age,experience,endurance);
            bool result = this.wareHouse.TryEquipSoldier(soldier);
            if(result == false)
            {
                this.writer.StoreMessage(string.Format(OutputMessages.NoWeaponForSoldier, soldier.GetType().Name, soldier.Name));
            }
            else
            {
                this.army.AddSoldier(soldier);
            }
        }
    }

    private const string Results = "Results:";
    private const string SuccessfulMissions = "Successful missions - {0}";
    private const string FailedMissions = "Failed missions - {0}";
    private const string Soldiers = "Soldiers:";

    public void GenerateReport()
    {
        this.writer.StoreMessage(Results);
        this.writer.StoreMessage(string.Format(SuccessfulMissions,this.missionControllerField.SuccessMissionCounter));
        this.missionControllerField.FailMissionsOnHold();
        this.writer.StoreMessage(string.Format(FailedMissions,this.missionControllerField.FailedMissionCounter));
        this.writer.StoreMessage(Soldiers);

        foreach (var item in this.army.Soldiers.OrderByDescending(x=>x.OverallSkill))
        {
            this.writer.StoreMessage(item.ToString());
        }
    }
}