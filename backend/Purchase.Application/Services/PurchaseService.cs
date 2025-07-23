using Purchase.Application.DTO_s;
using Purchase.Application.Interfaces;
using Purchase.Infra.Interfaces;

namespace Purchase.Application.Service
{
    public class PurchaseService : IPurchaseService
    {
        private readonly IPurchaseRepository _purchaseRepository;
        private readonly IPurchaseMapper _mapper;

        public PurchaseService(IPurchaseRepository purchaseRepository, IPurchaseMapper mapper)
        {
            _purchaseRepository = purchaseRepository;
            _mapper = mapper;
        }

        public async Task<PurchaseDTO> Create(PurchaseDTO dto)
        {
            var entity = _mapper.ToEntity(dto);
            await _purchaseRepository.Create(entity);
            return _mapper.ToDto(entity);
        }

        public async Task<bool> Delete(Guid id)
        {
            return await _purchaseRepository.Delete(id);
        }

        public async Task<IList<PurchaseDTO>> GetAll()
        {
            var purchases = await _purchaseRepository.GetAll();
            return purchases.Select(_mapper.ToDto).ToList();
        }

        public async Task<PurchaseDTO> GetById(Guid id)
        {
            var purchase = await _purchaseRepository.GetById(id);
            return _mapper.ToDto(purchase);
        }

        public async Task<PurchaseDTO> Update(PurchaseDTO dto)
        {
            var entity = _mapper.ToEntity(dto);
            await _purchaseRepository.Update(entity);
            return _mapper.ToDto(entity);
        }
    }
}
