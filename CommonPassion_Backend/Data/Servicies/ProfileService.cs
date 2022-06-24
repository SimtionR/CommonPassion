using CommonPassion_Backend.Data.Entities;
using CommonPassion_Backend.Data.IServicies;
using CommonPassion_Backend.Migrations;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonPassion_Backend.Data.Servicies
{
    public class ProfileService : IProfileService
    {
        private readonly CommonPassionDbContext _ctx;
        public ProfileService(CommonPassionDbContext ctx)
        {
            _ctx = ctx;
        }
        public async Task<Profile> CreateProfileAsync(User user)
        {
            var idPart = new string(user.Id.Take(10).ToArray());
            var defaultProfilePicture = new StringBuilder("profilepictures").Append(idPart).ToString();
            var profile = new Profile
            {
                User = user,
                UserId = user.Id,
                UserName = user.UserName,
                ProfilePicture = defaultProfilePicture
            };

            _ctx.Profiles.Add(profile);
            await _ctx.SaveChangesAsync();

            var userToUpdate = await _ctx.Users.Where(u => u.Id == user.Id).FirstOrDefaultAsync();
            _ctx.Update(userToUpdate.Profile = profile);

            await _ctx.SaveChangesAsync();

            return profile;
        }

        public async Task<Profile> GetProfileByProfileId(int profileId)
        {
            var profile = await _ctx.Profiles.Where(p => p.Id == profileId).FirstOrDefaultAsync();
            return profile;
        }

        public async Task<Profile> GetProfileByUserId(string userId)
        {
            var profile = await _ctx.Profiles.Where(p => p.UserId == userId).FirstOrDefaultAsync();
            return profile;
        }

        public async Task<IEnumerable<Profile>> GetProfilesBySearchAsync(string search)
        {
            var profiles = await _ctx.Profiles.Where(p => p.UserName.Contains(search)).ToListAsync();
            return profiles;
        }

        public async Task<bool> UpdateProfilePicture(string userId)
        {
            var profileToUpdate = await GetProfileByUserId(userId);
            var idPart = new string(userId.Take(10).ToArray());
            var defaultProfilePicture = new StringBuilder("profilepictures").Append(idPart).ToString();

            profileToUpdate.ProfilePicture = defaultProfilePicture;

            await _ctx.SaveChangesAsync();

            return true;
        }
    }
}
