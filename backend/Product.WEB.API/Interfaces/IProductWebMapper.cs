using Product.Domain.DTOs;
using Product.WEB.API.Request;
using Product.WEB.API.Response;

namespace Product.WEB.API.Interfaces
{
    public interface IProductWebMapper
    {
        ProductDTO ToDto(ProductRequest dto);
        ProductResponse ToResponse(ProductDTO entity);
    }
}
