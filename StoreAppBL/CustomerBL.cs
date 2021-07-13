using System;
using System.Collections.Generic;
using StoreAppModels;
using StoreAppDL;

namespace StoreAppBL {
    public class CustomerBL : ICustomerBL {
        private IRepository _repository;
        public CustomerBL(IRepository p_repository) {
            _repository = p_repository;
        }
        public Customer AddCustomer(Customer _customer) {
            return _repository.AddCustomer(_customer);
        }
        
        public Customer SearchCustomer(string userEntry1, string userEntry2) {
            return _repository.SearchCustomer(userEntry1, userEntry2);
        }

        public List<Order> SearchCustomerOrders(string _customerName, string _customerEmail) {
            return _repository.SearchCustomerOrders(_customerName, _customerEmail);
        }
    }
}