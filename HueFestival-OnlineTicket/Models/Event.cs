namespace HueFestival_OnlineTicket.Models
{
    public class Evnet
    {
        public int Id { get; set; }

        public string Nameevent { get; set; }
        public string Content { get; set; }
        public string Alias { get; set; }
        public bool Puslish { get; set; }
        public string Thumb { get; set; }
        public DateTime? EndDate { get; set; }
        public DateTime? Datecreate { get; set; }
    }
}
