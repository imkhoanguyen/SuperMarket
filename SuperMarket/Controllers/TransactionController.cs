using Microsoft.AspNetCore.Mvc;
using SuperMarket.Models;
using SuperMarket.ViewModel;

namespace SuperMarket.Controllers
{
    public class TransactionController : Controller
    {
        public IActionResult Index()
        {
            TransactionViewModel transactionViewModel = new TransactionViewModel();
            return View(transactionViewModel);
        }

        public IActionResult Search(TransactionViewModel transactionViewModel)
        {
            var transactions = TransactionRepository.Search(transactionViewModel.CashierName??string.Empty, transactionViewModel.StartDate, transactionViewModel.EndDate);
            transactionViewModel.Transactions = transactions;
            return View("Index", transactionViewModel);
        }
    }
}
