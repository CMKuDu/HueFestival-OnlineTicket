using System.ComponentModel.DataAnnotations.Schema;

namespace HueFestival_OnlineTicket.Models
{
    public class Roles
    {
        public int Id { get; set; }
        public string Namerole { get; set; }
        public string Description { get; set; }
    }
}
