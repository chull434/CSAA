using CSAA.DataModels;
using Microsoft.AspNet.Identity;
using Server.App_Data;
using Server.Services;
using System.Collections.Generic;
using System.Net.Http;
using System.Web.Http;
using Microsoft.AspNet.Identity.Owin;
using ServiceModel = CSAA.ServiceModels;

namespace Server.Areas.API
{
    public class SprintController : ApiController
    {
        private ServerDbContext context;
        private IRepository<Sprint> repository;
        private IRepository<Project> projectRepository;
        private ISprintService service;

        private IApplicationUserManager _userManager;
        public IApplicationUserManager UserManager
        {
            get => _userManager ?? Request.GetOwinContext().GetUserManager<ApplicationUserManager>();
            set => _userManager = value;
        }

        public SprintController()
        {
            context = new ServerDbContext();
            repository = new SprintRepository(context);
            projectRepository = new ProjectRepository(context);
            service = new SprintService(repository, projectRepository);
        }

        public SprintController(ISprintService service)
        {
            this.service = service;
        }

        [HttpGet]
        public List<ServiceModel.Sprint> Get()
        {
            service.SetApplicationUserManager(UserManager);
            return service.GetSprints();
        }

        [HttpGet]
        public ServiceModel.Sprint Get(string id)
        {
            service.SetApplicationUserManager(UserManager);
            return service.GetSprint(id, User.Identity.GetUserId());
        }

        [HttpPost]
        public string Post(ServiceModel.Sprint sprint)
        {
            return service.CreateSprint(sprint, User.Identity.GetUserId());
        }

        [HttpPut]
        public void Put(string id, ServiceModel.Sprint sprint)
        {
            service.UpdateSprint(id, sprint);
        }

        [HttpDelete]
        public void Delete(string id)
        {
            service.DeleteSprint(id);
        }
    }
}