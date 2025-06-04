using DGD208_Final_IrazEdizcan;
using Programming2final;
using System;

namespace DGD208_Final_IrazEdizcan
{
    public class Game
    {
        private IPet pet;
        private PlayerInventory inventory = new PlayerInventory();
        private string selectedPetType = "";


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
            if (string.IsNullOrEmpty(selectedPetType))
            {
                Console.WriteLine("You need to choose a pet before starting the game.");
                Console.WriteLine("Press Enter to return to the menu.");
                Console.ReadLine();
                return;
            }

            Console.Write("Enter a name for your pet: ");
            string petName = Console.ReadLine();

            switch (selectedPetType)
            {
                case "Dog":
                    pet = new Dog(petName);
                    break;
                case "Cat":
                    pet = new Cat(petName);
                    break;
                case "Parrot":
                    pet = new Parrot(petName);
                    break;
            }

            Console.WriteLine($"Starting the game with your {pet.Type} named {petName}...");
            pet.StartPetGame(inventory);
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
                        selectedPetType = "Dog";
                        break;
                    case "2":
                        selectedPetType = "Cat";
                        break;
                    case "3":
                        selectedPetType = "Parrot";
                        break;
                    default:
                        Console.WriteLine("Invalid input. Please select again.\n");
                        continue;
                }

                Console.WriteLine($"You chose: {selectedPetType}");
                Console.WriteLine("Press Enter to return to the menu.");
                Console.ReadLine();
                break;
            }
        }

        private void OpenShop()
        {
            Shop.ShowShop(inventory);
        }

        private void ShowPetStats()
        {
            Console.Clear();
            Console.WriteLine("=== Pet Personalities and Stats ===\n");

            Console.WriteLine("Dog:");
            Console.WriteLine("Personality: Loyal and happy.");
            Console.WriteLine("Max Hunger: 100");
            Console.WriteLine("Max Happiness: 120");
            Console.WriteLine("Max Energy: 110");
            Console.WriteLine();

            Console.WriteLine("Cat:");
            Console.WriteLine("Personality: Grumpy but secretly loves you.");
            Console.WriteLine("Max Hunger: 100");
            Console.WriteLine("Max Happiness: 80");
            Console.WriteLine("Max Energy: 90");
            Console.WriteLine();

            Console.WriteLine("Parrot:");
            Console.WriteLine("Personality: Weird and talkative.");
            Console.WriteLine("Hunger: 70");
            Console.WriteLine("Happiness: 100");
            Console.WriteLine("Energy: 100");
            Console.WriteLine();

            Console.WriteLine("All pets start with 50 with all stats.");

            Console.WriteLine("Press Enter to return to the main menu.");
            Console.ReadLine();
        }


        private void ShowInventory()
        {
            inventory.ShowInventory();
        }
    }
}
