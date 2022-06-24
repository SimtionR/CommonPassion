using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonPassion_Backend.Data.Entities
{
    public class ConnectionPending
    {
        public int Id { get; set; }
        public int SenderId { get; set; }
        public string SenderName { get; set; }
        public string SenderPhoto { get; set; }
        public int ReceiverId { get; set; }
        public bool IsAccepted { get; set; }
    }
}
