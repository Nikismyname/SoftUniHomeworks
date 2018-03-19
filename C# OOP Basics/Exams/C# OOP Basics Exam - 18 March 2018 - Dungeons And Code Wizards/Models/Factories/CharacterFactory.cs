using DungeonsAndCodeWizards.Models.Characters;
using DungeonsAndCodeWizards.Models.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace DungeonsAndCodeWizards.Models.Factories
{
    public class CharacterFactory
    {

        public Character CreateCharacter(string faction1, string type, string name)
        {
            Faction faction;
            if(!Enum.TryParse(faction1, out faction))
            {
                throw new ArgumentException();
            }

            switch (type)
            {
                case "Cleric":
                    return new Cleric(name, faction);
                case "Warrior":
                    return new Warrior(name, faction);
            }

            throw new ArgumentException($"Invalid character type \"{type}\"!");
        }
    }
}
