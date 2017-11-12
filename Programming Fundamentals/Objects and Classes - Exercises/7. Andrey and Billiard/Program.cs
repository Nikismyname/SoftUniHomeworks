using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _7.Andrey_and_Billiard
{
    class Program
    {
        /// <summary>
        /// There is a catch here that I don't think is described in the problem. Items from orders should stack.
        /// </summary>
        static void Main()
        {
            var shop = new Dictionary<string, float>();
            var clients  = new List<Client>();

            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                var tokens = Console.ReadLine().Split('-').ToArray();
                shop[tokens[0]] = float.Parse(tokens[1]);
            }

            var input = Console.ReadLine();
            while(input != "end of clients")
            {
                var tokens = input.Split(new char[] { ',', '-' }, StringSplitOptions.None).ToArray();
                var name = tokens[0];
                var item = tokens[1];
                var qtt = int.Parse(tokens[2]);

                if (!shop.ContainsKey(item))
                {
                    input = Console.ReadLine();
                    continue;
                }

                if(!clients.Any(x=>x.name == name))
                {
                    clients.Add(new Client(name));
                }
                var currClient = clients.Single(x => x.name == name);

                if (currClient.orders.Any(x=>x.item == item))
                {
                    currClient.orders.Single(x => x.item == item).qtt += qtt;
                }
                else
                {
                    clients.Single(x => x.name == name).orders.Add(new Order(item, qtt));
                }
                input = Console.ReadLine();
            }
            float allBills = 0;
            foreach (var client in clients.OrderBy(x=>x.name))
            {
                float bill = 0;
                Console.WriteLine(client.name);
                foreach (var item in client.orders)
                {
                    Console.WriteLine($"-- {item.item} - {item.qtt}");
                    bill += item.qtt * shop[item.item];
                }
                Console.WriteLine($"Bill: {bill.ToString("0.00")}");
                allBills += bill;
            }
            Console.WriteLine($"Total bill: {allBills.ToString("0.00")}");

            //Console.ReadLine();
        }
    }

    class Client
    {
        public string name;
        public List<Order> orders = new List<Order>();
        public Client(string Name)
        {
            name = Name;
        }
    }

    class Order
    {
        public string item;
        public int qtt;
        public Order(string Item, int Qtt)
        {
            item = Item;
            qtt = Qtt;
        }
    }
}
