using HungryHelper.Data;
using HungryHelper.Services.ShoppingList;
using HungryHelper.Services.FavoritedRecipes;
using HungryHelper.Services.Ingredient;
using HungryHelper.Services.Recipe;
using Microsoft.EntityFrameworkCore;
using HungryHelper.Services.UserProfile;
using Microsoft.IdentityModel.Tokens;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using System.Text;
using HungryHelper.Services.Token;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(connectionString));

// This is setting up the HttpContext access for UserProfile and Shopping List
builder.Services.AddHttpContextAccessor();
// Add Favorited Recipes Service/Interface for Dependency Injection here
builder.Services.AddScoped<IFavoritedRecipesService, FavoritedRecipesService>();
// Dependency Injection
builder.Services.AddScoped<IUserProfileService, UserProfileService>();

// Add ShoppingList Service/Interface for Dependency Injection here
builder.Services.AddScoped<IShoppingListService, ShoppingListService>();

//adds reipeservice/interface for dependency
builder.Services.AddScoped<IRecipeService, RecipeService>();
builder.Services.AddScoped<IIngredientService, IngredientService>();

// token dependency injection
builder.Services.AddScoped<ITokenService, TokenService>();

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
    {
        options.RequireHttpsMetadata = false;
        options.SaveToken = true;
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidIssuer = builder.Configuration["Jwt:Issuer"],
            ValidAudience = builder.Configuration["Jwt:Audience"],
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]))
        };
    });

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

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
