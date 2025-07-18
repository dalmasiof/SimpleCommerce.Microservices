using Sharedkernel.Interfaces;

namespace Product.Infra.Interfaces
{
    public  interface IProductRepository : IBaseRepository<Domain.Entities.Product>
    {
    }
}
