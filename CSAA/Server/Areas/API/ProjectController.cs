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
    [Authorize]
    public class ProjectController : ApiController
    {
        private ServerDbContext context;
        private IRepository<Project> repository;
        private IProjectService service;

        private IApplicationUserManager _userManager;
        public IApplicationUserManager UserManager
        {
            get => _userManager ?? Request.GetOwinContext().GetUserManager<ApplicationUserManager>();
            set => _userManager = value;
        }

        public ProjectController()
        {
            context = new ServerDbContext();
            repository = new ProjectRepository(context);
            service = new ProjectService(repository);
        }

        public ProjectController(IProjectService service)
        {
            this.service = service;
        }

        [HttpGet]
        public List<ServiceModel.Project> Get()
        {
            service.SetApplicationUserManager(UserManager);
            return service.GetProjects(User.Identity.GetUserId());
        }

        [HttpGet]
        public ServiceModel.Project Get(string id)
        {
            service.SetApplicationUserManager(UserManager);
            return service.GetProject(id, User.Identity.GetUserId());
        }

        [HttpPost]
        public string Post(ServiceModel.Project project)
        {
            return service.CreateProject(project, User.Identity.GetUserId());
        }

        [HttpPut]
        public void Put(string id, ServiceModel.Project project)
        {
            service.UpdateProject(id, project);
        }

        [HttpDelete]
        public void Delete(string id)
        {
            service.DeleteProject(id);
        }
    }
}