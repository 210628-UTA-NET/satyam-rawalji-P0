using System;

namespace StoreAppUI {
    public class CustomerMenu : IConsoleMenu {
        public void ConsoleMenu() {
            Console.WriteLine("Welcome to the Store App Customer Menu!");
            Console.WriteLine("What would you like to do?");
            Console.WriteLine("[1] Add a new customer");
            Console.WriteLine("[2] Search for a customer");
            Console.WriteLine("[0] Go back to Main Menu");
        }

        public MenuType UserChoice() {
            string userInput = Console.ReadLine();

            switch(userInput) {
                case "1":
                    return MenuType.AddCustomerMenu;
                case "0":
                    return MenuType.MainMenu;
                default:
                    Console.WriteLine("Input was not valid.");
                    Console.WriteLine("Please press Enter to continue");
                    Console.ReadLine();
                    return MenuType.CustomerMenu;
            }
        }
    }
}