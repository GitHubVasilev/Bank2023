﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Persistence;

#nullable disable

namespace Persistence.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20230731203113_init1")]
    partial class init1
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.5");

            modelBuilder.Entity("Bank.Domain.Account", b =>
                {
                    b.Property<Guid>("UID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("Guid");

                    b.Property<Guid?>("ClientId")
                        .HasColumnType("TEXT");

                    b.Property<decimal>("CountMonetaryUnit")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("DateOpen")
                        .HasColumnType("TEXT");

                    b.Property<bool>("IsClose")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("IsLock")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("Procent")
                        .HasColumnType("INTEGER");

                    b.Property<Guid>("TypeAccountId")
                        .HasColumnType("Guid");

                    b.HasKey("UID");

                    b.HasIndex("TypeAccountId");

                    b.ToTable("Accounts", (string)null);
                });

            modelBuilder.Entity("Bank.Domain.Customer", b =>
                {
                    b.Property<Guid>("UID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("Guid");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("TEXT");

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasMaxLength(256)
                        .HasColumnType("TEXT");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Passport")
                        .HasColumnType("TEXT");

                    b.Property<string>("Patronymic")
                        .HasColumnType("TEXT");

                    b.Property<string>("Telephone")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("TEXT");

                    b.Property<string>("UpdatedBy")
                        .HasMaxLength(256)
                        .HasColumnType("TEXT");

                    b.HasKey("UID");

                    b.ToTable("Customers", (string)null);
                });

            modelBuilder.Entity("Bank.Domain.TypeAccount", b =>
                {
                    b.Property<Guid>("UID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("Guid");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("UID");

                    b.ToTable("TypeAccounts", (string)null);
                });

            modelBuilder.Entity("Bank.Domain.Account", b =>
                {
                    b.HasOne("Bank.Domain.TypeAccount", "TypeAccount")
                        .WithMany()
                        .HasForeignKey("TypeAccountId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("TypeAccount");
                });
#pragma warning restore 612, 618
        }
    }
}
