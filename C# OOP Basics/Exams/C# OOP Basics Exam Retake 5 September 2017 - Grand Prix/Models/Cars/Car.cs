using System;

public class Car
{
    private const double MAX_FUEL = 160;

    private double fuelAmount;

    public Car( int hp, double fuelAmount, Tyre tyre)
    {
        Hp = hp;
        FuelAmount = fuelAmount;
        Tyre = tyre;
    }

    public Tyre Tyre { get; private set; }
    public int Hp { get; private set; }

    public void ChangeTyre(Tyre tyre)
    {
        this.Tyre = tyre;
    }

    public double FuelAmount
    {
        get => this.fuelAmount;

        protected set
        {
            if (value < 0)
                throw new ArgumentException("Placeholder");

            if (value > MAX_FUEL)
                this.fuelAmount = MAX_FUEL;
            else
                this.fuelAmount = value;
        }
    } 

    public void Refuel(double amount)
    {
        this.FuelAmount += amount;
    }
}

