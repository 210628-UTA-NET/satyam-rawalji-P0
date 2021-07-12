using System;
using System.Collections.Generic;
using StoreAppModels;

namespace StoreAppBL
{
    public interface ICustomerBL {
        Customer AddCustomer(Customer _customer);

        Customer SearchCustomer(string userEntry1, string userEntry2);
    }
}
