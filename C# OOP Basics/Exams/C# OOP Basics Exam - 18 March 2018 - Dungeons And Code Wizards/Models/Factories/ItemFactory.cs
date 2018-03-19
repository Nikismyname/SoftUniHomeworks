using DungeonsAndCodeWizards.Models.Items;
using System;
using System.Collections.Generic;
using System.Text;

namespace DungeonsAndCodeWizards.Models.Factories
{
    class ItemFactory
    {
        public Item CreateItem(string name)
        {
            switch (name)
            {
                case "ArmorRepairKit":
                    return new ArmorRepairKit();
                case "PoisonPotion":
                    return new PoisonPotion();
                case "HealthPotion":
                    return new HealthPotion();
            }

            throw new ArgumentException($"Invalid item type \"{name}\"!");
        }
    }
}
