﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace SIT.Models
{
    public class AuditEntityConfiguration : IEntityTypeConfiguration<AuditEntity>
    {
        public AuditEntityConfiguration()
        {
        }

        public void Configure(EntityTypeBuilder<AuditEntity> builder)
        {
            #region Configuration
            builder.ToTable("Audits");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();
            #endregion
        }
    }
}
