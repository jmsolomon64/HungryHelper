using System.Threading.Tasks;
using HungryHelper.Models.UserProfile;
using HungryHelper.Data;
using HungryHelper.Data.Entities;
using Microsoft.AspNetCore.Identity;

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
                Username = model.Username,
                // Password = model.Password,
                CookingExperienceLevel = model.CookingExperienceLevel,
                FirstName = model.FirstName,
                LastName = model.LastName,
                FavoriteFood = model.FavoriteFood,
                DateJoined = DateTime.Now
            };

            var passwordHasher = new PasswordHasher<UserProfileEntity>();
            entity.Password = passwordHasher.HashPassword(entity, model.Password);

            _context.UserProfile.Add(entity);
            var numberOfChanges = await _context.SaveChangesAsync();

            return numberOfChanges == 1;
        }

        public List<UserProfileDetail> GetAllUserProfiles()
        {
            List<UserProfileDetail> listOfUsers = new List<UserProfileDetail>();
            var users = _context.UserProfile;
            foreach (var user in users)
            {
                var userDetail = new UserProfileDetail()
                {
                    Id = user.Id,
                    Username = user.Username,
                    CookingExperienceLevel = user.CookingExperienceLevel,
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    FavoriteFood = user.FavoriteFood,
                    DateJoined = user.DateJoined
                    // Username = user.Username,
                };

                listOfUsers.Add(userDetail);
            }
            return listOfUsers;
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
                Username = entity.Username,
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