using Product.Domain.DTOs;
using Sharedkernel.Interfaces;

namespace Product.Application.Interfaces
{
    public interface IProductService : IBaseService<ProductDTO>
    {
    }
}
