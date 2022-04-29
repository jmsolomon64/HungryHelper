using Microsoft.EntityFrameworkCore;
using HungryHelper.Data.Entities;

namespace HungryHelper.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
        
        public DbSet<UserProfileEntity> UserProfile { get; set;}
    }
}