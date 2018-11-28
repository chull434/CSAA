using CSAA.ServiceModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.Services
{
    public interface IAcceptanceTestService
    {
        List<AcceptanceTest> GetAllAcceptanceTests();
        AcceptanceTest GetAcceptanceTest(string AcceptanceTestID);
        string CreateAcceptanceTest(AcceptanceTest acceptanceTest);
        void UpdateAcceptanceTest(string acceptanceTestId, AcceptanceTest acceptanceTest);
        void DeleteAcceptanceTest(string acceptanceTestId);
    }
}
