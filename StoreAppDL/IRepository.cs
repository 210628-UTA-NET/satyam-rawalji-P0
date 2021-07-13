using System;
using System.Collections.Generic;
using StoreAppModels;

namespace StoreAppDL
{
    public interface IRepository {
        Customer AddCustomer(Customer _customer);

        Customer SearchCustomer(string userEntry1, string userEntry2);

        Order PlaceOrder(string _customerName, string _customerEmail, int _storeID, double _total);

        List<LineItem> SearchStore(string _storeName);

        List<LineItem> ReplenishStore(List<LineItem> _replenishStore);

        List<Order> SearchStoreOrders(string _storeName);

        List<Order> SearchCustomerOrders(string _customerName, string _customerEmail);
    }    
}
