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
            /*Console.WriteLine("[1] Name - " + _customer.Name);
            Console.WriteLine("[2] Address - " + _customer.Address);
            Console.WriteLine("[3] Email - " + _customer.Email);
            Console.WriteLine("[4] Phone Number - " + _customer.PhoneNumber);
            Console.WriteLine("[5] Finalize Adding Customer");
            Console.WriteLine("[0] Go back to Main Menu");*/
        }

        public MenuType UserChoice() {
            // current placeholder for now
            return MenuType.MainMenu;
        }
    }
}