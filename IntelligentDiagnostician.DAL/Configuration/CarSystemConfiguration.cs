﻿using IntelligentDiagnostician.DataModels.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace IntelligentDiagnostician.DAL.Configuration;

public class CarSystemConfiguration : IEntityTypeConfiguration<CarSystem>
{
    public void Configure(EntityTypeBuilder<CarSystem> builder)
    {
        builder.Property(x=> x.CarSystemName)
            .IsRequired()
            .HasMaxLength(50)
            .HasColumnType("varchar");
    }
}