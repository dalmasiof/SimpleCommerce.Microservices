namespace Purchase.WEB.API.Request
{
    public class PurchaseRequest
    {
        public Guid ClientGuid { get; set; }
        public Guid ProductGuid { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal Discount { get; set; }
    }
}
