using Programming2final;
using System;
using System.Threading;

namespace DGD208_Final_IrazEdizcan
{
    public class PetBase : IPet
    {
        public string Name { get; private set; }
        public string Type { get; private set; }
        public int Hunger { get; private set; } = 50;
        public int Energy { get; private set; } = 50;
        public int Happiness { get; private set; } = 50;

        private bool isAlive = true;

        public PetBase(string type)
        {
            Type = type;
            Name = $"Your {type}";
        }

        public void StartPetGame(PlayerInventory inventory)
        {
            Console.Clear();
            Console.WriteLine($"You are now playing with your {Type}!");

            Thread statDecreaseThread = new Thread(() =>
            {
                while (isAlive)
                {
                    Thread.Sleep(5000); 
                    Hunger = Math.Max(0, Hunger - 1);
                    Energy = Math.Max(0, Energy - 1);
                    Happiness = Math.Max(0, Happiness - 1);

                    if (Hunger == 0 || Energy == 0 || Happiness == 0)
                    {
                        isAlive = false;
                        Console.WriteLine($"\nYour {Type} has died due to poor care.");
                        Console.WriteLine("Press Enter to return to the menu.");
                        Console.ReadLine();
                    }
                }
            });
            statDecreaseThread.Start();

            while (isAlive)
            {
                Console.Clear();
                Console.WriteLine($"{Type}'s Stats:");
                Console.WriteLine($"Hunger: {Hunger}");
                Console.WriteLine($"Sleep: {Energy}");
                Console.WriteLine($"Fun: {Happiness}");
                Console.WriteLine("Choose an action:");
                Console.WriteLine("1. Feed");
                Console.WriteLine("2. Let Sleep");
                Console.WriteLine("3. Play");
                Console.WriteLine("4. Return to Menu");

                string input = Console.ReadLine();

                switch (input)
                {
                    case "1":
                        UseItem(inventory, "Food", () => Hunger = Math.Min(Hunger + 20, 100));
                        break;
                    case "2":
                        UseItem(inventory, "Bed", () => Energy = Math.Min(Energy + 20, 100));
                        break;
                    case "3":
                        UseItem(inventory, "Toy", () => Happiness = Math.Min(Happiness + 30, 100));
                        break;
                    case "4":
                        isAlive = false;
                        break;
                    default:
                        Console.WriteLine("Press Enter to continue.");
                        Console.ReadLine();
                        break;
                }
            }
        }

        private void UseItem(PlayerInventory inventory, string itemName, Action increaseStat)
        {
            if (inventory.UseItem(itemName))
            {
                Console.WriteLine($"Using {itemName}...");
                Thread.Sleep(2000); 
                increaseStat();
            }
        
            else
            {
                Console.WriteLine($"You don't have any {itemName}. Buy some from the shop!");
                Console.ReadLine();
            }
        }
    }
}

