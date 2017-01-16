using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary.Authorization
{
    public enum Role
    {
        [Description("Администратор")]
        Admin =1,
        [Description("Секретарь")]
        Secretary =2,
        [Description("Комиссия")]
        Committee =3,
        [Description("Абитуриент")]
        Entrant =4
    }
    public class User
    {
        public int Id { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public Role Role { get; set; }
    }
}
