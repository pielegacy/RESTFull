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
    [Migration("20170410040642_Using kevin's system")]
    partial class Usingkevinssystem
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

            modelBuilder.Entity("RESTFull.Models.ComboItem", b =>
                {
                    b.HasOne("RESTFull.Models.Combo", "Combo")
                        .WithMany()
                        .HasForeignKey("ComboId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("RESTFull.Models.MenuItem", "MenuItem")
                        .WithMany()
                        .HasForeignKey("MenuItemId")
                        .OnDelete(DeleteBehavior.Cascade);
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
