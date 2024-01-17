using CoreBusiness;

namespace UseCases.TransactionUseCase
{
    public interface ISearchTransactionUseCase
    {
        IEnumerable<Transaction> Execute(string cashierName, DateTime startDate, DateTime endDate);
    }
}