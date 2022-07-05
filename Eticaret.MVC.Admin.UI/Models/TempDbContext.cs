using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using Eticaret.Domain.POCO;

namespace Eticaret.MVC.Admin.UI.Models
{
    public class TempDbContext : DbContext
    {
        public TempDbContext() : base("name=tempdb")
        {

        }
        

    }
    
}