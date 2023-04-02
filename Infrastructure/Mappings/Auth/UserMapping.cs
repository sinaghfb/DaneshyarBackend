using Domain.Entites.BaseInfo;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Domain.Entites.Auth;

namespace Infrastructure.Mappings.Auth
{
    public class UserMapping : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("User");
            builder.HasIndex(p => p.Username).IsUnique();
            builder.HasOne(x=>x.TheRole).WithMany(x=>x.TheUsers).HasForeignKey(x=>x.RoleId).IsRequired();
            builder.HasOne(x => x.ThePerson).WithMany(x => x.TheUsers).HasForeignKey(x => x.PersonId).IsRequired();

        }
    }
}
