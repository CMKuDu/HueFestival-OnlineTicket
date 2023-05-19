using System.ComponentModel.DataAnnotations.Schema;

namespace HueFestival_OnlineTicket.Models
{
    public class Customer
    {
        public int Id { get; set; }
        public string Namecustomer { get; set; }
        public DateTime? Birthdaycustomer { get; set; }
        public string Avatar { get; set; }
        public string Emailcustomer { get; set; }
        public string Phonecustomer { get; set; }
        [ForeignKey("Idlocation")]
        public int Idlocation { get; set; }         
    }
}
