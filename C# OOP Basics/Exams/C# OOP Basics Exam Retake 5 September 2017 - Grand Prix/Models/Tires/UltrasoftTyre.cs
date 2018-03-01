using System;

public class UltrasoftTyre : Tyre
{
    public UltrasoftTyre(double hardness, double grip) : base("Ultrasoft", hardness)
    {
        this.Grip = grip;
    }

    public override double Degradation
    {
        get => base.Degradation;
        protected set
        {
            if (value < 30)
                throw new ArgumentException("Placeholder");
           
            base.Degradation = value;
        }
    }

    public double Grip {get; protected set;}

    public override void Lap()
    {
        this.Degradation -= (this.Hardness + this.Grip); 
    }
}
