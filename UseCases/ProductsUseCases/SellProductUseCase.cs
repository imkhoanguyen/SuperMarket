using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UseCases.DataStorePluginInterfaces;
using UseCases.TransactionUseCase;

namespace UseCases.ProductsUseCases
{
    public class SellProductUseCase
    {
        private readonly IProductRepository productRepository;
        private readonly IRecordTransactionUseCase recordTransactionUseCase;

        public SellProductUseCase(IProductRepository productRepository, IRecordTransactionUseCase recordTransactionUseCase)
        {
            this.productRepository = productRepository;
            this.recordTransactionUseCase = recordTransactionUseCase;
        }

        public void Execute(string cashierName, int productId, int qtyToSell)
        {
            var product = productRepository.GetById(productId);
            if (product == null) return;

            recordTransactionUseCase.Execute(cashierName, productId, qtyToSell);
            product.Quantity -= qtyToSell;
            productRepository.UpdateProduct(productId, product);
        }
    }
}
