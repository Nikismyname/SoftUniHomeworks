using DungeonsAndCodeWizards.Models.Characters;
using System;
using System.Collections.Generic;
using System.Text;

namespace DungeonsAndCodeWizards.Models.Items
{
    public abstract class Item
    {
        protected Item(int weight)
        {
            this.Weight = weight;
        }

        public int Weight { get; }

        public string Name { get; protected set; }

        public virtual void AffectCharacter(Character character)
        {
            if (character.IsAlive == false)
                throw new InvalidOperationException("Invalid Operation: Must be alive to perform this action!");
        }
    }
}
