using CSAA.Models;
using Server.App_Data;
using Server.Services;
using System.Collections.Generic;
using System.Web.Http;
using Microsoft.AspNet.Identity;

namespace Server.Areas.API
{
    [Authorize]
    public class ProjectController : ApiController
    {
        private ServerDbContext context;
        private IRepository<Project> repository;
        private IProjectService service;

        public ProjectController()
        {
            context = new ServerDbContext();
            repository = new ProjectRepository(context);
            service = new ProjectService(repository);
        }

        public ProjectController(IRepository<Project> repository, IProjectService service)
        {
            this.repository = repository;
            this.service = service;
        }

        // GET api/<controller>
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
        public void Post(Project project)
        {
            service.CreateProject(project, User.Identity.GetUserId());
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