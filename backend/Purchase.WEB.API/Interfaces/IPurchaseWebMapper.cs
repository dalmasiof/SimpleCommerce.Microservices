using Purchase.Application.DTO_s;
using Purchase.WEB.API.Request;
using Purchase.WEB.API.Response;

namespace Purchase.WEB.API.Interfaces
{
    public interface IPurchaseWebMapper
    {
        PurchaseDTO ToDto(PurchaseRequest request);
        PurchaseResponse ToResponse(PurchaseDTO dto);
    }
}
