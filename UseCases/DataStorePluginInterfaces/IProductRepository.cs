using CoreBusiness;

namespace UseCases.DataStorePluginInterfaces
{
    public interface IProductRepository
    {
        void AddProduct(Product Product);
        void DeleteProduct(int id);
        Product? GetById(int ProductId, bool loadCategory = false);
        IEnumerable<Product> GetProducts(bool loadCategory = false);
        IEnumerable<Product> GetProductsByCategoryId(int categoryId);
        void UpdateProduct(int ProductId, Product Product);
    }
}