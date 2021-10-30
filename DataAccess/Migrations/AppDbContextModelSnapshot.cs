﻿// <auto-generated />
using Data.Migrations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Data.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.11")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Data.Model.Brand", b =>
                {
                    b.Property<int>("BrandId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("BrandId");

                    b.ToTable("Brands");
                });

            modelBuilder.Entity("Data.Model.Inventory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.Property<int>("UnitsInStock")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ProductId")
                        .IsUnique();

                    b.ToTable("Inventory");
                });

            modelBuilder.Entity("Data.Model.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ProductDescriptionId")
                        .HasColumnType("int");

                    b.Property<int>("ProductTypesBrandId")
                        .HasColumnType("int");

                    b.Property<int>("QuantityId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ProductDescriptionId");

                    b.HasIndex("ProductTypesBrandId");

                    b.HasIndex("QuantityId");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("Data.Model.ProductDescription", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("ProductDescription");
                });

            modelBuilder.Entity("Data.Model.ProductOrder", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.Property<int>("ShipmentId")
                        .HasColumnType("int");

                    b.Property<int>("Units")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ProductId");

                    b.HasIndex("ShipmentId");

                    b.ToTable("ProductsOrder");
                });

            modelBuilder.Entity("Data.Model.ProductType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Type")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("ProductType");
                });

            modelBuilder.Entity("Data.Model.ProductType_Brand", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("BrandId")
                        .HasColumnType("int");

                    b.Property<int>("ProductTypeId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("BrandId");

                    b.HasIndex("ProductTypeId");

                    b.ToTable("ProductTypesBrand");
                });

            modelBuilder.Entity("Data.Model.Quantity", b =>
                {
                    b.Property<int>("QuantityId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ItemsPerUnit")
                        .HasColumnType("int");

                    b.Property<decimal>("WeightPerUnit")
                        .HasColumnType("decimal(18,4)");

                    b.HasKey("QuantityId");

                    b.ToTable("Quantity");
                });

            modelBuilder.Entity("Data.Model.Shipment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.HasKey("Id");

                    b.ToTable("Shipment");
                });

            modelBuilder.Entity("Data.Model.ShipmentStatus", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Status")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("ShipmentStatus");
                });

            modelBuilder.Entity("Data.Model.Shipment_StatusLog", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("LoggedDate")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ShipmentId")
                        .HasColumnType("int");

                    b.Property<int>("ShipmentStatusId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ShipmentId");

                    b.HasIndex("ShipmentStatusId");

                    b.ToTable("ShipmentStatusLogs");
                });

            modelBuilder.Entity("Data.Model.Inventory", b =>
                {
                    b.HasOne("Data.Model.Product", "Product")
                        .WithOne("Inventory")
                        .HasForeignKey("Data.Model.Inventory", "ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Product");
                });

            modelBuilder.Entity("Data.Model.Product", b =>
                {
                    b.HasOne("Data.Model.ProductDescription", "ProductDescription")
                        .WithMany("Products")
                        .HasForeignKey("ProductDescriptionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Data.Model.ProductType_Brand", "ProductTypesBrand")
                        .WithMany("Product")
                        .HasForeignKey("ProductTypesBrandId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Data.Model.Quantity", "Quantity")
                        .WithMany("Product")
                        .HasForeignKey("QuantityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ProductDescription");

                    b.Navigation("ProductTypesBrand");

                    b.Navigation("Quantity");
                });

            modelBuilder.Entity("Data.Model.ProductOrder", b =>
                {
                    b.HasOne("Data.Model.Product", "Product")
                        .WithMany()
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Data.Model.Shipment", "Shipment")
                        .WithMany("ProductsOrder")
                        .HasForeignKey("ShipmentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Product");

                    b.Navigation("Shipment");
                });

            modelBuilder.Entity("Data.Model.ProductType_Brand", b =>
                {
                    b.HasOne("Data.Model.Brand", "Brand")
                        .WithMany("ProductTypeBrands")
                        .HasForeignKey("BrandId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Data.Model.ProductType", "ProductType")
                        .WithMany("ProductTypesBrand")
                        .HasForeignKey("ProductTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Brand");

                    b.Navigation("ProductType");
                });

            modelBuilder.Entity("Data.Model.Shipment_StatusLog", b =>
                {
                    b.HasOne("Data.Model.Shipment", "Shipment")
                        .WithMany("ShipmentLog")
                        .HasForeignKey("ShipmentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Data.Model.ShipmentStatus", "ShipmentStatus")
                        .WithMany("ShipmentStatusLogs")
                        .HasForeignKey("ShipmentStatusId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Shipment");

                    b.Navigation("ShipmentStatus");
                });

            modelBuilder.Entity("Data.Model.Brand", b =>
                {
                    b.Navigation("ProductTypeBrands");
                });

            modelBuilder.Entity("Data.Model.Product", b =>
                {
                    b.Navigation("Inventory");
                });

            modelBuilder.Entity("Data.Model.ProductDescription", b =>
                {
                    b.Navigation("Products");
                });

            modelBuilder.Entity("Data.Model.ProductType", b =>
                {
                    b.Navigation("ProductTypesBrand");
                });

            modelBuilder.Entity("Data.Model.ProductType_Brand", b =>
                {
                    b.Navigation("Product");
                });

            modelBuilder.Entity("Data.Model.Quantity", b =>
                {
                    b.Navigation("Product");
                });

            modelBuilder.Entity("Data.Model.Shipment", b =>
                {
                    b.Navigation("ProductsOrder");

                    b.Navigation("ShipmentLog");
                });

            modelBuilder.Entity("Data.Model.ShipmentStatus", b =>
                {
                    b.Navigation("ShipmentStatusLogs");
                });
#pragma warning restore 612, 618
        }
    }
}
