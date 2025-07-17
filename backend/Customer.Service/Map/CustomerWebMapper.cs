using Customer.Application;
using Customer.WEB.API.Interfaces;
using Customer.WEB.API.Requests;

namespace Customer.WEB.API.Map
{
    public class CustomerWebMapper : ICustomerWebMapper
    {
        public CustomerDTO ToDto(CustomerRequest dto)
        {
            return new CustomerDTO()
            {
                Email = dto.Email,
                FullName = dto.FullName,
            };
        }

        public CustomerResponse ToResponse(CustomerDTO dto)
        {
            return new CustomerResponse()
            {
                Email = dto.Email,
                FullName = dto.FullName,
            };
        }
    }
}
