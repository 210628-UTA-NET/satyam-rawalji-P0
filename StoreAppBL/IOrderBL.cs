using System;
using StoreAppModels;

namespace StoreAppBL {
    public interface IOrderBL {
        Order PlaceOrder(string _customerName, string _customerEmail, int _storeID, double _total);
    }
}