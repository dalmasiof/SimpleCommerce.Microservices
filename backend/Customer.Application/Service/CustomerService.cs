using Customer.Application.Interfaces;
using Customer.Application.Map;
using Customer.Infra.Interfaces;

namespace Customer.Application.Service
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly ICustomerMapper _mapper;

        public CustomerService(ICustomerRepository customerRepository, ICustomerMapper mapper)
        {
            _customerRepository = customerRepository;
            _mapper = mapper;
        }

        public async Task<CustomerDTO> Create(CustomerDTO dto)
        {
            var entity = _mapper.ToEntity(dto);
            
            await _customerRepository.Create(entity);

            dto = _mapper.ToDto(entity);

            return dto;
        }

        public async Task<bool> Delete(Guid guid)
        {
            return await _customerRepository.Delete(guid);
        }

        public async Task<IList<CustomerDTO>> GetAll()
        {
            var customers = await _customerRepository.GetAll();
            return customers.Select(x => new CustomerDTO
            {
                Email = x.Email,
                FullName = x.FullName
            }).ToList();
        }

        public async Task<CustomerDTO> GetById(Guid guid)
        {
            var customers = await _customerRepository.GetById(guid);
            return _mapper.ToDto(customers);
        }

        public async Task<CustomerDTO> Update(CustomerDTO dto)
        {
            var entity = _mapper.ToEntity(dto);
            await _customerRepository.Create(entity);

            dto = _mapper.ToDto(entity);
            return dto;
        }
    }
}
