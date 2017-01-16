using ClassLibrary;
using ClassLibrary.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UniversitySystem.Models;

namespace UniversitySystem.DAO
{
    public class AuthorizeDAO
    {
        public RepositoryContext context = new RepositoryContext();
        public User Login (LoginModel model)
        {
            User user = context.Users.FirstOrDefault(x => x.Login == model.Login);
            if (user?.Password.CompareTo(model.Password) == 0)
            {
                return user;
            }
            return null;
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