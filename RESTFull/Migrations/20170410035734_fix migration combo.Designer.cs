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
    [Migration("20170410035734_fix migration combo")]
    partial class fixmigrationcombo
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
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

                    b.ToTable("MenuItem");
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
