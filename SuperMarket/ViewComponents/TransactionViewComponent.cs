using Microsoft.AspNetCore.Mvc;
using UseCases.TransactionUseCase;

namespace SuperMarket.ViewComponents
{
    public class TransactionViewComponent : ViewComponent
    {
        private readonly IGetToDayTransactionUseCase getToDayTransactionUseCase;

        public TransactionViewComponent(IGetToDayTransactionUseCase getToDayTransactionUseCase)
        {
            this.getToDayTransactionUseCase = getToDayTransactionUseCase;
        }
        public IViewComponentResult Invoke(string userName)
        {
            var transaction = getToDayTransactionUseCase.Execute(userName);
            return View(transaction);
        }
    }
}
