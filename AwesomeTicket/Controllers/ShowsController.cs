using Microsoft.AspNetCore.Mvc;
using AwesomeTicket.Models;

namespace AwesomeTicket.Controllers
{
    public class ShowsController : Controller
    {
        // 模拟数据（替代数据库）
        private static List<Show> shows = new List<Show>
        {
            new Show { Id = 1, Title = "Concert", Location = "Halifax", Date = DateTime.Now.AddDays(7) },
            new Show { Id = 2, Title = "Tech Meetup", Location = "NSCC", Date = DateTime.Now.AddDays(14) }
        };

        public IActionResult Index()
        {
            return View(shows);
        }
    }
}
