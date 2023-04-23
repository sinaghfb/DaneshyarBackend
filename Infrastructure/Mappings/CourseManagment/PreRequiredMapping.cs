using Domain.Entites.CourseManagment;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Mappings.CourseManagment
{
    internal class PreRequiredMapping : IEntityTypeConfiguration<PreRequired>
    {
        public void Configure(EntityTypeBuilder<PreRequired> builder)
        {
            builder.ToTable("PreRequired");
        
        }
    }
}
