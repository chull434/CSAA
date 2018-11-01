using System.Collections.Generic;
using System.Net.Http;
using System.Web.Http;
using CSAA.DataModels;
using CSAA.ServiceModels;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Server.App_Data;
using Server.Services;

namespace Server.Areas.API
{
    [Authorize]
    public class ProjectTeamMemberController : ApiController
    {
        private IApplicationUserManager userManager;
        private ServerDbContext context;
        private IRepository<ProjectTeamMember> repository;
        private IRepository<Project> projectRepository;
        private IProjectTeamMemberService service;
        private IProjectService projectService;

        public ProjectTeamMemberController()
        {
            context = new ServerDbContext();
            repository = new ProjectTeamMemberRepository(context);
            projectRepository = new ProjectRepository(context);
            projectService = new ProjectService(projectRepository);
            service = new ProjectTeamMemberService(repository, projectService);
        }

        public ProjectTeamMemberController(IRepository<ProjectTeamMember> repository, IProjectTeamMemberService service, IRepository<Project> projectRepository, IProjectService projectService)
        {
            this.repository = repository;
            this.projectRepository = projectRepository;
            this.projectService = projectService;
            this.service = service;
        }

        public IApplicationUserManager UserManager
        {
            get => userManager ?? Request.GetOwinContext().GetUserManager<ApplicationUserManager>();
            set => userManager = value;
        }

        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        [HttpGet]
        public string Get(int id)
        {
            return "value";
        }

        [HttpPost]
        public void Post(AddTeamMember addTeamMember)
        {
            service.AddTeamMember(UserManager.FindUserByEmail(addTeamMember.email).Id, addTeamMember.projectId);
        }

        [HttpPut]
        public void Put(int id, [FromBody]string value)
        {
        }

        [HttpDelete]
        public void Delete(int id)
        {
        }
    }
}