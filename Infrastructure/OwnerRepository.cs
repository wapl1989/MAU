using Domain.Models;
using Infrastructure.Data;
using Infrastructure.Interfaces;
using Microsoft.Extensions.Logging;

namespace Infrastructure
{
    public class OwnerRepository : IOwnerRepository
    {
        private readonly MAUDbContext _dbContext;
        private readonly ILogger<OwnerRepository> _logger;

        public OwnerRepository(MAUDbContext dbContext, ILogger<OwnerRepository> logger)
        {
            _dbContext = dbContext;
            _logger = logger;
        }

        public async Task<bool> CreateOwner(Owner owner)
        {
            try
            {
                _logger.LogInformation($"Creating a new owner: {owner.Name}");

                _dbContext.Owners.Add(owner);
                await _dbContext.SaveChangesAsync();

                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error creating the owner");
                return false; 
            }
        }

    }
}
