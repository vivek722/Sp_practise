using Domain.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SP.EF.Configration
{
    public class SkillConfigration : IEntityTypeConfiguration<SkillEntity>
    {
        public void Configure(EntityTypeBuilder<SkillEntity> builder)
        {
            builder.HasKey(u => u.id);
            builder.Property(u => u.CreateAT);
            builder.Property(u => u.UpdateAt);
            builder.Property(u => u.IsDelete);
            builder.Property(u => u.IsActive);
            builder.Property(u => u.Skillname).IsRequired().HasMaxLength(100);
            builder.ToTable("skill");

           //builder.HasOne(u => u.Employee).WithMany(x => x.skills).HasForeignKey(x => x.Empid).OnDelete(DeleteBehavior.Restrict);
        }
    }
}
