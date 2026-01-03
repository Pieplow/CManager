
using CManager.Core.Models;
using CManager.Infrastructure.Interfaces;
using System.Diagnostics;
using System.Text.Json;

namespace CManager.Infrastructure
{
    public class JsonFormatter : IJsonFormatter
    {
        private readonly string _filePath;

        public JsonFormatter()
        {
            _filePath = Path.Combine(
                AppContext.BaseDirectory,
                "data/customers.json");
        }

        /// <summary>
        /// Loads a list of customers from the file specified by the current file path.
        /// </summary>
        /// <remarks>If the file is missing or contains invalid or empty data, the method returns an empty
        /// list rather than throwing an exception. The returned list will never be null.</remarks>
        /// <returns>A list of <see cref="Customer"/> objects deserialized from the file. Returns an empty list if the file does
        /// not exist or contains no customers.</returns>
        public List<Customer> LoadCustomersFromFile()
        {
            if (!File.Exists(_filePath))
                return new List<Customer>();

            string json = File.ReadAllText(_filePath);

            return JsonSerializer.Deserialize<List<Customer>>(json)
                ?? new List<Customer>();
        }

        /// <summary>
        /// Saves the specified list of customers to a file in JSON format, overwriting any existing content.
        /// Creates the directory if it does not exist.
        /// </summary>
        /// <remarks>The file is written using indented JSON formatting for readability. If the file already
        /// exists at the configured path, its contents will be replaced.</remarks>
        /// <param name="customers">The list of customers to be saved. Cannot be null.</param>
        public bool SaveCustomersToFile(List<Customer> customers)
        {
            string directory = Path.GetDirectoryName(_filePath)!;

            if (!Directory.Exists(directory))
            {
                Directory.CreateDirectory(directory);
            }

            string json = JsonSerializer.Serialize(customers, new JsonSerializerOptions
            {
                WriteIndented = true
            });

            try
            {
                File.WriteAllText(_filePath, json);
                return true;
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Failed to save customers to file. Error: ", ex.InnerException);
                return false;
            }
        }
    }
}
