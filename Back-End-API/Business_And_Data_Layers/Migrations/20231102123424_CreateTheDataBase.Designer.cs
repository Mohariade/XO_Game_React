﻿// <auto-generated />
using System;
using Business_And_Data_Layers.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Business_And_Data_Layers.Migrations
{
    [DbContext(typeof(DataLayer))]
    [Migration("20231102123424_CreateTheDataBase")]
    partial class CreateTheDataBase
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.13")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Business_And_Data_Layers.Models.Game", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("Game_Id");

                    b.Property<string>("Board")
                        .IsRequired()
                        .HasMaxLength(9)
                        .HasColumnType("nvarchar(9)");

                    b.Property<Guid>("Player1_Id")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("Player1_Id");

                    b.Property<Guid>("Player2_Id")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("Player2_Id");

                    b.Property<Guid>("PlayerTurn_Id")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("PlayerTurn_Id");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Games");
                });
#pragma warning restore 612, 618
        }
    }
}
