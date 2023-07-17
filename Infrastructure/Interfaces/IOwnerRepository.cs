using Domain.Models;

namespace Infrastructure.Interfaces
{
    public interface IOwnerRepository
    {
        public Task<bool> CreateOwner(Owner owner);
    }
}
