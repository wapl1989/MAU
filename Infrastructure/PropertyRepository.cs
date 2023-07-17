using Domain.Models;
using Infrastructure.Data;
using Infrastructure.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Infrastructure
{
    public class PropertyRepository : IPropertyRepository
    {
        private readonly MAUDbContext _dbContext;
        private readonly ILogger<PropertyRepository> _logger;

        public PropertyRepository(MAUDbContext dbContext, ILogger<PropertyRepository> logger)
        {
            _dbContext = dbContext;
            _logger = logger;
        }

        public async Task<int> Create(Property property)
        {
            try
            {
                _logger.LogInformation($"Creating a new property: {property.Name}");

                _dbContext.Properties.Add(property);
                await _dbContext.SaveChangesAsync();

                return property.IdProperty;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error creating the property");
                return 0;
            }
        }

        public async Task<Property> GetPropertyById(int propertyId)
        {
            return await _dbContext.Properties.FindAsync(propertyId) ?? new Property();
        }

        public async Task<bool> UpdateProperty(Property property)
        {
            try
            {
                _logger.LogInformation($"Updating property: {property.Name}");

                _dbContext.Properties.Update(property);
                await _dbContext.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error updating the property");
                return false;
            }
        }

        public async Task<List<Property>> GetProperties(string? nameFilter, decimal? minPrice, decimal? maxPrice, int? year)
        {
            IQueryable<Property> query = _dbContext.Properties;

            if (!string.IsNullOrEmpty(nameFilter))
            {
                query = query.Where(property => property.Name.Contains(nameFilter));
            }

            if (minPrice.HasValue)
            {
                query = query.Where(property => property.Price >= minPrice.Value);
            }

            if (maxPrice.HasValue)
            {
                query = query.Where(property => property.Price <= maxPrice.Value);
            }

            if (year.HasValue)
            {
                query = query.Where(property => property.Year == year.Value);
            }

            return await query.ToListAsync();
        }
    }
}
