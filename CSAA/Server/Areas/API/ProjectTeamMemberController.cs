using System.Collections.Generic;
using System.Net.Http;
using System.Web.Http;
using CSAA.DataModels;
using Microsoft.AspNet.Identity.Owin;
using Server.App_Data;
using Server.Models;
using Server.Services;
using ServiceModel = CSAA.ServiceModels;

namespace Server.Areas.API
{
    [Authorize]
    [RoutePrefix("api/ProjectTeamMember")]
    public class ProjectTeamMemberController : ApiController
    {    
        private ServerDbContext context;
        private IRepository<ProjectTeamMember> repository;
        private IRepository<Project> projectRepository;
        private IProjectTeamMemberService service;
        private IRepository<ApplicationUser> userRepository;

        private IApplicationUserManager _userManager;
        public IApplicationUserManager UserManager
        {
            get => _userManager ?? Request.GetOwinContext().GetUserManager<ApplicationUserManager>();
            set => _userManager = value;
        }

        public ProjectTeamMemberController()
        {
            context = new ServerDbContext();
            repository = new ProjectTeamMemberRepository(context);
            projectRepository = new ProjectRepository(context);
            userRepository = new UserRepository(context);
            service = new ProjectTeamMemberService(repository, projectRepository, userRepository);
        }

        public ProjectTeamMemberController(IProjectTeamMemberService service)
        {
            this.service = service;
        }

        [HttpGet]
        public List<ServiceModel.ProjectTeamMember> Get()
        {
            service.SetApplicationUserManager(UserManager);
            return service.GetAllProjectTeamMembers();
        }

        [HttpPost]
        [Route("Search")]
        public List<ServiceModel.User> Search(ServiceModel.User user)
        {
            service.SetApplicationUserManager(UserManager);
            return service.SearchProjectTeamMembers(user);
        }

        [HttpGet]
        public ServiceModel.ProjectTeamMember Get(string id)
        {
            service.SetApplicationUserManager(UserManager);
            return service.GetProjectTeamMember(id);
        }

        [HttpPost]
        public void Post(ServiceModel.ProjectTeamMember projectTeamMember)
        {
            var user = UserManager.FindUserByEmail(projectTeamMember.UserEmail);
            if(user != null) service.AddProjectTeamMember(user.Id, projectTeamMember.ProjectId);
        }

        [HttpPut]
        public void Put(string id, ServiceModel.ProjectTeamMember projectTeamMember)
        {
            service.UpdateProjectTeamMember(id, projectTeamMember);
        }

        [HttpDelete]
        public void Delete(string id)
        {
            service.DeleteProjectTeamMember(id);
        }
    }
}