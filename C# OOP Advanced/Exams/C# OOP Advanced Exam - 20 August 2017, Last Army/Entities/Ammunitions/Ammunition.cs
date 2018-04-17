public abstract class Ammunition : IAmmunition
{
    private const int WearMultiplier = 100;
    protected Ammunition(string Name, double Weight)
    {
        this.Name = Name;
        this.Weight = Weight;
        this.WearLevel = this.Weight * WearMultiplier;
    }

    public string Name { get; }

    public double Weight { get; }

    public double WearLevel { get; private set; }

    public void DecreaseWearLevel(double wearAmount)
    {
        this.WearLevel -= wearAmount;
    }
}

