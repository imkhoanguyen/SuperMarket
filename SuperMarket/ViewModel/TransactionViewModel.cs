using CoreBusiness;
using System.ComponentModel.DataAnnotations;

namespace SuperMarket.ViewModel
{
    public class TransactionViewModel
    {
        [Display(Name = "Cashier Name")]
        public string? CashierName { get; set; }
        [Display(Name = "Start Date")]
        public DateTime StartDate { get; set; }
        [Display(Name = "End Date")]
        public DateTime EndDate { get; set; }
        public IEnumerable<Transaction> Transactions { get; set; } = new List<Transaction>();
    }
}
