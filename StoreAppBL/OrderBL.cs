using System;
using StoreAppModels;
using StoreAppDL;

namespace StoreAppBL {
    public class OrderBL : IOrderBL {
        private IRepository _repository;
        public OrderBL(IRepository p_repository) {
            _repository = p_repository;
        }
        public Order PlaceOrder(string _customerName, string _customerEmail, int _storeID, double _total) {
            return _repository.PlaceOrder(_customerName, _customerEmail, _storeID, _total);
        }
    }
}