using System;
using System.IO;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
using StoreAppBL;
using StoreAppDL;
using StoreAppDL.Entities;

namespace StoreAppUI {
    public class FactoryMenu : IFactoryMenu {
        public IConsoleMenu GetMenu(MenuType _menu) {

            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("app_setting.json")
                .Build();

            string connectionString = configuration.GetConnectionString("DBConnString");

            DbContextOptions<satyamdbContext> options = new DbContextOptionsBuilder<satyamdbContext>()
                .UseSqlServer(connectionString)
                .Options;

            switch(_menu) {
                case MenuType.MainMenu:
                    return new MainMenu();
                case MenuType.CustomerMenu:
                    return new CustomerMenu();
                case MenuType.AddCustomerMenu:
                    return new AddCustomerMenu(new CustomerBL(new Repository(new satyamdbContext(options))));
                case MenuType.SearchCustomerMenu:
                    return new SearchCustomerMenu(new CustomerBL(new Repository(new satyamdbContext(options))));
                default:
                    return null;
            }
        }
    }
}