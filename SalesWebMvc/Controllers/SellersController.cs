using SalesWebMvc.Services;
using Microsoft.AspNetCore.Mvc;

namespace SalesWebMvc.Controllers
{
    public class SellersController : Controller
    {
        private readonly SellerService _SellerService;
      

        public SellersController(SellerService sellerService)
        {
            _SellerService = sellerService;
        } 
        
        public IActionResult Index()
        {
            var list = _SellerService.FindAll();
            return View(list);
        }
    }
}
