using System;
using System.Collections.Generic;
using StoreAppModels;

namespace StoreAppBL
{
    public interface IStoreFrontBL {
        List<LineItem> SearchStore(string _storeName);

        List<LineItem> ReplenishStore(List<LineItem> _replenishStore);

        List<Order> SearchStoreOrders(string _storeName);
    }
}