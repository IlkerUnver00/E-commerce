using Eticaret.Datacore.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Eticaret.MVC.Admin.UI.Controllers
{
    public class BaseController : Controller
    {
        protected EticaretDbContext db = new EticaretDbContext();

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}