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
    public class CustomerMap : EntityTypeConfiguration<Customer>
    {
        public CustomerMap()
        {
            ToTable(DbCons.Customers.Name, DbCons.Customers.Schema);


            Property(x => x.Country)
                .HasMaxLength(100);
                //.IsRequired();

            Property(x => x.Name)
                .HasMaxLength(100);
                //.IsRequired();

            Property(x => x.Surname)
                .HasMaxLength(100);
                //.IsRequired();

            Property(x => x.City)
                .HasMaxLength(100);
                //.IsRequired();

            Property(x => x.Address)
                .HasMaxLength(500);
                //.IsRequired();



            


        }
    }
}
