﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ShipService.Infrastructure.Ship.Cqrs.Repository.Sqlite;

namespace ShipService.Infrastructure.Ship.Cqrs.Repository.Sqlite.Migrations.ShipViewModelDb
{
    [DbContext(typeof(ShipViewModelDbContext))]
    [Migration("20210827052232_Initial Migration")]
    partial class InitialMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "5.0.9");

            modelBuilder.Entity("ShipService.ReadSilde.ViewModels.DimensionViewModel", b =>
                {
                    b.Property<Guid>("ViewModelId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT")
                        .HasColumnName("ViewModelId");

                    b.Property<Guid>("DimensionId")
                        .HasColumnType("TEXT")
                        .HasColumnName("DimensionId");

                    b.Property<decimal>("Height")
                        .HasColumnType("TEXT")
                        .HasColumnName("Height");

                    b.Property<Guid?>("ShipViewModelId")
                        .HasColumnType("TEXT");

                    b.Property<string>("Unit")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasColumnName("Unit");

                    b.Property<decimal>("Width")
                        .HasColumnType("TEXT")
                        .HasColumnName("Width");

                    b.HasKey("ViewModelId");

                    b.HasIndex("ShipViewModelId");

                    b.ToTable("DimensionViewModels");

                    b.HasData(
                        new
                        {
                            ViewModelId = new Guid("ec4622fd-a610-4775-b3f0-ce2488f203f2"),
                            DimensionId = new Guid("851b7c67-462e-46d4-8ecf-8c75e53a6602"),
                            Height = 1.1m,
                            ShipViewModelId = new Guid("98a0c57f-2f32-4ec1-b769-2bc4e51c4e37"),
                            Unit = "Meters",
                            Width = 2.2m
                        },
                        new
                        {
                            ViewModelId = new Guid("851b7c67-462e-46d4-8ecf-8c75e53a661d"),
                            DimensionId = new Guid("851b7c67-462e-46d4-8ecf-8c75e53a6603"),
                            Height = 10.1m,
                            ShipViewModelId = new Guid("98a0c57f-2f32-4ec1-b769-2bc4e51c4e37"),
                            Unit = "Feet",
                            Width = 2.2m
                        },
                        new
                        {
                            ViewModelId = new Guid("ec4622fd-a610-4775-b3f0-ce2488f203f3"),
                            DimensionId = new Guid("851b7c67-462e-46d4-8ecf-8c75e53a6602"),
                            Height = 1.1m,
                            ShipViewModelId = new Guid("b308da0e-c000-4a35-8244-793f5699d7e7"),
                            Unit = "Meters",
                            Width = 2.2m
                        },
                        new
                        {
                            ViewModelId = new Guid("851b7c67-462e-46d4-8ecf-8c75e53a661e"),
                            DimensionId = new Guid("851b7c67-462e-46d4-8ecf-8c75e53a6603"),
                            Height = 10.1m,
                            ShipViewModelId = new Guid("b308da0e-c000-4a35-8244-793f5699d7e7"),
                            Unit = "Feet",
                            Width = 2.2m
                        });
                });

            modelBuilder.Entity("ShipService.ReadSilde.ViewModels.ShipViewModel", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT")
                        .HasColumnName("Id");

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasColumnName("Code");

                    b.Property<Guid>("CreatedBy")
                        .HasColumnType("TEXT")
                        .HasColumnName("CreatedBy");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("TEXT")
                        .HasColumnName("CreatedDate");

                    b.Property<bool>("IsMarkedToDelete")
                        .HasColumnType("INTEGER")
                        .HasColumnName("IsMarkedToDelete");

                    b.Property<Guid>("LastUpdatedBy")
                        .HasColumnType("TEXT")
                        .HasColumnName("LastUpdatedBy");

                    b.Property<DateTime>("LastUpdatedDate")
                        .HasColumnType("TEXT")
                        .HasColumnName("LastUpdatedDate");

                    b.Property<string>("RolesAllowedToRead")
                        .HasColumnType("TEXT")
                        .HasColumnName("RolesAllowedToRead");

                    b.Property<Guid>("ShipId")
                        .HasColumnType("TEXT")
                        .HasColumnName("ShipId");

                    b.Property<string>("ShipName")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasColumnName("ShipName");

                    b.Property<int>("Version")
                        .HasColumnType("INTEGER")
                        .HasColumnName("Version");

                    b.HasKey("Id");

                    b.ToTable("ShipViewModels");

                    b.HasData(
                        new
                        {
                            Id = new Guid("98a0c57f-2f32-4ec1-b769-2bc4e51c4e37"),
                            Code = "AAAA-1111-A1",
                            CreatedBy = new Guid("b542ec68-c721-4455-8b04-54e8ca7e8462"),
                            CreatedDate = new DateTime(2021, 8, 27, 5, 22, 31, 455, DateTimeKind.Utc).AddTicks(9986),
                            IsMarkedToDelete = false,
                            LastUpdatedBy = new Guid("570a38d6-c777-495a-9d1f-21174d038a16"),
                            LastUpdatedDate = new DateTime(2021, 8, 27, 5, 22, 31, 455, DateTimeKind.Utc).AddTicks(9999),
                            ShipId = new Guid("851b7c67-462e-46d4-8ecf-8c75e53a6601"),
                            ShipName = "Ship 1",
                            Version = 1
                        },
                        new
                        {
                            Id = new Guid("b308da0e-c000-4a35-8244-793f5699d7e7"),
                            Code = "BBBB-2222-B2",
                            CreatedBy = new Guid("c53a5a8f-8720-4091-83b0-22d65855c274"),
                            CreatedDate = new DateTime(2021, 8, 27, 5, 22, 31, 457, DateTimeKind.Utc).AddTicks(4353),
                            IsMarkedToDelete = false,
                            LastUpdatedBy = new Guid("24245a26-262d-4158-9255-f449438124b8"),
                            LastUpdatedDate = new DateTime(2021, 8, 27, 5, 22, 31, 457, DateTimeKind.Utc).AddTicks(4360),
                            ShipId = new Guid("851b7c67-462e-46d4-8ecf-8c75e53a6601"),
                            ShipName = "Ship 2",
                            Version = 1
                        });
                });

            modelBuilder.Entity("ShipService.ReadSilde.ViewModels.DimensionViewModel", b =>
                {
                    b.HasOne("ShipService.ReadSilde.ViewModels.ShipViewModel", "ShipViewModel")
                        .WithMany("DimensionViewModels")
                        .HasForeignKey("ShipViewModelId");

                    b.Navigation("ShipViewModel");
                });

            modelBuilder.Entity("ShipService.ReadSilde.ViewModels.ShipViewModel", b =>
                {
                    b.Navigation("DimensionViewModels");
                });
#pragma warning restore 612, 618
        }
    }
}
