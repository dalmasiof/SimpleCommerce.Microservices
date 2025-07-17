using Customer.Application;
using Customer.WEB.API.Requests;

namespace Customer.WEB.API.Interfaces
{
    public interface ICustomerWebMapper
    {
        CustomerDTO ToDto(CustomerRequest dto);
        CustomerResponse ToResponse(CustomerDTO entity);
    }
}
