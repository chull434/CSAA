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
    public class UserStoryController : ApiController
    {
        private ServerDbContext context;
        private IRepository<UserStory> repository;
        private IRepository<Project> projectRepository;
        private IUserStoryService service;

        private IApplicationUserManager _userManager;
        public IApplicationUserManager UserManager
        {
            get => _userManager ?? Request.GetOwinContext().GetUserManager<ApplicationUserManager>();
            set => _userManager = value;
        }

        public UserStoryController()
        {
            context = new ServerDbContext();
            repository = new UserStoryRepository(context);
            projectRepository = new ProjectRepository(context);
            service = new UserStoryService(repository, projectRepository);
        }

        public UserStoryController(IUserStoryService service)
        {
            this.service = service;
        }

        [HttpGet]
        public IEnumerable<ServiceModel.UserStory> Get()
        {
            return service.GetAllUserStories();
        }

        [HttpGet]
        public ServiceModel.UserStory Get(string id)
        {
            return service.GetUserStory(id);
        }

        [HttpPost]
        public string Post(ServiceModel.UserStory userStory)
        {
            return service.CreateUserStory(userStory);
        }

        [HttpPut]
        public void Put(string id, ServiceModel.UserStory userStory)
        {
            service.UpdateUserStory(id, userStory);
        }

        [HttpDelete]
        public void Delete(string id)
        {
            service.DeleteUserStory(id);
        }
    }
}