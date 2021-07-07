using System;

namespace StoreAppUI {
    public class FactoryMenu : IFactoryMenu {
        public IConsoleMenu GetMenu(MenuType _menu) {
            switch(_menu) {
                default:
                    return null;
            }
        }
    }
}