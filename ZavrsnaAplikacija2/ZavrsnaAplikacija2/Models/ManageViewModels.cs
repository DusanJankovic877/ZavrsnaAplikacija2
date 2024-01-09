using Microsoft.AspNet.Identity;
using Microsoft.AspNetCore.Http.Authentication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ZavrsnaAplikacija2.Models
{
    public class ManageViewModels
    {
        public class IndexViewModel
        {
            public bool HasPassword { get; set; }
            public IList<UserLoginInfo> Logins { get; set; }
            public bool BrowserRemembered;
        }

        public class ManageLoginsViewModel
        {
            public IList<UserLoginInfo> CurrentLogins { get; set; }
            public IList<AuthenticationDescription> OtherLogins { get; set; }
        }
        public class FactoryViewModel
        {
            public string Purpose { get; set; }
        }
    }
}