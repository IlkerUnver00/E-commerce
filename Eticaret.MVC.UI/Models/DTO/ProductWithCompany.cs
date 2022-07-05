using Eticaret.Domain.POCO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Eticaret.MVC.UI.Models.DTO
{
    public class ProductWithCompany
    {
        public string CompanyName { get; set; }

        public Product Product { get; set; }
    }
}