using Microsoft.AspNetCore.Mvc;
using SelesWebMvc.Models;
using SelesWebMvc.Services;
using System.Threading.Tasks;

namespace SelesWebMvc.Controllers
{
    public class SellersController : Controller
    {
        private readonly SellerService _sellerService;

        public SellersController(SellerService sellerService)
        {
            _sellerService = sellerService;
        }

        public async Task<IActionResult> Index()
        {
            var sellers = await _sellerService.FindAllAsync();
            return View(sellers);
        }

        // GET: Sellers/Create
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Seller seller)
        {
            if (!ModelState.IsValid)
            {
                return View(seller);
            }

            _sellerService.Insert(seller);
            return RedirectToAction(nameof(Index));
        }


    }
}
