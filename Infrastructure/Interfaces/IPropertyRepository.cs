using Domain.Models;

namespace Infrastructure.Interfaces
{
    public interface IPropertyRepository
    {
        public Task<int> Create(Property property);

        public Task<Property> GetPropertyById(int propertyId);

        public Task<bool> UpdateProperty(Property property);

        public Task<List<Property>> GetProperties(string? nameFilter, decimal? minPrice, decimal? maxPrice, int? year);
    }
}
