using HueFestival_OnlineTicket.Model;
using HueFestival_OnlineTicket.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace HueFestival_OnlineTicket.Data
{
    public partial class DataContext : DbContext
    {
        
        public DataContext(DbContextOptions<DataContext> options)
       : base(options)
        {
        }
        public DbSet<Ticket> Tickets { get; set; }
        public DbSet<Account> Accounts { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Evnet> Events { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<News> News { get; set; }
        public DbSet<Roles> Roles { get; set; }
        public DbSet<TicketBook> TicketBooks { get; set; }
        public DbSet<TicketType> TicketTypes { get; set; }
        public DbSet<Transacstatus> Transacstatus { get; set; }

    }
}
