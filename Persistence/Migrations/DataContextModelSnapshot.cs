﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
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
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Domain.ActionTackerTaskList", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("ActualComplectionDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime>("ComplectionDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.Property<string>("DetailsJson")
                        .HasColumnType("text");

                    b.Property<DateTime>("ModifiedDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("ParentID")
                        .HasColumnType("integer");

                    b.Property<string>("Responsibility")
                        .HasColumnType("text");

                    b.Property<string>("Stakeholder")
                        .HasColumnType("text");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("StatusId")
                        .HasColumnType("integer");

                    b.Property<string>("TaskType")
                        .HasColumnType("text");

                    b.Property<string>("Test")
                        .HasColumnType("text");

                    b.Property<string>("Title")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("ActionTackerTaskLists");
                });

            modelBuilder.Entity("Domain.ActionTackerTypesList", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("ActionCreaedBy")
                        .HasColumnType("text");

                    b.Property<DateTime>("ActionCreatedTime")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime>("ActionModifiedTime")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("ActionType")
                        .HasColumnType("text");

                    b.Property<string>("DetailsJson")
                        .HasColumnType("text");

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("ParentID")
                        .HasColumnType("text");

                    b.Property<string>("ProjectOwner")
                        .HasColumnType("text");

                    b.Property<string>("StakeHolders")
                        .HasColumnType("text");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("StatusId")
                        .HasColumnType("integer");

                    b.Property<string>("Title")
                        .HasColumnType("text");

                    b.Property<string>("TypeID")
                        .HasColumnType("text");

                    b.Property<string>("test")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("ActionTackerTypesLists");
                });

            modelBuilder.Entity("Domain.ActionTrackerAuditLog", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Action")
                        .HasColumnType("text");

                    b.Property<string>("ActionBy")
                        .HasColumnType("text");

                    b.Property<DateTime>("ActionTime")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Comment")
                        .HasColumnType("text");

                    b.Property<string>("Source")
                        .HasColumnType("text");

                    b.Property<int>("TaskID")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.ToTable("ActionTrackerAuditLogs");
                });

            modelBuilder.Entity("Domain.AppConfig", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("ConfigTypeId")
                        .HasColumnType("integer");

                    b.Property<int>("Order")
                        .HasColumnType("integer");

                    b.Property<string>("Title")
                        .HasColumnType("text");

                    b.Property<string>("Val1")
                        .HasColumnType("text");

                    b.Property<string>("Val2")
                        .HasColumnType("text");

                    b.Property<string>("Val3")
                        .HasColumnType("text");

                    b.Property<string>("Val4")
                        .HasColumnType("text");

                    b.Property<string>("Val5")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("AppConfigs");
                });

            modelBuilder.Entity("Domain.AppConfigType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Title")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("AppConfigTypes");
                });

            modelBuilder.Entity("Domain.AppUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("text");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("integer");

                    b.Property<string>("Bio")
                        .HasColumnType("text");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("text");

                    b.Property<string>("DisplayName")
                        .HasColumnType("text");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("boolean");

                    b.Property<bool>("IsActive")
                        .HasColumnType("boolean");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("boolean");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("text");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("text");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("boolean");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("text");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("boolean");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

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
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Access")
                        .HasColumnType("text");

                    b.Property<string>("AccessType")
                        .HasColumnType("text");

                    b.Property<int>("FiledId")
                        .HasColumnType("integer");

                    b.Property<int>("StatusId")
                        .HasColumnType("integer");

                    b.Property<int>("TableId")
                        .HasColumnType("integer");

                    b.Property<string>("UserListID")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("DataSecuritys");
                });

            modelBuilder.Entity("Domain.RoleMaster", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("RoleMasters");
                });

            modelBuilder.Entity("Domain.TableData", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("Date1")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime>("Date10")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime>("Date2")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime>("Date3")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime>("Date4")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime>("Date5")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime>("Date6")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime>("Date7")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime>("Date8")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime>("Date9")
                        .HasColumnType("timestamp with time zone");

                    b.Property<float>("Num1")
                        .HasColumnType("real");

                    b.Property<float>("Num10")
                        .HasColumnType("real");

                    b.Property<float>("Num2")
                        .HasColumnType("real");

                    b.Property<float>("Num3")
                        .HasColumnType("real");

                    b.Property<float>("Num4")
                        .HasColumnType("real");

                    b.Property<float>("Num5")
                        .HasColumnType("real");

                    b.Property<float>("Num6")
                        .HasColumnType("real");

                    b.Property<float>("Num7")
                        .HasColumnType("real");

                    b.Property<float>("Num8")
                        .HasColumnType("real");

                    b.Property<float>("Num9")
                        .HasColumnType("real");

                    b.Property<int>("TableId")
                        .HasColumnType("integer");

                    b.Property<string>("Txt1")
                        .HasColumnType("text");

                    b.Property<string>("Txt10")
                        .HasColumnType("text");

                    b.Property<string>("Txt11")
                        .HasColumnType("text");

                    b.Property<string>("Txt12")
                        .HasColumnType("text");

                    b.Property<string>("Txt13")
                        .HasColumnType("text");

                    b.Property<string>("Txt14")
                        .HasColumnType("text");

                    b.Property<string>("Txt15")
                        .HasColumnType("text");

                    b.Property<string>("Txt16")
                        .HasColumnType("text");

                    b.Property<string>("Txt17")
                        .HasColumnType("text");

                    b.Property<string>("Txt18")
                        .HasColumnType("text");

                    b.Property<string>("Txt19")
                        .HasColumnType("text");

                    b.Property<string>("Txt2")
                        .HasColumnType("text");

                    b.Property<string>("Txt20")
                        .HasColumnType("text");

                    b.Property<string>("Txt3")
                        .HasColumnType("text");

                    b.Property<string>("Txt4")
                        .HasColumnType("text");

                    b.Property<string>("Txt5")
                        .HasColumnType("text");

                    b.Property<string>("Txt6")
                        .HasColumnType("text");

                    b.Property<string>("Txt7")
                        .HasColumnType("text");

                    b.Property<string>("Txt8")
                        .HasColumnType("text");

                    b.Property<string>("Txt9")
                        .HasColumnType("text");

                    b.Property<int>("User1")
                        .HasColumnType("integer");

                    b.Property<int>("User10")
                        .HasColumnType("integer");

                    b.Property<int>("User2")
                        .HasColumnType("integer");

                    b.Property<int>("User3")
                        .HasColumnType("integer");

                    b.Property<int>("User4")
                        .HasColumnType("integer");

                    b.Property<int>("User5")
                        .HasColumnType("integer");

                    b.Property<int>("User6")
                        .HasColumnType("integer");

                    b.Property<int>("User7")
                        .HasColumnType("integer");

                    b.Property<int>("User8")
                        .HasColumnType("integer");

                    b.Property<int>("User9")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.ToTable("TableDatas");
                });

            modelBuilder.Entity("Domain.TableField", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("CustomValidationId")
                        .HasColumnType("integer");

                    b.Property<int>("DataSecurityId")
                        .HasColumnType("integer");

                    b.Property<string>("FideldName")
                        .HasColumnType("text");

                    b.Property<string>("FiledType")
                        .HasColumnType("text");

                    b.Property<bool>("Required")
                        .HasColumnType("boolean");

                    b.Property<int>("TableId")
                        .HasColumnType("integer");

                    b.Property<string>("Title")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("TableFields");
                });

            modelBuilder.Entity("Domain.TableName", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("StatusId")
                        .HasColumnType("integer");

                    b.Property<string>("Title")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("TableNames");
                });

            modelBuilder.Entity("Domain.ToDo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Status")
                        .HasColumnType("text");

                    b.Property<string>("Title")
                        .HasColumnType("text");

                    b.Property<DateTime>("TragetDate")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.ToTable("ToDos");
                });

            modelBuilder.Entity("Domain.ToDoAssignedTo", b =>
                {
                    b.Property<string>("AppUserId")
                        .HasColumnType("text");

                    b.Property<int>("ToDoId")
                        .HasColumnType("integer");

                    b.Property<bool>("IsCreatedBy")
                        .HasColumnType("boolean");

                    b.HasKey("AppUserId", "ToDoId");

                    b.HasIndex("ToDoId");

                    b.ToTable("ToDoAssignedTos");
                });

            modelBuilder.Entity("Domain.UserType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("GrpId")
                        .HasColumnType("text");

                    b.Property<string>("Type")
                        .HasColumnType("text");

                    b.Property<string>("UserId")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("UserTypes");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("text");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

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
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("text");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("text");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("text");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("text");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("text");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("text");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("text");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("text");

                    b.Property<string>("RoleId")
                        .HasColumnType("text");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("text");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<string>("Value")
                        .HasColumnType("text");

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
