using Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data
{
    public class MAUDbContext : DbContext
    {
        public DbSet<Domain.Models.Property> Properties { get; set; }
        public DbSet<Owner> Owners { get; set; }
        public DbSet<PropertyImage> PropertyImages { get; set; }
        public DbSet<PropertyTrace> PropertyTraces { get; set; }

        public MAUDbContext(DbContextOptions<MAUDbContext> options) : base(options)
        {
        }
    }
}
