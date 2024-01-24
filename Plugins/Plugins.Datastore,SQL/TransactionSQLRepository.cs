using CoreBusiness;
using Microsoft.EntityFrameworkCore;
using Plugins.Datastore.SQL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UseCases.DataStorePluginInterfaces;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Plugins.Datastore_SQL
{
    public class TransactionSQLRepository : ITransactionRepository
    {
        private readonly MakeContext db;

        public TransactionSQLRepository(MakeContext db)
        {
            this.db = db;
        }
        public void AddTransaction(string cashierName, int productId, string productName, double price, int beforeQty, int soldQty)
        {
            var transaction = new Transaction
            {
                ProductId = productId,
                ProductName = productName,
                Price = price,
                BeforeQty = beforeQty,
                SoldQty = soldQty,
                TimeStamp = DateTime.Now,
                CashierName = cashierName,
            };
            db.Transactions.Add(transaction);
            db.SaveChanges();
        }

        public IEnumerable<Transaction> GetByDayAndCashier(string cashierName, DateTime date)
        {
            if(string.IsNullOrEmpty(cashierName))
            {
                return db.Transactions.Where(x => x.TimeStamp.Date == date.Date);
            } else
            {
                return db.Transactions.Where(x =>
                EF.Functions.Like(x.CashierName, $"%{cashierName}") &&
                x.TimeStamp.Date == date.Date);

            }
        }

        public IEnumerable<Transaction> Search(string cashierName, DateTime startDate, DateTime endDate)
        {
            if (string.IsNullOrEmpty(cashierName))
            {
                return db.Transactions.Where(x => x.TimeStamp.Date >= startDate.Date &&
                x.TimeStamp.Date < endDate);
            }
            else
            {
                return db.Transactions.Where(x =>
                EF.Functions.Like(x.CashierName, $"%{cashierName}") &&
                x.TimeStamp.Date >= startDate.Date &&
                x.TimeStamp.Date < endDate);
            }
        }
    }
}
