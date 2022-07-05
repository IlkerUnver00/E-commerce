using Basecore.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eticaret.Domain.POCO
{
    public class Basket : BaseModel
    {
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }
        public string ProductId { get; set; }
        public Product Product { get; set; }
    }
}
