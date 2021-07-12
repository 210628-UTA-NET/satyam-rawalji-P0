using System;
using StoreAppBL;
using StoreAppModels;

namespace StoreAppUI {
    public class PlaceOrderMenu : IConsoleMenu {
        private static Order _order = new Order();
        private IOrderBL _orderBL;
        public PlaceOrderMenu(IOrderBL p_orderBL) {
            _orderBL = p_orderBL;
        }

        public void ConsoleMenu() {
            Console.WriteLine("Welcome to the Place Order Menu!");
            Console.WriteLine("Please choose an option to get started.");
            Console.WriteLine("[1] Get an order started");
            Console.WriteLine("[0] Go back to Main Menu");
            /*Console.WriteLine("Choose a number to add items to cart");
            Console.WriteLine("[1] Bottle of Thousand Island Dressing - $2.32 - " + _order.Item1);
            Console.WriteLine("[2] Loaf of Rye Bread - $2.69 - " + _order.Item2);
            Console.WriteLine("[3] Jar of Sauerkraut - $2.11 - " + _order.Item3);
            Console.WriteLine("[4] Swiss Cheese slices - $3.39 - " + _order.Item4);
            Console.WriteLine("[5] Pastrami slices - $4.99 - " + _order.Item5);
            Console.WriteLine("[6] Finalize Order");
            Console.WriteLine("[0] Go back to Main Menu");*/
        }

        // switch statement for making an order
        /*
            case "1":
                    Console.WriteLine("Please enter desired quantity: ");
                    _order.Item1 = Convert.ToInt32(Console.ReadLine());
                    return MenuType.PlaceOrderMenu;
                case "2":
                    Console.WriteLine("Please enter desired quantity: ");
                    _order.Item2 = Convert.ToInt32(Console.ReadLine());
                    return MenuType.PlaceOrderMenu;
                case "3":
                    Console.WriteLine("Please enter desired quantity: ");
                    _order.Item3 = Convert.ToInt32(Console.ReadLine());
                    return MenuType.PlaceOrderMenu;
                case "4":
                    Console.WriteLine("Please enter desired quantity: ");
                    _order.Item4 = Convert.ToInt32(Console.ReadLine());
                    return MenuType.PlaceOrderMenu;
                case "5":
                    Console.WriteLine("Please enter desired quantity: ");
                    _order.Item5 = Convert.ToInt32(Console.ReadLine());
                    return MenuType.PlaceOrderMenu;
                case "6":
                    _orderBL.PlaceOrder(_order);
                    return MenuType.MainMenu;
        */

        public MenuType UserChoice() {
            string userInput = Console.ReadLine();
 
            switch(userInput) {
                case "1":
                // placeholder 
                    return MenuType.SearchCustomerMenu;
                case "0":
                    return MenuType.MainMenu;
                default:
                    Console.WriteLine("Input was not valid.");
                    Console.WriteLine("Please press Enter to continue");
                    Console.ReadLine();
                    return MenuType.PlaceOrderMenu;
            }
        }
    }
}