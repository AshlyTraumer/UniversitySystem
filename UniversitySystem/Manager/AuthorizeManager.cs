using ClassLibrary;
using ClassLibrary.Authorization;
using System;
using System.Linq;
using UniversitySystem.Models;

namespace UniversitySystem.Manager
{
    public class AuthorizeManager
    {
        private readonly RepositoryContext _context;

        public AuthorizeManager(RepositoryContext context)
        {
            _context = context;
        }

        public Role? Login(LoginModel model)
        {
            var user = _context.Users.Single(x => x.Login == model.Login);

            if (user == null || user.Password != model.Password)
                return null;

            return user.Role;
        }

        public void Register(RegisterModel model)
        {
            var user = new User
            {
                Login = model.Login,
                Password = model.Password,
                Role = model.Role
            };

            _context.Users.Add(user);
            _context.SaveChanges();
        }
    }
}