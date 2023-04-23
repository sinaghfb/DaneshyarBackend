using Domain.Entites.CourseManagment;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Mappings.CourseManagment
{
    internal class CourseMapping : IEntityTypeConfiguration<Course>
    {
        public void Configure(EntityTypeBuilder<Course> builder)
        {
            builder.ToTable("Course");
            builder.HasIndex(p => p.CourseNo).IsUnique();
            builder.HasMany(x => x.PreRequireds).WithOne(x => x.PreRequiredCourse).OnDelete(DeleteBehavior.NoAction);
            builder.HasMany(x => x.Requireds).WithOne(x => x.RequiredCourse).OnDelete(DeleteBehavior.NoAction);

        }
    }
}
