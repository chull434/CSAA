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
            List<ServiceModel.AcceptanceTest> userStoryAcceptanceTests = new List<ServiceModel.AcceptanceTest>();
            var AcceptanceTests = repository.GetAll().Select(m => m.Map()).ToList();
            foreach (var userStoryAcceptanceTest in AcceptanceTests)
            {
                if (userStoryAcceptanceTest.UserStoryId == userStoryRepository.GetByID(userStoryAcceptanceTest.UserStoryId).Id.ToString())
                {
                    userStoryAcceptanceTests.Add(userStoryAcceptanceTest);
                }
            }
            return userStoryAcceptanceTests;
        }

        public ServiceModel.AcceptanceTest GetAcceptanceTest(string AcceptanceTestId)
        {
            var acceptanceTest = repository.GetByID(AcceptanceTestId).Map();
            return acceptanceTest;
        }

        public string CreateAcceptanceTest(ServiceModel.AcceptanceTest acceptanceTest)
        {
            var dataAcceptanceTest = new AcceptanceTest(acceptanceTest.Title, acceptanceTest.Criteria, acceptanceTest.Completed);
            dataAcceptanceTest.UserStory = userStoryRepository.GetByID(acceptanceTest.UserStoryId);
            dataAcceptanceTest.UserStoryId = dataAcceptanceTest.UserStory.Id;
            dataAcceptanceTest.UserStory.UserStoryAcceptanceTests.Add(dataAcceptanceTest);
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