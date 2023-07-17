
namespace Infrastructure.Interfaces
{
    public interface IPropertyTraceRepository
    {
        public Task<bool> Create(Domain.Models.PropertyTrace propertyTrace);
    }
}
