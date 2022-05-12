using HungryHelper.Models.Token;

namespace HungryHelper.Services.Token
{
    public interface ITokenService
    {
        Task<TokenResponse> GetTokenAsync(TokenRequest model);
    }
}