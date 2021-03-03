using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using TipWallet.Models;
using Dapper;

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
            var documentPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            var databasePath = Path.Combine(documentPath, "TipWallet_DB.db");
            _connection = new SQLiteAsyncConnection(databasePath);
            await _connection.CreateTableAsync<WithdrawModel>();
        }

        public async Task AddItem(WithdrawModel obj)
        {
             await CreateConnection();
            await _connection.InsertAsync(obj);

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
    }
}
