using CSAA.DataModels;
using Microsoft.AspNet.Identity;
using Server.App_Data;
using Server.Services;
using System.Collections.Generic;
using System.Net.Http;
using System.Web.Http;
using Microsoft.AspNet.Identity.Owin;
using Server.Models;
using ServiceModel = CSAA.ServiceModels;

namespace Server.Areas.API
{
    [Authorize]
    public class UserController : ApiController
    {
        private ServerDbContext context;
        private IRepository<ApplicationUser> repository;
        private IUserService service;

        private IApplicationUserManager _userManager;
        public IApplicationUserManager UserManager
        {
            get => _userManager ?? Request.GetOwinContext().GetUserManager<ApplicationUserManager>();
            set => _userManager = value;
        }

        public UserController()
        {
            context = new ServerDbContext();
            repository = new UserRepository(context);
            service = new UserService(repository);
        }

        public UserController(IUserService service)
        {
            this.service = service;
        }

        [HttpGet]
        public List<ServiceModel.User> Get()
        {
            service.SetApplicationUserManager(UserManager);
            return service.GetUsers();
        }

        [HttpGet]
        public ServiceModel.User Get(string id)
        {
            service.SetApplicationUserManager(UserManager);
            return service.GetUser(id);
        }

        [HttpPost]
        public string Post(ServiceModel.User user)
        {
            return service.CreateUser(user);
        }

        [HttpPut]
        public void Put(string id, ServiceModel.User user)
        {
            service.UpdateUser(id, user);
        }

        [HttpDelete]
        public void Delete(string id)
        {
            service.DeleteUser(id);
        }
    }
}