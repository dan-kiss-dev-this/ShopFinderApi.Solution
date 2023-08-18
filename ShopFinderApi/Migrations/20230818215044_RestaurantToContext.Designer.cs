﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ShopFinderApi.Models;

#nullable disable

namespace ShopFinderApi.Migrations
{
    [DbContext(typeof(ShopFinderApiContext))]
    [Migration("20230818215044_RestaurantToContext")]
    partial class RestaurantToContext
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("ShopFinderApi.Models.Restaurant", b =>
                {
                    b.Property<int>("RestaurantId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("Rating")
                        .HasColumnType("int");

                    b.Property<string>("TypeOfFood")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("RestaurantId");

                    b.ToTable("Restaurants");
                });

            modelBuilder.Entity("ShopFinderApi.Models.Shop", b =>
                {
                    b.Property<int>("ShopId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("Rating")
                        .HasColumnType("int");

                    b.HasKey("ShopId");

                    b.ToTable("Shops");

                    b.HasData(
                        new
                        {
                            ShopId = 1,
                            Description = "Larry's Rock Climbing",
                            Rating = 5
                        },
                        new
                        {
                            ShopId = 2,
                            Description = "DogLand",
                            Rating = 5
                        },
                        new
                        {
                            ShopId = 3,
                            Description = "Paint-topia",
                            Rating = 4
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
