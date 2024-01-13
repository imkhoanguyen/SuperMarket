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

        public IActionResult SellProduct(int id)
        {
            var product = ProductsRepository.GetById(id);
            return PartialView("_SellProduct", product);
        }

        public IActionResult Sell(SaleViewModel saleViewModel)
        {
            if (ModelState.IsValid)
            {
                var prod = ProductsRepository.GetById(saleViewModel.SelectedProductId);
                if (prod != null)
                {
                    TransactionRepository.AddTransaction(
                        "Cashier1",
                        saleViewModel.SelectedProductId,
                        prod.Name,
                        prod.Price.HasValue ? prod.Price.Value : 0,
                        prod.Quantity.HasValue ? prod.Quantity.Value : 0,
                        saleViewModel.QuantityToSell);
                    prod.Quantity -= saleViewModel.QuantityToSell;
                    ProductsRepository.UpdateProduct(saleViewModel.SelectedProductId, prod);
                }
            }
            var product = ProductsRepository.GetById(saleViewModel.SelectedProductId);
            saleViewModel.SelectedCategoryId = (product?.CategoryId == null) ? 0 : product.CategoryId.Value;
            saleViewModel.Categories = CategoriesRepository.GetCategories();

            return View("Index", saleViewModel);
        }
    }
}
