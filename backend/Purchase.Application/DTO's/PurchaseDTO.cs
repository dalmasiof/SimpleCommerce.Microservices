namespace Purchase.Application.DTO_s
{
    public class PurchaseDTO
    {
        public Guid Id { get; set; }
        public Guid CustomerId { get; set; }
        public Guid ProductId { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal Discount { get; set; }
        public decimal TotalPrice => Quantity * UnitPrice;
        public decimal FinalPrice => TotalPrice - Discount;
    }
}
