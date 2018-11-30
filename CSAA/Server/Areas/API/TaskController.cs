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
    public class TaskController : ApiController
    {
        private ServerDbContext context;
        private IRepository<Task> repository;
        private IRepository<UserStory> userStoryRepository;
        private IRepository<Project> projectRepository;
        private IRepository<Sprint> sprintRepository;
        private ITaskService service;

        private IApplicationUserManager _userManager;
        public IApplicationUserManager UserManager
        {
            get => _userManager ?? Request.GetOwinContext().GetUserManager<ApplicationUserManager>();
            set => _userManager = value;
        }

        public TaskController()
        {
            context = new ServerDbContext();
            repository = new TaskRepository(context);
            userStoryRepository = new UserStoryRepository(context);
            projectRepository = new ProjectRepository(context);
            sprintRepository = new SprintRepository(context);
            service = new TaskService(repository, userStoryRepository, projectRepository, sprintRepository);
        }

        public TaskController(ITaskService service)
        {
            this.service = service;
        }

        [HttpGet]
        public IEnumerable<ServiceModel.Task> Get()
        {
            return service.GetAllTasks();
        }

        [HttpGet]
        public ServiceModel.Task Get(string id)
        {
            service.SetApplicationUserManager(UserManager);
            return service.GetTask(id, User.Identity.GetUserId());
        }

        [HttpPost]
        public string Post(ServiceModel.Task acceptanceTest)
        {
            return service.CreateTask(acceptanceTest);
        }

        [HttpPut]
        public void Put(string id, ServiceModel.Task task)
        {
            service.UpdateTask(id, task, User.Identity.GetUserId());
        }

        [HttpDelete]
        public void Delete(string id)
        {
            service.DeleteTask(id);
        }
    }
}