using Sharedkernel.Interfaces;

namespace Customer.Infra.Migrations
{
    public interface ICustomerRepository : IBaseRepository<Domain.Entities.Customer>
    {

    }
}
