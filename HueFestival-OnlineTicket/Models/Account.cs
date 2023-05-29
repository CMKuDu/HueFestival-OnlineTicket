using MessagePack;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;

namespace HueFestival_OnlineTicket.Models
{
    
    public class Account
    {
        public int Id { get; set; }
        public string LoginAccount { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Salt { get; set; }
        public bool Active { get; set; }
        public DateTime? Datecreate { get; set; }
        public DateTime? Lastlogin { get; set; }
        public string PasswordResetToken { get; set; }
        public DateTime ResetTokenExpires { get; set; }
        public int LocationId { get; set; }
        public virtual ICollection<Roles> Roless { get; set; }

    }
}
