using System;
using System.Collections.Generic;
using System.Text;
using DungeonsAndCodeWizards.Models.Bags;
using DungeonsAndCodeWizards.Models.Contracts;
using DungeonsAndCodeWizards.Models.Enums;

namespace DungeonsAndCodeWizards.Models.Characters
{
    public class Warrior : Character, IAttackable 
    {
        public Warrior(string name, Faction faction) : base(name, 100d, 50d, 40d, new Satchel(), faction)
        {
        }

        public void Attack(Character character)
        {
            if (this.IsAlive == false)
                throw new InvalidOperationException("Invalid Operation: Must be alive to perform this action!");

            if (character.IsAlive == false)
                throw new InvalidOperationException("Invalid Operation: Must be alive to perform this action!");

            //maybe change the check 
            if (this == character)
                throw new InvalidOperationException("Invalid Operation: Cannot attack self!");

            if (this.Faction == character.Faction)
                throw new ArgumentException($"Parameter Error: Friendly fire! Both characters are from {this.Faction} faction!");

            character.TakeDamage(this.AbilityPoints);
        }
    }
}
