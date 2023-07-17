using Infrastructure.Interfaces;
using Service.Dtos;
using Service.Interfaces;

namespace Service
{
    public class PropertyImageService : IPropertyImageService
    {
        private readonly IPropertyImageRepository _propertyImageRepository;
        public PropertyImageService(IPropertyImageRepository propertyImageRepository)
        {
            _propertyImageRepository = propertyImageRepository;
        }
        public Task<bool> Create(PropertyImageDto propertyImageDto)
        {
            return _propertyImageRepository.Create((Domain.Models.PropertyImage)propertyImageDto);
        }
    }
}
