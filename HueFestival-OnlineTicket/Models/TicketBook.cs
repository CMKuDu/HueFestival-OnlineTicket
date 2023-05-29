using MessagePack;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;

namespace HueFestival_OnlineTicket.Models
{
    public class TicketBook
    {
        
        public int Id { get; set; }
        public DateTime? Datecreatebook { get; set; }
        public DateTime? Datepay { get; set; }
        public virtual ICollection<Transacstatus> Transacstatuss { get; set; }
        public virtual ICollection<Customer> Customers { get; set; }
        //public string Note { get; set; }
        //public int Money { get; set; }
        //public string? Description { get; set; }


    }
}   
