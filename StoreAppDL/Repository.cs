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
                CId = p_customer.CId,
                CName = p_customer.Name,
                CAddress = p_customer.Address,
                CEmail = p_customer.Email,
                CPhoneNumber = p_customer.PhoneNumber
            });
            _context.SaveChanges();
            return p_customer;
        }

        public StoreAppModels.Customer SearchCustomer(string userEntry1, string userEntry2) {
            StoreAppModels.Customer queryCustomer = new StoreAppModels.Customer();
            var customer = _context.Customers.Single(person => person.CName == userEntry1 && person.CEmail == userEntry2);
            queryCustomer.Name = customer.CName;
            queryCustomer.Email = customer.CEmail;
            queryCustomer.Address = customer.CAddress;
            queryCustomer.PhoneNumber = customer.CPhoneNumber;

            return queryCustomer;
        }

        public StoreAppModels.Order PlaceOrder(StoreAppModels.Order p_order) {
            // place holder
            return new StoreAppModels.Order();
        }

        public List<StoreAppModels.LineItem> SearchStore(string _storeName) {
            return (from li in _context.LineItems
                    join p in _context.Products on li.LPId equals p.PId
                    join sf in _context.StoreFronts on li.LSId equals sf.SId
                    where sf.SName == _storeName
                    select new StoreAppModels.LineItem() {
                        LId = li.LId,
                        LSId = (int)li.LSId,
                        Name = p.PName,
                        Price = p.PPrice,
                        Quantity = li.LQuantity
                    }).ToList();
        }

        public List<StoreAppModels.LineItem> ReplenishStore(List<StoreAppModels.LineItem> _replenishStore) {
            foreach(var product in _replenishStore) {
                var item = _context.LineItems.Single(li => li.LId == product.LId);
                item.LQuantity = product.Quantity;
                _context.SaveChanges();
            }
            return _replenishStore;
        }
    }
}