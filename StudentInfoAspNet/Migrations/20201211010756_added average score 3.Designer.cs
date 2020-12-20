﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using StudentInfoAspNet.Models;

namespace StudentInfoAspNet.Migrations
{
    [DbContext(typeof(StudentInfoContext))]
    [Migration("20201211010756_added average score 3")]
    partial class addedaveragescore3
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("StudentInfoAspNet.Models.Groups", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id")
                        .HasColumnType("int(11)");

                    b.Property<double>("AverageScore")
                        .HasColumnName("average_score")
                        .HasColumnType("double");

                    b.Property<string>("CuratorFamily")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasColumnName("curator_family")
                        .HasColumnType("varchar(20)")
                        .HasDefaultValueSql("''")
                        .HasMaxLength(20);

                    b.Property<string>("Title")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasColumnName("title")
                        .HasColumnType("varchar(20)")
                        .HasDefaultValueSql("''")
                        .HasMaxLength(20);

                    b.Property<string>("TitleDirection")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasColumnName("title_direction")
                        .HasColumnType("varchar(20)")
                        .HasDefaultValueSql("''")
                        .HasMaxLength(20);

                    b.HasKey("Id");

                    b.ToTable("groups");
                });

            modelBuilder.Entity("StudentInfoAspNet.Models.Students", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id")
                        .HasColumnType("int(11)");

                    b.Property<double>("AverageScore")
                        .HasColumnName("average_score")
                        .HasColumnType("double");

                    b.Property<int>("GroupId")
                        .HasColumnName("group_id")
                        .HasColumnType("int(11)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasColumnName("last_name")
                        .HasColumnType("varchar(20)")
                        .HasDefaultValueSql("'0'")
                        .HasMaxLength(20);

                    b.Property<string>("Name")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasColumnName("name")
                        .HasColumnType("varchar(20)")
                        .HasDefaultValueSql("'0'")
                        .HasMaxLength(20);

                    b.Property<string>("SecondName")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasColumnName("second_name")
                        .HasColumnType("varchar(20)")
                        .HasDefaultValueSql("'0'")
                        .HasMaxLength(20);

                    b.HasKey("Id");

                    b.HasIndex("GroupId")
                        .HasName("FK1");

                    b.ToTable("students");
                });

            modelBuilder.Entity("StudentInfoAspNet.Models.Students", b =>
                {
                    b.HasOne("StudentInfoAspNet.Models.Groups", "Group")
                        .WithMany("Students")
                        .HasForeignKey("GroupId")
                        .HasConstraintName("FK1")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
