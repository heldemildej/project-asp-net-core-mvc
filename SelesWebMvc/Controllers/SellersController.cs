using Microsoft.AspNetCore.Mvc;
using SelesWebMvc.Models;
using SelesWebMvc.Models.ViewModels;
using SelesWebMvc.Services;
using SelesWebMvc.Services.Exceptions;
using System.Threading.Tasks;

namespace SelesWebMvc.Controllers
{
    public class SellersController : Controller
    {
        private readonly SellerService _sellerService;
        private readonly DepartmentService _departmentService;

        public SellersController(SellerService sellerService, DepartmentService departmentService)
        {
            _sellerService = sellerService;
            _departmentService = departmentService;
        }

        public async Task<IActionResult> Index()
        {
            var sellers = await _sellerService.FindAllAsync();
            return View(sellers);
        }

        // GET: Sellers/Create
        public IActionResult Create()
        {
            var departments = _departmentService.FindAll();
            var viewModel = new SellerFormViewModel { Departments = departments };

            return View(viewModel);
        }

        // POST: Sellers/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Seller seller)
        {
            if (!ModelState.IsValid)
            {
                var departments = _departmentService.FindAll();
                var viewModel = new SellerFormViewModel { Departments = departments };
                return View(viewModel);
            }

            _sellerService.Insert(seller);
            return RedirectToAction(nameof(Index));
        }

        // GET: Sellers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var seller = await _sellerService.FindByIdAsync(id.Value);
            if (seller == null)
            {
                return NotFound();
            }

            return View(seller);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            await _sellerService.RemoveAsync(id);
            return RedirectToAction(nameof(Index));
        }

        // GET: Sellers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var seller = await _sellerService.FindByIdAsync(id.Value);
            if (seller == null)
            {
                return NotFound();
            }

            return View(seller);
        }

        // GET: Sellers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var seller = await _sellerService.FindByIdAsync(id.Value);
            if (seller == null)
            {
                return NotFound();
            }

            var departments = await _departmentService.FindAllAsync();
            var viewModel = new SellerFormViewModel { Seller = seller, Departments = departments };
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Seller seller)
        {
            if (!ModelState.IsValid)
            {
                var departments = await _departmentService.FindAllAsync();
                var viewModel = new SellerFormViewModel { Seller = seller, Departments = departments };
                return View(viewModel);
            }

            if (id != seller.Id)
            {
                return BadRequest();
            }

            try
            {
                await _sellerService.UpdateAsync(seller);
                return RedirectToAction(nameof(Index));
            }
            catch (NotFoundException)
            {
                return NotFound();
            }
            catch (DbConcurrencyException e)
            {
                return BadRequest(e.Message);
            }
        }

    }
}
