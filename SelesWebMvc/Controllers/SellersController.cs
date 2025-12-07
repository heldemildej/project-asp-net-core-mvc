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

        // GET: Sellers
        public async Task<IActionResult> Index()
        {
            var sellers = await _sellerService.FindAllAsync();
            return View(sellers);
        }
    }
}
