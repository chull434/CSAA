using System.Collections.Generic;
using System.Net.Http;
using System.Web.Http;
using CSAA.DataModels;
using Microsoft.AspNet.Identity.Owin;
using Server.App_Data;
using Server.Services;
using ServiceModel = CSAA.ServiceModels;

namespace Server.Areas.API
{
    [Authorize]
    public class ProjectTeamMemberController : ApiController
    {    
        private ServerDbContext context;
        private IRepository<ProjectTeamMember> repository;
        private IRepository<Project> projectRepository;
        private IProjectTeamMemberService service;

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
            service = new ProjectTeamMemberService(repository, projectRepository);
        }

        public ProjectTeamMemberController(IProjectTeamMemberService service)
        {
            this.service = service;
        }

        [HttpGet]
        public List<ServiceModel.ProjectTeamMember> Get()
        {
            service = new ProjectTeamMemberService(repository, projectRepository, UserManager);
            return service.GetAllProjectTeamMembers();
        }

        [HttpGet]
        public ServiceModel.ProjectTeamMember Get(string id)
        {
            service = new ProjectTeamMemberService(repository, projectRepository, UserManager);
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