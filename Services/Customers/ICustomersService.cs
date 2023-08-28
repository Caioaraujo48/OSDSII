using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OsDsII.api.Models;

namespace Services.Customers
{
    public interface ICustomersServices
    {
        public Task<IEnumerable<Customer>> GetAllCustomersAsync();
        public Task<Customer> GetCustomerByIdAsync(int id);
        public Task<Customer> CreateCustomerAsync([FromBody] Customer newCustomer);
        public Task<Customer> UpdateCustomerAsync(int id, [FromBody] Customer customer);
        public Task<Customer> DeleteCustomerAsync(int id);
    }
}