﻿// <auto-generated />
using IntelligentDiagnostics.DAL;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace IntelligentDiagnostics.DAL.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20231205124845_init-add-systemcar-table")]
    partial class initaddsystemcartable
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("IntelligentDiagnostics.DataModels.Models.SystemCar", b =>
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