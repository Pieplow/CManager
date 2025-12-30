using System;
using System.Collections.Generic;
using CManager.Core.Models;

namespace CManager.Core.Interfaces
{
    public interface ICustomerRepository
    {
        List<Customer> GetAll();

        bool SaveAll(List<Customer> customers);
    
    }
}


