using Service.Dtos;

namespace Service.Interfaces
{
    public interface IPropertyService
    {
        public Task<int> CreateProperty(PropertyDto property);
        public Task<bool> ChangePrice(int propertyId, decimal newPrice);
        public Task<bool> UpdateProperty(int propertyId, PropertyDto updatedProperty);
        public Task<List<PropertyDto>> GetProperties(string? nameFilter, decimal? minPrice, decimal? maxPrice, int? year);
    }
}
