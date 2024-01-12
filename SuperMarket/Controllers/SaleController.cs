using Microsoft.AspNetCore.Mvc;
using SuperMarket.Models;
using SuperMarket.ViewModel;

namespace SuperMarket.Controllers
{
    public class SaleController : Controller
    {
        public IActionResult Index()
        {
            var saleViewModel = new SaleViewModel
            {
                Categories = CategoriesRepository.GetCategories()
            };
            return View(saleViewModel);
        }
    }
}
