using Microsoft.AspNetCore.Mvc;
using Purchase.Application.Interfaces;
using Purchase.WEB.API.Interfaces;
using Purchase.WEB.API.Request;

namespace Purchase.WEB.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PurchaseController : ControllerBase
    {
        private readonly IPurchaseService purchaseService;
        private readonly IPurchaseWebMapper purchaseWebMapper;

        public PurchaseController(IPurchaseService purchaseService, IPurchaseWebMapper purchaseWebMapper)
        {
            this.purchaseService = purchaseService;
            this.purchaseWebMapper = purchaseWebMapper;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await purchaseService.GetAll());
        }

        [HttpGet("{guid}")]
        public async Task<IActionResult> Get([FromRoute] Guid guid)
        {
            return Ok(await purchaseService.GetById(guid));
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] PurchaseRequest request)
        {
            var dto = purchaseWebMapper.ToDto(request);
            var response = purchaseWebMapper.ToResponse(await purchaseService.Create(dto));
            return Ok(response);
        }

        [HttpPut]
        public async Task<IActionResult> Put([FromBody] PurchaseRequest request)
        {
            var dto = purchaseWebMapper.ToDto(request);
            var response = purchaseWebMapper.ToResponse(await purchaseService.Update(dto));
            return Ok(response);
        }

        [HttpDelete("{guid}")]
        public async Task<IActionResult> Delete([FromRoute] Guid guid)
        {
            return Ok(await purchaseService.Delete(guid));
        }
    }
}
