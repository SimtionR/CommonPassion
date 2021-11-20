using CommonPassion_Backend.Entities;
using CommonPassion_Backend.IServicies;
using CommonPassion_Backend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonPassion_Backend.Data.Servicies
{
    public class UserService : IUserService
    {

        public AuthResponseModel Auth(AuthRequestModel model)
        {
            //var user = 

            return null;
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
