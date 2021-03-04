using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using TipWallet.Models;
using System.Linq;

namespace TipWallet.Repository
{
    public class DepositRepository : IRepository<DepositModel>
    {
        private SQLiteAsyncConnection _connection;

        public event EventHandler<DepositModel> OnObjAdded;
        public event EventHandler<DepositModel> OnObjUpdated;
        public event EventHandler<DepositModel> OnObjDeleted;
        private async Task CreateConnection()
        {
            if (_connection != null)
            {
                return;
            }

            var documentPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            var databasePath = Path.Combine(documentPath, "TipWallet_DB.db");

            _connection = new SQLiteAsyncConnection(databasePath);
            await _connection.CreateTableAsync<DepositModel>();

        }
        public async Task AddItem(DepositModel obj)
        {
            await CreateConnection();
            await _connection.InsertAsync(obj);
        }

        public async Task AddOrUpdate(DepositModel obj)
        {
            if (obj.Id == 0)
            {
                await AddItem(obj);
            }
            else
            {
                await UpdateItem(obj);
            }
        }

        public async Task DeleteItem(DepositModel obj)
        {
            await CreateConnection();
            await _connection.DeleteAsync(obj);
        }

        public async Task<List<DepositModel>> GetItems()
        {
            await CreateConnection();
            return await _connection.Table<DepositModel>().ToListAsync();
        }

        public async Task UpdateItem(DepositModel obj)
        {
            await CreateConnection();
            await _connection.UpdateAsync(obj);
        }

        public async Task<decimal> GetAmount()
        {
            await CreateConnection();
            var table = await _connection.Table<DepositModel>().ToListAsync();
            var amounts = table.Select(x => x.Amount);
            decimal total = 0;
            foreach (var amount in amounts)
            {
                total += amount;
            }
            return total;
        }
    }
}
