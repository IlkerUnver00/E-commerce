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
    public class RoleMap : EntityTypeConfiguration<Role>
    {
        public RoleMap()
        {
            ToTable(DbCons.Roles.Name, DbCons.Roles.Schema);

            Property(x => x.Name)
                .HasMaxLength(100)
                .IsRequired();

            Property(x => x.Description)
                .HasMaxLength(500)
                .IsOptional();


            HasMany(x => x.Users)
                .WithMany(x => x.Roles)
                .Map(x =>
                {
                    x.MapLeftKey("RoleId");
                    x.MapRightKey("UserId");
                    x.ToTable(DbCons.UserRoles.Name, DbCons.UserRoles.Schema);
                });

            HasMany(x => x.Modules)
                .WithMany(x => x.Roles)
                .Map(x =>
                {
                    x.MapLeftKey("RoleId");
                    x.MapRightKey("ModuleId");
                    x.ToTable(DbCons.RoleModules.Name, DbCons.RoleModules.Schema);
                });

        }
    }
}
