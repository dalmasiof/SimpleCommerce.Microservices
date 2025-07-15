using Customer.Domain.Interfaces;
using Customer.WEB.API;
using Microsoft.AspNetCore.Mvc;

namespace Customer.Service.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerRepository customerRepository;
        public CustomerController(ICustomerRepository customerRepository)
        {
            this.customerRepository = customerRepository;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await customerRepository.Get());
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CustomerDto customerDto)
        {
            Customer.Domain.Entities.Customer entity = new Domain.Entities.Customer(customerDto.FullName, customerDto.Email);

            return Ok(await customerRepository.Create(entity));
        }
    }
}
