using DGD208_Final_IrazEdizcan;
using Programming2final;
using System;
using System.Threading;

public class Parrot : IPet
{
    public string Name { get; private set; }
    public string Type => "Parrot";
    public int Hunger { get; private set; } = 50;
    public int Energy { get; private set; } = 50;
    public int Happiness { get; private set; } = 50;

    private bool isAlive = true;

    public Parrot(string name)
    {
        Name = name;
    }

    public void StartPetGame(PlayerInventory inventory)
    {
        Console.Clear();
        Console.WriteLine($"You adopted a parrot named {Name}! Weird and talkative.");
        Console.WriteLine("Press Enter to begin caring for your parrot.");
        Console.ReadLine();

        Thread statThread = new Thread(() => DecreaseStatsOverTime());
        statThread.Start();

        while (isAlive)
        {
            Console.Clear();
            Console.WriteLine($"{Name}'s Stats:");
            Console.WriteLine($"Hunger: {Hunger}");
            Console.WriteLine($"Energy: {Energy}");
            Console.WriteLine($"Happiness: {Happiness}\n");

            Console.WriteLine("What would you like to do?");
            Console.WriteLine("1. Feed (uses Parrot Food)");
            Console.WriteLine("2. Let Sleep (uses Bed)");
            Console.WriteLine("3. Play (uses Toy)");
            Console.WriteLine("4. Exit");

            string input = Console.ReadLine();
            switch (input)
            {
                case "1":
                    UseItem(inventory, "Parrot Food", () => Hunger = Math.Min(Hunger + 30, 100));
                    break;
                case "2":
                    UseItem(inventory, "Bed", () => Energy = Math.Min(Energy + 30, 100));
                    break;
                case "3":
                    bool usedToy = TryUseItem(inventory, "Toy", () => Happiness = Math.Min(Happiness + 30, 100));
                    if (usedToy)
                    {
                        inventory.Coins += 100;
                        Console.WriteLine("You earned 100 coins for playing with your pet!");
                        Thread.Sleep(1000);
                    }
                    break;
                case "4":
                    isAlive = false;
                    break;
                default:
                    Console.WriteLine("Invalid input. Press Enter to continue.");
                    Console.ReadLine();
                    break;
            }
        }

        Console.WriteLine("Your parrot has been removed from the game. Press Enter.");
        Console.ReadLine();
    }

    private void DecreaseStatsOverTime()
    {
        while (isAlive)
        {
            Thread.Sleep(3000);
            Hunger = Math.Max(0, Hunger - 1);
            Energy = Math.Max(0, Energy - 1);
            Happiness = Math.Max(0, Happiness - 1);

            if (Hunger == 0 || Energy == 0 || Happiness == 0)
            {
                Console.WriteLine($"{Name} has died due to neglect. :(");
                isAlive = false;
            }
        }
    }

    private void UseItem(PlayerInventory inventory, string itemName, Action applyEffect)
    {
        if (inventory.UseItem(itemName))
        {
            Console.WriteLine($"Using {itemName}...");
            Thread.Sleep(1000);
            applyEffect();
        }
        else
        {
            Console.WriteLine($"You don't have a {itemName}.");
            Console.WriteLine($"Would you like to buy a {itemName} for {Shop.Items[itemName]} coins? (yes/no)");

            string choice = Console.ReadLine()?.Trim().ToLower();
            if (choice == "yes")
            {
                int price = Shop.Items[itemName];

                if (inventory.Coins >= price)
                {
                    inventory.Coins -= price;
                    inventory.AddItem(itemName);
                    Console.WriteLine($"You bought a {itemName}!");

                    Thread.Sleep(1000);

                    Console.WriteLine($"Using {itemName}...");
                    Thread.Sleep(1000);
                    applyEffect();
                }
                else
                {
                    Console.WriteLine("You don't have enough coins to buy that item.");
                    Thread.Sleep(1000);
                }
            }
            else
            {
                Console.WriteLine("Okay, skipping this action. Press Enter to continue.");
                Console.ReadLine();
            }
        }
    }

    private bool TryUseItem(PlayerInventory inventory, string itemName, Action applyEffect)
    {
        if (inventory.UseItem(itemName))
        {
            Console.WriteLine($"Using {itemName}...");
            Thread.Sleep(1000);
            applyEffect();
            return true;
        }
        else
        {
            Console.WriteLine($"You don't have a {itemName}.");
            Console.WriteLine($"Would you like to buy a {itemName} for {Shop.Items[itemName]} coins? (yes/no)");

            string choice = Console.ReadLine()?.Trim().ToLower();
            if (choice == "yes")
            {
                int price = Shop.Items[itemName];

                if (inventory.Coins >= price)
                {
                    inventory.Coins -= price;
                    inventory.AddItem(itemName);
                    Console.WriteLine($"You bought a {itemName}!");

                    Thread.Sleep(1000);
                    Console.WriteLine($"Using {itemName}...");
                    Thread.Sleep(1000);
                    applyEffect();
                    return true;
                }
                else
                {
                    Console.WriteLine("You don't have enough coins to buy that item.");
                    Thread.Sleep(1000);
                }
            }
            else
            {
                Console.WriteLine("Okay, skipping this action. Press Enter to continue.");
                Console.ReadLine();
            }
        }
        return false;
    }


    public void Speak()
    {
        Console.WriteLine("Squawk!");
    }
}
