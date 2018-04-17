public interface IWareHouse
{
    void AddAmmunition(string name, int quantity);

    void EquipArmy(IArmy army);

    bool TryEquipSoldier(ISoldier soldier);
}
