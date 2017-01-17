using ClassLibrary;
using ClassLibrary.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UniversitySystem.Models;

namespace UniversitySystem.Manager
{
    public class AuthorizeManager
    {
        private RepositoryContext context;
        public AuthorizeManager(RepositoryContext context)
        {
            this.context = context;
        }

        public UserModel Login(LoginModel model)
        {
            User user = context.Users.Single(x => x.Login == model.Login);
            if (user?.Password.CompareTo(model.Password) == 0)
            {
                UserModel uModel = new UserModel()
                {
                    Id = user.Id,
                    Login = user.Login,
                    Password = user.Password,
                    Role = user.Role
                };
                return uModel;
            }
            throw new Exception();
        }

        public void Register(RegisterModel model)
        {
            User user = new User()
            {
                Login = model.Login,
                Password = model.Password,
                Role = model.Role
            };
            context.Users.Add(user);
            context.SaveChanges();
        }
    }
}