using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using RESTFull;
using RESTFull.Models;

namespace RESTFull.Migrations
{
    [DbContext(typeof(Db))]
    [Migration("20170507021606_Tags implemented")]
    partial class Tagsimplemented
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.1");

            modelBuilder.Entity("RESTFull.Models.Combo", b =>
                {
                    b.Property<int>("ComboId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ComboDescription")
                        .IsRequired();

                    b.Property<decimal?>("ComboPrice");

                    b.HasKey("ComboId");

                    b.ToTable("Combos");
                });

            modelBuilder.Entity("RESTFull.Models.ComboItem", b =>
                {
                    b.Property<int>("MenuItemId");

                    b.Property<int>("ComboId");

                    b.HasKey("MenuItemId", "ComboId");

                    b.HasAlternateKey("ComboId", "MenuItemId");

                    b.ToTable("ComboItems");
                });

            modelBuilder.Entity("RESTFull.Models.Discount", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Description")
                        .IsRequired();

                    b.Property<decimal>("DiscountPercentage");

                    b.HasKey("Id");

                    b.ToTable("Discounts");
                });

            modelBuilder.Entity("RESTFull.Models.MenuItem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("Calories");

                    b.Property<int?>("DiscountId");

                    b.Property<string>("Name")
                        .IsRequired();

                    b.Property<decimal>("Price");

                    b.Property<int>("Type");

                    b.HasKey("Id");

                    b.HasIndex("DiscountId");

                    b.ToTable("MenuItems");
                });

            modelBuilder.Entity("RESTFull.Models.StoreDetails", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ABN");

                    b.Property<string>("AddressCity");

                    b.Property<string>("AddressCountry");

                    b.Property<string>("AddressPostCode");

                    b.Property<string>("AddressState");

                    b.Property<string>("AddressStreet");

                    b.Property<string>("AddressSuburb");

                    b.Property<string>("Name")
                        .IsRequired();

                    b.Property<string>("PhoneNumber");

                    b.Property<string>("Proprietor");

                    b.HasKey("Id");

                    b.ToTable("StoreDetails");
                });

            modelBuilder.Entity("RESTFull.Models.Tag", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("MenuName");

                    b.Property<string>("TagName")
                        .IsRequired();

                    b.HasKey("Id");

                    b.ToTable("Tags");
                });

            modelBuilder.Entity("RESTFull.Models.MenuItem", b =>
                {
                    b.HasOne("RESTFull.Models.Discount", "Discount")
                        .WithMany()
                        .HasForeignKey("DiscountId");
                });
        }
    }
}
