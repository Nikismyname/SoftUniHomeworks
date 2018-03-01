using System;

public abstract class Tyre
{
    private double degradation;

    protected Tyre(string name, double hardness)
    {
        Name = name;
        Hardness = hardness;
        Degradation = 100;
    }

    public string Name { get; protected set; }
    public double Hardness { get; protected set; }

    virtual public double  Degradation
    {
        get => this.degradation;
        protected set
        {
            if (value < 0)
                throw new ArgumentException("placeholder");

            this.degradation = value;
        }
    }

    virtual public void Lap()
    {
        this.Degradation -= this.Hardness;
    }
}

