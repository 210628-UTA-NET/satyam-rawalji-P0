using System;
using System.Collections.Generic;
using StoreAppBL;
using StoreAppModels;

namespace StoreAppUI {
    public class SearchCustomerOrderHistoryMenu : IConsoleMenu {
        private ICustomerBL _customerBL;
        public SearchCustomerOrderHistoryMenu(ICustomerBL p_customerBL) {
            _customerBL = p_customerBL;
        }
        public void ConsoleMenu() {
            Console.WriteLine("Welcome to the Search Customer Order Menu!");
            Console.WriteLine("What would you like to do?");
            Console.WriteLine("[1] Search for orders by customer name and email");
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
                    
                    // try catch not working in this scenario
                    try {
                        List<Order> queryResult = _customerBL.SearchCustomerOrders(queryInput1, queryInput2);
                        Console.WriteLine("Found Customer!");
                        Console.WriteLine("Inventory: \n");
                        foreach(var query in queryResult) {
                            Console.WriteLine("Store: {0}  |  Date: {1}  |  Total purchase price: ${2}", 
                                                query.SName,
                                                query.Date,
                                                query.Total);
                        }
                        Console.WriteLine("Press Enter to go back to Customer Menu");
                        Console.ReadLine();
                        return MenuType.CustomerMenu;
                    }   
                    catch(InvalidOperationException) {
                        Console.WriteLine("Input was not found. Press press enter to try again.");
                        Console.ReadLine();
                        return MenuType.SearchCustomerOrderHistoryMenu;
                    }
                case "0":
                    return MenuType.CustomerMenu;
                default:
                    Console.WriteLine("Input was not valid.");
                    Console.WriteLine("Please press Enter to continue");
                    Console.ReadLine();
                    return MenuType.SearchCustomerOrderHistoryMenu;
            }
        }
    }
}