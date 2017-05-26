using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using Microsoft.AspNet.SignalR;

namespace Presentation
{
    public class SignalRManagerHub : Hub
    {
        public void LogOutUser(string userName)
        {
            Clients.All.checkLogOut(userName);
        }
    }
}