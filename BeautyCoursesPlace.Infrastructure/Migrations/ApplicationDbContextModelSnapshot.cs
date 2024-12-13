﻿// <auto-generated />
using System;
using BeautyCoursesPlace.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace BeautyCoursesPlace.Infrastructure.Migrations
{
    [DbContext(typeof(BeautyCoursesDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("BeautyCoursesPlace.Infrastructure.Data.Models.ApplicationUser", b =>
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

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

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
                            Id = "dea12856-c198-4129-b3f3-b893d8395082",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "cea67c02-8a10-4929-9e4e-9337d6dad62e",
                            Email = "agent@mail.com",
                            EmailConfirmed = false,
                            FirstName = "",
                            LastName = "",
                            LockoutEnabled = false,
                            NormalizedEmail = "agent@mail.com",
                            NormalizedUserName = "agent@mail.com",
                            PasswordHash = "AQAAAAIAAYagAAAAEPK0R2oC65eA6Clf9Oz65gCkLlKG42xcESqz1Uq8+fF9kJZevIhZO8hVrdeutoSIYw==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "cd40e727-8104-41ad-8ddb-c0d275b2c9ef",
                            TwoFactorEnabled = false,
                            UserName = "agent@mail.com"
                        },
                        new
                        {
                            Id = "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "cea3db77-0dd1-4d38-892b-ac782d6ad953",
                            Email = "guest@mail.com",
                            EmailConfirmed = false,
                            FirstName = "",
                            LastName = "",
                            LockoutEnabled = false,
                            NormalizedEmail = "guest@mail.com",
                            NormalizedUserName = "guest@mail.com",
                            PasswordHash = "AQAAAAIAAYagAAAAEMO6HHJTmbH1NfnXJARW4Y9cxC0upMH9E0FaQKkO//1iOz8FdUCE9rZX3FTfSKcbAg==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "28204033-3922-40dc-b674-74f301040dfd",
                            TwoFactorEnabled = false,
                            UserName = "guest@mail.com"
                        },
                        new
                        {
                            Id = "cc7a0b3d-02fc-468e-ad0c-3b4c79dcd53a",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "69028920-5a3b-4ad6-9969-0e6a8ad18b36",
                            Email = "admin@mail.com",
                            EmailConfirmed = false,
                            FirstName = "Viktoria",
                            LastName = "Deyanska Great Admin",
                            LockoutEnabled = false,
                            NormalizedEmail = "ADMIN@MAIL.COM",
                            NormalizedUserName = "ADMIN@MAIL.COM",
                            PasswordHash = "AQAAAAIAAYagAAAAEOxmPjaNyrfKxaaiVNGSn9pdhfjTEPta9yTYI0icV3GdmDC8D9S3tfa30QsLzPbC8A==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "9033b5fd-fea1-4d8f-9c63-1242d6f85b4d",
                            TwoFactorEnabled = false,
                            UserName = "admint@mail.com"
                        });
                });

            modelBuilder.Entity("BeautyCoursesPlace.Infrastructure.Data.Models.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasComment("Category Identifier");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasComment("Category name");

                    b.HasKey("Id");

                    b.ToTable("Categories", t =>
                        {
                            t.HasComment("Course category");
                        });

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Makeup"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Hair"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Nails"
                        });
                });

            modelBuilder.Entity("BeautyCoursesPlace.Infrastructure.Data.Models.Course", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasComment("Course Identifier");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)")
                        .HasComment("Course address");

                    b.Property<int>("CategoryId")
                        .HasColumnType("int")
                        .HasComment("Category Identifier");

                    b.Property<decimal>("Cost")
                        .HasColumnType("decimal(18,2)")
                        .HasComment("Course cost");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(600)
                        .HasColumnType("nvarchar(600)")
                        .HasComment("Course description");

                    b.Property<string>("ImageUrl")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasComment("Course image");

                    b.Property<int>("LectorId")
                        .HasColumnType("int")
                        .HasComment("Lector Identifier");

                    b.Property<int?>("PartnerId")
                        .HasColumnType("int")
                        .HasComment("Identifier for partner");

                    b.Property<string>("StudentId")
                        .HasColumnType("nvarchar(max)")
                        .HasComment("Identifier for student");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasComment("Course title");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.HasIndex("LectorId");

                    b.HasIndex("PartnerId");

                    b.ToTable("Courses", t =>
                        {
                            t.HasComment("Courses to display");
                        });

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Address = "17 Lydford Rd London UK",
                            CategoryId = 1,
                            Cost = 700.00m,
                            Description = "If you want to learn how to do Half cut crease and create this makeup look, join the course.",
                            ImageUrl = "https://artdeco.com/cdn/shop/files/Shop-the-Look-Schminktipp-Cut-Crease_V2-600x600_600x600.jpg?v=1684735658",
                            LectorId = 1,
                            StudentId = "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e",
                            Title = "Cut crease tehnique"
                        },
                        new
                        {
                            Id = 2,
                            Address = "  77 Sidmouth Rd London, England",
                            CategoryId = 2,
                            Cost = 400.00m,
                            Description = "This course covers several methods for professionally blow-drying, curling, trimming, and colouring hair.",
                            ImageUrl = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcSY16nniu9WfRnBZisa1BKW5ss9sHlx2blUeg&s",
                            LectorId = 1,
                            Title = "Hair Styling: Blow-Dry, Cut, and Colour Like a Pro"
                        },
                        new
                        {
                            Id = 3,
                            Address = "290 Willesden Lane London, England",
                            CategoryId = 3,
                            Cost = 2000.00m,
                            Description = "Learn how to care for nails like a pro and perform treatments like manicures and pedicures in this free online course.",
                            ImageUrl = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcSE0LHapGysMlndotyOkN0h4T4RynF7P_xJEA&s",
                            LectorId = 1,
                            Title = "Nail Care and Treatment "
                        });
                });

            modelBuilder.Entity("BeautyCoursesPlace.Infrastructure.Data.Models.Lector", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasComment("Lector Identifier");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Telephone")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar(15)")
                        .HasComment("Lector phone number");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)")
                        .HasComment("User Identifier");

                    b.HasKey("Id");

                    b.HasIndex("Telephone")
                        .IsUnique();

                    b.HasIndex("UserId");

                    b.ToTable("Lectors", t =>
                        {
                            t.HasComment("Lector");
                        });

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Telephone = "+359888888888",
                            UserId = "dea12856-c198-4129-b3f3-b893d8395082"
                        },
                        new
                        {
                            Id = 5,
                            Telephone = "+359899987654",
                            UserId = "cc7a0b3d-02fc-468e-ad0c-3b4c79dcd53a"
                        });
                });

            modelBuilder.Entity("BeautyCoursesPlace.Infrastructure.Data.Models.Partner", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Address")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)")
                        .HasComment("Partner address");

                    b.Property<string>("ImageUrl")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasComment("Partner logo or image URL");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)")
                        .HasComment("Partner name");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Partners");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Address = "",
                            ImageUrl = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQNttQsOgRhhhzmKi-gAW23cj2VgGcayhsnkA&s",
                            Name = "BeautyPlace",
                            UserId = ""
                        },
                        new
                        {
                            Id = 2,
                            Address = "",
                            ImageUrl = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQa4puCFpPTXAjYJHIMCXEz1vUFuCj6LnwUKg&s",
                            Name = "HairByMaster",
                            UserId = ""
                        });
                });

            modelBuilder.Entity("BeautyCoursesPlace.Infrastructure.Data.Models.Saloon", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)")
                        .HasComment("Saloon address");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)")
                        .HasComment("Saloon name");

                    b.Property<int>("PartnerId")
                        .HasColumnType("int");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("PartnerId");

                    b.ToTable("Saloons");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
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
                });

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
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("ProviderKey")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

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
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("Name")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("BeautyCoursesPlace.Infrastructure.Data.Models.Course", b =>
                {
                    b.HasOne("BeautyCoursesPlace.Infrastructure.Data.Models.Category", "Category")
                        .WithMany("Courses")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("BeautyCoursesPlace.Infrastructure.Data.Models.Lector", "Lector")
                        .WithMany("Courses")
                        .HasForeignKey("LectorId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("BeautyCoursesPlace.Infrastructure.Data.Models.Partner", "Partner")
                        .WithMany("Courses")
                        .HasForeignKey("PartnerId");

                    b.Navigation("Category");

                    b.Navigation("Lector");

                    b.Navigation("Partner");
                });

            modelBuilder.Entity("BeautyCoursesPlace.Infrastructure.Data.Models.Lector", b =>
                {
                    b.HasOne("BeautyCoursesPlace.Infrastructure.Data.Models.ApplicationUser", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("BeautyCoursesPlace.Infrastructure.Data.Models.Saloon", b =>
                {
                    b.HasOne("BeautyCoursesPlace.Infrastructure.Data.Models.Partner", "Partner")
                        .WithMany("Saloons")
                        .HasForeignKey("PartnerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Partner");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("BeautyCoursesPlace.Infrastructure.Data.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("BeautyCoursesPlace.Infrastructure.Data.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BeautyCoursesPlace.Infrastructure.Data.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("BeautyCoursesPlace.Infrastructure.Data.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("BeautyCoursesPlace.Infrastructure.Data.Models.Category", b =>
                {
                    b.Navigation("Courses");
                });

            modelBuilder.Entity("BeautyCoursesPlace.Infrastructure.Data.Models.Lector", b =>
                {
                    b.Navigation("Courses");
                });

            modelBuilder.Entity("BeautyCoursesPlace.Infrastructure.Data.Models.Partner", b =>
                {
                    b.Navigation("Courses");

                    b.Navigation("Saloons");
                });
#pragma warning restore 612, 618
        }
    }
}
