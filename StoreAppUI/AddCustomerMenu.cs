using System;
using StoreAppModels;
using StoreAppBL;

// dotnet add reference ..\StoreAppModels\StoreAppModels.csproj
namespace StoreAppUI {
    public class AddCustomerMenu : IConsoleMenu {
        // create customer object to add
        private static Customer _customer = new Customer();
        private ICustomerBL _customerBL;
        public AddCustomerMenu(ICustomerBL p_customerBL) {
            _customerBL = p_customerBL;
        }

        // create customerBL object
        public void ConsoleMenu() {
            Console.WriteLine("Welcome to the Add Customer Menu!");
            Console.WriteLine("[1] Change Name - " + _customer.Name);
            Console.WriteLine("[2] Change Address - " + _customer.Address);
            Console.WriteLine("[3] Change Email - " + _customer.Email);
            Console.WriteLine("[4] Change Phone Number - " + _customer.PhoneNumber);
            Console.WriteLine("[5] Finalize Adding Customer");
            Console.WriteLine("[0] Go back to Main Menu");
        }

        public MenuType UserChoice() {
            string userInput = Console.ReadLine();
 
            switch(userInput) {
                case "1":
                    Console.WriteLine("Please enter a customer name: ");
                    _customer.Name = Console.ReadLine();
                    return MenuType.AddCustomerMenu;
                case "2":
                    Console.WriteLine("Please enter a customer address: ");
                    _customer.Address = Console.ReadLine();
                    return MenuType.AddCustomerMenu;
                case "3":
                    Console.WriteLine("Please enter a customer email: ");
                    _customer.Email = Console.ReadLine();
                    return MenuType.AddCustomerMenu;
                case "4":
                    Console.WriteLine("Please enter a customer phone number: ");
                    _customer.PhoneNumber = Console.ReadLine();
                    return MenuType.AddCustomerMenu;
                case "5":
                    _customerBL.AddCustomer(_customer);
                    return MenuType.CustomerMenu;
                case "0":
                    return MenuType.MainMenu;
                default:
                    Console.WriteLine("Input was not valid.");
                    Console.WriteLine("Please press Enter to continue");
                    Console.ReadLine();
                    return MenuType.AddCustomerMenu;
            }
        }
    }
}