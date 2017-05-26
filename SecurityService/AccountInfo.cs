using System;
using System.Collections.Generic;
using System.Text;

namespace SecurityService
{
    public class AccountInfo
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public bool isMaster { get; set; }
        public bool isLoggedIn { get; set; }
    }
}
