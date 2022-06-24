using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonPassion_Backend.Data.Entities
{
    public class Connection
    {
        public int Id { get; set; }
        public int ProfileId { get; set; }
        public int ProfileConnectionId { get; set; }
        public string ProfileUserName { get; set; }
        public string ProfilePicture { get; set; }
    }
}
