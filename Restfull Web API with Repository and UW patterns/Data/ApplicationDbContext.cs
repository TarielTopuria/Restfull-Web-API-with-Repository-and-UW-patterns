using Microsoft.EntityFrameworkCore;
using Restfull_Web_API_with_Repository_and_UW_patterns.Models;

namespace Restfull_Web_API_with_Repository_and_UW_patterns.Data
{
    public class ApplicationDbContext : DbContext
    {
        // the dbSet Property will tell ef core that we hav a table that need to be created if doesn;t exist
        public virtual DbSet<User> Users { get; set; }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) 
        {

        }
    }
}
