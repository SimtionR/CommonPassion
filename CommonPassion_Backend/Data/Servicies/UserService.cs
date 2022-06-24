using CommonPassion_Backend.Data.Entities;
using CommonPassion_Backend.IServicies;
using CommonPassion_Backend.Migrations;
using CommonPassion_Backend.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonPassion_Backend.Data.Servicies
{
    public class UserService : IUserService
    {
        private readonly UserManager<User> _userMananger;
        private readonly CommonPassionDbContext _ctx;

        public UserService(UserManager<User> userManager, CommonPassionDbContext ctx)
        {
            _userMananger = userManager;
            _ctx = ctx;

        }

        public AuthResponseModel Auth(AuthRequestModel model)
        {
            //var user = 

            return null;
        }
        public async Task<bool> CheckPasswordAsync(User user, string password)
        {
            var isValid = await _userMananger.CheckPasswordAsync(user, password);

            return isValid;
        }

        public async Task<User> FindByNameAsync(string username)
        {
            var user = await _ctx.Users.Include(u => u.Profile).Where(u => u.UserName == username).FirstOrDefaultAsync();
            return user;
        }   
        public IEnumerable<User> GetAll()
        {
            throw new NotImplementedException();
        }

        public User GetUserById(string Id)
        {
            throw new NotImplementedException();
        }

        public bool SaveChanges()
        {
            throw new NotImplementedException();
        }
    }
}
