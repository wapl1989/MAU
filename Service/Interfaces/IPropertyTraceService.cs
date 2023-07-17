using Service.Dtos;

namespace Service.Interfaces
{
    public interface IPropertyTraceService
    {
        public Task<bool> Create(PropertyTraceDto propertyTrace);
    }
}
