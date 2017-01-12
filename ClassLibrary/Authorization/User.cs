﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary.Authorization
{
    public enum Role { Admin, Secretary, Committee, Entrant}
    public class User
    {
        public int Id { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public Role Role { get; set; }
    }
}
