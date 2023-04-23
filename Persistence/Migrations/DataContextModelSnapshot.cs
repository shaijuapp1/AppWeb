﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Persistence;

#nullable disable

namespace Persistence.Migrations
{
    [DbContext(typeof(DataContext))]
    partial class DataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.3");

            modelBuilder.Entity("Domain.AppConfig", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("ConfigTypeId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Order")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Title")
                        .HasColumnType("TEXT");

                    b.Property<string>("Val1")
                        .HasColumnType("TEXT");

                    b.Property<string>("Val2")
                        .HasColumnType("TEXT");

                    b.Property<string>("Val3")
                        .HasColumnType("TEXT");

                    b.Property<string>("Val4")
                        .HasColumnType("TEXT");

                    b.Property<string>("Val5")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("AppConfigs");
                });

            modelBuilder.Entity("Domain.AppConfigType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Title")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("AppConfigTypes");
                });

            modelBuilder.Entity("Domain.AppUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("TEXT");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Bio")
                        .HasColumnType("TEXT");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("TEXT");

                    b.Property<string>("DisplayName")
                        .HasColumnType("TEXT");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("TEXT");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("IsActive")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("INTEGER");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("TEXT");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("TEXT");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("TEXT");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("TEXT");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("TEXT");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("INTEGER");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("TEXT");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("INTEGER");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex");

                    b.ToTable("AspNetUsers", (string)null);
                });

            modelBuilder.Entity("Domain.DataSecurity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Access")
                        .HasColumnType("TEXT");

                    b.Property<string>("AccessType")
                        .HasColumnType("TEXT");

                    b.Property<int>("FiledId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("StatusId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("TableId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("UserListID")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("DataSecuritys");
                });

            modelBuilder.Entity("Domain.RoleMaster", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("RoleMasters");
                });

            modelBuilder.Entity("Domain.TableData", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("Date1")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("Date10")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("Date2")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("Date3")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("Date4")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("Date5")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("Date6")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("Date7")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("Date8")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("Date9")
                        .HasColumnType("TEXT");

                    b.Property<float>("Num1")
                        .HasColumnType("REAL");

                    b.Property<float>("Num10")
                        .HasColumnType("REAL");

                    b.Property<float>("Num2")
                        .HasColumnType("REAL");

                    b.Property<float>("Num3")
                        .HasColumnType("REAL");

                    b.Property<float>("Num4")
                        .HasColumnType("REAL");

                    b.Property<float>("Num5")
                        .HasColumnType("REAL");

                    b.Property<float>("Num6")
                        .HasColumnType("REAL");

                    b.Property<float>("Num7")
                        .HasColumnType("REAL");

                    b.Property<float>("Num8")
                        .HasColumnType("REAL");

                    b.Property<float>("Num9")
                        .HasColumnType("REAL");

                    b.Property<int>("TableId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Txt1")
                        .HasColumnType("TEXT");

                    b.Property<string>("Txt10")
                        .HasColumnType("TEXT");

                    b.Property<string>("Txt11")
                        .HasColumnType("TEXT");

                    b.Property<string>("Txt12")
                        .HasColumnType("TEXT");

                    b.Property<string>("Txt13")
                        .HasColumnType("TEXT");

                    b.Property<string>("Txt14")
                        .HasColumnType("TEXT");

                    b.Property<string>("Txt15")
                        .HasColumnType("TEXT");

                    b.Property<string>("Txt16")
                        .HasColumnType("TEXT");

                    b.Property<string>("Txt17")
                        .HasColumnType("TEXT");

                    b.Property<string>("Txt18")
                        .HasColumnType("TEXT");

                    b.Property<string>("Txt19")
                        .HasColumnType("TEXT");

                    b.Property<string>("Txt2")
                        .HasColumnType("TEXT");

                    b.Property<string>("Txt20")
                        .HasColumnType("TEXT");

                    b.Property<string>("Txt3")
                        .HasColumnType("TEXT");

                    b.Property<string>("Txt4")
                        .HasColumnType("TEXT");

                    b.Property<string>("Txt5")
                        .HasColumnType("TEXT");

                    b.Property<string>("Txt6")
                        .HasColumnType("TEXT");

                    b.Property<string>("Txt7")
                        .HasColumnType("TEXT");

                    b.Property<string>("Txt8")
                        .HasColumnType("TEXT");

                    b.Property<string>("Txt9")
                        .HasColumnType("TEXT");

                    b.Property<int>("User1")
                        .HasColumnType("INTEGER");

                    b.Property<int>("User10")
                        .HasColumnType("INTEGER");

                    b.Property<int>("User2")
                        .HasColumnType("INTEGER");

                    b.Property<int>("User3")
                        .HasColumnType("INTEGER");

                    b.Property<int>("User4")
                        .HasColumnType("INTEGER");

                    b.Property<int>("User5")
                        .HasColumnType("INTEGER");

                    b.Property<int>("User6")
                        .HasColumnType("INTEGER");

                    b.Property<int>("User7")
                        .HasColumnType("INTEGER");

                    b.Property<int>("User8")
                        .HasColumnType("INTEGER");

                    b.Property<int>("User9")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.ToTable("TableDatas");
                });

            modelBuilder.Entity("Domain.TableField", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("CustomValidationId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("DataSecurityId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("FideldName")
                        .HasColumnType("TEXT");

                    b.Property<string>("FiledType")
                        .HasColumnType("TEXT");

                    b.Property<bool>("Required")
                        .HasColumnType("INTEGER");

                    b.Property<int>("TableId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Title")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("TableFields");
                });

            modelBuilder.Entity("Domain.TableName", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("StatusId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Title")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("TableNames");
                });

            modelBuilder.Entity("Domain.ToDo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Status")
                        .HasColumnType("TEXT");

                    b.Property<string>("Title")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("TragetDate")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("ToDos");
                });

            modelBuilder.Entity("Domain.ToDoAssignedTo", b =>
                {
                    b.Property<string>("AppUserId")
                        .HasColumnType("TEXT");

                    b.Property<int>("ToDoId")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("IsCreatedBy")
                        .HasColumnType("INTEGER");

                    b.HasKey("AppUserId", "ToDoId");

                    b.HasIndex("ToDoId");

                    b.ToTable("ToDoAssignedTos");
                });

            modelBuilder.Entity("Domain.UserType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("GrpId")
                        .HasColumnType("TEXT");

                    b.Property<string>("Type")
                        .HasColumnType("TEXT");

                    b.Property<string>("UserId")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("UserTypes");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("TEXT");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("TEXT");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex");

                    b.ToTable("AspNetRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("ClaimType")
                        .HasColumnType("TEXT");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("TEXT");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("ClaimType")
                        .HasColumnType("TEXT");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("TEXT");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("TEXT");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("TEXT");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("TEXT");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("TEXT");

                    b.Property<string>("RoleId")
                        .HasColumnType("TEXT");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("TEXT");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.Property<string>("Value")
                        .HasColumnType("TEXT");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("Domain.ToDoAssignedTo", b =>
                {
                    b.HasOne("Domain.AppUser", "AppUser")
                        .WithMany("ToDoAssignedTo")
                        .HasForeignKey("AppUserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.ToDo", "ToDo")
                        .WithMany("AssignedTo")
                        .HasForeignKey("ToDoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("AppUser");

                    b.Navigation("ToDo");
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
                    b.HasOne("Domain.AppUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Domain.AppUser", null)
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

                    b.HasOne("Domain.AppUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Domain.AppUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Domain.AppUser", b =>
                {
                    b.Navigation("ToDoAssignedTo");
                });

            modelBuilder.Entity("Domain.ToDo", b =>
                {
                    b.Navigation("AssignedTo");
                });
#pragma warning restore 612, 618
        }
    }
}
