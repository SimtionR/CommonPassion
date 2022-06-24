using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonPassion_Backend.Data.Entities
{
    public class Profile
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string UserId { get; set; }
        public User User { get; set; }
        public string ProfilePicture { get; set; }
        public List<UserReview> Reviews { get; set; } = new List<UserReview>();
        public List<Connection> Connections { get; set; } = new List<Connection>();
        public List<ConnectionPending> ConnectionPendings { get; set; } = new List<ConnectionPending>();
        public List<ResponsePending> ResponsePendings { get; set; } = new List<ResponsePending>();
    }
}
