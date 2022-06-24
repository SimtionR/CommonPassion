using CommonPassion_Backend.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonPassion_Backend.Data.IServicies
{
    public interface IProfileService
    {
        Task<Profile> CreateProfileAsync(User user);
        Task<Profile> GetProfileByUserId(string userId);
        Task<Profile> GetProfileByProfileId(int profileId);
        Task<bool> UpdateProfilePicture(string userId);
        Task<IEnumerable<Profile>> GetProfilesBySearchAsync(string search);
    }
}
