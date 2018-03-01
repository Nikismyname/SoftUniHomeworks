using System;

public abstract class Driver
{
    protected Driver(string name, Car car, double fuelConsumptionPerKm)
    {
        Name = name;
        Car = car;
        FuelConsumptionPerKm = fuelConsumptionPerKm;
        TotalTime = 0;
        OutOfRace = false;
    }

    public string Name { get; protected set; }
    public double TotalTime { get; protected set; }
    public Car Car { get; protected set; }
    public double FuelConsumptionPerKm{ get; protected set; }
    public string OutOfRaceReason { get; protected set; }
    public bool OutOfRace { get; protected set; }

    virtual public double CalculateSpeed()
    {
        return (Car.Hp + Car.Tyre.Degradation) / Car.FuelAmount;
    }

    private void GetOutOfRace(string reason)
    {
        this.OutOfRace = true;
        this.OutOfRaceReason = reason;
    }

    public bool RunLap(int trackLength)
    {
        this.TotalTime += 60 / (trackLength / CalculateSpeed());

        try
        {
            this.Car.Refuel( - trackLength * FuelConsumptionPerKm);
        }
        catch
        {
            GetOutOfRace($"Out of fuel");
            return true;
        }

        try
        {
            this.Car.Tyre.Lap();
        }
        catch
        {
            GetOutOfRace($"Blown Tyre");
            return true;
        }

        return false;
    }

    internal void Crash()
    {
        GetOutOfRace($"Crashed");
    }

    public void ChangeTotalTime(double amount)
    {
        this.TotalTime += amount;
    }
}

