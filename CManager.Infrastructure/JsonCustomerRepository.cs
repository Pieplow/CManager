using System.IO;
using System.Text.Json;
using System.Collections.Generic;
using CManager.Core.Interfaces;
using CManager.Core.Models;

namespace CManager.Infrastructure
{
    public class JsonCustomerRepository : ICustomerRepository
    {
        private readonly string _filePath;
        public JsonCustomerRepository(string filePath = "Data/customers.json")
        {
            _filePath = filePath;
        }
        public List<Customer> GetAll()
        {
            if (!File.Exists(_filePath))
            { 
                
               return new List<Customer>(); 
            
            }
               
            var json = File.ReadAllText(_filePath);
            var customers = System.Text.Json.JsonSerializer.Deserialize<List<Customer>>(json);

            return customers ?? new List<Customer>();

        }

        public bool SaveAll(List<Customer> customers)
        {
            var directory = Path.GetDirectoryName(_filePath);

            if (!string.IsNullOrEmpty(directory) && !Directory.Exists(directory))
            {
                Directory.CreateDirectory(directory);
            }

            var json = System.Text.Json.JsonSerializer.Serialize(customers, new System.Text.Json.JsonSerializerOptions
            {
                WriteIndented = true
            });

            File.WriteAllText(_filePath, json);
            return true;
        }

    }
}
