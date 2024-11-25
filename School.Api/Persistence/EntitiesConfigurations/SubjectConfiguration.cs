using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using School.Api.Entities;

namespace School.Api.Persistence.EntitiesConfigurations
{
    public class SubjectConfiguration : IEntityTypeConfiguration<Subject>
    {
        public void Configure(EntityTypeBuilder<Subject> builder)
        {
            builder.HasOne(s => s.Grade)
                .WithMany(g => g.Subjects)
                .HasForeignKey(s => s.GradeId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}