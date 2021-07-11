using System;
using System.Collections.Generic;
using StoreAppModels;

namespace StoreAppDL
{
    public interface IRepository {
        Customer AddCustomer(Customer _customer);

        Customer SearchCustomer(string userEntry);
    }    
}
