namespace Purchase.Application.DTO_s
{
    public class PurchaseDTO
    {
        public Guid Id { get; set; }
        public Guid CustomerId { get; private set; }
        public Guid ProductId { get; private set; }
        public int Quantity { get; private set; }
        public decimal UnitPrice { get; private set; }
        public decimal Discount { get; private set; }
        public decimal TotalPrice => Quantity * UnitPrice;
        public decimal FinalPrice => TotalPrice - Discount;

    }
}
