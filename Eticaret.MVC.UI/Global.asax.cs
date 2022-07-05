using Ninject.Web.Common.WebHost;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using Ninject;
using Eticaret.Infrastructure.Modules;
using Eticaret.MVC.UI.Manage;

namespace Eticaret.MVC.UI
{
    public class MvcApplication : NinjectHttpApplication
    {

        protected override void OnApplicationStarted()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            base.OnApplicationStarted();
        }
        protected override IKernel CreateKernel()
        {
            IoCHelper.Kernel = new StandardKernel(new RepositoryModule());
            return IoCHelper.Kernel;
        }
    }
}
