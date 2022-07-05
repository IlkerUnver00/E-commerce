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
    public class ProductMap : EntityTypeConfiguration<Product>
    {
        public ProductMap()
        {

            ToTable(DbCons.Products.Name, DbCons.Products.Schema);
            Property(x => x.Name)
                .HasMaxLength(100)
                .IsRequired();

            Property(x => x.Description)
                .HasMaxLength(500)
                .IsOptional();


            Property(x => x.Image)
                .HasMaxLength(500)
                .IsRequired();

            Property(x => x.UnitPrice)
                .HasColumnType("money");
       
        }

    }
}
