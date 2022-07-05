using Basecore.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eticaret.Domain.POCO
{
    public class ApplicationUser : BaseModel
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string FullName { get; set; }

        public ICollection<Role> Roles { get; set; }


        //public static bool operator ==(ApplicationUser p1, ApplicationUser p2)
        //{
        //    return (p1.Email == p2.Email) && (p1.FullName == p2.FullName) && (p1.Id == p2.Id) && (p1.IsActive == p2.IsActive);
        //}

        //public static bool operator !=(ApplicationUser p1, ApplicationUser p2)
        //{
        //    return true;
        //}
        //public override bool Equals(object obj)
        //{
        //    return base.Equals(obj);
        //}
    }
}
