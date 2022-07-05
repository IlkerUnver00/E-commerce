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
    public class ModuleMap : EntityTypeConfiguration<Module>
    {
        public ModuleMap()
        {

            ToTable(DbCons.Modules.Name, DbCons.Modules.Schema);

            Property(x => x.Name)
                .HasMaxLength(100)
                .IsRequired();

            Property(x => x.Description)
                .HasMaxLength(500)
                .IsOptional();

        }
    }
}
