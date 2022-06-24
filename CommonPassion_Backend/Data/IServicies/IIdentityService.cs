using CommonPassion_Backend.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonPassion_Backend.Data.IServicies
{
    public interface IIdentityService
    {
        public string GenerateJwtToken(string userId, string userName, string secret);
    }
}
