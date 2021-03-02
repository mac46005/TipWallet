using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TipWallet.Models;

namespace TipWallet.Repository
{
    public class WithdrawRepository : IRepository<WithdrawModel>
    {
        private SQLiteAsyncConnection _connection;

        public event EventHandler<WithdrawModel> OnObjAdded;
        public event EventHandler<WithdrawModel> OnObjUpdated;
        public event EventHandler<WithdrawModel> OnObjDeleted;

        private async  Task CreateConnection()
        {

        }

        public Task AddItem(WithdrawModel obj)
        {
            throw new NotImplementedException();
        }

        public Task AddOrUpdate(WithdrawModel obj)
        {
            throw new NotImplementedException();
        }

        public Task DeleteItem(WithdrawModel obj)
        {
            throw new NotImplementedException();
        }

        public Task<List<WithdrawModel>> GetItems()
        {
            throw new NotImplementedException();
        }

        public Task UpdateItem(WithdrawModel obj)
        {
            throw new NotImplementedException();
        }
    }
}
