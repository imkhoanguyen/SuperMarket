using System.ComponentModel.DataAnnotations;
using UseCases.Interfaces;

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
                    var getProductByIdUseCase = validationContext.GetService(typeof(IViewSelectedProductUseCase)) as IViewSelectedProductUseCase;
                    if (getProductByIdUseCase != null)
                    {
                        var product = getProductByIdUseCase.Execute(saleViewModel.SelectedProductId);
                        if (product != null)
                        {
                            if (product.Quantity < saleViewModel.QuantityToSell)
                                return new ValidationResult($"{product.Name} only has {product.Quantity} left. It is not enough.");
                        }
                        else
                        {
                            return new ValidationResult("The selected product doesn't exist.");
                        }
                    }
                }
            }
            return ValidationResult.Success;
        }
    }
}
