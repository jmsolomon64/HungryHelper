using HungryHelper.Data;
using HungryHelper.Services.ShoppingList;
using HungryHelper.Services.FavoritedRecipes;
using HungryHelper.Services.Ingredient;
using HungryHelper.Services.Recipe;
using Microsoft.EntityFrameworkCore;
using HungryHelper.Services.UserProfile;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("HungryHelperDB");
builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(connectionString));

// Add Favorited Recipes Service/Interface for Dependency Injection here
builder.Services.AddScoped<IFavoritedRecipesService, FavoritedRecipesService>();
// Dependency Injection
builder.Services.AddScoped<IUserProfileService, UserProfileService>();

// Add ShoppingList Service/Interface for Dependency Injection here
builder.Services.AddScoped<IShoppingListService, ShoppingListService>();

//adds reipeservice/interface for dependency
builder.Services.AddScoped<IRecipeService, RecipeService>();
builder.Services.AddScoped<IIngredientService, IngredientService>();

builder.Services.AddControllers(); // calls controllers from webapi 
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseDefaultFiles();
app.UseStaticFiles();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
