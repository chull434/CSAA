using System.Collections.Generic;
using CSAA.ServiceModels;

namespace Client.Requests
{
    public interface IAcceptanceTestRequest
    {
        List<AcceptanceTest> GetAcceptanceTests();
        AcceptanceTest GetAcceptanceTestById(string acceptanceTestId);
        string CreateAcceptanceTest(AcceptanceTest acceptanceTest);
        bool UpdateAcceptanceTest(string acceptanceTestId, AcceptanceTest acceptanceTest);
        bool DeleteAcceptanceTest(string acceptanceTestId);
    }
}
