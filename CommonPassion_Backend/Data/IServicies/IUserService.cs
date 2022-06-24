using CommonPassion_Backend.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonPassion_Backend.IServicies
{
    public interface IUserService
    {
        IEnumerable<User> GetAll();
        Task<User> FindByNameAsync(string username);
        Task<bool> CheckPasswordAsync(User user, string password);
        User GetUserById(string Id);
        bool SaveChanges();

        
    }
}
