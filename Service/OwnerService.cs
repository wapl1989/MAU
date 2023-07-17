using Infrastructure.Interfaces;
using Service.Dtos;
using Service.Interfaces;

namespace Service
{
    public class OwnerService : IOwnerService
    {
        private readonly IOwnerRepository _ownerRepository;
        public OwnerService(IOwnerRepository ownerRepository)
        {
            _ownerRepository = ownerRepository;
        }
        public async Task<bool> CreateOwner(OwnerDto ownerDto)
        {
            return await _ownerRepository.CreateOwner((Domain.Models.Owner)ownerDto);
        }

    }
}
