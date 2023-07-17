using Infrastructure.Interfaces;
using Service.Dtos;
using Service.Interfaces;

namespace Service
{
    public class PropertyTraceService : IPropertyTraceService
    {
        private readonly IPropertyTraceRepository _propertyTraceRepository;
        public PropertyTraceService(IPropertyTraceRepository propertyTraceRepository)
        {
            _propertyTraceRepository = propertyTraceRepository;
        }
        public async Task<bool> Create(PropertyTraceDto propertytraceDto)
        {
            return await _propertyTraceRepository.Create((Domain.Models.PropertyTrace)propertytraceDto);
        }
    }
}
