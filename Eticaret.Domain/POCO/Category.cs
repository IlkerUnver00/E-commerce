using Basecore.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eticaret.Domain.POCO
{
    public class Category : BaseModel
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public ICollection<Product> Products { get; set; }

        public int MasterCategoryId { get; set; }
        public MasterCategory MasterCategory { get; set; }
    }
}
