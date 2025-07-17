using Customer.Application.Interfaces;
using Customer.WEB.API.Interfaces;
using Customer.WEB.API.Requests;
using Microsoft.AspNetCore.Mvc;

namespace Customer.WEB.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService customerService;
        private readonly ICustomerWebMapper customerRequestMapper;
        public CustomerController(ICustomerService customerService, ICustomerWebMapper customerRequestMapper)
        {
            this.customerService = customerService;
            this.customerRequestMapper = customerRequestMapper;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await customerService.GetAll());
        }

        [HttpGet("{guid}")]
        public async Task<IActionResult> Get([FromRoute] Guid guid)
        {
            return Ok(await customerService.GetById(guid));
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CustomerRequest request)
        {            
            var dto = customerRequestMapper.ToDto(request);

            var response = customerRequestMapper.ToResponse(await customerService.Create(dto));

            return Ok(response);
        }

        [HttpPut]
        public async Task<IActionResult> Put([FromBody] CustomerRequest request)
        {
            var dto = customerRequestMapper.ToDto(request);

            var response = customerRequestMapper.ToResponse(await customerService.Update(dto));

            return Ok(response);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete([FromRoute] Guid guid)
        {
            return Ok(await customerService.Delete(guid));
        }
    }
}
