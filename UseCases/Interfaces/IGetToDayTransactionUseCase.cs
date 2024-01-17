using CoreBusiness;

namespace UseCases.TransactionUseCase
{
    public interface IGetToDayTransactionUseCase
    {
        IEnumerable<Transaction> Execute(string cashierName);
    }
}