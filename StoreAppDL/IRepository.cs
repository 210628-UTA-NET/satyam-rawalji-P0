﻿using System;
using System.Collections.Generic;
using StoreAppModels;

namespace StoreAppDL
{
    public interface IRepository {
        List<Customer> GetAllCustomers();
        Customer AddCustomer(Customer _customer);
    }    
}