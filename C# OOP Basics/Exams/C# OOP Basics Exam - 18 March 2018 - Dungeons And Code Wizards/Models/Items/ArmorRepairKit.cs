using System;
using System.Collections.Generic;
using System.Text;
using DungeonsAndCodeWizards.Models.Characters;

namespace DungeonsAndCodeWizards.Models.Items
{
    public class ArmorRepairKit : Item
    {
        public ArmorRepairKit() : base(10)
        {
            this.Name = "ArmorRepairKit";
        }

        public override void AffectCharacter(Character character)
        {
            base.AffectCharacter(character);
            character.RepairArmour();
        }
    }
}
