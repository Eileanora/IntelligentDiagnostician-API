﻿using IntelligentDiagnostics.DataModels.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace IntelligentDiagnostics.DAL.Configuration;

public class ReadingConfiguration : IEntityTypeConfiguration<Reading>
{
    public void Configure(EntityTypeBuilder<Reading> builder)
    {
        // builder.HasKey(x => x.UserId);
        // builder.HasKey(x => x.CarSystemId);
        // builder.HasKey(x => x.ParameterId);
        // builder.HasKey(x => x.CreatedDate);
        builder.Property(x => x.ReadingValue)
               .IsRequired();

        builder.HasOne(x => x.Sensor)
           .WithMany(x => x.Readings)
           .HasForeignKey(x => x.SensorId).IsRequired()
           .OnDelete(DeleteBehavior.Cascade);
        
        builder.HasOne(x => x.User)
           .WithMany(x => x.Readings)
           .HasForeignKey(x => x.UserId).IsRequired()
           .OnDelete(DeleteBehavior.Cascade);
    }
}
