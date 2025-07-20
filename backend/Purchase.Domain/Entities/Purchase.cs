namespace Purchase.Domain.Entities
{
    public class Purchase
    {
        public Guid Id { get; private set; }
        public Guid CustomerId { get; private set; }
        public Guid ProductId { get; private set; }
        public int Quantity { get; private set; }
        public decimal UnitPrice { get; private set; }
        public decimal Discount { get; private set; }
        public decimal TotalPrice => Quantity * UnitPrice;
        public decimal FinalPrice => TotalPrice - Discount;

        private Purchase() { }

        public static Purchase Create(Guid customerId, Guid productId, int quantity, decimal unitPrice)
        {
            if (quantity <= 0)
                throw new ArgumentException("Quantity must be greater than zero.");

            if (unitPrice <= 0)
                throw new ArgumentException("Unit price must be greater than zero.");

            return new Purchase
            {
                Id = Guid.NewGuid(),
                CustomerId = customerId,
                ProductId = productId,
                Quantity = quantity,
                UnitPrice = unitPrice
            };
        }

        public void UpdateQuantity(int quantity)
        {
            if (quantity <= 0)
                throw new ArgumentException("Quantity must be greater than zero.");

            Quantity = quantity;
        }
    }
}
