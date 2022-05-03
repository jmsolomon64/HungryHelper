using System.Threading.Tasks;
using HungryHelper.Models.UserProfile;
using HungryHelper.Data;
using HungryHelper.Data.Entities;

namespace HungryHelper.Services.UserProfile
{
    public class UserProfileService : IUserProfileService
    {
        private readonly ApplicationDbContext _context;
        public UserProfileService(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<bool> RegisterUserProfileAsync(UserProfileRegister model)
        {
            var entity = new UserProfileEntity
            {
                CookingExperienceLevel = model.CookingExperienceLevel,
                FirstName = model.FirstName,
                LastName = model.LastName,
                FavoriteFood = model.FavoriteFood,
                DateJoined = DateTime.Now
            };

            _context.UserProfile.Add(entity);
            var numberOfChanges = await _context.SaveChangesAsync();

            return numberOfChanges == 1;
        }
    }
}