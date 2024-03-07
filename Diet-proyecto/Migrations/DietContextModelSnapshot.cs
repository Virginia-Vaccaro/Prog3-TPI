﻿// <auto-generated />
using System;
using Diet_proyecto.DBContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Diet_proyecto.Migrations
{
    [DbContext(typeof(DietContext))]
    partial class DietContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "6.0.5");

            modelBuilder.Entity("Diet_proyecto.Entities.ItemOrder", b =>
                {
                    b.Property<int>("ItemOrderId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("Cantidad")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("OrderId")
                        .IsRequired()
                        .HasColumnType("INTEGER");

                    b.Property<float>("PriceCalc")
                        .HasColumnType("REAL");

                    b.Property<int>("ProductId")
                        .HasColumnType("INTEGER");

                    b.HasKey("ItemOrderId");

                    b.HasIndex("OrderId");

                    b.HasIndex("ProductId");

                    b.ToTable("Items");
                });

            modelBuilder.Entity("Diet_proyecto.Entities.Order", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("ClientId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("PaymentStatus")
                        .HasColumnType("INTEGER");

                    b.Property<int>("StatusType")
                        .HasColumnType("INTEGER");

                    b.Property<float>("TotalPrice")
                        .HasColumnType("REAL");

                    b.HasKey("Id");

                    b.HasIndex("ClientId");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("Diet_proyecto.Entities.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("TEXT");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Img")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<DateTime?>("LastModificationDate")
                        .HasColumnType("TEXT");

                    b.Property<float>("Price")
                        .HasColumnType("REAL");

                    b.Property<int>("StatusType")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("Diet_proyecto.Entities.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("DNI")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("UserType")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Users");

                    b.HasDiscriminator<string>("UserType").HasValue("User");
                });

            modelBuilder.Entity("Diet_proyecto.Entities.Admin", b =>
                {
                    b.HasBaseType("Diet_proyecto.Entities.User");

                    b.HasDiscriminator().HasValue("Admin");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Address = "calle 123",
                            DNI = 35131301,
                            Email = "vir.vaccaro@gmail.com",
                            LastName = "Vaccaro",
                            Name = "Virginia",
                            Password = "123vir",
                            PhoneNumber = "11223344",
                            UserName = "Vir"
                        });
                });

            modelBuilder.Entity("Diet_proyecto.Entities.Client", b =>
                {
                    b.HasBaseType("Diet_proyecto.Entities.User");

                    b.Property<int?>("OrderId")
                        .HasColumnType("INTEGER");

                    b.HasIndex("OrderId");

                    b.HasDiscriminator().HasValue("Client");

                    b.HasData(
                        new
                        {
                            Id = 2,
                            Address = "calle 456",
                            DNI = 11333444,
                            Email = "lr@gmail.com",
                            LastName = "Ramon",
                            Name = "Lucy",
                            Password = "123LR",
                            PhoneNumber = "11223366",
                            UserName = "Lura"
                        });
                });

            modelBuilder.Entity("Diet_proyecto.Entities.Salesman", b =>
                {
                    b.HasBaseType("Diet_proyecto.Entities.User");

                    b.HasDiscriminator().HasValue("Salesman");

                    b.HasData(
                        new
                        {
                            Id = 3,
                            Address = "calle 456",
                            DNI = 11333222,
                            Email = "facu@gmail.com",
                            LastName = "Bargut",
                            Name = "Facundo",
                            Password = "123facu",
                            PhoneNumber = "11223355",
                            UserName = "Facu"
                        });
                });

            modelBuilder.Entity("Diet_proyecto.Entities.ItemOrder", b =>
                {
                    b.HasOne("Diet_proyecto.Entities.Order", "Order")
                        .WithMany("Items")
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Diet_proyecto.Entities.Product", "Product")
                        .WithMany()
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Order");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("Diet_proyecto.Entities.Order", b =>
                {
                    b.HasOne("Diet_proyecto.Entities.Client", "Client")
                        .WithMany("Orders")
                        .HasForeignKey("ClientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Client");
                });

            modelBuilder.Entity("Diet_proyecto.Entities.Client", b =>
                {
                    b.HasOne("Diet_proyecto.Entities.Order", null)
                        .WithMany("Clients")
                        .HasForeignKey("OrderId");
                });

            modelBuilder.Entity("Diet_proyecto.Entities.Order", b =>
                {
                    b.Navigation("Clients");

                    b.Navigation("Items");
                });

            modelBuilder.Entity("Diet_proyecto.Entities.Client", b =>
                {
                    b.Navigation("Orders");
                });
#pragma warning restore 612, 618
        }
    }
}
