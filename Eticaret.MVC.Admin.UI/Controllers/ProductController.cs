using Eticaret.Datacore.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Eticaret.MVC.Admin.UI.Controllers
{
    public class ProductController : Controller
    {
        private EticaretDbContext db = new EticaretDbContext();
        public ActionResult Index()
        {
            return View(db.Products.ToList());
        }

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