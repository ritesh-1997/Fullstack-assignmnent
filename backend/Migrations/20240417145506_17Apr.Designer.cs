﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using backend.Common.Data;

#nullable disable

namespace backend.Migrations
{
    [DbContext(typeof(Context))]
    [Migration("20240417145506_17Apr")]
    partial class _17Apr
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "8.0.4");

            modelBuilder.Entity("backend.Common.Models.MutualFundOrderTBL", b =>
                {
                    b.Property<int>("orderid")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<double>("amount")
                        .HasColumnType("REAL");

                    b.Property<DateTime>("createdDate")
                        .HasColumnType("TEXT");

                    b.Property<DateTime?>("failedAt")
                        .HasColumnType("TEXT");

                    b.Property<string>("fundName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("orderGuid")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("paymentid")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<double>("pricePerUnit")
                        .HasColumnType("REAL");

                    b.Property<bool>("status")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime?>("succeededAt")
                        .HasColumnType("TEXT");

                    b.Property<double>("units")
                        .HasColumnType("REAL");

                    b.Property<DateTime>("updatedDate")
                        .HasColumnType("TEXT");

                    b.HasKey("orderid");

                    b.ToTable("MutualFundOrderTBL");
                });

            modelBuilder.Entity("backend.Common.Models.PaymentTBL", b =>
                {
                    b.Property<int>("transactionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<double>("amount")
                        .HasColumnType("REAL");

                    b.Property<DateTime>("createdDate")
                        .HasColumnType("TEXT");

                    b.Property<bool>("isTried")
                        .HasColumnType("INTEGER");

                    b.Property<string>("paymentid")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("phoneNumber")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<bool>("status")
                        .HasColumnType("INTEGER");

                    b.Property<string>("strategyName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("updatedDate")
                        .HasColumnType("TEXT");

                    b.Property<string>("utr")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("transactionId");

                    b.ToTable("PaymentTBL");
                });

            modelBuilder.Entity("backend.Common.Models.UserProfileTBL", b =>
                {
                    b.Property<int>("profileId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("phoneNumber")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("profileId");

                    b.ToTable("UserProfileTBL");
                });

            modelBuilder.Entity("backend.Common.Models.UserTBL", b =>
                {
                    b.Property<string>("phoneNumber")
                        .HasColumnType("TEXT");

                    b.HasKey("phoneNumber");

                    b.ToTable("UserTBL");
                });
#pragma warning restore 612, 618
        }
    }
}
