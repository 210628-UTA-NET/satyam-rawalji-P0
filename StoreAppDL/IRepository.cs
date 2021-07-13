using System;
using System.Collections.Generic;
using StoreAppModels;

namespace StoreAppDL
{
    public interface IRepository {
        Customer AddCustomer(Customer _customer);

        Customer SearchCustomer(string userEntry1, string userEntry2);

        Order PlaceOrder(Order _order);

        List<LineItem> SearchStore(string _storeName);
    }    
}
