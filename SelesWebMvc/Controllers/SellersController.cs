using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SelesWebMvc.Data;
using SelesWebMvc.Models;
using System.Linq;
using System.Threading.Tasks;

namespace SelesWebMvc.Controllers
{
    public class SellersController : Controller
    {
        private readonly SelesWebMvcContext _context;

        public SellersController(SelesWebMvcContext context)
        {
            _context = context;
        }

        // GET: Sellers
        public async Task<IActionResult> Index()
        {
            var sellers = await _context.Seller
                                        .Include(s => s.Department)
                                        .ToListAsync();
            return View(sellers);
        }

        // GET: Sellers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
                return NotFound();

            var seller = await _context.Seller
                                       .Include(s => s.Department)
                                       .FirstOrDefaultAsync(s => s.Id == id);

            if (seller == null)
                return NotFound();

            return View(seller);
        }

        // GET: Sellers/Create
        public IActionResult Create()
        {
            ViewData["Departments"] = _context.Department.ToList();
            return View();
        }

        // POST: Sellers/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Name,Email,BirthDate,BaseSalary,DepartmentId")] Seller seller)
        {
            if (ModelState.IsValid)
            {
                _context.Add(seller);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            ViewData["Departments"] = _context.Department.ToList();
            return View(seller);
        }

        // GET: Sellers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
                return NotFound();

            var seller = await _context.Seller.FindAsync(id);
            if (seller == null)
                return NotFound();

            ViewData["Departments"] = _context.Department.ToList();
            return View(seller);
        }

        // POST: Sellers/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Email,BirthDate,BaseSalary,DepartmentId")] Seller seller)
        {
            if (id != seller.Id)
                return NotFound();

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(seller);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!_context.Seller.Any(e => e.Id == id))
                        return NotFound();
                    else
                        throw;
                }
                return RedirectToAction(nameof(Index));
            }

            ViewData["Departments"] = _context.Department.ToList();
            return View(seller);
        }

        // GET: Sellers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
                return NotFound();

            var seller = await _context.Seller
                                       .Include(s => s.Department)
                                       .FirstOrDefaultAsync(s => s.Id == id);

            if (seller == null)
                return NotFound();

            return View(seller);
        }

        // POST: Sellers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var seller = await _context.Seller.FindAsync(id);
            _context.Seller.Remove(seller);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
