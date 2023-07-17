using Infrastructure.Interfaces;
using Service.Dtos;
using Service.Interfaces;

namespace Service
{
    public class PropertyService : IPropertyService
    {
        private readonly IPropertyRepository _propertyRepository;
        public PropertyService(IPropertyRepository propertyReposiroty)
        {
            _propertyRepository = propertyReposiroty;
        }

        public async Task<int> CreateProperty(PropertyDto property)
        {
            return await _propertyRepository.Create((Domain.Models.Property)property);
        }

        public async Task<bool> ChangePrice(int propertyId, decimal newPrice)
        {
            var property = await _propertyRepository.GetPropertyById(propertyId);
            if (property == null)
            {
                throw new Exception($"The property was not found");
            }

            property.Price = newPrice;
            return await _propertyRepository.UpdateProperty(property);
        }

        public async Task<bool> UpdateProperty(int propertyId, PropertyDto updatedProperty)
        {
            var existingProperty = await _propertyRepository.GetPropertyById(propertyId);
            if (existingProperty == null)
            {
                return false;
            }

            existingProperty.Name = updatedProperty.Name;
            existingProperty.Address = updatedProperty.Address;
            existingProperty.Price = updatedProperty.Price;
            existingProperty.CodeInternal = updatedProperty.CodeInternal;
            existingProperty.Year = updatedProperty.Year;
            existingProperty.IdOwner = updatedProperty.IdOwner;

            return await _propertyRepository.UpdateProperty(existingProperty);
        }

        public async Task<List<PropertyDto>> GetProperties(string? nameFilter, decimal? minPrice, decimal? maxPrice, int? year)
        {
            var properties = await _propertyRepository.GetProperties(nameFilter, minPrice, maxPrice, year);

            var propertyDtos = properties.Select(property => new PropertyDto
            {
                IdProperty = property.IdProperty,
                Name = property.Name,
                Address = property.Address,
                Price = property.Price,
                CodeInternal = property.CodeInternal,
                Year = property.Year,
                IdOwner = property.IdOwner
            }).ToList();

            return propertyDtos;
        }
    }
}
