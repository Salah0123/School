/*using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using School.Api.Entities;

namespace School.Api.Persistence.EntitiesConfigurations
{
    public class SubjectConfiguration : IEntityTypeConfiguration<Subject>
    {
        public void Configure(EntityTypeBuilder<Subject> builder)
        {
            builder.HasIndex(x => x.SubjectName).IsUnique();
            builder.Property(x => x.SubjectName).HasMaxLength(100);
        }
    }
}*/