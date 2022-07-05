using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Eticaret.MVC.UI.Models.DTO
{
    public class ProductFilterModel
    {
        public int SelectedCategoryId { get; set; }

        public decimal MaxPrice { get; set; }

        public decimal MinPrice { get; set; }
    }
}