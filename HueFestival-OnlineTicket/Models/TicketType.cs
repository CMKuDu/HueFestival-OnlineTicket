using HueFestival_OnlineTicket.Model;

namespace HueFestival_OnlineTicket.Models
{
    public class TicketType
    {
        public int id { get; set; }
        public string Nametypeticket { get; set; }
        public string Descriptionticket { get; set; }
        public string Address { get; set; }
        public string Pirce { get; set; }
        public bool Puslish { get; set; }
        public string Aliasticket { get; set; }
        public bool Payment { get; set; }
        
    }
}
