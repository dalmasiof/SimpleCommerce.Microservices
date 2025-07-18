using Product.Application.Interfaces;
using Product.Domain.DTOs;
using Product.Infra.Interfaces;

namespace Product.Application.Service
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        private readonly IProductMapper _mapper;

        public ProductService(IProductRepository productRepository, IProductMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public async Task<ProductDTO> Create(ProductDTO dto)
        {
            var entity = _mapper.ToEntity(dto);
            await _productRepository.Create(entity);
            return _mapper.ToDto(entity);
        }

        public async Task<bool> Delete(Guid id)
        {
            return await _productRepository.Delete(id);
        }

        public async Task<IList<ProductDTO>> GetAll()
        {
            var products = await _productRepository.GetAll();
            return products.Select(_mapper.ToDto).ToList();
        }

        public async Task<ProductDTO> GetById(Guid id)
        {
            var product = await _productRepository.GetById(id);
            return _mapper.ToDto(product);
        }

        public async Task<ProductDTO> Update(ProductDTO dto)
        {
            var entity = _mapper.ToEntity(dto);
            await _productRepository.Update(entity);
            return _mapper.ToDto(entity);
        }
    }
}
