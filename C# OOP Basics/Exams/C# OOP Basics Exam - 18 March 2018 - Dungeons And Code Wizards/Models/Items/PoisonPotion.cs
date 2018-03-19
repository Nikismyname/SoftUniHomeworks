using System;
using System.Collections.Generic;
using System.Text;
using DungeonsAndCodeWizards.Models.Characters;

namespace DungeonsAndCodeWizards.Models.Items
{
    public class PoisonPotion : Item
    {
        public PoisonPotion() : base(5)
        {
            this.Name = "PoisonPotion";
        }

        public override void AffectCharacter(Character character)
        {
            base.AffectCharacter(character);

            character.DrinkPoisonPotion();
        }
    }
}
