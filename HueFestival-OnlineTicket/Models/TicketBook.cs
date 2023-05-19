using MessagePack;
using System.ComponentModel.DataAnnotations.Schema;

namespace HueFestival_OnlineTicket.Models
{
    public class TicketBook
    {
        
        public int Id { get; set; }
        public DateTime? Datecreatebook { get; set; }
        public DateTime? Datepay { get; set; }
        public string Note { get; set; }
        public int Money { get; set; }
        public string? Description { get; set; }
        public int CustomerId { get; set; }
        public int Transacstatus { get; set; }
        public virtual Customer Customer { get; set; }
        public virtual ICollection<Transacstatus> Transacstatuss{ get; set; }



    }
}
