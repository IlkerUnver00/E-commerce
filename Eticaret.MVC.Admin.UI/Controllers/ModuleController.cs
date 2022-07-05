using Eticaret.Domain.POCO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Eticaret.MVC.Admin.UI.Controllers
{
    public class ModuleController : BaseController
    {
        // GET: Module
        public ActionResult Index()
        {
            return View(db.Modules.ToList());
        }
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
        [HttpPost]
        public ActionResult AddModule(string modName,string modDesc)
        {

            Dictionary<string, object> result = new Dictionary<string, object>();
            try
            {
                if (!string.IsNullOrWhiteSpace(modName) || !string.IsNullOrWhiteSpace(modDesc))
                {
                    var modul = db.Modules.Add(new Module
                    {
                        Name = modName,
                        Description = modDesc
                    });
                    if (db.SaveChanges() > 0)
                    {
                        result.Add("status", true);
                        result.Add("data", modul);
                        result.Add("message", "");
                    }
                    else
                    {
                        result.Add("status", false);
                        result.Add("data", null);
                        result.Add("message", "Unknow error");
                    }
                }
                else
                {
                    result.Add("status", false);
                    result.Add("data", null);
                    result.Add("message", "All fields are required");
                }
            }
            catch (Exception ex)
            {
                result.Add("status", false);
                result.Add("data", null);
                result.Add("message", ex.Message);
            }
            return Json(result);
        }
    }
}