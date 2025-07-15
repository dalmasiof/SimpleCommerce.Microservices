namespace Customer.Domain.Entities
{
    public class Customer
    {
        public Guid Id { get; private set; }
        public string FullName { get; private set; }
        public string Email { get; private set; }
        public DateTime CreatedAt { get; private set; }
        public DateTime UpdatedAt { get; private set; }
        public bool IsActive { get; private set; }

        protected Customer() { }

        public Customer(string fullName, string email)
        {
            Validate(fullName, email);

            Id = Guid.NewGuid();
            FullName = fullName;
            Email = email;
            CreatedAt = DateTime.UtcNow;
            IsActive = true;
        }

        public void Update_Email(string email) {
            UpdatedAt = DateTime.UtcNow;
        }
        
        public void Delete()
        {
            UpdatedAt = DateTime.UtcNow;
            this.IsActive = false;
        }

        public void Activate()
        {
            UpdatedAt = DateTime.UtcNow;
            this.IsActive = false;
        }

        private void Validate(string fullName, string email)
        {
            if (string.IsNullOrWhiteSpace(fullName))
                throw new ArgumentException("Customer name is required.");

            if (email == null)
                throw new ArgumentException("Customer email is required.");

        }
    }
}
