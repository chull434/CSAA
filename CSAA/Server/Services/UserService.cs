using CSAA.DataModels;
using ServiceModel = CSAA.ServiceModels;
using CSAA.Enums;
using Server.App_Data;
using System.Collections.Generic;
using System.Linq;
using Server.Models;

namespace Server.Services
{
    public class UserService : IUserService
    {
        private IRepository<ApplicationUser> repository;
        private IApplicationUserManager UserManager;

        public UserService(IRepository<ApplicationUser> repository)
        {
            this.repository = repository;
        }

        public UserService(IRepository<ApplicationUser> repository, IApplicationUserManager UserManager)
        {
            this.repository = repository;
            this.UserManager = UserManager;
        }

        public List<ServiceModel.User> GetUsers()
        {
            var users = repository.GetAll().Select(p => p.Map()).ToList();
            return users;
        }

        public ServiceModel.User GetUser(string userId)
        {
            var user = repository.GetByID(userId).Map();           
            return user;
        }

        public string CreateUser(ServiceModel.User user)
        {
            var dataUser = new ApplicationUser();
            repository.Insert(dataUser);
            repository.Save();
            return dataUser.Id;
        }

        public void UpdateUser(string userId, ServiceModel.User user)
        {
            var dataUser = repository.GetByID(userId);
            repository.Save();
        }

        public void DeleteUser(string userId)
        {
            repository.Delete(userId);
            repository.Save();
        }

        public void SetApplicationUserManager(IApplicationUserManager applicationUserManager)
        {
            UserManager = applicationUserManager;
        }
    }
}