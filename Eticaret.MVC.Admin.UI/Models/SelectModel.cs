using Eticaret.Domain.POCO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Eticaret.MVC.Admin.UI.Models
{
    public class SelectModel<T>
    {
        public T Model { get; set; }
        public bool Selected { get; set; }
    }
}