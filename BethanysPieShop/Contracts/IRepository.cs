using BethanysPieShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BethanysPieShop.Contracts
{
    public interface IRepository<T> where T : BaseEntity
    {
        IEnumerable<T> GetAllItems();
        T GetItemById(string id);

        T AddItem(T item);

        void UpdateItem(T item);

        void Commit();
        void Delete(string id);
    }
}
