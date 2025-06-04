using System;
using System.Collections.Generic;

namespace Programming2final
{
    public class PlayerInventory
    {
        public int Coins { get; set; } = 200;

        private Dictionary<string, int> items = new Dictionary<string, int>();

        public Dictionary<string, int> GetItems()
        {
            return new Dictionary<string, int>(items); 
        }

        public void AddItem(string itemName)
        {
            if (items.ContainsKey(itemName))
                items[itemName]++;
            else
                items[itemName] = 1;
        }

        public bool HasItem(string itemName)
        {
            return items.ContainsKey(itemName) && items[itemName] > 0;
        }

        public bool UseItem(string itemName)
        {
            if (HasItem(itemName))
            {
                items[itemName]--;
                if (items[itemName] == 0)
                    items.Remove(itemName); 
                return true;
            }
            return false;
        }

        public int GetItemCount(string itemName)
        {
            return items.ContainsKey(itemName) ? items[itemName] : 0;
        }

        public void AddCoins(int amount)
        {
            Coins += amount;
        }

        public bool SpendCoins(int amount)
        {
            if (Coins >= amount)
            {
                Coins -= amount;
                return true;
            }
            return false;
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
