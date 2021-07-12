using System;
using StoreAppModels;
using StoreAppDL;

namespace StoreAppBL {
    public class OrderBL : IOrderBL {
        private IRepository _repository;
        public OrderBL(IRepository p_repository) {
            _repository = p_repository;
        }
        public Order PlaceOrder(Order _order) {
            return _repository.PlaceOrder(_order);
        }
    }
}