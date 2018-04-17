using System.Collections.Generic;
using System.Text;


public class SpecialForce : Soldier
{
    private const int BaseRegeneration = 30;

    protected override IReadOnlyList<string> WeaponsAllowed => weaponsAllowed;
    private const double OverallSkillMiltiplier = 3.5;
    private readonly List<string> weaponsAllowed = new List<string>
        {
            nameof(Gun),
            nameof(AutomaticMachine),
            nameof(MachineGun),
            nameof(RPG),
            nameof(Helmet),
            nameof(Knife),
            nameof(NightVision)
        };

    public SpecialForce(string name, int age, double experience, double endurance)
        : base(name, age, experience, endurance)
    {
    }

    public override double OverallSkill => base.OverallSkill * OverallSkillMiltiplier;

    public override void Regenerate()
    {
        this.Endurance += this.Age + BaseRegeneration;
    }
}