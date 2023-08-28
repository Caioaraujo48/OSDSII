using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OsDsII.api.data;
using OsDsII.api.Models;

namespace OsDsII.api.Controllers
{
    [ApiController]
    [Route("Controller")]
    public class CustomersController : ControllerBase
    {
        private readonly DataContext _context;
        public CustomersController(DataContext context)
        {
            //Inicialização do atributo a partir de um parâmetro          
            _context = context;
        }
        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                List<Customer> lista = await _context.Customers.ToListAsync();
                return Ok(lista);
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                Customer customer = await _context.Customers.FirstOrDefaultAsync(pBusca => pBusca.Id == id);

                return Ok(customer);
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Customer novoCustomer)
        {
            try 
            {
                Customer currentCustomer = await _context.Customers.FirstOrDefaultAsync(p => p.Id == novoCustomer.Id);

                if (currentCustomer != null && currentCustomer.Equals(novoCustomer))
                  throw new Exception("Usuário já existe");

                await _context.Customers.AddAsync(novoCustomer);
                await _context.SaveChangesAsync();

                return Ok(novoCustomer.Id);
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                 Customer customerRmv = await _context.Customers.FirstOrDefaultAsync(customerRmv => customerRmv.Id == id);

                _context.Customers.Remove(customerRmv);
                int linhaAfetadas = await _context.SaveChangesAsync();
                return Ok(linhaAfetadas);
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);                
            }
        }
        [HttpPut]
        public async Task<IActionResult> Update(Customer novoCustomer)
        {
            try
            {

                _context.Customers.Update(novoCustomer);
                int linhasAfetadas = await _context.SaveChangesAsync();

                return Ok(linhasAfetadas);
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}