using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;
using ClassLibrary.Authorization;
using UniversitySystem.Core;

namespace UniversitySystem.Manager.Tests
{
    [TestClass()]
    public class AuthorizeManagerTests
    {
        [TestMethod()]
        public void ListConstrTest()
        {
            var list = new List<Role> {Role.Admin, Role.Committee};
            var role = new RoleSetWrapper(list);
            Assert.IsTrue(role.RoleSet == 5);
        }

        [TestMethod()]
        public void IntConstrTest()
        {
            var list = (int) Role.Admin;
            var role = new RoleSetWrapper(list);
            Assert.IsTrue(role.RoleSet == 1);
        }

        [TestMethod()]
        public void GetListTest()
        {
            var list = new List<Role> { Role.Admin, Role.Committee };
            var role = new RoleSetWrapper(list);
            var l = role.Roles;
            Assert.IsTrue(l.Contains(Role.Committee)&& l.Contains(Role.Admin));
        }

        [TestMethod()]
        public void ResetTest()
        {
            var list = new List<Role> { Role.Admin, Role.Committee };
            var role = new RoleSetWrapper(list);
            role.ResetRole(Role.Secretary);
            Assert.IsTrue(role.RoleSet == 5);
            role.ResetRole(Role.Admin);
            Assert.IsTrue(role.RoleSet == 4);
        }

        [TestMethod()]
        public void SetTest()
        {
            var role = new RoleSetWrapper((int) Role.Admin);
            role.SetRole(Role.Admin);
            Assert.IsTrue(role.RoleSet == 1);
            role.SetRole(Role.Secretary);
            Assert.IsTrue(role.RoleSet == 3);
        }

        [TestMethod()]
        public void DescriptionTest()
        {
            string str = Role.Admin.GetDescription();
            Assert.IsTrue(str == "Администратор");
        }
    }
}