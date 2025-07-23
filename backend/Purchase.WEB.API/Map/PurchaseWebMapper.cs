using Purchase.Application.DTO_s;
using Purchase.WEB.API.Interfaces;
using Purchase.WEB.API.Request;
using Purchase.WEB.API.Response;

public class PurchaseWebMapper : IPurchaseWebMapper
{
    public PurchaseDTO ToDto(PurchaseRequest request)
    {
        return new PurchaseDTO()
        {
            CustomerId= request.ClientGuid,
            ProductId = request.ProductGuid,
            Quantity = request.Quantity,
            UnitPrice = request.UnitPrice,
            Discount = request.Discount
        };
    }

    public PurchaseResponse ToResponse(PurchaseDTO dto)
    {
        return new PurchaseResponse()
        {
            Guid = dto.Id,
            ClientGuid = dto.CustomerId,
            ProductGuid = dto.ProductId,
            Quantity = dto.Quantity,
            TotalPrice = dto.TotalPrice
        };
    }
}
