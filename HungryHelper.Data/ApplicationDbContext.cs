using HungryHelper.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace HungryHelper.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
        





        public DbSet<RecipeEntity> Recipes {get; set;}
    }
}