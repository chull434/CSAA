using CSAA.Models;
using Server.App_Data;
using Server.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Server.Areas.API
{
    public class ProjectController : ApiController
    {
        private ServerDbContext context;
        private ProjectRepository repository;
        private ProjectService service;

        public ProjectController()
        {
            context = new ServerDbContext();
            repository = new ProjectRepository(context);
            service = new ProjectService(repository);
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
        public void Post(Project project)
        {
            service.CreateProject(project);
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