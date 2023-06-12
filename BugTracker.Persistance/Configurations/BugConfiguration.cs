using BugTracker.Domain.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BugTracker.Persistance.Configurations
{
    public class BugConfiguration : IEntityTypeConfiguration<Bug>
    {
        public void Configure(EntityTypeBuilder<Bug> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x=> x.Name).HasMaxLength(300).IsRequired();
            builder.Property(x=> x.Environment).IsRequired();
            builder.Property(x=> x.Description).IsRequired();
        }
    }
}
