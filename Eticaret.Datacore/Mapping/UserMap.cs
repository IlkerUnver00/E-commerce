using Eticaret.Domain.Constants;
using Eticaret.Domain.POCO;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eticaret.Datacore.Mapping
{
    public class UserMap : EntityTypeConfiguration<ApplicationUser>
    {
        public UserMap()
        {

            ToTable(DbCons.Users.Name, DbCons.Users.Schema);

            HasKey(x => x.Id);
            Property(x => x.Email).HasMaxLength(100).IsRequired();
            Property(x => x.Password).HasColumnType("nchar").HasMaxLength(64).IsRequired();
            
             
        }
    }
}
