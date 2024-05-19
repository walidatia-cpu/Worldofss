﻿// <auto-generated />
using CV_Manager.DAL.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace CV_Manager.DAL.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20240519184700_init")]
    partial class init
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.30")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("CV_Manager.Core.Entities.CV", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("Experience_Information_Id")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Personal_Information_Id")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("Experience_Information_Id")
                        .IsUnique();

                    b.HasIndex("Personal_Information_Id")
                        .IsUnique();

                    b.ToTable("CVs");
                });

            modelBuilder.Entity("CV_Manager.Core.Entities.ExperienceInformation", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("City")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CompanyField")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CompanyName")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.HasKey("Id");

                    b.ToTable("ExperienceInformations");
                });

            modelBuilder.Entity("CV_Manager.Core.Entities.PersonalInformation", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("CityName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MobileNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("PersonalInformations");
                });

            modelBuilder.Entity("CV_Manager.Core.Entities.CV", b =>
                {
                    b.HasOne("CV_Manager.Core.Entities.ExperienceInformation", "ExperienceInformation")
                        .WithOne("CV")
                        .HasForeignKey("CV_Manager.Core.Entities.CV", "Experience_Information_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CV_Manager.Core.Entities.PersonalInformation", "PersonalInformation")
                        .WithOne("CV")
                        .HasForeignKey("CV_Manager.Core.Entities.CV", "Personal_Information_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ExperienceInformation");

                    b.Navigation("PersonalInformation");
                });

            modelBuilder.Entity("CV_Manager.Core.Entities.ExperienceInformation", b =>
                {
                    b.Navigation("CV")
                        .IsRequired();
                });

            modelBuilder.Entity("CV_Manager.Core.Entities.PersonalInformation", b =>
                {
                    b.Navigation("CV")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}