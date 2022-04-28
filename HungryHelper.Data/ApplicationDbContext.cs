using Microsoft.EntityFrameworkCore;

namespace HungryHelper.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
        
    }
}