using System.Collections.Generic;

namespace Server.App_Data
{
    public interface IRepository<T>
    {
        List<T> GetAll();
        T GetByID(string id);
        void Insert(T item);
        void Delete(string id);
        void Save();
    }
}
