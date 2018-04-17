
public class Gun:Ammunition
{
    private const double Weight = 1.4;

    public Gun(string name)
        : base(name, Weight)
    {
    }
}