using DungeonsAndCodeWizards.Models.Characters;
using DungeonsAndCodeWizards.Models.Contracts;
using DungeonsAndCodeWizards.Models.Enums;
using DungeonsAndCodeWizards.Models.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DungeonsAndCodeWizards.Core
{

    public class DungeonMaster
    {
        private List<Character> party;
        private List<Item> itemPool;
        private int lastSurvivorRounds;

        public DungeonMaster()
        {
            this.party = new List<Character>();
            this.itemPool = new List<Item>();
            this.lastSurvivorRounds = 0;
        }

        public string JoinParty(string[] args)
        {
            var factionStr = args[0];
            if(factionStr != "CSharp" && factionStr != "Java")
            {
                throw new ArgumentException($"Parameter Error: Invalid faction \"{factionStr}\"!");
            }

            var faction = Enum.Parse<Faction>(args[0]);
            var type = args[1];
            var name = args[2];

            var character = GenerateCharacter(faction, type, name);
            this.party.Add(character);

            return $"{name} joined the party!";
        }

        private Character GenerateCharacter(Faction faction, string type, string name)
        {
            switch (type)
            {
                case "Cleric":
                    return new Cleric(name, faction);
                case "Warrior":
                    return new Warrior(name, faction);
            }

            throw new ArgumentException($"Parameter Error: Invalid character type \"{type}\"!"); 
        }

        public string AddItemToPool(string[] args)
        {
            var itemName = args[0];

            if(itemName != "ArmorRepairKit" &&
                itemName != "PoisonPotion" &&
                itemName != "HealthPotion")
            {
                throw new ArgumentException($"Parameter Error: Invalid item \"{itemName}\"!");
            }

            var item = GenerateItem(itemName);
            this.itemPool.Add(item);

            return $"{itemName} added to pool.";
        }

        public Item GenerateItem(string name)
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
            return null;
        }

        public string PickUpItem(string[] args)
        {
            var charName = args[0];
            if (!this.party.Any(x=>x.Name == charName))
            {
                throw new ArgumentException($"Parameter Error: Character {charName} not found!");
            }

            var charr = this.party.First(x => x.Name == charName);

            if (this.itemPool.Count == 0)
            {
                throw new InvalidOperationException("Invalid Operation: No items left in pool!");
            }

            var item = this.itemPool.Last();
            this.itemPool.RemoveAt(this.itemPool.Count-1);
            charr.ReceiveItem(item);

            return $"{charName} picked up {item.GetType().Name}!";
        }

        public string UseItem(string[] args)
        {
            var charName = args[0];
            var itemName = args[1];

            var charr = this.party.FirstOrDefault(x => x.Name == charName);
            if(charr == null)
            {
                throw new ArgumentException($"Parameter Error: Character {charName} not found!");
            }

            var item = charr.Bag.GetItem(itemName);

            charr.UseItem(item);

            return $"{charName} used {itemName}.";
        }

        public string UseItemOn(string[] args)
        {
            var giverName = args[0];
            var receiverName = args[1];
            var itemName = args[2];

            var giver = this.party.FirstOrDefault(x => x.Name == giverName);
            if (giver == null)
            {
                throw new ArgumentException($"Parameter Error: Character {giverName} not found!");
            }

            var reciver = this.party.FirstOrDefault(x => x.Name == receiverName);
            if (reciver == null)
            {
                throw new ArgumentException($"Parameter Error: Character {receiverName} not found!");
            }

            var item = giver.Bag.GetItem(itemName);

            giver.UseItemOn(item,reciver);

            return $"{giverName} used {itemName} on {receiverName}.";
        }

        public string GiveCharacterItem(string[] args)
        {
            var giverName = args[0];
            var receiverName = args[1];
            var itemName = args[2];

            var giver = this.party.FirstOrDefault(x => x.Name == giverName);
            if (giver == null)
            {
                throw new ArgumentException($"Parameter Error: Character {giverName} not found!");
            }

            var reciver = this.party.FirstOrDefault(x => x.Name == receiverName);
            if (reciver == null)
            {
                throw new ArgumentException($"Parameter Error: Character {receiverName} not found!");
            }

            var item = giver.Bag.GetItem(itemName);
            reciver.ReceiveItem(item);

            return $"{giverName} gave {receiverName} {itemName}.";
        }

        public string GetStats()
        {
            var sb = new StringBuilder();

            var toPrint = this.party.OrderByDescending(x => x.IsAlive).ThenByDescending(x => x.Health);
            foreach (var charr in toPrint)
            {
                sb.AppendLine(charr.ToString());
            }

            return sb.ToString().Trim();
        }

        public string Attack(string[] args)
        {
            var attackerName = args[0];
            var receiverName = args[1];

            var attacker = this.party.FirstOrDefault(x => x.Name == attackerName);
            if (attacker == null)
            {
                throw new ArgumentException($"Parameter Error: Character {attackerName} not found!");
            }

            var receiver = this.party.FirstOrDefault(x => x.Name == receiverName);
            if (receiver == null)
            {
                throw new ArgumentException($"Parameter Error: Character {receiverName} not found!");
            }

            if (!(attacker is IAttackable))
            {
                throw new ArgumentException($"Parameter Error: {attacker.Name} cannot attack!");
            }

            var attackable = (IAttackable)attacker;

            attackable.Attack(receiver);

            var sb = new StringBuilder();


            sb.AppendLine($"{attackerName} attacks {receiverName} for {attacker.AbilityPoints} hit points! {receiverName} has {receiver.Health}/{receiver.BaseHealth} HP and {receiver.Armor}/{receiver.BaseArmor} AP left!");
            if(receiver.IsAlive == false)
            {
                sb.AppendLine($"{receiver.Name} is dead!");
            }

            return sb.ToString().Trim();
        }

        public string Heal(string[] args)
        {
            var healerName = args[0];
            var healingReceiverName = args[1];

            var healer = this.party.FirstOrDefault(x => x.Name == healerName);
            if (healer == null)
            {
                throw new ArgumentException($"Parameter Error: Character {healerName} not found!");
            }

            var receiver = this.party.FirstOrDefault(x => x.Name == healingReceiverName);
            if (receiver == null)
            {
                throw new ArgumentException($"Parameter Error: Character {healingReceiverName} not found!");
            }

            if (!(healer is IHealable))
            {
                throw new ArgumentException($"Parameter Error: {healer.Name} cannot heal!");
            }

            var healable = (IHealable)healer;

            healable.Heal(receiver);

            return $"{healer.Name} heals {receiver.Name} for {healer.AbilityPoints}! {receiver.Name} has {receiver.Health} health now!";
        }

        public string EndTurn()
        {
            var sb = new StringBuilder();

            foreach (var charr in this.party.Where(x=>x.IsAlive == true))
            {
                var beforeHealth = charr.Health;
                charr.Rest();
                var afterHealth = charr.Health;
                sb.AppendLine($"{charr.Name} rests ({beforeHealth} => {afterHealth})");
            }

            if (this.party.Where(x=>x.IsAlive == true).Count() <= 1)
            {
                lastSurvivorRounds++;
            }

            return sb.ToString().Trim();
        }

        public bool IsGameOver()
        {
            return (lastSurvivorRounds == 2) ? true : false;
        }
    }
}
