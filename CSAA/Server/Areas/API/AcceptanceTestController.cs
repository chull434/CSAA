using CSAA.DataModels;
using Microsoft.AspNet.Identity.Owin;
using Server.App_Data;
using Server.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ServiceModel = CSAA.ServiceModels;
using Microsoft.AspNet.Identity;

namespace Server.Areas.API
{
    [Authorize]
    public class AcceptanceTestController : ApiController
    {
        private ServerDbContext context;
        private IRepository<AcceptanceTest> repository;
        private IRepository<UserStory> userStoryRepository;
        private IAcceptanceTestService service;

        public AcceptanceTestController()
        {
            context = new ServerDbContext();
            repository = new AcceptanceTestRepository(context);
            userStoryRepository = new UserStoryRepository(context);
            service = new AcceptanceTestService(repository, userStoryRepository);
        }

        public AcceptanceTestController(IAcceptanceTestService service)
        {
            this.service = service;
        }

        [HttpGet]
        public IEnumerable<ServiceModel.AcceptanceTest> Get()
        {
            return service.GetAllAcceptanceTests();
        }

        [HttpGet]
        public ServiceModel.AcceptanceTest Get(string id)
        {
            return service.GetAcceptanceTest(id);
        }

        [HttpPost]
        public string Post(ServiceModel.AcceptanceTest acceptanceTest)
        {
            return service.CreateAcceptanceTest(acceptanceTest);
        }

        [HttpPut]
        public void Put(string id, ServiceModel.AcceptanceTest acceptanceTest)
        {
            service.UpdateAcceptanceTest(id, acceptanceTest);
        }

        [HttpDelete]
        public void Delete(string id)
        {
            service.DeleteAcceptanceTest(id);
        }
    }
}