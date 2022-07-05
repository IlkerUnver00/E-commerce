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
    public class OrderMap : EntityTypeConfiguration<Order>
    {
        public OrderMap()
        {
            ToTable(DbCons.Orders.Name, DbCons.Orders.Schema);

            Property(x => x.OrderTotal)
                .HasColumnType("money");

            Property(x => x.OrderNumber)
                .HasMaxLength(20);


            HasMany(x => x.Products)
                .WithMany(x => x.Orders)
                .Map(x =>
                {
                    x.MapLeftKey("OrderId");
                    x.MapRightKey("ProductId");
                    x.ToTable(DbCons.OrderProducts.Name,DbCons.OrderProducts.Schema);
                });
        }
        
    }
}
