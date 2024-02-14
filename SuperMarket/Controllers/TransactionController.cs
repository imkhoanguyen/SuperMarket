using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SuperMarket.ViewModel;
using UseCases.TransactionUseCase;

namespace SuperMarket.Controllers
{
    [Authorize]
    public class TransactionController : Controller
    {
        private readonly ISearchTransactionUseCase searchTransactionsUseCase;

        public TransactionController(ISearchTransactionUseCase searchTransactionsUseCase)
        {
            this.searchTransactionsUseCase = searchTransactionsUseCase;
        }
        public IActionResult Index()
        {
            TransactionViewModel transactionViewModel = new TransactionViewModel();
            return View(transactionViewModel);
        }

        public IActionResult Search(TransactionViewModel transactionsViewModel)
        {
            var transactions = searchTransactionsUseCase.Execute(
                 transactionsViewModel.CashierName ?? string.Empty,
                 transactionsViewModel.StartDate,
                 transactionsViewModel.EndDate);

            transactionsViewModel.Transactions = transactions;

            return View("Index", transactionsViewModel);
        }
    }
}
