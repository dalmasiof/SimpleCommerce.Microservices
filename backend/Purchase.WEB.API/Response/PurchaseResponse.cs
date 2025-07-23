namespace Purchase.WEB.API.Response
{
    public class PurchaseResponse
    {
        public Guid Guid { get; set; }
        public Guid ClientGuid { get; set; }
        public Guid ProductGuid { get; set; }
        public int Quantity { get; set; }
        public decimal TotalPrice { get; set; }
    }
}
