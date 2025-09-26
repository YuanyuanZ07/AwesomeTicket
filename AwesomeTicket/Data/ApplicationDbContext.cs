using Microsoft.EntityFrameworkCore;
using AwesomeTicket.Models;

namespace AwesomeTicket.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

     
        public DbSet<Show> Shows { get; set; }
        public DbSet<Category> Categories { get; set; }
    }
}
