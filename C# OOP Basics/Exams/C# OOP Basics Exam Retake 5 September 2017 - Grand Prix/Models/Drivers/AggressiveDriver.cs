class AggressiveDriver : Driver
{
    public AggressiveDriver(string name, Car car)
        : base(name, car, 2.7d) { }

    override public double CalculateSpeed()
    {
        return base.CalculateSpeed() * 1.3;
    }
}

