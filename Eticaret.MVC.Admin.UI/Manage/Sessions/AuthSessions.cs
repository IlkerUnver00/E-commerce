using Eticaret.Domain.POCO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Eticaret.MVC.Admin.UI.Manage.Sessions
{
    public class AuthSessions
    {
        public static int SelectedRoleId
        {
            get
            {
                var session = HttpContext.Current.Session["SelectedRoleId"];
                if (session !=null)
                {
                    return Convert.ToInt32(session);
                }
                return 0;
            }
            set { HttpContext.Current.Session.Add("SelectedRoleId", value); }
        }

    }
}