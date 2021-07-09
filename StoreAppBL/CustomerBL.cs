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
        public List<Customer> RetrieveAllCustomers() {
            // placeholder
            return new List<Customer>();
        }

        public Customer AddCustomer(Customer _customer) {
            return _repository.AddCustomer(_customer);
        }

    }
}