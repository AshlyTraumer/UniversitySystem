using ClassLibrary;
using ClassLibrary.Authorization;
using System.Collections.Generic;
using System.Linq;
using UniversitySystem.Core.Exceptions;
using UniversitySystem.Models;

namespace UniversitySystem.Manager
{
    public class UserManager
    {
        private readonly RepositoryContext _context;

        public UserManager(RepositoryContext context)
        {
            _context = context;
        }

        public IEnumerable<UserModel> Get()
        {
            var uModel = _context.Users.Select(x => new UserModel
            {
                Id = x.Id,
                Login = x.Login,
                Password = x.Password,
                Role = x.Role
            }).ToList();

            return uModel;
        }

        public void Delete(int id)
        {
            var user = _context.Users.Single(x => x.Id == id);

            if (user.Role != Role.Admin)
            {
                _context.Users.Remove(user);
                _context.SaveChanges();
            }

            throw new UniversalException("Admin can't be removed");
        }

        public UserModel GetById(int id)
        {
            var user = _context.Users.Single(x => x.Id == id);

            var model = new UserModel
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
            var oldUser = _context.Users.Single(x => x.Id == instance.Id);

            oldUser.Login = instance.Login;
            oldUser.Password = instance.Password;
            oldUser.Role = instance.Role;

            _context.SaveChanges();
        }

        public void Create(UserModel user)
        {
            var newUser = new User
            {
                Login = user.Login,
                Password = user.Password,
                Role = user.Role
            };

            _context.Users.Add(newUser);
            _context.SaveChanges();
        }
    }
}