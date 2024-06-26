﻿// <auto-generated />
using IntelligentDiagnostics.EFCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace IntelligentDiagnostics.EFCore.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("IntelligentDiagnostics.Core.Models.SystemCar", b =>
                {
                    b.Property<int>("SystemCarId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("SystemCarId"));

                    b.Property<string>("SystemCarName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("SystemCarId");

                    b.ToTable("systemCars");
                });
#pragma warning restore 612, 618
        }
    }
}
