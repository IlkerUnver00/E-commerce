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
    public class MasterCategoryMap : EntityTypeConfiguration<MasterCategory>
    {
        public MasterCategoryMap()
        {

            ToTable(DbCons.MasterCategories.Name, DbCons.MasterCategories.Schema);
            Property(x => x.Name)
                .HasMaxLength(100)
                .IsRequired();

            Property(x => x.Description)
                .HasMaxLength(500)
                .IsOptional();



            HasMany(x => x.Categories)
                .WithRequired(x => x.MasterCategory)
                .HasForeignKey(x => x.MasterCategoryId)
                .WillCascadeOnDelete(false);

        }
    }
}
