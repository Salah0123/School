using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using School.Api.Entities;

namespace School.Api.Persistence.EntitiesConfigurations
{
    public class GradeConfiguration : IEntityTypeConfiguration<Grade>
    {
        public void Configure(EntityTypeBuilder<Grade> builder)
        {
            builder.HasOne(g => g.Level)
                .WithMany(l => l.Grades)
                .HasForeignKey(g => g.LevelId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
