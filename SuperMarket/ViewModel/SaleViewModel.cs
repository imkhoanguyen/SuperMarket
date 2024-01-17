using CoreBusiness;
using SuperMarket.ViewModel.Validations;
using System.ComponentModel.DataAnnotations;

namespace SuperMarket.ViewModel
{
    public class SaleViewModel
    {
        public int SelectedCategoryId { get; set; }
        public IEnumerable<Category> Categories { get; set; } = new List<Category>();
        public int SelectedProductId { get; set; }
        [Display(Name = "Quantity")]
        [Range(1,int.MaxValue)]
        [SaleViewModel_EnsureProperQuantity]
        public int QuantityToSell { get; set; }
    }
}
