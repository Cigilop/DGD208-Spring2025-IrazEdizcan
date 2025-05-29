using System;
using System.Collections.Generic;

namespace Programming2final
{
    public class PlayerInventory
    {
        public int Coins { get; set; } = 200;
        private Dictionary<string, int> items = new Dictionary<string, int>();

        public void AddItem(string itemName)
        {
            if (items.ContainsKey(itemName))
                items[itemName]++;
            else
                items[itemName] = 1;
        }

        public void ShowInventory()
        {
            Console.Clear();
            Console.WriteLine("=== Inventory ===");
            Console.WriteLine($"Coins: {Coins}\n");

            if (items.Count == 0)
            {
                Console.WriteLine("You have no items.");
            }
            else
            {
                foreach (var item in items)
                {
                    Console.WriteLine($"{item.Key}: {item.Value}");
                }
            }

            Console.WriteLine("\nPress Enter to return.");
            Console.ReadLine();
        }
    }
}
