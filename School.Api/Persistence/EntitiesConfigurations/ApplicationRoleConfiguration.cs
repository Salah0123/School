using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using School.Api.Abstractions.Consts;
using School.Api.Entities;

namespace School.Api.Persistence.EntitiesConfigurations
{
    public class ApplicationRoleConfiguration : IEntityTypeConfiguration<ApplicationRole>
    {
        public void Configure(EntityTypeBuilder<ApplicationRole> builder)
        {
            //defaultData

            //builder.HasData(new ApplicationRole
            //{ 
            //    Id = 
            //});
        }
        
    }
}