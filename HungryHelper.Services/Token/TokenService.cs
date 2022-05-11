using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using HungryHelper.Data;
using HungryHelper.Data.Entities;
using HungryHelper.Models.Token;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace HungryHelper.Services.Token
{
    public class TokenService : ITokenService
    {
        private readonly ApplicationDbContext _context;
        private readonly IConfiguration _configuration;
        public TokenService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<TokenResponse> GetTokenAsync(TokenRequest model)
        {
            var userProfileEntity = await GetValidUserAsync(model);
            if (userProfileEntity is null)
                return null;
            return GenerateToken(userProfileEntity);
        }
        private async Task<UserProfileEntity> GetValidUserAsync(TokenRequest model)
        {
            var userProfileEntity = await _context.UserProfile.FirstOrDefaultAsync(userProfile => userProfile.Username.ToLower() == model.Username.ToLower());
            if (userProfileEntity is null)
                return null;

            var passwordHasher = new PasswordHasher<UserProfileEntity>();
            var verifyPasswordResult = passwordHasher.VerifyHashedPassword(userProfileEntity, userProfileEntity.Password, model.Password);
            if (verifyPasswordResult == PasswordVerificationResult.Failed)
                return null;
            
            return userProfileEntity;
        }
        private TokenResponse GenerateToken(UserProfileEntity entity)
        {
            var claims = GetClaims(entity);
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Issuer = _configuration["Jwt:Issuer"],
                Audience = _configuration["Jwt:Audience"],
                Subject = new ClaimsIdentity(claims),
                IssuedAt = DateTime.UtcNow,
                Expires = DateTime.UtcNow.AddDays(14),
                SigningCredentials = credentials
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDescriptor);

            var tokenResponse = new TokenResponse
            {
                Token = tokenHandler.WriteToken(token),
                IssuedAt = token.ValidFrom,
                Expires = token.ValidTo
            };

            return tokenResponse;
        }

        private Claim[] GetClaims(UserProfileEntity userProfile)
        {
            var fullName = $"{userProfile.FirstName} {userProfile.LastName}";
            var name = !string.IsNullOrWhiteSpace(fullName) ? fullName : userProfile.Username;

            var claims = new Claim[]
            {
                new Claim("Id", userProfile.Id.ToString()),
                new Claim("Username", userProfile.Username),
                new Claim("Name", name)
            };

            return claims;
        }
    }
}