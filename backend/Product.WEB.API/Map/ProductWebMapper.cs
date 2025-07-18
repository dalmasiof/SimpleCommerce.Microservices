using Product.Domain.DTOs;
using Product.WEB.API.Interfaces;
using Product.WEB.API.Request;
using Product.WEB.API.Response;

public class ProductWebMapper : IProductWebMapper
{
    public ProductDTO ToDto(ProductRequest request)
    {
        return new ProductDTO()
        {
            Name = request.Name,
            Description = request.Description,
            Price = request.Price,
            StockQuantity = request.StockQuantity
        };
    }

    public ProductResponse ToResponse(ProductDTO dto)
    {
        return new ProductResponse()
        {
            Name = dto.Name,
            Description = dto.Description,
            Price = dto.Price,
            StockQuantity = dto.StockQuantity
        };
    }
}
