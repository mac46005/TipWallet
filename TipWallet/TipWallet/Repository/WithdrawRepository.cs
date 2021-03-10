using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using TipWallet.Models;
using Dapper;
using System.Linq;

namespace TipWallet.Repository
{
    public class WithdrawRepository : IRepository<WithdrawModel>
    {
        private SQLiteAsyncConnection _connection;

        public event EventHandler<WithdrawModel> OnObjAdded;
        public event EventHandler<WithdrawModel> OnObjUpdated;
        public event EventHandler<WithdrawModel> OnObjDeleted;

        private async Task CreateConnection()
        {
            if (_connection != null)
            {
                return;
            }
            var documentPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            var databasePath = Path.Combine(documentPath, "TipWallet.db");
            _connection = new SQLiteAsyncConnection(databasePath);
            await _connection.CreateTableAsync<WithdrawModel>();
        }

        public async Task AddItem(WithdrawModel obj)
        {
             await CreateConnection();
            await _connection.InsertAsync(obj);
            OnObjAdded.Invoke(this, obj);

        }

        public async Task AddOrUpdate(WithdrawModel obj)
        {
            await CreateConnection();
            if (obj.Id == 0)
            {
                await AddItem(obj);
            }
            else
            {
                await UpdateItem(obj);
            }
        }

        public async Task DeleteItem(WithdrawModel obj)
        {
            await CreateConnection();
            await _connection.DeleteAsync(obj);
        }

        public async Task<List<WithdrawModel>> GetItems()
        {
            await CreateConnection();
            return await _connection.Table<WithdrawModel>().ToListAsync();
        }

        public async Task UpdateItem(WithdrawModel obj)
        {
            await CreateConnection();
            await _connection.UpdateAsync(obj);
        }

        public async Task<decimal> GetAmount()
        {
            await CreateConnection();
            var table = await _connection.Table<WithdrawModel>().ToListAsync();
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
