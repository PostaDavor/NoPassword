using System;
using System.Collections.Generic;
using System.Linq;

namespace SecurityService
{
    public class AccountManager : IAccountManager
    {
        public bool AuthenticateUser(string username, string password)
        {
            var acc = UsersRepository.DummyUserAccounts.FirstOrDefault(x => x.Username == username);

            if(acc!=null && acc.Password == password)
            {
                SetUserIsLoggedIn(acc.Username);
                return true;
            }else
            {
                return false;
            }
        }
        
        public List<AccountInfo> GetAllUsers()
        {
            var retVal = UsersRepository.DummyUserAccounts;
            return retVal;
        }

        private void SetUserIsLoggedIn(string username)
        {
            UsersRepository.DummyUserAccounts.FirstOrDefault(x => x.Username == username).isLoggedIn = true;
        }

        public void SetUserIsLoggedOut(string username)
        {
            UsersRepository.DummyUserAccounts.FirstOrDefault(x => x.Username == username).isLoggedIn = false;
        }

    }
}
