﻿// <auto-generated />
using System;
using BaoTran.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace BaoTran.Migrations
{
    [DbContext(typeof(MyDbContext))]
    [Migration("20240829133118_DbUpdate2")]
    partial class DbUpdate2
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("BaoTran.Data.FileType", b =>
                {
                    b.Property<int>("IdFileType")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdFileType"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdFileType");

                    b.ToTable("FileTypes");
                });

            modelBuilder.Entity("BaoTran.Data.MediaFile", b =>
                {
                    b.Property<int>("IdMediaFile")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdMediaFile"), 1L, 1);

                    b.Property<string>("Duration")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("File")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FileFormat")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("IdFileType")
                        .HasColumnType("int");

                    b.Property<string>("Musician")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Singer")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdMediaFile");

                    b.HasIndex("IdFileType");

                    b.ToTable("MediaFiles");
                });

            modelBuilder.Entity("BaoTran.Data.PlaySchedual", b =>
                {
                    b.Property<int>("IdPlaySchedual")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdPlaySchedual"), 1L, 1);

                    b.Property<int>("DaysOfWeek")
                        .HasColumnType("int");

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("datetime2");

                    b.Property<TimeSpan>("EndTime")
                        .HasColumnType("time");

                    b.Property<int>("IdMediaFile")
                        .HasColumnType("int");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime2");

                    b.Property<TimeSpan>("StartTime")
                        .HasColumnType("time");

                    b.HasKey("IdPlaySchedual");

                    b.HasIndex("IdMediaFile");

                    b.ToTable("PlayScheduals");
                });

            modelBuilder.Entity("BaoTran.Data.MediaFile", b =>
                {
                    b.HasOne("BaoTran.Data.FileType", "FileType")
                        .WithMany("MediaFiles")
                        .HasForeignKey("IdFileType")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("FileType");
                });

            modelBuilder.Entity("BaoTran.Data.PlaySchedual", b =>
                {
                    b.HasOne("BaoTran.Data.MediaFile", "MediaFile")
                        .WithMany("PlayScheduals")
                        .HasForeignKey("IdMediaFile")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("MediaFile");
                });

            modelBuilder.Entity("BaoTran.Data.FileType", b =>
                {
                    b.Navigation("MediaFiles");
                });

            modelBuilder.Entity("BaoTran.Data.MediaFile", b =>
                {
                    b.Navigation("PlayScheduals");
                });
#pragma warning restore 612, 618
        }
    }
}
