﻿// <auto-generated />
using BulkyWeb_1._0.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace BulkyWeb_1._0.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20230504104044_b4")]
    partial class b4
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("BulkyWeb_1._0.Models.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("DisplayOrder")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Categories");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            DisplayOrder = 1,
                            Name = "Action"
                        },
                        new
                        {
                            Id = 2,
                            DisplayOrder = 2,
                            Name = "Comedy"
                        },
                        new
                        {
                            Id = 3,
                            DisplayOrder = 3,
                            Name = "Thriller"
                        },
                        new
                        {
                            Id = 4,
                            DisplayOrder = 4,
                            Name = "Romance"
                        });
                });

            modelBuilder.Entity("BulkyWeb_1._0.Models.QList", b =>
                {
                    b.Property<int>("Question_ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Question_ID"));

                    b.Property<string>("Correst_Answer")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Question")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("WrongAnswer_1")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("WrongAnswer_2")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("WrongAnswer_3")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Question_ID");

                    b.ToTable("QuestionList");

                    b.HasData(
                        new
                        {
                            Question_ID = 2,
                            Correst_Answer = "King Charles III",
                            Question = "King Of England",
                            WrongAnswer_1 = "King Charles II",
                            WrongAnswer_2 = "King Charles I",
                            WrongAnswer_3 = "King Charles IV"
                        },
                        new
                        {
                            Question_ID = 3,
                            Correst_Answer = "50",
                            Question = "How many states are there in USA",
                            WrongAnswer_1 = "51",
                            WrongAnswer_2 = "49",
                            WrongAnswer_3 = "52"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
