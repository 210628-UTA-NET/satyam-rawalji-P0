using System;
using StoreAppBL;
using StoreAppModels;


namespace StoreAppUI {
    public class SearchCustomerMenu : IConsoleMenu {
        private ICustomerBL _customerBL;
        public SearchCustomerMenu(ICustomerBL p_customerBL) {
            _customerBL = p_customerBL;
        }
        public void ConsoleMenu() {
            Console.WriteLine("Welcome to the Search Customer Menu!");
            Console.WriteLine("What would you like to find a customer by?");
            Console.WriteLine("[1] Search by Name and Email");
            Console.WriteLine("[0] Go back to Customer Menu");
        }

        public MenuType UserChoice() {
            string userInput = Console.ReadLine();

            switch(userInput) {
                case "1":
                    Console.WriteLine();
                    Console.WriteLine("Please enter the customer name: ");
                    string queryInput1 = Console.ReadLine();
                    Console.WriteLine("Please enter the customer email: ");
                    string queryInput2 = Console.ReadLine();
                    Console.WriteLine();
                    try {
                        Customer queryResult = _customerBL.SearchCustomer(queryInput1, queryInput2);
                        Console.WriteLine("Found Customer!");
                        Console.WriteLine("Name: " + queryResult.Name);
                        Console.WriteLine("Address: " + queryResult.Address);
                        Console.WriteLine("Email: " + queryResult.Email);
                        Console.WriteLine("Phone Number: " + queryResult.PhoneNumber);

                        Console.WriteLine("Press Enter to go back to Search Customer Menu");
                        Console.ReadLine();
                        return MenuType.SearchCustomerMenu;
                    }   
                    catch(InvalidOperationException) {
                        Console.WriteLine("Input was not found. Press press enter to try again.");
                        Console.ReadLine();
                        return MenuType.SearchCustomerMenu;
                    }
                case "0":
                    return MenuType.CustomerMenu;
                default:
                    Console.WriteLine("Input was not valid.");
                    Console.WriteLine("Please press Enter to continue");
                    Console.ReadLine();
                    return MenuType.SearchCustomerMenu;
            }
        }
    }
}