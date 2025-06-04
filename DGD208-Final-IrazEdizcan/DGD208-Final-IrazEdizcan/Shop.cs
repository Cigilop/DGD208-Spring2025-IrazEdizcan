using System;
using System.Collections.Generic;

namespace Programming2final
{
    public static class Shop
    {
        public static Dictionary<string, int> Items = new Dictionary<string, int>()
        {
            {"Cat Food", 50},
            {"Dog Food", 50},
            {"Parrot Food", 50},
            {"Bed", 70},
            {"Toy", 30}
        };

        public static void ShowShop(PlayerInventory inventory)
        {
            Console.Clear();
            Console.WriteLine("=== Shop ===");
            Console.WriteLine($"Coins: {inventory.Coins}\n");

            int i = 1;
            foreach (var item in Items)
            {
                Console.WriteLine($"{i}. {item.Key} - {item.Value} coins");
                i++;
            }
            Console.WriteLine($"{i}. Exit");

            Console.Write("\nEnter the number of the item you want to buy: ");
            string input = Console.ReadLine();
            if (int.TryParse(input, out int choice) && choice >= 1 && choice <= Items.Count)
            {
                string selectedItem = new List<string>(Items.Keys)[choice - 1];
                int price = Items[selectedItem];

                if (inventory.Coins >= price)
                {
                    inventory.Coins -= price;
                    inventory.AddItem(selectedItem);
                    Console.WriteLine($"You bought: {selectedItem}");
                }
                else
                {
                    Console.WriteLine("Not enough coins.");
                }
            }
            else
            {
                Console.WriteLine("Returning to menu...");
            }

            Console.WriteLine("Press Enter to return to the menu.");
            Console.ReadLine();
        }
    }
}
