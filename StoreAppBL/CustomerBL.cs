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
        public Customer SearchCustomer(string userEntry) {
            // placeholder
            return _repository.SearchCustomer(userEntry);
        }

        public Customer AddCustomer(Customer _customer) {
            return _repository.AddCustomer(_customer);
        }

    }
}