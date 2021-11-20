using CommonPassion_Backend.Entities;
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
        User GetUserById(string Id);
        bool SaveChanges();

        
    }
}
