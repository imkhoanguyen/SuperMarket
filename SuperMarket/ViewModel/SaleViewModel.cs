using SuperMarket.Models;

namespace SuperMarket.ViewModel
{
    public class SaleViewModel
    {
        public int SelectedCategoryId { get; set; }
        public IEnumerable<Category> Categories { get; set; } = new List<Category>();
    }
}
