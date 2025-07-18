namespace Product.Domain.Entities
{
    public class Product
    {
        public Guid Id { get; private set; }
        public string Name { get; private set; }
        public string Description { get; private set; }
        public decimal Price { get; private set; }
        public int StockQuantity { get; private set; }
        public bool IsActive { get; private set; }

        protected Product() { }

        public Product(string name, string description, decimal price, int stockQuantity)
        {
            Id = Guid.NewGuid();
            SetName(name);
            SetDescription(description);
            SetPrice(price);
            SetStock(stockQuantity);
            Activate();
        }

        public void SetName(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("Product name is required.");
            Name = name;
        }

        public void SetDescription(string description)
        {
            Description = description ?? string.Empty;
        }

        public void SetPrice(decimal price)
        {
            if (price < 0)
                throw new ArgumentException("Price cannot be negative.");
            Price = price;
        }

        public void SetStock(int quantity)
        {
            if (quantity < 0)
                throw new ArgumentException("Stock cannot be negative.");
            StockQuantity = quantity;
        }

        public void DebitStock(int quantity)
        {
            if (quantity <= 0)
                throw new ArgumentException("Quantity must be positive.");

            if (StockQuantity < quantity)
                throw new InvalidOperationException("Insufficient stock.");

            StockQuantity -= quantity;
        }

        public void ReplenishStock(int quantity)
        {
            if (quantity <= 0)
                throw new ArgumentException("Quantity must be positive.");

            StockQuantity += quantity;
        }

        public void Activate() => IsActive = true;
        public void Deactivate() => IsActive = false;
    }
}
