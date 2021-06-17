﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WebCoreRepositorio;

namespace WebCoreRepositorio.Migrations
{
    [DbContext(typeof(PersistDbContext))]
    [Migration("20210617032115_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.4-rtm-31024")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("WebCoreRepositorio.DBModel.Caminhao", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<short>("AnoFabricacao");

                    b.Property<short>("AnoModelo");

                    b.Property<short>("Modelo");

                    b.Property<string>("Nome")
                        .HasMaxLength(100);

                    b.HasKey("ID");

                    b.ToTable("Caminhao");
                });
#pragma warning restore 612, 618
        }
    }
}