using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class Corporal : Soldier
{
    protected override IReadOnlyList<string> WeaponsAllowed => this.weaponsAllowed;
    private const double OverallSkillMiltiplier = 2.5;
    private readonly List<string> weaponsAllowed = new List<string>
        {
            nameof(Gun),
            nameof(AutomaticMachine),
            nameof(MachineGun),
            nameof(Helmet),
            nameof(Knife),
        };
    public  Corporal(string name, int age, double experience, double endurance) : base(name, age, experience, endurance)
    {
    }

    public override double OverallSkill => base.OverallSkill * OverallSkillMiltiplier;
}

