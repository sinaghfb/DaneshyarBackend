using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Domain.Entites.TermManagment;

namespace Infrastructure.Mappings.TermManagment
{
    internal class TermCourseMapping : IEntityTypeConfiguration<TermCourse>
    {
        public void Configure(EntityTypeBuilder<TermCourse> builder)
        {
            builder.ToTable("TermCourse");
            builder.HasIndex(p => p.TermCourseNo).IsUnique();
            builder.HasOne(x => x.TheTerm).WithMany(x => x.TermCourseList).OnDelete(DeleteBehavior.Cascade);
            builder.HasOne(x => x.TheCourse).WithMany(x => x.TermCourses).OnDelete(DeleteBehavior.Cascade);

        }
    }
}
