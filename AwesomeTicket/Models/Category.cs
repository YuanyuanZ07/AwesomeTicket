namespace AwesomeTicket.Models
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public List<Show> Shows { get; set; } = new List<Show>();

    }
}
