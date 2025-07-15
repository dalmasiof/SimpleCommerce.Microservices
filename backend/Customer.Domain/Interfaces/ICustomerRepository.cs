namespace Customer.Domain.Interfaces
{
    public interface ICustomerRepository
    {
        Task<Domain.Entities.Customer> Create(Domain.Entities.Customer entity);
        Task<Domain.Entities.Customer> Get(Guid guid);
        Task<IList<Domain.Entities.Customer>> Get();
    }
}
