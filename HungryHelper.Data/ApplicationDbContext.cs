using HungryHelper.Data.Entities;
using Microsoft.EntityFrameworkCore;
using HungryHelper.Data.Entities;

namespace HungryHelper.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
        
        public DbSet<RecipeEntity> Recipes {get; set;}

        public DbSet<IngredientEntity> Ingredients {get; set;}
        
        public DbSet<UserProfileEntity> UserProfile { get; set;}

    }
}