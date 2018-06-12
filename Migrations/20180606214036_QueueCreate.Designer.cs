﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using QueueSystemRazor.Data;

namespace QueueSystemRazor.Migrations
{
    [DbContext(typeof(QueueContext))]
    [Migration("20180606214036_QueueCreate")]
    partial class QueueCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.0-rtm-30799");

            modelBuilder.Entity("QueueSystemRazor.Models.Member", b =>
                {
                    b.Property<int>("MemberId")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("Age");

                    b.Property<string>("Email");

                    b.Property<bool>("IsMember");

                    b.Property<string>("Name");

                    b.Property<string>("PhoneNo");

                    b.HasKey("MemberId");

                    b.ToTable("Member");
                });

            modelBuilder.Entity("QueueSystemRazor.Models.QueueEntry", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("IsDone");

                    b.Property<int>("MemberId");

                    b.Property<DateTime>("StartTime");

                    b.HasKey("Id");

                    b.HasIndex("MemberId");

                    b.ToTable("QueueEntry");
                });

            modelBuilder.Entity("QueueSystemRazor.Models.QueueEntry", b =>
                {
                    b.HasOne("QueueSystemRazor.Models.Member", "Member")
                        .WithMany()
                        .HasForeignKey("MemberId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}