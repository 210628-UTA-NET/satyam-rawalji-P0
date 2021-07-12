using System;
using StoreAppModels;

namespace StoreAppBL {
    public interface IOrderBL {
        Order PlaceOrder(Order _order);
    }
}