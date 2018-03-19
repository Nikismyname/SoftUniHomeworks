using System;
using System.Collections.Generic;
using System.Text;
using DungeonsAndCodeWizards.Models.Characters;

namespace DungeonsAndCodeWizards.Models.Items
{
    public class HealthPotion : Item
    {
        public HealthPotion() : base(5)
        {
            this.Name = "HealthPotion";
        }

        public override void AffectCharacter(Character character)
        {
            base.AffectCharacter(character);
            character.RecieveHeal(20);
        }
    }
}
