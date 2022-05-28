﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ShoppingAPI.EntityFramework;

#nullable disable

namespace ShoppingAPI.Business.Migrations
{
    [DbContext(typeof(ShoppingDbContext))]
    [Migration("20220528212104_CaseInsensitiveColumns")]
    partial class CaseInsensitiveColumns
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "6.0.5");

            modelBuilder.Entity("ShoppingAPI.EntityFramework.Entities.CustomerEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .UseCollation("NOCASE");

                    b.HasKey("Id");

                    b.ToTable("Customers");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "John"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Mary"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Lucas"
                        });
                });

            modelBuilder.Entity("ShoppingAPI.EntityFramework.Entities.ProductEntity", b =>
                {
                    b.Property<int?>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("ProductCode")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("TEXT")
                        .UseCollation("NOCASE");

                    b.Property<decimal>("ProductPrice")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Products");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            ProductCode = "EAN1",
                            ProductPrice = 99.95m
                        },
                        new
                        {
                            Id = 2,
                            ProductCode = "EAN2",
                            ProductPrice = 16.15m
                        },
                        new
                        {
                            Id = 3,
                            ProductCode = "EAN3",
                            ProductPrice = 12m
                        });
                });

            modelBuilder.Entity("ShoppingAPI.EntityFramework.Entities.SpecificPriceEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int?>("CustomerId")
                        .IsRequired()
                        .HasColumnType("INTEGER");

                    b.Property<decimal>("Price")
                        .HasColumnType("TEXT");

                    b.Property<int?>("ProductId")
                        .IsRequired()
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("CustomerId");

                    b.HasIndex("ProductId");

                    b.ToTable("SpecificPrices");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CustomerId = 1,
                            Price = 95.99m,
                            ProductId = 1
                        },
                        new
                        {
                            Id = 2,
                            CustomerId = 1,
                            Price = 16.15m,
                            ProductId = 2
                        },
                        new
                        {
                            Id = 3,
                            CustomerId = 2,
                            Price = 16.05m,
                            ProductId = 2
                        },
                        new
                        {
                            Id = 4,
                            CustomerId = 2,
                            Price = 9.99m,
                            ProductId = 3
                        },
                        new
                        {
                            Id = 5,
                            CustomerId = 3,
                            Price = 14m,
                            ProductId = 2
                        });
                });

            modelBuilder.Entity("ShoppingAPI.EntityFramework.Entities.SpecificPriceEntity", b =>
                {
                    b.HasOne("ShoppingAPI.EntityFramework.Entities.CustomerEntity", "Customer")
                        .WithMany()
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ShoppingAPI.EntityFramework.Entities.ProductEntity", "Product")
                        .WithMany()
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Customer");

                    b.Navigation("Product");
                });
#pragma warning restore 612, 618
        }
    }
}
