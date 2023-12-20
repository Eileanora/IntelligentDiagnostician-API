﻿// <auto-generated />
using System;
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
    [Migration("20231217104654_add completed database")]
    partial class addcompleteddatabase
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("IntelligentDiagnostics.DataModels.Models.Error", b =>
                {
                    b.Property<int>("ErrorId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ErrorId"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("varchar");

                    b.Property<DateTime>("ErrorDateTime")
                        .HasColumnType("datetime2");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("ErrorId");

                    b.HasIndex("UserId");

                    b.ToTable("errors");
                });

            modelBuilder.Entity("IntelligentDiagnostics.DataModels.Models.Parameter", b =>
                {
                    b.Property<int>("ParameterId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ParameterId"));

                    b.Property<string>("ParameterName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar");

                    b.HasKey("ParameterId");

                    b.ToTable("parameters");
                });

            modelBuilder.Entity("IntelligentDiagnostics.DataModels.Models.Reading", b =>
                {
                    b.Property<int>("ReadingId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ReadingId"));

                    b.Property<int>("ParameterId")
                        .HasColumnType("int");

                    b.Property<DateTime>("ReadingDateTime")
                        .HasColumnType("datetime2");

                    b.Property<int>("ReadingValue")
                        .HasColumnType("int");

                    b.Property<int>("SystemCarId")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("ReadingId");

                    b.HasIndex("ParameterId");

                    b.HasIndex("SystemCarId");

                    b.HasIndex("UserId");

                    b.ToTable("readings");
                });

            modelBuilder.Entity("IntelligentDiagnostics.DataModels.Models.SystemCar", b =>
                {
                    b.Property<int>("SystemCarId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("SystemCarId"));

                    b.Property<string>("SystemCarName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar");

                    b.HasKey("SystemCarId");

                    b.ToTable("systemCars");
                });

            modelBuilder.Entity("IntelligentDiagnostics.DataModels.Models.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("UserId"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Fname")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Lname")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId");

                    b.ToTable("users");
                });

            modelBuilder.Entity("IntelligentDiagnostics.DataModels.Models.Error", b =>
                {
                    b.HasOne("IntelligentDiagnostics.DataModels.Models.User", "User")
                        .WithMany("errors")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("IntelligentDiagnostics.DataModels.Models.Reading", b =>
                {
                    b.HasOne("IntelligentDiagnostics.DataModels.Models.Parameter", "Parameter")
                        .WithMany("Readings")
                        .HasForeignKey("ParameterId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("IntelligentDiagnostics.DataModels.Models.SystemCar", "SystemCar")
                        .WithMany("Readings")
                        .HasForeignKey("SystemCarId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("IntelligentDiagnostics.DataModels.Models.User", "User")
                        .WithMany("Readings")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Parameter");

                    b.Navigation("SystemCar");

                    b.Navigation("User");
                });

            modelBuilder.Entity("IntelligentDiagnostics.DataModels.Models.Parameter", b =>
                {
                    b.Navigation("Readings");
                });

            modelBuilder.Entity("IntelligentDiagnostics.DataModels.Models.SystemCar", b =>
                {
                    b.Navigation("Readings");
                });

            modelBuilder.Entity("IntelligentDiagnostics.DataModels.Models.User", b =>
                {
                    b.Navigation("Readings");

                    b.Navigation("errors");
                });
#pragma warning restore 612, 618
        }
    }
}
