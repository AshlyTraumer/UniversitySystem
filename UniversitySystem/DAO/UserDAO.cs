using ClassLibrary;
using ClassLibrary.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UniversitySystem.Models;

namespace UniversitySystem.DAO
{
    public class UserDAO//:DAO<User>
    {
        public RepositoryContext context = new RepositoryContext();
        public IEnumerable<User> Get()
        {
            return context.Users;
        }

        public void Delete(int id)
        {
            User user = context.Users.FirstOrDefault(x => x.Id == id);
            if (user != null)
            {
                if (user.Role != Role.Admin)
                    context.Users.Remove(user);
                context.SaveChanges();
            }
        }

        public User GetById(int id)
        {
            return context.Users.FirstOrDefault(x => x.Id == id);            
        }

        public void Change(User instance)
        {
            User oldUser=context.Users.FirstOrDefault(x => x.Id == instance.Id);
            oldUser.Login = instance.Login;
            oldUser.Password = instance.Password;
            oldUser.Role = instance.Role;
            context.SaveChanges();
        }

        public User Create(UserModel user)
        {
            User newUser = new User()
            {
                Login = user.Login,
                Password = user.Password,
                Role = user.Role
            };            
            context.Users.Add(newUser);
            context.SaveChanges();
            return newUser;
        }
    }
}