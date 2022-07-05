using Basecore.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eticaret.Domain.POCO
{
    public class Customer : BaseModel
    {
        public string IpAddress { get; set; }
        public string Key { get; set; }
        public string Email { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public int? UserId { get; set; }
        public ApplicationUser User { get; set; }
    }
}
