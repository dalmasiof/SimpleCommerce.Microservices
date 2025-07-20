using Sharedkernel.Interfaces;

namespace Purchase.Infra.Interfaces
{
    public interface IPurchaseRepository : IBaseRepository<Domain.Entities.Purchase>
    {
    }
}
