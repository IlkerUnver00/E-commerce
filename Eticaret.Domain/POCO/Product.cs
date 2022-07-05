using Basecore.Model;
using Eticaret.Domain.Constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eticaret.Domain.POCO
{
    public class Product : BaseModel
    {

        public Product()
        {
            Id = Guid.NewGuid().ToString();
        }
        public new string Id { get; set; }

        public string Name { get; set; }

        public string Image { get; set; }

        public decimal UnitPrice { get; set; }

        public string Description { get; set; }

        public UnitType UnitType { get; set; }

        public int Quantity { get; set; }



        public int CategoryId { get; set; }
        public Category Category { get; set; }


        public ICollection<Order> Orders { get; set; }

    }
}
