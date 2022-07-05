using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Eticaret.MVC.UI
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            routes.MapMvcAttributeRoutes();
            ////https://www.sitem.com/Home/Index/3/toplama
            ////https://www.sitem.com/home
            //routes.MapRoute(
            //    name: "Default",
            //    url: "{controller}/{action}/{id}/{islem}",
            //    defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            //);

            //routes.MapRoute("rtMath1", "math/{islem}/{sayi1}/{sayi2}", new { controller = "Math", action = "Index" });
            //routes.MapRoute("rtMath2", "redirected", new { controller = "Math", action = "Redirected" });

            routes.MapRoute("rtMain", "home", new { controller = "Home", action = "Index" });
            routes.MapRoute("rtMain2", "", new { controller = "Home", action = "Index" });



            routes.MapRoute("rtLoadCart", "loadcart", new { controller = "Home", action = "LoadCart" });

            routes.MapRoute("rtProfile", "profile", new { controller = "Profile", action = "Index" });

            routes.MapRoute("rtAddToBasket", "addtobasket", new { controller = "Product", action = "AddToBasket" });
            routes.MapRoute("rtAddToBasket2", "addtobasket2", new { controller = "Product", action = "AddToBasket2" });

            routes.MapRoute("rtSingle", "product/single/{productid}", new { controller = "Product", action = "SingleProduct" });


            routes.MapRoute("rtCategory", "products", new { controller = "Category", action = "Index" });
            routes.MapRoute("rtSetCategory", "products/{productid}", new { controller = "Category",action="SetCategory" });
        }
    }
}
