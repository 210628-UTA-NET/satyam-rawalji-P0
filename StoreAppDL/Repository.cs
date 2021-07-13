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

        public StoreAppModels.Order PlaceOrder(string _customerName, string _customerEmail, int _storeID, double _total) {
            var customer = (from c in _context.Customers
                            where c.CName == _customerName && c.CEmail == _customerEmail
                            select new StoreAppModels.Customer() {
                                CId = c.CId
                            }).Single();
            _context.Orders.Add(new StoreAppDL.Entities.Order{
                OCId = customer.CId,
                OSId = _storeID,
                OTotal = _total
            });
            _context.SaveChanges();
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

        public List<StoreAppModels.Order> SearchStoreOrders(string _storeName) {
            return (from sf in _context.StoreFronts
                    join o in _context.Orders on sf.SId equals o.OSId
                    where sf.SName == _storeName
                    select new StoreAppModels.Order() {
                        CId = o.OCId,
                        SId = sf.SId,
                        Total = (double)o.OTotal,
                        Date = (DateTime)o.OOrderDate
                    }).OrderByDescending(date => date.Date)
                    .ToList();
        }

        public List<StoreAppModels.Order> SearchCustomerOrders(string _customerName, string _customerEmail) {
            return (from c in _context.Customers
                    join o in _context.Orders on c.CId equals o.OCId
                    join s in _context.StoreFronts on o.OSId equals s.SId
                    where c.CName == _customerName && c.CEmail == _customerEmail
                    select new StoreAppModels.Order() {
                        CId = o.OCId,
                        SId = o.OSId,
                        SName = s.SName,
                        Total = (double)o.OTotal,
                        Date = (DateTime)o.OOrderDate
                    }).OrderByDescending(date => date.Date)
                    .ToList();
        }
    }
}