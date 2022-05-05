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

        public async Task<UserProfileDetail> GetUserProfileByIdAsync(int userProfileId)
        {
            var entity = await _context.UserProfile.FindAsync(userProfileId);
            if (entity is null)
                {
                    return null;
                }

            var userProfileDetail = new UserProfileDetail
            {
                Id = entity.Id,
                CookingExperienceLevel = entity.CookingExperienceLevel,
                FirstName = entity.FirstName,
                LastName = entity.LastName,
                FavoriteFood = entity.FavoriteFood,
                DateJoined = entity.DateJoined
            };

            return userProfileDetail;
        }

        public async Task<bool> UpdateUserProfileAsync(UserProfileUpdate request)
        {
            var userProfileEntity = await _context.UserProfile.FindAsync(request.Id);
            // To do: validate profile is owned by the updating user

            // Updates the entities properties
            userProfileEntity.CookingExperienceLevel = request.CookingExperienceLevel;
            userProfileEntity.FirstName = request.FirstName;
            userProfileEntity.LastName = request.LastName;
            userProfileEntity.FavoriteFood = request.FavoriteFood;

            // saves changes to the database and captures how many rows were updated
            var numberOfChanges = await _context.SaveChangesAsync();
            return numberOfChanges == 1;
        }

        public async Task<bool> DeleteUserProfileAsync(int userProfileId)
        {
            var userProfileEntity = await _context.UserProfile.FindAsync(userProfileId);
            // To do: validate profile is owned by the updating user

            _context.UserProfile.Remove(userProfileEntity);
            return await _context.SaveChangesAsync() == 1;
        }
    }
}