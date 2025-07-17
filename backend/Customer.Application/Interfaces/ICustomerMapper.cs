namespace Customer.Application.Interfaces
{
    public interface ICustomerMapper
    {
        Domain.Entities.Customer ToEntity(CustomerDTO dto);
        CustomerDTO ToDto(Domain.Entities.Customer entity);
    }
}
