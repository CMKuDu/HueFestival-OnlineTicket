namespace HueFestival_OnlineTicket.Models
{
    public class News
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Alias { get; set; }
        public string Author { get; set; }
        public DateTime? Datecreate { get; set; }
        public string Description { get; set; }
        public string Content { get; set; }
        public virtual ICollection<Account> Accounts { get; set; }
    }
}
