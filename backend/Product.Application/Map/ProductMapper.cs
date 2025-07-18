using Product.Application.Interfaces;
using Product.Domain.DTOs;

namespace Product.Application.Map
{
    public class ProductMapper : IProductMapper
    {
        public ProductDTO ToDto(Product.Domain.Entities.Product entity)
        {
            return new ProductDTO
            {
                Id = entity.Id,
                Name = entity.Name,
                Description = entity.Description,
                Price = entity.Price,
                StockQuantity = entity.StockQuantity,
                IsActive = entity.IsActive
            };
        }

        public Product.Domain.Entities.Product ToEntity(ProductDTO dto)
        {
            if (dto == null) return null;

            var entity = new Product.Domain.Entities.Product(dto.Name, dto.Description ?? "", dto.Price, dto.StockQuantity);

            return entity;
        }
    }
}
