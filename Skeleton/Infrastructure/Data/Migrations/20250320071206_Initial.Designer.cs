﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Skeleton.Infrastructure.Data;

#nullable disable

namespace Skeleton.Infrastructure.Data.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20250320071206_Initial")]
    partial class Initial
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.13")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);

                    b.HasData(
                        new
                        {
                            UserId = "98fee139-00a1-4da6-ad61-92998e41264a",
                            RoleId = "61c697cb-ed25-4685-9030-45693a0ce433"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("Skeleton.Domain.Entities.CountryEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasMaxLength(3)
                        .HasColumnType("nvarchar(3)");

                    b.Property<DateTime?>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("UpdatedBy")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("CreatedBy");

                    b.HasIndex("UpdatedBy");

                    b.ToTable("Countries");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Code = "USA",
                            Name = "United States"
                        },
                        new
                        {
                            Id = 2,
                            Code = "CAN",
                            Name = "Canada"
                        },
                        new
                        {
                            Id = 3,
                            Code = "GBR",
                            Name = "United Kingdom"
                        },
                        new
                        {
                            Id = 4,
                            Code = "AUS",
                            Name = "Australia"
                        },
                        new
                        {
                            Id = 5,
                            Code = "IND",
                            Name = "India"
                        },
                        new
                        {
                            Id = 6,
                            Code = "DEU",
                            Name = "Germany"
                        },
                        new
                        {
                            Id = 7,
                            Code = "FRA",
                            Name = "France"
                        },
                        new
                        {
                            Id = 8,
                            Code = "ITA",
                            Name = "Italy"
                        },
                        new
                        {
                            Id = 9,
                            Code = "ESP",
                            Name = "Spain"
                        },
                        new
                        {
                            Id = 10,
                            Code = "JPN",
                            Name = "Japan"
                        },
                        new
                        {
                            Id = 11,
                            Code = "CHN",
                            Name = "China"
                        },
                        new
                        {
                            Id = 12,
                            Code = "BRA",
                            Name = "Brazil"
                        },
                        new
                        {
                            Id = 13,
                            Code = "MEX",
                            Name = "Mexico"
                        },
                        new
                        {
                            Id = 14,
                            Code = "RUS",
                            Name = "Russia"
                        },
                        new
                        {
                            Id = 15,
                            Code = "ZAF",
                            Name = "South Africa"
                        },
                        new
                        {
                            Id = 16,
                            Code = "KOR",
                            Name = "South Korea"
                        },
                        new
                        {
                            Id = 17,
                            Code = "ARG",
                            Name = "Argentina"
                        },
                        new
                        {
                            Id = 18,
                            Code = "SAU",
                            Name = "Saudi Arabia"
                        },
                        new
                        {
                            Id = 19,
                            Code = "TUR",
                            Name = "Turkey"
                        },
                        new
                        {
                            Id = 20,
                            Code = "NLD",
                            Name = "Netherlands"
                        },
                        new
                        {
                            Id = 21,
                            Code = "SWE",
                            Name = "Sweden"
                        },
                        new
                        {
                            Id = 22,
                            Code = "NOR",
                            Name = "Norway"
                        },
                        new
                        {
                            Id = 23,
                            Code = "DNK",
                            Name = "Denmark"
                        },
                        new
                        {
                            Id = 24,
                            Code = "FIN",
                            Name = "Finland"
                        },
                        new
                        {
                            Id = 25,
                            Code = "CHE",
                            Name = "Switzerland"
                        },
                        new
                        {
                            Id = 26,
                            Code = "AUT",
                            Name = "Austria"
                        },
                        new
                        {
                            Id = 27,
                            Code = "BEL",
                            Name = "Belgium"
                        },
                        new
                        {
                            Id = 28,
                            Code = "PRT",
                            Name = "Portugal"
                        },
                        new
                        {
                            Id = 29,
                            Code = "POL",
                            Name = "Poland"
                        },
                        new
                        {
                            Id = 30,
                            Code = "GRC",
                            Name = "Greece"
                        },
                        new
                        {
                            Id = 31,
                            Code = "IRL",
                            Name = "Ireland"
                        },
                        new
                        {
                            Id = 32,
                            Code = "NZL",
                            Name = "New Zealand"
                        },
                        new
                        {
                            Id = 33,
                            Code = "SGP",
                            Name = "Singapore"
                        },
                        new
                        {
                            Id = 34,
                            Code = "THA",
                            Name = "Thailand"
                        },
                        new
                        {
                            Id = 35,
                            Code = "IDN",
                            Name = "Indonesia"
                        },
                        new
                        {
                            Id = 36,
                            Code = "MYS",
                            Name = "Malaysia"
                        },
                        new
                        {
                            Id = 37,
                            Code = "PHL",
                            Name = "Philippines"
                        },
                        new
                        {
                            Id = 38,
                            Code = "VNM",
                            Name = "Vietnam"
                        },
                        new
                        {
                            Id = 39,
                            Code = "EGY",
                            Name = "Egypt"
                        },
                        new
                        {
                            Id = 40,
                            Code = "NGA",
                            Name = "Nigeria"
                        });
                });

            modelBuilder.Entity("Skeleton.Domain.Entities.ItemCategoryEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime?>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Description")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("UpdatedBy")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("CreatedBy");

                    b.HasIndex("UpdatedBy");

                    b.ToTable("ItemCategories");
                });

            modelBuilder.Entity("Skeleton.Domain.Entities.ItemEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime?>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ItemCategoryId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("UpdatedBy")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("CreatedBy");

                    b.HasIndex("ItemCategoryId");

                    b.HasIndex("UpdatedBy");

                    b.ToTable("Items");
                });

            modelBuilder.Entity("Skeleton.Domain.Entities.RoleEntity", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles", (string)null);

                    b.HasData(
                        new
                        {
                            Id = "61c697cb-ed25-4685-9030-45693a0ce433",
                            Name = "Admin",
                            NormalizedName = "ADMIN"
                        });
                });

            modelBuilder.Entity("Skeleton.Domain.Entities.UserEntity", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers", (string)null);

                    b.HasData(
                        new
                        {
                            Id = "98fee139-00a1-4da6-ad61-92998e41264a",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "e48a48ed-9b58-495f-93e3-6a215f34cac7",
                            Email = "technicaltest@test.com",
                            EmailConfirmed = true,
                            LockoutEnabled = false,
                            NormalizedEmail = "technicaltest@test.com",
                            NormalizedUserName = "technicaltest@test.com",
                            PasswordHash = "AQAAAAIAAYagAAAAEDuHD3CxCAly/itS4p8g7QcnMhWviKU8GDllnobFAhIs+KbaR0BD6qikRPKgcFzcUA==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "ac45eba8-b6e8-4c9a-a4a2-cb2f16463c81",
                            TwoFactorEnabled = false,
                            UserName = "technicaltest@test.com"
                        });
                });

            modelBuilder.Entity("Skeleton.Domain.Entities.UserNotificationEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Body")
                        .IsRequired()
                        .HasMaxLength(5000)
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<bool>("Read")
                        .HasColumnType("bit");

                    b.Property<string>("Subject")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("UserNotifications");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Skeleton.Domain.Entities.RoleEntity", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Skeleton.Domain.Entities.UserEntity", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Skeleton.Domain.Entities.UserEntity", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Skeleton.Domain.Entities.RoleEntity", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Skeleton.Domain.Entities.UserEntity", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Skeleton.Domain.Entities.UserEntity", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Skeleton.Domain.Entities.CountryEntity", b =>
                {
                    b.HasOne("Skeleton.Domain.Entities.UserEntity", "CreatedUser")
                        .WithMany()
                        .HasForeignKey("CreatedBy");

                    b.HasOne("Skeleton.Domain.Entities.UserEntity", "UpdatedUser")
                        .WithMany()
                        .HasForeignKey("UpdatedBy");

                    b.Navigation("CreatedUser");

                    b.Navigation("UpdatedUser");
                });

            modelBuilder.Entity("Skeleton.Domain.Entities.ItemCategoryEntity", b =>
                {
                    b.HasOne("Skeleton.Domain.Entities.UserEntity", "CreatedUser")
                        .WithMany()
                        .HasForeignKey("CreatedBy");

                    b.HasOne("Skeleton.Domain.Entities.UserEntity", "UpdatedUser")
                        .WithMany()
                        .HasForeignKey("UpdatedBy");

                    b.Navigation("CreatedUser");

                    b.Navigation("UpdatedUser");
                });

            modelBuilder.Entity("Skeleton.Domain.Entities.ItemEntity", b =>
                {
                    b.HasOne("Skeleton.Domain.Entities.UserEntity", "CreatedUser")
                        .WithMany()
                        .HasForeignKey("CreatedBy");

                    b.HasOne("Skeleton.Domain.Entities.ItemCategoryEntity", "ItemCategory")
                        .WithMany("Items")
                        .HasForeignKey("ItemCategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Skeleton.Domain.Entities.UserEntity", "UpdatedUser")
                        .WithMany()
                        .HasForeignKey("UpdatedBy");

                    b.Navigation("CreatedUser");

                    b.Navigation("ItemCategory");

                    b.Navigation("UpdatedUser");
                });

            modelBuilder.Entity("Skeleton.Domain.Entities.UserNotificationEntity", b =>
                {
                    b.HasOne("Skeleton.Domain.Entities.UserEntity", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("Skeleton.Domain.Entities.ItemCategoryEntity", b =>
                {
                    b.Navigation("Items");
                });
#pragma warning restore 612, 618
        }
    }
}
