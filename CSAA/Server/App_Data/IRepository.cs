using System.Collections.Generic;

namespace Server.App_Data
{
    public interface IRepository<T>
    {
        IEnumerable<T> GetAll();
        T GetByID(string id);
        void Insert(T issue);
        void Delete(string id);
        void Save();
    }
}
