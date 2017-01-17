using ClassLibrary;
using ClassLibrary.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UniversitySystem.Models;

namespace UniversitySystem.Manager
{
    public class UserManager//:DAO<User>
    {
        private RepositoryContext context;
        public UserManager(RepositoryContext context)
        {
            this.context = context;
        }

        public IEnumerable<User> Get()
        {
            return context.Users.Select(x => x);
        }

        public void Delete(int id)
        {
            User user = context.Users.Single(x => x.Id == id);
            if (user.Role != Role.Admin)
                context.Users.Remove(user);
            context.SaveChanges();
        }

        public UserModel GetById(int id)
        {
            User user = context.Users.Single(x => x.Id == id);

            UserModel model = new UserModel()
            {
                Id = id,
                Login = user.Login,
                Password = user.Password,
                Role = user.Role
            };
            return model;
        }

        public void Change(UserModel instance)
        {
            User oldUser = context.Users.Single(x => x.Id == instance.Id);
            oldUser.Login = instance.Login;
            oldUser.Password = instance.Password;
            oldUser.Role = instance.Role;
            context.SaveChanges();
        }

        public void Create(UserModel user)
        {
            User newUser = new User()
            {
                Login = user.Login,
                Password = user.Password,
                Role = user.Role
            };
            context.Users.Add(newUser);
            context.SaveChanges();            
        }
    }
}