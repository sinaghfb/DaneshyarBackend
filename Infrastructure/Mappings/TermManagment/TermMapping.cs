using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Domain.Entites.TermManagment;

namespace Infrastructure.Mappings.TermManagment
{
    internal class TermMapping : IEntityTypeConfiguration<Term>
    {
        public void Configure(EntityTypeBuilder<Term> builder)
        {
            builder.ToTable("Term");
            builder.HasIndex(p => p.TermNo).IsUnique();
            builder.HasMany(x => x.TermCourseList).WithOne(x => x.TheTerm).OnDelete(DeleteBehavior.Cascade);

        }
    }
}
