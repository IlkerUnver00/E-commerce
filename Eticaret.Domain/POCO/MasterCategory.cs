using Basecore.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eticaret.Domain.POCO
{
    public class MasterCategory : BaseModel
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public ICollection<Category> Categories { get; set; }
    }
}
