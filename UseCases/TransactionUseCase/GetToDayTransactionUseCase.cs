using CoreBusiness;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UseCases.DataStorePluginInterfaces;

namespace UseCases.TransactionUseCase
{
    public class GetToDayTransactionUseCase : IGetToDayTransactionUseCase
    {
        private readonly ITransactionRepository transactionRepository;

        public GetToDayTransactionUseCase(ITransactionRepository transactionRepository)
        {
            this.transactionRepository = transactionRepository;
        }

        public IEnumerable<Transaction> Execute(string cashierName)
        {
            return transactionRepository.GetByDayAndCashier(cashierName, DateTime.Now);
        }
    }
}
