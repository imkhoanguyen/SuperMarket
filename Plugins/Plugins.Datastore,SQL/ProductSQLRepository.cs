using CoreBusiness;
using Microsoft.EntityFrameworkCore;
using Plugins.Datastore.SQL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UseCases.DataStorePluginInterfaces;

namespace Plugins.Datastore_SQL
{
    public class ProductSQLRepository : IProductRepository
    {
        private readonly MakeContext db;

        public ProductSQLRepository(MakeContext db)
        {
            this.db = db;
        }
        public void AddProduct(Product Product)
        {
            db.Products.Add(Product);
            db.SaveChanges();
        }

        public void DeleteProduct(int id)
        {
            var product = db.Products.FirstOrDefault(x => x.ProductId == id);
            if (product == null) return;
            db.Products.Remove(product);
            db.SaveChanges();
        }

        public Product? GetById(int ProductId, bool loadCategory = false)
        {
            if (loadCategory)
            {
                return db.Products.Include(x => x.Category).FirstOrDefault(x => x.ProductId == ProductId);
            }
            else
            {
                return db.Products.FirstOrDefault(x => x.ProductId == ProductId);
            }
        }

        public IEnumerable<Product> GetProducts(bool loadCategory = false)
        {
            if(loadCategory)
            {
                return db.Products.Include(x => x.Category).OrderBy(x=>x.CategoryId).ToList();
            } else
            {
                return db.Products.OrderBy(x=> x.CategoryId).ToList();
            }
        }

        public IEnumerable<Product> GetProductsByCategoryId(int categoryId)
        {
            return db.Products.Where(x => x.CategoryId == categoryId).ToList();
        }

        public void UpdateProduct(int ProductId, Product Product)
        {
            if (Product.ProductId != ProductId) return;
            var prod = db.Products.Find(ProductId);
            if (prod == null) return;
            prod.CategoryId = Product.CategoryId;
            prod.Name = Product.Name;
            prod.Price = Product.Price;
            prod.Quantity = Product.Quantity;
            db.SaveChanges();
        }
    }
}
