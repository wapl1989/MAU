using Service.Dtos;

namespace Service.Interfaces
{
    public interface IOwnerService
    {
        public Task<bool> CreateOwner(OwnerDto owner);
    }
}
