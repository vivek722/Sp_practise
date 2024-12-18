using Domain.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SP.EF.Configration
{
    public class EmployeeConfigration : IEntityTypeConfiguration<EmployeeEntity>
    {
        public void Configure(EntityTypeBuilder<EmployeeEntity> builder)
        {
            builder.ToTable("employee");
            builder.HasKey(u => u.id);
            builder.Property(u => u.CreateAT);
            builder.Property(u => u.UpdateAt);
            builder.Property(u => u.IsDelete);
            builder.Property(u => u.IsActive);
            builder.Property(u => u.name).IsRequired().HasMaxLength(100);
            builder.Property(u => u.age).IsRequired().HasMaxLength(200);
            builder.Property(u => u.mno).IsRequired().HasMaxLength(200);
            builder.Property(u => u.emailid).IsRequired().HasMaxLength(200);
            builder.Property(u => u.image).IsRequired().HasMaxLength(200);
        }
    }
}
