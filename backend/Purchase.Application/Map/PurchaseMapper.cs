using Purchase.Application.DTO_s;
using Purchase.Application.Interfaces;

namespace Purchase.Application.Map
{
    public class PurchaseMapper : IPurchaseMapper
    {
        public PurchaseDTO ToDto(Purchase.Domain.Entities.Purchase entity)
        {
            if (entity == null) return null;

            return new PurchaseDTO
            {
                Id = entity.Id,
                CustomerId = entity.CustomerId,
                ProductId = entity.ProductId,
                Quantity = entity.Quantity,
                UnitPrice = entity.UnitPrice,
                Discount = entity.Discount
            };
        }

        public Purchase.Domain.Entities.Purchase ToEntity(PurchaseDTO dto)
        {
            if (dto == null) return null;

            var entity = Purchase.Domain.Entities.Purchase.Create(dto.CustomerId, dto.ProductId, dto.Quantity, dto.UnitPrice);

            return entity;
        }
    }
}
