using HungryHelper.Data;
using HungryHelper.Services.ShoppingList;
using HungryHelper.Services.FavoritedRecipes;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("HungryHelperDB");

builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(connectionString));

// Add Favorited Recipes Service/Interface for Dependency Injection here
builder.Services.AddScoped<IFavoritedRecipesService, FavoritedRecipeService>();

// Add ShoppingList Service/Interface for Dependency Injection here
builder.Services.AddScoped<IShoppingListService, ShoppingListService>();

builder.Services.AddControllers();
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

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
