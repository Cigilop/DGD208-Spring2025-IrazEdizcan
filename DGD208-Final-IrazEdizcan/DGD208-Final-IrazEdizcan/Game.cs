using DGD208_Final_IrazEdizcan;
using System;

namespace DGD208_Final_IrazEdizcan
{
    public class Game
    {
        private Pets pet;

        public void ShowMenu()
        {
            bool running = true;

            while (running)
            {
                Console.Clear();
                Console.WriteLine("=== Welcome to the Adopt a Pet game! ===");
                Console.WriteLine("1. Start the Game");
                Console.WriteLine("2. Select a Pet");
                Console.WriteLine("3. Shop");
                Console.WriteLine("4. View Pet Stats");
                Console.WriteLine("5. View Inventory");
                Console.WriteLine("6. Credits");
                Console.WriteLine("7. Exit");
                Console.Write("Please enter your choice: ");

                string input = Console.ReadLine();

                switch (input)
                {
                    case "1":
                        StartGame();
                        break;
                    case "2":
                        ChoosePetType();
                        break;
                    case "3":
                        OpenShop();
                        break;
                    case "4":
                        ShowPetStats();
                        break;
                    case "5":
                        ShowInventory();
                        break;
                    case "6":
                        Credits.Show();
                        break;
                    case "7":
                        running = false;
                        Console.WriteLine("You decided to leave. I hope we will see you again!");
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please press Enter to continue and type correctly.");
                        Console.ReadLine();
                        break;
                }
            }
        }

        private void StartGame()
        {
            if (pet == null)
            {
                Console.WriteLine("You need to choose a pet before starting the game.");
                Console.WriteLine("Press Enter to return to the menu.");
                Console.ReadLine();
                return;
            }

            Console.WriteLine($"Starting the game with your {pet.Type}...");
            Console.WriteLine("Press Enter to continue...");
            Console.ReadLine();
        }

        private void ChoosePetType()
        {
            Console.Clear();
            while (true)
            {
                Console.WriteLine("Select a Pet Type:");
                Console.WriteLine("1. Dog");
                Console.WriteLine("2. Cat");
                Console.WriteLine("3. Parrot");
                Console.Write("Please enter your choice: ");
                string input = Console.ReadLine();

                switch (input)
                {
                    case "1":
                        pet = new Dog();
                        break;
                    case "2":
                        pet = new Cat();
                        break;
                    case "3":
                        pet = new Parrot();
                        break;
                    default:
                        Console.WriteLine("Invalid input. Please select again.\n");
                        continue;
                }

                Console.WriteLine($"You chose: {pet.Type}");
                Console.WriteLine("Press Enter to return to the menu.");
                Console.ReadLine();
                break;
            }
        }

        private void OpenShop()
        {
            Console.WriteLine("Shop is not yet implemented. Press Enter to return.");
            Console.ReadLine();
        }

        private void ShowPetStats()
        {
            Console.Clear();
            Console.WriteLine("=== Pet Personalities and Stats ===\n");

            Console.WriteLine("Dog:");
            Console.WriteLine("Personality: Loyal and happy.");
            Console.WriteLine("Hunger: 100");
            Console.WriteLine("Happiness: 120");
            Console.WriteLine("Energy: 110");
            Console.WriteLine("Hygiene: 90");
            Console.WriteLine();

            Console.WriteLine("Cat:");
            Console.WriteLine("Personality: Grumpy but secretly loves you.");
            Console.WriteLine("Hunger: 100");
            Console.WriteLine("Happiness: 80");
            Console.WriteLine("Energy: 90");
            Console.WriteLine("Hygiene: 90");
            Console.WriteLine();

            Console.WriteLine("Parrot:");
            Console.WriteLine("Personality: Weird and talkative.");
            Console.WriteLine("Hunger: 70");
            Console.WriteLine("Happiness: 100");
            Console.WriteLine("Energy: 100");
            Console.WriteLine("Hygiene: 80");
            Console.WriteLine();

            Console.WriteLine("Press Enter to return to the main menu.");
            Console.ReadLine();
        }


        private void ShowInventory()
        {
            Console.WriteLine("Inventory is not yet implemented. Press Enter to return.");
            Console.ReadLine();
        }
    }
}
