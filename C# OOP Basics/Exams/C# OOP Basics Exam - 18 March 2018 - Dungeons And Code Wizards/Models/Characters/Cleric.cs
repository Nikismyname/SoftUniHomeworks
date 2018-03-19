using System;
using System.Collections.Generic;
using System.Text;
using DungeonsAndCodeWizards.Models.Bags;
using DungeonsAndCodeWizards.Models.Contracts;
using DungeonsAndCodeWizards.Models.Enums;

namespace DungeonsAndCodeWizards.Models.Characters
{
    public class Cleric : Character, IHealable
    {
        public Cleric(string name, Faction faction) : base(name, 50d, 25d, 40d, new Backpack(), faction)
        {
        }

        public override double RestHealMultiplier => 0.5d;

        public void Heal(Character character)
        {
            if (this.IsAlive == false)
                throw new InvalidOperationException("Invalid Operation: Must be alive to perform this action!");

            if (character.IsAlive == false)
                throw new InvalidOperationException("Invalid Operation: Must be alive to perform this action!");

            if (this.Faction != character.Faction)
                throw new InvalidOperationException("Invalid Operation: Cannot heal enemy character!");

            character.RecieveHeal(this.AbilityPoints);
        }
    }
}
