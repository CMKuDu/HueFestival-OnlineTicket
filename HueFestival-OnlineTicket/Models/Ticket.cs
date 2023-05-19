using MessagePack;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Net.Sockets;
using Microsoft.EntityFrameworkCore.SqlServer;

namespace HueFestival_OnlineTicket.Model
{

    public class Ticket
    {
        public int Id { get; set; }
        public string NameTicket { get; set; }
        public string DescriptionTicket { get; set; }
        public int TicketTypeId { get; set; }
        [ForeignKey("TicketTypeId")]
        public bool Status { get; set; }
        public DateTime? CreatedDate { get; set; }
        //public virtual ICollection<Ticket> Tickets { get; set; } = new List<Ticket>();


    }
    //public virtual Tickettype IdtypeticketNavigation { get; set; } = null!;

}
