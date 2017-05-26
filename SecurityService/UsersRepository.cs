using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecurityService
{
    public static class UsersRepository
    {
        public static List<AccountInfo> DummyUserAccounts = new List<AccountInfo> {
            new AccountInfo { Password = "Password", Username = "User1", isMaster=false, isLoggedIn = false },
            new AccountInfo { Password = "Password", Username = "User2", isMaster=false, isLoggedIn = false },
            new AccountInfo { Password = "Password", Username = "MasterUser", isMaster=true, isLoggedIn = false }
        };
    }
}
