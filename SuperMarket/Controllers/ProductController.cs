using CoreBusiness;
using Microsoft.AspNetCore.Mvc;
using SuperMarket.ViewModel;
using UseCases.Interfaces;

namespace SuperMarket.Controllers
{
    public class ProductController : Controller
    {
        private readonly IAddProductUseCase addProductUseCase;
        private readonly IEditProductUseCase editProductUseCase;
        private readonly IDeleteProductUseCase deleteProductUseCase;
        private readonly IViewSelectedProductUseCase viewSelectedProductUseCase;
        private readonly IViewProductUseCase viewProductUseCase;
        private readonly IViewCategoriesUseCase viewCategoriesUseCase;
        private readonly IViewProductsInCategoryUseCase viewProductsInCategoryUseCase;

        public ProductController(
            IAddProductUseCase addProductUseCase,
            IEditProductUseCase editProductUseCase,
            IDeleteProductUseCase deleteProductUseCase,
            IViewSelectedProductUseCase viewSelectedProductUseCase,
            IViewProductUseCase viewProductUseCase,
            IViewCategoriesUseCase viewCategoriesUseCase,
            IViewProductsInCategoryUseCase viewProductsInCategoryUseCase)
        {
            this.addProductUseCase = addProductUseCase;
            this.editProductUseCase = editProductUseCase;
            this.deleteProductUseCase = deleteProductUseCase;
            this.viewSelectedProductUseCase = viewSelectedProductUseCase;
            this.viewProductUseCase = viewProductUseCase;
            this.viewCategoriesUseCase = viewCategoriesUseCase;
            this.viewProductsInCategoryUseCase = viewProductsInCategoryUseCase;
        }

        public IActionResult Index()
        {
            var products = viewProductUseCase.Execute(loadCategory: true);
            return View(products);
        }

        public IActionResult Add()
        {
            ViewBag.Action = "add";
            var ProductViewModel = new ProductViewModel
            {
                Categories = viewCategoriesUseCase.Execute()
            };
            return View(ProductViewModel);
        }

        [HttpPost]
        public IActionResult Add(ProductViewModel productViewModel)
        {
            if (ModelState.IsValid)
            {
                addProductUseCase.Excute(productViewModel.Product);
                return RedirectToAction(nameof(Index));
            }
            return View(productViewModel);
        }

        public IActionResult Edit(int id)
        {
            ViewBag.Action = "edit";
            var productViewModel = new ProductViewModel
            {
                Product = viewSelectedProductUseCase.Execute(id) ?? new Product(),
                Categories = viewCategoriesUseCase.Execute()
            };
            return View(productViewModel);
        }

        [HttpPost]
        public IActionResult Edit(ProductViewModel productViewModel)
        {
            if (ModelState.IsValid)
            {
                editProductUseCase.Execute(productViewModel.Product);
                return RedirectToAction(nameof(Index));
            }
            return View(productViewModel);
        }

        public IActionResult Delete(int productId)
        {
            deleteProductUseCase.Execute(productId);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult GetProductsByCategory(int categoryId)
        {
            var products = viewProductsInCategoryUseCase.Execute(categoryId);
            return PartialView("_Products", products);
        }

        
    }
}
