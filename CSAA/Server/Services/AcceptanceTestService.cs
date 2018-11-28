using CSAA.DataModels;
using Server.App_Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ServiceModel = CSAA.ServiceModels;

namespace Server.Services
{
    public class AcceptanceTestService : IAcceptanceTestService
    {
        private IRepository<AcceptanceTest> repository;
        private IRepository<UserStory> userStoryRepository;       

        public AcceptanceTestService(IRepository<AcceptanceTest> repository, IRepository<UserStory> userStoryRepository)
        {
            this.repository = repository;
            this.userStoryRepository = userStoryRepository;
        }

        public List<ServiceModel.AcceptanceTest> GetAllAcceptanceTests()
        {
            return repository.GetAll().Select(m => m.Map()).ToList();
        }

        public ServiceModel.AcceptanceTest GetAcceptanceTest(string AcceptanceTestId)
        {
            return repository.GetByID(AcceptanceTestId).Map();
        }

        public string CreateAcceptanceTest(ServiceModel.AcceptanceTest acceptanceTest)
        {
            var dataAcceptanceTest = new AcceptanceTest(acceptanceTest.Title, acceptanceTest.Criteria, acceptanceTest.Completed);
            dataAcceptanceTest.UserStory = userStoryRepository.GetByID(acceptanceTest.UserStoryId);
            repository.Insert(dataAcceptanceTest);
            repository.Save();
            return dataAcceptanceTest.Id.ToString();
        }

        public void UpdateAcceptanceTest(string userStoryId, ServiceModel.AcceptanceTest acceptanceTest)
        {
            var dataAcceptanceTest = repository.GetByID(userStoryId);
            dataAcceptanceTest.Title = acceptanceTest.Title;
            dataAcceptanceTest.Criteria = acceptanceTest.Criteria;
            dataAcceptanceTest.Completed = acceptanceTest.Completed;
            repository.Save();
        }

        public void DeleteAcceptanceTest(string acceptanceTestId)
        {
            repository.Delete(acceptanceTestId);
            repository.Save();
        }
    }
}