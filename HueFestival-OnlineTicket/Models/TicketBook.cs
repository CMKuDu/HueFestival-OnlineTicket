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
        public int Idtransacstatus { get; set; }
        [ForeignKey("Idtransacstatus")]
        public string? Description { get; set; }
        [ForeignKey("Idcustomer")]
        public int Idcustomer { get; set; }
        public virtual Customer? IdcustomerNavigation { get; set; }

        
    }
}
