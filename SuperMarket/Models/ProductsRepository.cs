namespace SuperMarket.Models
{
    public class ProductsRepository
    {
        private static List<Product> _products = new List<Product>()
        {
            new Product {ProductId = 1, CategoryId = 1, Name = "Tao", Quantity = 1, Price = 500},
            new Product {ProductId = 2, CategoryId = 2,Name = "Sua", Quantity = 2, Price = 300},
            new Product {ProductId = 3, CategoryId = 3, Name = "thit heo", Quantity = 3, Price = 200}
        };
        public static List<Product> GetProducts() => _products;

        public static List<Product> GetProducts(bool loadCategory = false)
        {
            if (!loadCategory)
            {
                return _products;
            }
            else
            {
                if (_products != null && _products.Count > 0)
                {
                    _products.ForEach(product =>
                    {
                        if (product.CategoryId.HasValue)
                        {
                            product.Category = CategoriesRepository.GetById(product.CategoryId.Value);
                        }
                    });
                }
                return _products ?? new List<Product>();
            }
        }
        public static void AddProduct(Product Product)
        {
            int maxId = _products.Max(c => c.ProductId);
            Product.ProductId = maxId + 1;
            _products.Add(Product);
        }
        public static void DeleteProduct(int id)
        {
            var ProductToDelete = _products.FirstOrDefault(x => x.ProductId == id);
            if (ProductToDelete != null)
            {
                _products.Remove(ProductToDelete);
            }
        }

        public static Product? GetById(int ProductId, bool loadCategory = false)
        {
            var Product = _products.FirstOrDefault(x => x.ProductId == ProductId);
            if (Product != null)
            {
                var prod = new Product
                {
                    ProductId = ProductId,
                    Name = Product.Name,
                    Quantity = Product.Quantity,
                    Price = Product.Price,
                    CategoryId = Product.CategoryId,
                };
                if (loadCategory && prod.CategoryId.HasValue)
                {
                    prod.Category = CategoriesRepository.GetById(prod.CategoryId.Value);
                }
                return prod;
            }
            return null;
        }

        public static void UpdateProduct(int ProductId, Product Product)
        {
            if (Product.ProductId != ProductId) return;
            var ProductToUpdate = _products.FirstOrDefault(x => x.ProductId == ProductId);
            if (ProductToUpdate != null)
            {
                ProductToUpdate.Name = Product.Name;
                ProductToUpdate.CategoryId = Product.CategoryId;
                ProductToUpdate.Price = Product.Price;
                ProductToUpdate.Quantity = Product.Quantity;
            }
        }

        public static List<Product>? GetProductsByCategory(int categoryId)
        {
            var products = _products.Where(x => x.CategoryId == categoryId);
            if (products != null)
            {
                return products.ToList();
            }
            else return null;

        }
    }
}
