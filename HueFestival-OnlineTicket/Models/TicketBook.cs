using MessagePack;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;
using HueFestival_OnlineTicket.Model;

namespace HueFestival_OnlineTicket.Models
{
    public class TicketBook
    {
        
        public int Id { get; set; }
        public DateTime? Datecreatebook { get; set; }
        public DateTime? Datepay { get; set; }
        public int CustomerId { get; set; }
        public int TickId { get; set; }
        public virtual ICollection<Transacstatus> Transacstatuss { get; set; }
        public virtual ICollection<Customer> Customers { get; set; }
        public virtual ICollection<Ticket> Tickets { get; set; }
        //public string Note { get; set; }
        //public int Money { get; set; }
        //public string? Description { get; set; }


    }
}   
