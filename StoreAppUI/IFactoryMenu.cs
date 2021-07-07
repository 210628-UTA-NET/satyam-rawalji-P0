namespace StoreAppUI {
    // have interface for factory design menus
    public interface IFactoryMenu {
        IConsoleMenu GetMenu(MenuType _menu);
    }
}