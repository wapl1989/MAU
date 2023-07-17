using Service.Dtos;

namespace Service.Interfaces
{
    public interface IPropertyImageService
    {
        public Task<bool> Create(PropertyImageDto propertyImage);
    }
}
