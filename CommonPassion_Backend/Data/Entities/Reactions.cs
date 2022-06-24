using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonPassion_Backend.Data.Entities
{
    public class Reactions
    {
        public int Id { get; set; }
        public int ReviewId { get; set; }
        public int ProfileId { get; set; }
        public Profile Profile { get; set; }
        public bool IsLiked { get; set; }
        public bool IsDisliked { get; set; }
    }
}
