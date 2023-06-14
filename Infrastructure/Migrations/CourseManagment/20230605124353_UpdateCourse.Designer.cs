﻿// <auto-generated />
using System;
using Infrastructure.Contexts.CourseManagment;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Infrastructure.Migrations.CourseManagment
{
    [DbContext(typeof(CourseContext))]
    [Migration("20230605124353_UpdateCourse")]
    partial class UpdateCourse
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.4")
                .HasAnnotation("Proxies:ChangeTracking", false)
                .HasAnnotation("Proxies:CheckEquality", false)
                .HasAnnotation("Proxies:LazyLoading", true)
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Domain.Entites.Auth.Role", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("CreateDateTime")
                        .IsConcurrencyToken()
                        .HasColumnType("datetime2");

                    b.Property<string>("EnglishTitle")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FarsiTitle")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("State")
                        .HasColumnType("int");

                    b.Property<byte[]>("TimeStamp")
                        .IsConcurrencyToken()
                        .IsRequired()
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("rowversion");

                    b.Property<int>("UserAccessLevel")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Role", (string)null);
                });

            modelBuilder.Entity("Domain.Entites.Auth.User", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("CreateDateTime")
                        .IsConcurrencyToken()
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("HashedPassword")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MobileNo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PersonId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("State")
                        .HasColumnType("int");

                    b.Property<byte[]>("TimeStamp")
                        .IsConcurrencyToken()
                        .IsRequired()
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("rowversion");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("PersonId");

                    b.HasIndex("RoleId");

                    b.HasIndex("Username")
                        .IsUnique();

                    b.ToTable("User", (string)null);
                });

            modelBuilder.Entity("Domain.Entites.BaseInfo.Person", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("CreateDateTime")
                        .IsConcurrencyToken()
                        .HasColumnType("datetime2");

                    b.Property<string>("Family")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FatherName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NationalNo")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<int>("State")
                        .HasColumnType("int");

                    b.Property<byte[]>("TimeStamp")
                        .IsConcurrencyToken()
                        .IsRequired()
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("rowversion");

                    b.HasKey("Id");

                    b.HasIndex("NationalNo")
                        .IsUnique();

                    b.ToTable("Person", (string)null);
                });

            modelBuilder.Entity("Domain.Entites.CourseManagment.Course", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("CourseCode")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CourseName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CourseNo")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("CourseType")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreateDateTime")
                        .IsConcurrencyToken()
                        .HasColumnType("datetime2");

                    b.Property<int>("State")
                        .HasColumnType("int");

                    b.Property<byte[]>("TimeStamp")
                        .IsConcurrencyToken()
                        .IsRequired()
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("rowversion");

                    b.Property<int>("UnitCount")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CourseNo")
                        .IsUnique();

                    b.ToTable("Course", (string)null);
                });

            modelBuilder.Entity("Domain.Entites.CourseManagment.PreRequired", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("CreateDateTime")
                        .IsConcurrencyToken()
                        .HasColumnType("datetime2");

                    b.Property<string>("PreRequiredCourseId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RequiredCourseId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("State")
                        .HasColumnType("int");

                    b.Property<byte[]>("TimeStamp")
                        .IsConcurrencyToken()
                        .IsRequired()
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("rowversion");

                    b.HasKey("Id");

                    b.HasIndex("PreRequiredCourseId");

                    b.HasIndex("RequiredCourseId");

                    b.ToTable("PreRequired", (string)null);
                });

            modelBuilder.Entity("Domain.Entites.TermManagment.Term", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("CreateDateTime")
                        .IsConcurrencyToken()
                        .HasColumnType("datetime2");

                    b.Property<int>("EndYear")
                        .HasColumnType("int");

                    b.Property<int>("StartYear")
                        .HasColumnType("int");

                    b.Property<int>("State")
                        .HasColumnType("int");

                    b.Property<int>("TermCount")
                        .HasColumnType("int");

                    b.Property<string>("TermNo")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("TermTitle")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<byte[]>("TimeStamp")
                        .IsConcurrencyToken()
                        .IsRequired()
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("rowversion");

                    b.HasKey("Id");

                    b.HasIndex("TermNo")
                        .IsUnique();

                    b.ToTable("Term", (string)null);
                });

            modelBuilder.Entity("Domain.Entites.TermManagment.TermCourse", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Capacity")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CourseId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("CreateDateTime")
                        .IsConcurrencyToken()
                        .HasColumnType("datetime2");

                    b.Property<int>("Day")
                        .HasColumnType("int");

                    b.Property<string>("EndHour")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("EntraceYear")
                        .HasColumnType("int");

                    b.Property<int>("ExamDate")
                        .HasColumnType("int");

                    b.Property<string>("ExamEndHour")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ExamStartHour")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Location")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("StartHour")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("State")
                        .HasColumnType("int");

                    b.Property<string>("TeacherName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TermCourseNo")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("TermId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<byte[]>("TimeStamp")
                        .IsConcurrencyToken()
                        .IsRequired()
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("rowversion");

                    b.HasKey("Id");

                    b.HasIndex("CourseId");

                    b.HasIndex("TermCourseNo")
                        .IsUnique();

                    b.HasIndex("TermId");

                    b.ToTable("TermCourse", (string)null);
                });

            modelBuilder.Entity("Domain.Entites.Auth.User", b =>
                {
                    b.HasOne("Domain.Entites.BaseInfo.Person", "ThePerson")
                        .WithMany("TheUsers")
                        .HasForeignKey("PersonId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Entites.Auth.Role", "TheRole")
                        .WithMany("TheUsers")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ThePerson");

                    b.Navigation("TheRole");
                });

            modelBuilder.Entity("Domain.Entites.CourseManagment.PreRequired", b =>
                {
                    b.HasOne("Domain.Entites.CourseManagment.Course", "PreRequiredCourse")
                        .WithMany("PreRequireds")
                        .HasForeignKey("PreRequiredCourseId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("Domain.Entites.CourseManagment.Course", "RequiredCourse")
                        .WithMany("Requireds")
                        .HasForeignKey("RequiredCourseId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("PreRequiredCourse");

                    b.Navigation("RequiredCourse");
                });

            modelBuilder.Entity("Domain.Entites.TermManagment.TermCourse", b =>
                {
                    b.HasOne("Domain.Entites.CourseManagment.Course", "TheCourse")
                        .WithMany("TermCourses")
                        .HasForeignKey("CourseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Entites.TermManagment.Term", "TheTerm")
                        .WithMany("TermCourseList")
                        .HasForeignKey("TermId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("TheCourse");

                    b.Navigation("TheTerm");
                });

            modelBuilder.Entity("Domain.Entites.Auth.Role", b =>
                {
                    b.Navigation("TheUsers");
                });

            modelBuilder.Entity("Domain.Entites.BaseInfo.Person", b =>
                {
                    b.Navigation("TheUsers");
                });

            modelBuilder.Entity("Domain.Entites.CourseManagment.Course", b =>
                {
                    b.Navigation("PreRequireds");

                    b.Navigation("Requireds");

                    b.Navigation("TermCourses");
                });

            modelBuilder.Entity("Domain.Entites.TermManagment.Term", b =>
                {
                    b.Navigation("TermCourseList");
                });
#pragma warning restore 612, 618
        }
    }
}
