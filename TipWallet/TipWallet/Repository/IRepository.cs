using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace TipWallet.Repository
{
    public interface IRepository<T>
    {
        event EventHandler<T> OnObjAdded;
        event EventHandler<T> OnObjUpdated;
        event EventHandler<T> OnObjDeleted;

        Task<List<T>> GetItems();
        Task AddItem(T obj);
        Task UpdateItem(T obj);
        Task AddOrUpdate(T obj);
        Task DeleteItem(T obj);
    }
}
