namespace AwesomeTicket.Models
{
    public class Show
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Location { get; set; }

        public DateTime Date { get; set; }
        public TimeSpan Time { get; set; }
        public string Owner { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;

      
        public int CategoryId { get; set; }
        public Category Category { get; set; }
    }
}
