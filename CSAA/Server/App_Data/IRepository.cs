using System.Collections.Generic;

namespace Server.App_Data
{
    public interface IRepository<T>
    {
        IEnumerable<T> GetAll();
        T GetByID(string id);
        void Insert(T item);
        void Delete(string id);
        void Save();
        string GetUserIdFromEmail(string email);
    }
}
