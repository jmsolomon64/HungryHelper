using System.Threading.Tasks;
using HungryHelper.Models.UserProfile;

namespace HungryHelper.Services.UserProfile
{
    public interface IUserProfileService
    {
        Task<bool> RegisterUserProfileAsync(UserProfileRegister model);
        Task<UserProfileDetail> GetUserProfileByIdAsync(int userProfileId);

        Task<bool> UpdateUserProfileAsync(UserProfileUpdate request);

        Task<bool> DeleteUserProfileAsync(int userProfileId);
    }
}