﻿using System;

// dotnet new console -o StoreAppUI (creates project)

// To initialize repo
// git init
// git add .
// git commit -m "First commit" 
// git remote add origin https://github.com/210628-UTA-NET/satyam-rawalji-P0.git
// git branch -M main
// git push -u origin main
namespace StoreAppUI
{
    class Program
    {
        static void Main(string[] args)
        {
            // create main menu object
            IConsoleMenu mainMenu = new MainMenu();
            // use boolean variable to control while loop for menus
            bool switchCase = true;
            // use enum variable to declare current menu choice 
            MenuType currentMenu = MenuType.MainMenu;
            // use factory menu to handle user choices
            IFactoryMenu factoryMenu = new FactoryMenu();

            // use while loop 
            while(switchCase) {
                // always clear Console before choosing a new choice
                Console.Clear();
                mainMenu.ConsoleMenu();
                currentMenu = mainMenu.UserChoice();

                switch(currentMenu) {
                    case MenuType.MainMenu:
                        mainMenu = factoryMenu.GetMenu(MenuType.MainMenu);
                        break;
                    case MenuType.CustomerMenu:
                        mainMenu = factoryMenu.GetMenu(MenuType.CustomerMenu);
                        break;
                    case MenuType.AddCustomerMenu:
                        mainMenu = factoryMenu.GetMenu(MenuType.AddCustomerMenu);
                        break;
                    case MenuType.Exit:
                        Console.WriteLine("Thank you for using the Store App!");
                        switchCase = false;
                        break;
                    default:
                        Console.WriteLine("Invalid input. Please try again.");
                        break;
                }
            }

        }
    }
}
