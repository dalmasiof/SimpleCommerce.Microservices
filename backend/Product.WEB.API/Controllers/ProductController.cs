using Microsoft.AspNetCore.Mvc;
using Product.Application.Interfaces;
using Product.WEB.API.Interfaces;
using Product.WEB.API.Request;

namespace Product.WEB.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly IProductService productService;
        private readonly IProductWebMapper productWebMapper;

        public ProductController(IProductService productService, IProductWebMapper productWebMapper)
        {
            this.productService = productService;
            this.productWebMapper = productWebMapper;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await productService.GetAll());
        }

        [HttpGet("{guid}")]
        public async Task<IActionResult> Get([FromRoute] Guid guid)
        {
            return Ok(await productService.GetById(guid));
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] ProductRequest request)
        {
            var dto = productWebMapper.ToDto(request);
            var response = productWebMapper.ToResponse(await productService.Create(dto));
            return Ok(response);
        }

        [HttpPut]
        public async Task<IActionResult> Put([FromBody] ProductRequest request)
        {
            var dto = productWebMapper.ToDto(request);
            var response = productWebMapper.ToResponse(await productService.Update(dto));
            return Ok(response);
        }

        [HttpDelete("{guid}")]
        public async Task<IActionResult> Delete([FromRoute] Guid guid)
        {
            return Ok(await productService.Delete(guid));
        }
    }
}
