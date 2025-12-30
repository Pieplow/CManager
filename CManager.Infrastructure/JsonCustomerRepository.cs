
using System.Collections.Generic;
using CManager.Core.Interfaces;
using CManager.Core.Models;

namespace CManager.Infrastructure
{
    public class JsonCustomerRepository : ICustomerRepository
    {
        public List<Customer> GetAll()
        {
            throw new NotImplementedException();
        }

        public bool SaveAll(List<Customer> customers)
        {
            throw new NotImplementedException();
        }

    }
}
