using Customer.Application.Interfaces;

namespace Customer.Application.Map
{
    public class CustomerMapper : ICustomerMapper
    {
        public Domain.Entities.Customer ToEntity(CustomerDTO dto)
        {
            return new Domain.Entities.Customer(dto.FullName, dto.Email);
        }

        public CustomerDTO ToDto(Domain.Entities.Customer entity)
        {
            return new CustomerDTO()
            {
                FullName = entity.FullName,
                Email = entity.Email,
            };
        }
    }
}
