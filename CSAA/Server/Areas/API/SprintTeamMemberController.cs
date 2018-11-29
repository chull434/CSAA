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
    public class SprintTeamMemberController : ApiController
    {
        private ServerDbContext context;
        private IRepository<SprintTeamMember> repository;
        private IRepository<Sprint> sprintRepository;
        private ISprintTeamMemberService service;
        private IRepository<ApplicationUser> userRepository;
        private IRepository<ProjectTeamMember> projectTeamMemberRepository;

        private IApplicationUserManager _userManager;
        public IApplicationUserManager UserManager
        {
            get => _userManager ?? Request.GetOwinContext().GetUserManager<ApplicationUserManager>();
            set => _userManager = value;
        }

        public SprintTeamMemberController()
        {
            context = new ServerDbContext();
            repository = new SprintTeamMemberRepository(context);
            sprintRepository = new SprintRepository(context);
            userRepository = new UserRepository(context);
            projectTeamMemberRepository = new ProjectTeamMemberRepository(context);
            service = new SprintTeamMemberService(repository, sprintRepository, userRepository, projectTeamMemberRepository);
        }

        public SprintTeamMemberController(ISprintTeamMemberService service)
        {
            this.service = service;
        }

        [HttpGet]
        public List<ServiceModel.SprintTeamMember> Get()
        {
            service.SetApplicationUserManager(UserManager);
            return service.GetAllSprintTeamMembers();
        }

        [HttpGet]
        public ServiceModel.SprintTeamMember Get(string id)
        {
            service.SetApplicationUserManager(UserManager);
            return service.GetSprintTeamMember(id);
        }

        [HttpPost]
        public void Post(ServiceModel.SprintTeamMember sprintTeamMember)
        {
            service.SetApplicationUserManager(UserManager);
            service.AddSprintTeamMember(sprintTeamMember.SprintId, sprintTeamMember.ProjectTeamMemberId);
        }

        [HttpPut]
        public void Put(string id, ServiceModel.SprintTeamMember sprintTeamMember)
        {
            service.UpdateSprintTeamMember(id, sprintTeamMember);
        }

        [HttpDelete]
        public void Delete(string id)
        {
            service.DeleteSprintTeamMember(id);
        }
    }
}