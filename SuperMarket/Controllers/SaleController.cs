using Microsoft.AspNetCore.Mvc;
using SuperMarket.ViewModel;
using UseCases.Interfaces;
using UseCases.ProductsUseCases;

namespace SuperMarket.Controllers
{
    public class SaleController : Controller
    {
        private readonly IViewCategoriesUseCase viewCategoriesUseCase;
        private readonly IViewSelectedProductUseCase viewSelectedProductUseCase;
        private readonly ISellProductUseCase sellProductUseCase;

        public SaleController(IViewCategoriesUseCase viewCategoriesUseCase,
            IViewSelectedProductUseCase viewSelectedProductUseCase,
            ISellProductUseCase sellProductUseCase)
        {
            this.viewCategoriesUseCase = viewCategoriesUseCase;
            this.viewSelectedProductUseCase = viewSelectedProductUseCase;
            this.sellProductUseCase = sellProductUseCase;
        }
        public IActionResult Index()
        {
            var saleViewModel = new SaleViewModel
            {
                Categories = viewCategoriesUseCase.Execute()
            };
            return View(saleViewModel);
        }

        public IActionResult SellProductPartial(int productId)
        {
            var product = viewSelectedProductUseCase.Execute(productId);
            return PartialView("_SellProduct", product);
        }

        public IActionResult Sell(SaleViewModel salesViewModel)
        {
            if (ModelState.IsValid)
            {
                // Sell the product
                sellProductUseCase.Execute(
                    "cashier1",
                    salesViewModel.SelectedProductId,
                    salesViewModel.QuantityToSell);
            }

            var product = viewSelectedProductUseCase.Execute(salesViewModel.SelectedProductId);
            salesViewModel.SelectedCategoryId = (product?.CategoryId == null) ? 0 : product.CategoryId.Value;
            salesViewModel.Categories = viewCategoriesUseCase.Execute();

            return View("Index", salesViewModel);
        }

        public IActionResult SellProduct(int productId)
        {
            var product = viewSelectedProductUseCase.Execute(productId);
            return PartialView("_SellProduct", product);
        }
    }
}
