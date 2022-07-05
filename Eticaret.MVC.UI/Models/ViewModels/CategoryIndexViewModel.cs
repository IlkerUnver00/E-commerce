using Eticaret.Domain.POCO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Eticaret.MVC.UI.Models.ViewModels
{
    public class CategoryIndexViewModel
    {
        public List<Product> Products { get; set; }

        public List<Product> TopProducts { get; set; }

        public List<MasterCategory> Categories { get; set; }
    }
}