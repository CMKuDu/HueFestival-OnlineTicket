using MessagePack;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Net.Sockets;
using Microsoft.EntityFrameworkCore.SqlServer;
using HueFestival_OnlineTicket.Models;

namespace HueFestival_OnlineTicket.Model
{

    public class Ticket
    {
        public int Id { get; set; }
        public string NameTicket { get; set; }
        public string DescriptionTicket { get; set; }
        public bool Status { get; set; }
        public DateTime? CreatedDate { get; set; }
        public int TicketTypeId { get; set; }
        public virtual TicketType TicketTypes { get; set; }


    }
    //public virtual Tickettype IdtypeticketNavigation { get; set; } = null!;

}
