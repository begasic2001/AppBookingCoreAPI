﻿// <auto-generated />
using System;
using LearnAPI.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace LearnAPI.Migrations
{
    [DbContext(typeof(TourDatabaseContext))]
    [Migration("20230312120931_Fix On Delete Cascade")]
    partial class FixOnDeleteCascade
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("LearnAPI.Models.City", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("CityName")
                        .IsRequired()
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("CountryId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("CountryId");

                    b.ToTable("City");
                });

            modelBuilder.Entity("LearnAPI.Models.Country", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("CountryName")
                        .IsRequired()
                        .HasColumnType("nvarchar(255)");

                    b.HasKey("Id");

                    b.ToTable("Country");
                });

            modelBuilder.Entity("LearnAPI.Models.Order", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("DateOrder")
                        .HasColumnType("datetime2");

                    b.Property<double>("Total")
                        .HasColumnType("float");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Order");
                });

            modelBuilder.Entity("LearnAPI.Models.OrderDetail", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("OrderId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<double>("SinglePrice")
                        .HasColumnType("float");

                    b.Property<string>("TourId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("quantity")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("OrderId");

                    b.HasIndex("TourId");

                    b.ToTable("OrderDetail");
                });

            modelBuilder.Entity("LearnAPI.Models.Sight", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("CityId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Picture")
                        .IsRequired()
                        .HasColumnType("nvarchar(255)");

                    b.Property<double>("SightForMoney")
                        .HasColumnType("float");

                    b.Property<string>("SightName")
                        .IsRequired()
                        .HasColumnType("nvarchar(255)");

                    b.HasKey("Id");

                    b.HasIndex("CityId");

                    b.ToTable("Sight");
                });

            modelBuilder.Entity("LearnAPI.Models.Tour", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime?>("EndDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("MaxTourists")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(255)");

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.Property<DateTime?>("StartDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("TransportId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("TransportId");

                    b.ToTable("Tour");
                });

            modelBuilder.Entity("LearnAPI.Models.ToursCities", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("CityId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("TourId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("CityId");

                    b.HasIndex("TourId");

                    b.ToTable("ToursCities");
                });

            modelBuilder.Entity("LearnAPI.Models.ToursSight", b =>
                {
                    b.Property<string>("SightId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("TourId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("SightId", "TourId");

                    b.HasIndex("TourId");

                    b.ToTable("ToursSights");
                });

            modelBuilder.Entity("LearnAPI.Models.Transport", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("TransportName")
                        .IsRequired()
                        .HasColumnType("nvarchar(255)");

                    b.HasKey("Id");

                    b.ToTable("Transport");
                });

            modelBuilder.Entity("LearnAPI.Models.User", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("Avatar")
                        .IsRequired()
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnType("nvarchar(255)");

                    b.HasKey("Id");

                    b.ToTable("User");
                });

            modelBuilder.Entity("LearnAPI.Models.City", b =>
                {
                    b.HasOne("LearnAPI.Models.Country", "Country")
                        .WithMany("Cities")
                        .HasForeignKey("CountryId");

                    b.Navigation("Country");
                });

            modelBuilder.Entity("LearnAPI.Models.Order", b =>
                {
                    b.HasOne("LearnAPI.Models.User", "User")
                        .WithMany("Orders")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("LearnAPI.Models.OrderDetail", b =>
                {
                    b.HasOne("LearnAPI.Models.Order", "Order")
                        .WithMany("OrderDetails")
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("LearnAPI.Models.Tour", "Tour")
                        .WithMany("OrderDetails")
                        .HasForeignKey("TourId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Order");

                    b.Navigation("Tour");
                });

            modelBuilder.Entity("LearnAPI.Models.Sight", b =>
                {
                    b.HasOne("LearnAPI.Models.City", "City")
                        .WithMany("Sights")
                        .HasForeignKey("CityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("City");
                });

            modelBuilder.Entity("LearnAPI.Models.Tour", b =>
                {
                    b.HasOne("LearnAPI.Models.Transport", "Transport")
                        .WithMany("Tours")
                        .HasForeignKey("TransportId");

                    b.Navigation("Transport");
                });

            modelBuilder.Entity("LearnAPI.Models.ToursCities", b =>
                {
                    b.HasOne("LearnAPI.Models.City", "City")
                        .WithMany("ToursCities")
                        .HasForeignKey("CityId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("LearnAPI.Models.Tour", "Tour")
                        .WithMany("ToursCities")
                        .HasForeignKey("TourId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.Navigation("City");

                    b.Navigation("Tour");
                });

            modelBuilder.Entity("LearnAPI.Models.ToursSight", b =>
                {
                    b.HasOne("LearnAPI.Models.Sight", "Sight")
                        .WithMany("ToursSights")
                        .HasForeignKey("SightId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("LearnAPI.Models.Tour", "Tour")
                        .WithMany("ToursSights")
                        .HasForeignKey("TourId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Sight");

                    b.Navigation("Tour");
                });

            modelBuilder.Entity("LearnAPI.Models.City", b =>
                {
                    b.Navigation("Sights");

                    b.Navigation("ToursCities");
                });

            modelBuilder.Entity("LearnAPI.Models.Country", b =>
                {
                    b.Navigation("Cities");
                });

            modelBuilder.Entity("LearnAPI.Models.Order", b =>
                {
                    b.Navigation("OrderDetails");
                });

            modelBuilder.Entity("LearnAPI.Models.Sight", b =>
                {
                    b.Navigation("ToursSights");
                });

            modelBuilder.Entity("LearnAPI.Models.Tour", b =>
                {
                    b.Navigation("OrderDetails");

                    b.Navigation("ToursCities");

                    b.Navigation("ToursSights");
                });

            modelBuilder.Entity("LearnAPI.Models.Transport", b =>
                {
                    b.Navigation("Tours");
                });

            modelBuilder.Entity("LearnAPI.Models.User", b =>
                {
                    b.Navigation("Orders");
                });
#pragma warning restore 612, 618
        }
    }
}
