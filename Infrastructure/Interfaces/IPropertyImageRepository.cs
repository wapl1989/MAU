
namespace Infrastructure.Interfaces
{
    public interface IPropertyImageRepository
    {
        public Task<bool> Create(Domain.Models.PropertyImage propertyImage);
    }
}
