﻿// <auto-generated />
using System;
using IntelligentDiagnostics.DAL.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace IntelligentDiagnostics.DAL.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20240205132021_edit delete behavior for sensors")]
    partial class editdeletebehaviorforsensors
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("IntelligentDiagnostics.DataModels.Models.PrimaryKeyBaseEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CreatedBy")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasMaxLength(21)
                        .HasColumnType("nvarchar(21)");

                    b.Property<int>("ModifiedBy")
                        .HasColumnType("int");

                    b.Property<DateTime>("ModifiedDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("PrimaryKeyBaseEntity");

                    b.HasDiscriminator<string>("Discriminator").HasValue("PrimaryKeyBaseEntity");

                    b.UseTphMappingStrategy();
                });

            modelBuilder.Entity("IntelligentDiagnostics.DataModels.Models.CarSystem", b =>
                {
                    b.HasBaseType("IntelligentDiagnostics.DataModels.Models.PrimaryKeyBaseEntity");

                    b.Property<string>("CarSystemName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar");

                    b.HasDiscriminator().HasValue("CarSystem");
                });

            modelBuilder.Entity("IntelligentDiagnostics.DataModels.Models.Error", b =>
                {
                    b.HasBaseType("IntelligentDiagnostics.DataModels.Models.PrimaryKeyBaseEntity");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("varchar");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasIndex("UserId");

                    b.HasDiscriminator().HasValue("Error");
                });

            modelBuilder.Entity("IntelligentDiagnostics.DataModels.Models.Reading", b =>
                {
                    b.HasBaseType("IntelligentDiagnostics.DataModels.Models.PrimaryKeyBaseEntity");

                    b.Property<int>("CarSystemId")
                        .HasColumnType("int");

                    b.Property<int>("ParameterId")
                        .HasColumnType("int");

                    b.Property<int>("ReadingValue")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasIndex("CarSystemId");

                    b.HasIndex("ParameterId");

                    b.HasIndex("UserId");

                    b.ToTable("PrimaryKeyBaseEntity", t =>
                        {
                            t.Property("UserId")
                                .HasColumnName("Reading_UserId");
                        });

                    b.HasDiscriminator().HasValue("Reading");
                });

            modelBuilder.Entity("IntelligentDiagnostics.DataModels.Models.Role", b =>
                {
                    b.HasBaseType("IntelligentDiagnostics.DataModels.Models.PrimaryKeyBaseEntity");

                    b.Property<string>("RoleName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasDiscriminator().HasValue("Role");
                });

            modelBuilder.Entity("IntelligentDiagnostics.DataModels.Models.Sensor", b =>
                {
                    b.HasBaseType("IntelligentDiagnostics.DataModels.Models.PrimaryKeyBaseEntity");

                    b.Property<int>("CarSystemId")
                        .HasColumnType("int");

                    b.Property<string>("SensorName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar");

                    b.HasIndex("CarSystemId");

                    b.ToTable("PrimaryKeyBaseEntity", t =>
                        {
                            t.Property("CarSystemId")
                                .HasColumnName("Sensor_CarSystemId");
                        });

                    b.HasDiscriminator().HasValue("Sensor");
                });

            modelBuilder.Entity("IntelligentDiagnostics.DataModels.Models.User", b =>
                {
                    b.HasBaseType("IntelligentDiagnostics.DataModels.Models.PrimaryKeyBaseEntity");

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

                    b.Property<int>("RoleId")
                        .HasColumnType("int");

                    b.HasIndex("RoleId");

                    b.HasDiscriminator().HasValue("User");
                });

            modelBuilder.Entity("IntelligentDiagnostics.DataModels.Models.Error", b =>
                {
                    b.HasOne("IntelligentDiagnostics.DataModels.Models.User", "User")
                        .WithMany("Errors")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("IntelligentDiagnostics.DataModels.Models.Reading", b =>
                {
                    b.HasOne("IntelligentDiagnostics.DataModels.Models.CarSystem", "CarSystem")
                        .WithMany("Readings")
                        .HasForeignKey("CarSystemId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("IntelligentDiagnostics.DataModels.Models.Sensor", "Sensor")
                        .WithMany("Readings")
                        .HasForeignKey("ParameterId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("IntelligentDiagnostics.DataModels.Models.User", "User")
                        .WithMany("Readings")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CarSystem");

                    b.Navigation("Sensor");

                    b.Navigation("User");
                });

            modelBuilder.Entity("IntelligentDiagnostics.DataModels.Models.Sensor", b =>
                {
                    b.HasOne("IntelligentDiagnostics.DataModels.Models.CarSystem", "CarSystem")
                        .WithMany("Sensors")
                        .HasForeignKey("CarSystemId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CarSystem");
                });

            modelBuilder.Entity("IntelligentDiagnostics.DataModels.Models.User", b =>
                {
                    b.HasOne("IntelligentDiagnostics.DataModels.Models.Role", "Role")
                        .WithMany("Users")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Role");
                });

            modelBuilder.Entity("IntelligentDiagnostics.DataModels.Models.CarSystem", b =>
                {
                    b.Navigation("Readings");

                    b.Navigation("Sensors");
                });

            modelBuilder.Entity("IntelligentDiagnostics.DataModels.Models.Role", b =>
                {
                    b.Navigation("Users");
                });

            modelBuilder.Entity("IntelligentDiagnostics.DataModels.Models.Sensor", b =>
                {
                    b.Navigation("Readings");
                });

            modelBuilder.Entity("IntelligentDiagnostics.DataModels.Models.User", b =>
                {
                    b.Navigation("Errors");

                    b.Navigation("Readings");
                });
#pragma warning restore 612, 618
        }
    }
}
