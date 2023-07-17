using Domain.Models;
using Infrastructure.Data;
using Infrastructure.Interfaces;
using Microsoft.Extensions.Logging;

namespace Infrastructure
{
    public class PropertyImageRepository : IPropertyImageRepository
    {
        private readonly MAUDbContext _dbContext;
        private readonly ILogger<PropertyImageRepository> _logger;

        public PropertyImageRepository(MAUDbContext dbContext, ILogger<PropertyImageRepository> logger)
        {
            _dbContext = dbContext;
            _logger = logger;
        }

        public async Task<bool> Create(PropertyImage propertyImage)
        {
            try
            {
                _logger.LogInformation($"Creating a new property image of property Id : {propertyImage.IdProperty}");

                _dbContext.PropertyImages.Add(propertyImage);
                int v = await _dbContext.SaveChangesAsync();

                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error creating the property image");
                return false;
            }
        }
    }
}
