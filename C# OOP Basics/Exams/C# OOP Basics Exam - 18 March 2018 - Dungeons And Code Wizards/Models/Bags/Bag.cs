using DungeonsAndCodeWizards.Models.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DungeonsAndCodeWizards.Models.Bags
{
    public abstract class Bag
    {
        protected Bag(int capacity)
        {
            this.Capacity = capacity;
            this.Items = new List<Item>(); 
        }

        public int Capacity { get;} // default 100 

        public int Load =>this.Items.Count == 0? 0 : this.Items.Sum(x=>x.Weight);

        //which kind of readonly ??
        List<Item> Items { get; }

        public void AddItem(Item item)
        {
            if(this.Load + item.Weight > this.Capacity)
            {
                throw new InvalidOperationException("Invalid Operation: Bag is full!");
            }

            this.Items.Add(item);
        }

        public Item GetItem(string name)
        {
            if(this.Items.Count == 0)
                throw new InvalidOperationException("Invalid Operation: Bag is empty!");

            //not sure if this is the idea
            if (!this.Items.Select(x => x.GetType().Name).Contains(name))
            {
                throw new ArgumentException($"Parameter Error: No item with name {name} in bag!");
            }

            var item = this.Items.FirstOrDefault(x=>x.GetType().Name == name);
            this.Items.Remove(item);
            return item;
        }
    }
}
