using System;

namespace StoreAppUI {
    public class FactoryMenu : IFactoryMenu {
        public IConsoleMenu GetMenu(MenuType _menu) {
            switch(_menu) {
                case MenuType.MainMenu:
                    return new MainMenu();
                case MenuType.CustomerMenu:
                    return new CustomerMenu();
                /*case MenuType.AddCustomerMenu:
                    return new AddCustomerMenu();*/
                default:
                    return null;
            }
        }
    }
}