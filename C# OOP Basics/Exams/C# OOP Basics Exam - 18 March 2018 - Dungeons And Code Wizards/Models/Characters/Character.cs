using DungeonsAndCodeWizards.Models.Bags;
using DungeonsAndCodeWizards.Models.Enums;
using DungeonsAndCodeWizards.Models.Items;
using System;
using System.Collections.Generic;
using System.Text;

namespace DungeonsAndCodeWizards.Models.Characters
{
    public abstract class Character
    {
        private string name;
        private double health;
        private double armor;

        protected Character(string name, double health, double armor, double abilityPoints, Bag bag, Faction faction)
        {
            this.Name = name;
            this.BaseHealth = health;
            this.Health = health;
            this.BaseArmor = armor;
            this.Armor = armor;
            this.AbilityPoints = abilityPoints;
            this.Bag = bag;
            this.Faction = faction;
            this.IsAlive = true;
        }

        public string  Name
        {
            get { return name; }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("Parameter Error: Name cannot be null or whitespace!");

                name = value;
            }
        }

        public double BaseHealth { get; }

        //mins out at 0 ????
        public double Health
        {
            get => this.health;
            private set
            {
                if (value > this.BaseHealth)
                {
                    this.health = this.BaseHealth;
                }
                else if(value < 0)
                {
                    this.health = 0;
                }
                else
                {
                    this.health = value;
                }
            }
        }

        public double BaseArmor { get; }

        public double Armor 
        {
            get => this.armor;
            private set
            {
                if (value > this.BaseArmor)
                {
                    this.armor = this.BaseArmor;
                }
                else if (value < 0)
                {
                    this.armor = 0;
                }
                else
                {
                    this.armor = value;
                }
            }
        }

        public double AbilityPoints { get; }

        public Bag Bag { get; }

        public bool IsAlive { get; private set; }

        public Faction Faction { get; }

        public virtual double RestHealMultiplier => 0.2;

        public void TakeDamage(double hitPoints)
        {
            if (this.IsAlive == false)
                throw new InvalidOperationException("Invalid Operation: Must be alive to perform this action!");

            if(hitPoints<= this.Armor)
            {
                this.Armor -= hitPoints;
            }
            else
            {
                var extraDemage = hitPoints - this.Armor;
                this.Armor = 0;
                this.Health -= extraDemage;
            }

            if(this.Health == 0)
                this.IsAlive = false;
        }

        public void Rest()
        {
            if (this.IsAlive == false)
                throw new InvalidOperationException("Invalid Operation: Must be alive to perform this action!");

            this.Health += this.RestHealMultiplier * this.BaseHealth;
        }

        public void UseItem(Item item)
        {
            if (this.IsAlive == false)
                throw new InvalidOperationException("Invalid Operation: Must be alive to perform this action!");

            item.AffectCharacter(this);
        }

        public void UseItemOn(Item item, Character character)
        {
            if (this.IsAlive == false)
                throw new InvalidOperationException("Invalid Operation: Must be alive to perform this action!");

            if (character.IsAlive == false)
                throw new InvalidOperationException("Invalid Operation: Must be alive to perform this action!");

            item.AffectCharacter(character);
        }

        public void GiveCharacterItem(Item item, Character character)
        {
            if (this.IsAlive == false)
                throw new InvalidOperationException("Invalid Operation: Must be alive to perform this action!");

            if (character.IsAlive == false)
                throw new InvalidOperationException("Invalid Operation: Must be alive to perform this action!");

            //maybe recieve here
            character.ReceiveItem(item);
        }

        public void ReceiveItem(Item item)
        {
            if (this.IsAlive == false)
                throw new InvalidOperationException("Invalid Operation: Must be alive to perform this action!");

            this.Bag.AddItem(item);
        }

        public void RecieveHeal(double amount)
        {
            this.health += amount;
        }

        public void RepairArmour()
        {
            this.Armor = this.BaseArmor;
        }

        public void DrinkPoisonPotion()
        {
            this.Health -= 20;
            if (this.Health == 0)
            {
                this.IsAlive = false;
            }
        }

        public override string ToString()
        {
            var status = this.IsAlive ? "Alive" : "Dead";
            return $"{this.Name} - HP: {this.Health}/{this.BaseHealth}, AP: {this.Armor}/{this.BaseArmor}, Status: {status}";
        }
    }
}
