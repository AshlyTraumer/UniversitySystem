using System;
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
            RoleSet = 0;
            foreach (var role in roles)
            {
                RoleSet  |= (int)role;
            }

        }

        public IEnumerable<Role> Roles
        {
            get
            {
                var role = (Role)RoleSet;
                return Enum.GetValues(typeof(Role))
                            .Cast<Role>()
                            .Where(s => role.HasFlag(s));
                //return Enumerable.Empty<Role>(); //TODO delete and implement
            }
        }

        public void SetRole(Role role)
        {
            RoleSet |= (int) role;
        }

        public void ResetRole(Role role)
        {
            RoleSet &= ~(int) role;
        }
    }

    public static class RoleExtensions
    {
        public static string GetDescription(this Role role)
        {
            var field = role.GetType().GetField(role.ToString());
            var attribute = Attribute.GetCustomAttribute(field, typeof(System.ComponentModel.DescriptionAttribute)) as System.ComponentModel.DescriptionAttribute;
            return attribute == null ? role.ToString() : attribute.Description;
        }
    }
}