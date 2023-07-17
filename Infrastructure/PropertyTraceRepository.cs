using Domain.Models;
using Infrastructure.Data;
using Infrastructure.Interfaces;
using Microsoft.Extensions.Logging;

namespace Infrastructure
{
    public class PropertyTraceRepository : IPropertyTraceRepository
    {
        private readonly MAUDbContext _dbContext;
        private readonly ILogger<PropertyTraceRepository> _logger;

        public PropertyTraceRepository(MAUDbContext dbContext, ILogger<PropertyTraceRepository> logger)
        {
            _dbContext = dbContext;
            _logger = logger;
        }

        public async Task<bool> Create(PropertyTrace property)
        {
            try
            {
                _logger.LogInformation($"Creating a new property trace: {property.Name}");

                _dbContext.PropertyTraces.Add(property);
                int v = await _dbContext.SaveChangesAsync();

                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error creating the property trace");
                return false;
            }
        }
    }
}
