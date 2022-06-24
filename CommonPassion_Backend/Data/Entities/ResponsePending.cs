using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonPassion_Backend.Data.Entities
{
    public class ResponsePending
    {
        public int Id { get; set; }
        public int PendingId { get; set; }
        public int SenderId { get; set; }
        public string SenderName { get; set; }
        public string SenderPhoto { get; set; }
        public int ReceiverId { get; set; }
        public string ReceiverName { get; set; }
        public string ReceiverPhoto { get; set; }
        public bool IsAccepted { get; set; }
    }
}
