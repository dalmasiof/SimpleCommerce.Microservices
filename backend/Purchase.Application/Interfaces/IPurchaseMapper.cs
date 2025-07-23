using Purchase.Application.DTO_s;
using Sharedkernel.Interfaces;

namespace Purchase.Application.Interfaces
{
    public interface IPurchaseMapper : IBaseMapper<PurchaseDTO, Purchase.Domain.Entities.Purchase>
    {
    }
}
