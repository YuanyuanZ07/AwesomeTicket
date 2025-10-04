using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AwesomeTicket.Data;
using AwesomeTicket.Models;

namespace AwesomeTicket.Controllers
{
    public class ShowsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ShowsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Shows
        public async Task<IActionResult> Index()
        {
            var shows = _context.Shows
                .Include(s => s.Category)
                .OrderByDescending(s => s.CreatedAt);
            return View(await shows.ToListAsync());
        }

        // GET: Shows/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null) return NotFound();

            var show = await _context.Shows
                .Include(s => s.Category)
                .FirstOrDefaultAsync(m => m.Id == id);

            if (show == null) return NotFound();

            return View(show);
        }

        // GET: Shows/Create
        public IActionResult Create()
        {
            ViewData["CategoryId"] = new SelectList(_context.Categories, "Id", "Name");
            return View();
        }

        // POST: Shows/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Title,Description,Location,Date,Time,Owner,CategoryId")] Show show)
        {
            if (ModelState.IsValid)
            {
                show.CreatedAt = DateTime.Now;
                _context.Add(show);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            else
            {
                
                foreach (var error in ModelState.Values.SelectMany(v => v.Errors))
                {
                    Console.WriteLine("⚠️ ModelState Error: " + error.ErrorMessage);
                }
            }

            ViewData["CategoryId"] = new SelectList(_context.Categories, "Id", "Name", show.CategoryId);
            return View(show);
        }

        // GET: Shows/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();

            var show = await _context.Shows.FindAsync(id);
            if (show == null) return NotFound();

            ViewData["CategoryId"] = new SelectList(_context.Categories, "Id", "Name", show.CategoryId);
            return View(show);
        }

        // POST: Shows/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Title,Description,Location,Date,Time,Owner,CreatedAt,CategoryId")] Show show)
        {
            if (id != show.Id) return NotFound();

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(show);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!_context.Shows.Any(e => e.Id == show.Id))
                        return NotFound();
                    else
                        throw;
                }
                return RedirectToAction(nameof(Index));
            }

            ViewData["CategoryId"] = new SelectList(_context.Categories, "Id", "Name", show.CategoryId);
            return View(show);
        }

        // GET: Shows/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();

            var show = await _context.Shows
                .Include(s => s.Category)
                .FirstOrDefaultAsync(m => m.Id == id);

            if (show == null) return NotFound();

            return View(show);
        }

        // POST: Shows/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var show = await _context.Shows.FindAsync(id);
            if (show != null)
            {
                _context.Shows.Remove(show);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
