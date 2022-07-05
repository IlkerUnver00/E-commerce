using Eticaret.Domain.POCO;
using Eticaret.MVC.UI.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Eticaret.MVC.UI.Models.ViewModels
{
    public class HomeIndexViewModel
    {
        public List<Product> NewArrivals { get; set; }

        public List<Product> BestSellers { get; set; }

        public List<Product> Featured { get; set; }

        public List<ProductWithCompany> Products { get; set; }
    }
}