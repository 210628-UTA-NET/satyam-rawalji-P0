using System;
using System.Collections.Generic;
using StoreAppModels;
using StoreAppDL.Entities;
using System.Linq;

namespace StoreAppDL {
    public class Repository : IRepository {
        private satyamdbContext _context;
        public Repository(satyamdbContext p_context) {
            // dependency injection
            _context = p_context;
        }
        public StoreAppModels.Customer AddCustomer(StoreAppModels.Customer p_customer) {
            _context.Customers.Add(new StoreAppDL.Entities.Customer{
                CName = p_customer.Name,
                CAddress = p_customer.Address,
                CEmail = p_customer.Email,
                CPhoneNumber = p_customer.PhoneNumber
            });
            _context.SaveChanges();
            return p_customer;
        }

        public StoreAppModels.Customer SearchCustomer(string userEntry) {
            StoreAppModels.Customer queryCustomer = new StoreAppModels.Customer();
            var customer = _context.Customers.Single(person => person.CName == userEntry);
            queryCustomer.Name = customer.CName;
            queryCustomer.Email = customer.CEmail;
            queryCustomer.Address = customer.CAddress;
            queryCustomer.PhoneNumber = customer.CPhoneNumber;

            return queryCustomer;
        }
    }
}