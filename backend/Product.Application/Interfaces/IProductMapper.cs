using Product.Domain.DTOs;
using Sharedkernel.Interfaces;

namespace Product.Application.Interfaces
{
    public interface IProductMapper : IBaseMapper<ProductDTO, Product.Domain.Entities.Product>
    {
    }
}
