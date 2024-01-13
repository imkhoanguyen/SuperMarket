using Microsoft.AspNetCore.Mvc;
using SuperMarket.Models;

namespace SuperMarket.ViewComponents
{
    public class TransactionViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke(string userName)
        {
            var transaction = TransactionRepository.GetByDayAndCashier(userName, DateTime.Now);
            return View(transaction);
        }
    }
}
