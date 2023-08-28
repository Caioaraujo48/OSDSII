using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using OsDsII.api.Models;

namespace Services.Customers
{
    public class CustomersService : ICustomersService
    {
        private readonly DataContext _context;
        private readonly ICustomersRepository _customersRepository;

        public CustomersService(DataContext context, ICustomersRepositoy customersRepository)
        {
            _context = context;
            _customersRepository = customersRepository;
        } 

        public async Task<IEnumerable<Customers>> GetAllCustomersAsync()
        {
            IEnumerable<Customers> customers = await _customersRepository.GetAllCustomersAsync();
            return customers;
        }
        public async Task<Customer> GetCustomerByIdAsync(int id)
        {
            Customers customer = await _custumersRepository.GetCustomerByIdAsync(id);
            
            if (customer == null)
            {
                throw new Exception("Not Found");
            }
            return customer;
        }

        public async Task<Customer> CreateCustomerAsync([FromBody] Customer newCustomer)
        {
            Customers currentCustomer = await _custumersRepository.CreateCustomerAsync(newCustomer);

            if (currentCustomer != null)
            {
                throw new Exception("Usuário já existe");
            }
            return newCustomer;
        }

        public async Task<Customers> UpdateCustomerAsync(int id, [FromBody] Customer customer)
        {
            Customers currentCustomer = await _custumersRepository.UpdateCustomerAsync(id, customer);

            if (currentCustomer == null)
            {
                throw new Exception("Not found");
            }
            return customer;
        }

        public async Task<Customer> DeleteCustomerAsync(int id)
        {
            Customers customer = await _custumersRepository.DeleteCustomerAsync(id);

            if (customer == null)
            {
                throw new Exception("Not found");
            }

            return customer;
        }
    }
}