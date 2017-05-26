using System;
using System.Collections.Generic;
using System.Text;

namespace SecurityService
{
    public interface IAccountManager
    {
        bool AuthenticateUser(string username, string password);

        List<AccountInfo> GetAllUsers();

        void SetUserIsLoggedOut(string username);
    }
}
