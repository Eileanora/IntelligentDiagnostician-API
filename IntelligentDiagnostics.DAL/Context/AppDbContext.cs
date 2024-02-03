﻿using IntelligentDiagnostics.DAL.Configuration;
using IntelligentDiagnostics.DataModels.Models;
using Microsoft.EntityFrameworkCore;

namespace IntelligentDiagnostics.DAL.Context;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options):base(options) 
    {
    }

    public AppDbContext()
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder); 
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ErrorConfiguration).Assembly);
    }
    DbSet<CarSystem> SystemCars {  get; set; }    
    DbSet<User> Users { get; set; }
    DbSet<Reading> Readings { get; set; } 
    DbSet<Sensor> Parameters { get; set; }
    DbSet<Error> Errors { get; set; }
}
