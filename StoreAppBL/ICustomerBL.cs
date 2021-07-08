using System;
using System.Collections.Generic;
using StoreAppModels;

namespace StoreAppBL
{
    public interface ICustomerBL {
        List<Customer> RetrieveAllCustomers();
        Customer AddCustomer(Customer _customer);
    }
}
