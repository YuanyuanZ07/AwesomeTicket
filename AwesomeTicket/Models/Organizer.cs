namespace AwesomeTicket.Models
{
    public class Organizer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ContactEmail { get; set; }
        public string PhoneNumber { get; set; }
        public List<Show> Shows { get; set; }
    }
}
