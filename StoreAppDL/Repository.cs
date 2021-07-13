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
            // placeholder 
            /*return _context.LineItems
                .Join(
                    _context.Products,
                    lineitem => lineitem.LPId,
                    products => products.PId,
                    (lineitem, products) => new {
                        LineItemId = lineitem.LId,
                        ProductName = products.PName,
                        ProductPrice = products.PPrice,
                        LineItemQuantity = lineitem.LQuantity,
                        LineItemStoreId = lineitem.LSId
                    }
                ).Join(
                    _context.StoreFronts,
                    lineitem => lineitem.LineItemStoreId,
                    storefront => storefront.SId,
                    (lineitem, storefront) => new {
                        LineItemId = lineitem.LineItemId,
                        LineItemQuantity = lineitem.LineItemQuantity,
                        LineItemStoreId = lineitem.LineItemStoreId,
                        StoreFrontName = storefront.SName
                    }
                ).Select(
                    inventory => new StoreAppModels.LineItem() {
                        LId = inventory.LineItemId,
                        LSId = (int)inventory.LineItemStoreId,
                        Quantity = inventory.LineItemQuantity,
                        Price = 
                    }
                )*/
            return /*((List<StoreAppModels.LineItem>)*/(from li in _context.LineItems
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
    }
}