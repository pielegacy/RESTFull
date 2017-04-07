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
    partial class DbModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.1");

            modelBuilder.Entity("RESTFull.Models.Discount", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Description")
                        .IsRequired();

                    b.Property<decimal>("DiscountPercentage");

                    b.Property<int>("MenuItemId");

                    b.HasKey("Id");

                    b.HasIndex("MenuItemId");

                    b.ToTable("Discounts");
                });

            modelBuilder.Entity("RESTFull.Models.MenuItem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("Calories");

                    b.Property<string>("Name")
                        .IsRequired();

                    b.Property<decimal>("Price");

                    b.Property<int>("Type");

                    b.HasKey("Id");

                    b.ToTable("MenuItems");
                });

            modelBuilder.Entity("RESTFull.Models.Discount", b =>
                {
                    b.HasOne("RESTFull.Models.MenuItem", "Item")
                        .WithMany()
                        .HasForeignKey("MenuItemId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
        }
    }
}
