using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CSAA.DataModels;

namespace Server.App_Data
{
    public class AcceptanceTestRepository : Repository, IRepository<AcceptanceTest>
    {
        public AcceptanceTestRepository(ServerDbContext context)
        {
            this.context = context;
        }

        public List<AcceptanceTest> GetAll()
        {
            return context.AcceptanceTests.ToList();
        }

        public AcceptanceTest GetByID(string id)
        {
            return context.AcceptanceTests.FirstOrDefault(p => p.Id.ToString() == id);
        }

        public void Insert(AcceptanceTest acceptanceTest)
        {
            context.AcceptanceTests.Add(acceptanceTest);
        }

        public void Delete(string id)
        {
            var acceptanceTest = GetByID(id);
            context.AcceptanceTests.Remove(acceptanceTest);
        }
    }
}