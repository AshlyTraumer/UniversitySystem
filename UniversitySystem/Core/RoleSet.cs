using System.Collections.Generic;
using System.Linq;
using ClassLibrary.Authorization;

namespace UniversitySystem.Core
{
    //TODO изменить значения в Role (1, 2, 4, ...), написать юнит тесты
    public struct RoleSetWrapper
    {
        public int RoleSet { get; private set; }

        public RoleSetWrapper(int roleSet = 0)
        {
            RoleSet = roleSet;
        }

        public RoleSetWrapper(IEnumerable<Role> roles)
        {
            RoleSet = 0; //TODO delete and implement
        }

        public IEnumerable<Role> Roles
        {
            get
            {
                return Enumerable.Empty<Role>(); //TODO delete and implement
            }
        }

        public void SetRole(Role role)
        {
            //TODO
        }

        public void ResetRole(Role role)
        {
            //TODO
        }
    }

    public static class RoleExtensions
    {
        public static string GetDescription(this Role role)
        {
            return string.Empty; //TODO delete & implement
        }
    }
}