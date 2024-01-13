using SuperMarket.Models;
using System.ComponentModel.DataAnnotations;

namespace SuperMarket.ViewModel.Validations
{
    public class SaleViewModel_EnsureProperQuantity : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            var saleViewModel = validationContext.ObjectInstance as SaleViewModel;
            if (saleViewModel != null)
            {
                if (saleViewModel.QuantityToSell <= 0)
                {
                    return new ValidationResult("The quantity to sell has to be greater than zero.");
                }
                else
                {
                    var product = ProductsRepository.GetById(saleViewModel.SelectedProductId);
                    if (product != null)
                    {
                        if(product.Quantity < saleViewModel.QuantityToSell)
                        {
                            return new ValidationResult($"{product.Name} only has {product.Quantity} left.");
                        }
                    }
                }
            }
            return ValidationResult.Success;
        }
    }
}
