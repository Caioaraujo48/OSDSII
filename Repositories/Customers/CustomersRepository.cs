using Microsoft.EntityFrameworkCore;
using OsDsII.api.data;
using OsDsII.api.Models;
using OsDsII.api.Repositories.Interfaces;


namespace OsDsII.api.Repositories;
{
    public class CustomersController : ICustomersRepository
    {
        private readonly DataContext _context;

        public CustomersRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<CustomersViewModel> GetAllCustomersAsync()
        {
            IEnumerable<Customer> customers = await _context.Customers.ToListAsync();
            return customers;
        }
        public async Task<Customer> GetCustomerByIdAsync(int id)
        {
            Customer customer = await _context.Customers.FirstOrDefaultAsync(c => c.Id == id);
            return customer;
        }

        public async Task<Customer> CreateCustomerAsync([FromBody] Customer newCustomer)
        {
            Customer currentCustomer = await _context.Customers.FirstOrDefaultAsync(c => c.Id == newCustomer.Id);
            
            _context.Customers.Add(newCustomer);
            await _context.SaveChangesAsync();
            
            return newCustomer;
        }

        public async Task<Customer> UpdateCustomerAsync(int id, [FromBody] Customer customer)
        {
            Customer currentCustomer = await _context.Customers.FirstOrDefaultAsync(customerBusca => customerBusca.Id == id);

            currentCustomer.Name = customer.Name;
            currentCustomer.Email = customer.Email;
            currentCustomer.Phone = customer.Phone;
            await _context.SaveChangesAsync();

            return customer;
        }

        public async Task<Customer> DeleteCustomerAsync(int id)
        {
            Customer customer = await _context.Customers.FirstOrDefaultAsync(c => id == c.Id);

            _context.Customers.Remove(customer);
            await _context.SaveChangesAsync();
            
            return customer;
        }
    }
}