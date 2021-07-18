﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using OpenOsp.Data.Contexts;

namespace OpenOsp.Data.Migrations {
  [DbContext(typeof(AppDbContext))]
  partial class AppDbContextModelSnapshot : ModelSnapshot {
    protected override void BuildModel(ModelBuilder modelBuilder) {
#pragma warning disable 612, 618
      modelBuilder
          .HasAnnotation("Relational:MaxIdentifierLength", 64)
          .HasAnnotation("ProductVersion", "5.0.5");

      modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<int>", b => {
        b.Property<int>("Id")
            .ValueGeneratedOnAdd()
            .HasColumnType("int");

        b.Property<string>("ClaimType")
            .HasColumnType("longtext");

        b.Property<string>("ClaimValue")
            .HasColumnType("longtext");

        b.Property<int>("UserId")
            .HasColumnType("int");

        b.HasKey("Id");

        b.HasIndex("UserId");

        b.ToTable("AspNetUserClaims");
      });

      modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<int>", b => {
        b.Property<string>("LoginProvider")
            .HasColumnType("varchar(95)");

        b.Property<string>("ProviderKey")
            .HasColumnType("varchar(95)");

        b.Property<string>("ProviderDisplayName")
            .HasColumnType("longtext");

        b.Property<int>("UserId")
            .HasColumnType("int");

        b.HasKey("LoginProvider", "ProviderKey");

        b.HasIndex("UserId");

        b.ToTable("AspNetUserLogins");
      });

      modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<int>", b => {
        b.Property<int>("UserId")
            .HasColumnType("int");

        b.Property<string>("LoginProvider")
            .HasColumnType("varchar(95)");

        b.Property<string>("Name")
            .HasColumnType("varchar(95)");

        b.Property<string>("Value")
            .HasColumnType("longtext");

        b.HasKey("UserId", "LoginProvider", "Name");

        b.ToTable("AspNetUserTokens");
      });

      modelBuilder.Entity("OpenOsp.Model.Models.Action", b => {
        b.Property<int>("Id")
            .ValueGeneratedOnAdd()
            .HasColumnType("int");

        b.Property<DateTime>("EndTime")
            .HasColumnType("datetime");

        b.Property<string>("Location")
            .HasMaxLength(50)
            .HasColumnType("varchar(50)");

        b.Property<DateTime>("StartTime")
            .HasColumnType("datetime");

        b.Property<int>("Type")
            .ValueGeneratedOnAdd()
            .HasColumnType("int")
            .HasDefaultValue(2);

        b.Property<int>("UserId")
            .HasColumnType("int");

        b.HasKey("Id");

        b.HasIndex("UserId");

        b.ToTable("Actions");
      });

      modelBuilder.Entity("OpenOsp.Model.Models.ActionEquipment", b => {
        b.Property<int>("ActionId")
            .HasColumnType("int");

        b.Property<int>("EquipmentId")
            .HasColumnType("int");

        b.Property<int>("CounterState")
            .ValueGeneratedOnAdd()
            .HasColumnType("int")
            .HasDefaultValue(0);

        b.Property<float>("FuelUsed")
            .ValueGeneratedOnAdd()
            .HasColumnType("float")
            .HasDefaultValue(0f);

        b.Property<int>("Id")
            .ValueGeneratedOnAdd()
            .HasColumnType("int");

        b.HasKey("ActionId", "EquipmentId");

        b.HasIndex("EquipmentId");

        b.ToTable("ActionEquipment");
      });

      modelBuilder.Entity("OpenOsp.Model.Models.ActionMember", b => {
        b.Property<int>("ActionId")
            .HasColumnType("int");

        b.Property<int>("MemberId")
            .HasColumnType("int");

        b.Property<int>("Id")
            .ValueGeneratedOnAdd()
            .HasColumnType("int");

        b.Property<int>("Role")
            .ValueGeneratedOnAdd()
            .HasColumnType("int")
            .HasDefaultValue(0);

        b.HasKey("ActionId", "MemberId");

        b.HasIndex("MemberId");

        b.ToTable("ActionMembers");
      });

      modelBuilder.Entity("OpenOsp.Model.Models.Equipment", b => {
        b.Property<int>("Id")
            .ValueGeneratedOnAdd()
            .HasColumnType("int");

        b.Property<string>("Brand")
            .HasMaxLength(30)
            .HasColumnType("varchar(30)");

        b.Property<string>("Model")
            .HasMaxLength(30)
            .HasColumnType("varchar(30)");

        b.Property<string>("Name")
            .HasMaxLength(50)
            .HasColumnType("varchar(50)");

        b.Property<string>("RegistryNumber")
            .HasMaxLength(15)
            .HasColumnType("varchar(15)");

        b.Property<int>("UserId")
            .HasColumnType("int");

        b.HasKey("Id");

        b.HasIndex("UserId");

        b.ToTable("Equipment");
      });

      modelBuilder.Entity("OpenOsp.Model.Models.Member", b => {
        b.Property<int>("Id")
            .ValueGeneratedOnAdd()
            .HasColumnType("int");

        b.Property<string>("FirstName")
            .HasMaxLength(15)
            .HasColumnType("varchar(15)");

        b.Property<string>("LastName")
            .HasMaxLength(15)
            .HasColumnType("varchar(15)");

        b.Property<string>("Pesel")
            .HasMaxLength(11)
            .HasColumnType("varchar(11)");

        b.Property<int>("UserId")
            .HasColumnType("int");

        b.HasKey("Id");

        b.HasIndex("UserId");

        b.ToTable("Members");
      });

      modelBuilder.Entity("OpenOsp.Model.Models.User", b => {
        b.Property<int>("Id")
            .ValueGeneratedOnAdd()
            .HasColumnType("int");

        b.Property<int>("AccessFailedCount")
            .HasColumnType("int");

        b.Property<string>("ConcurrencyStamp")
            .IsConcurrencyToken()
            .HasMaxLength(85)
            .HasColumnType("varchar(85)");

        b.Property<string>("Email")
            .HasMaxLength(85)
            .HasColumnType("varchar(85)");

        b.Property<bool>("EmailConfirmed")
            .ValueGeneratedOnAdd()
            .HasColumnType("tinyint(1)")
            .HasDefaultValue(false);

        b.Property<bool>("LockoutEnabled")
            .HasColumnType("tinyint(1)");

        b.Property<DateTimeOffset?>("LockoutEnd")
            .HasColumnType("datetime");

        b.Property<string>("NormalizedEmail")
            .HasMaxLength(85)
            .HasColumnType("varchar(85)");

        b.Property<string>("NormalizedUserName")
            .HasMaxLength(30)
            .HasColumnType("varchar(30)");

        b.Property<string>("PasswordHash")
            .HasMaxLength(85)
            .HasColumnType("varchar(85)");

        b.Property<string>("PhoneNumber")
            .HasMaxLength(20)
            .HasColumnType("varchar(20)");

        b.Property<bool>("PhoneNumberConfirmed")
            .HasColumnType("tinyint(1)");

        b.Property<string>("SecurityStamp")
            .HasMaxLength(85)
            .HasColumnType("varchar(85)");

        b.Property<bool>("TwoFactorEnabled")
            .HasColumnType("tinyint(1)");

        b.Property<string>("UserName")
            .HasMaxLength(30)
            .HasColumnType("varchar(30)");

        b.HasKey("Id");

        b.HasIndex("NormalizedEmail")
            .HasDatabaseName("EmailIndex");

        b.HasIndex("NormalizedUserName")
            .IsUnique()
            .HasDatabaseName("UserNameIndex");

        b.ToTable("AspNetUsers");
      });

      modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<int>", b => {
        b.HasOne("OpenOsp.Model.Models.User", null)
            .WithMany()
            .HasForeignKey("UserId")
            .OnDelete(DeleteBehavior.Cascade)
            .IsRequired();
      });

      modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<int>", b => {
        b.HasOne("OpenOsp.Model.Models.User", null)
            .WithMany()
            .HasForeignKey("UserId")
            .OnDelete(DeleteBehavior.Cascade)
            .IsRequired();
      });

      modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<int>", b => {
        b.HasOne("OpenOsp.Model.Models.User", null)
            .WithMany()
            .HasForeignKey("UserId")
            .OnDelete(DeleteBehavior.Cascade)
            .IsRequired();
      });

      modelBuilder.Entity("OpenOsp.Model.Models.Action", b => {
        b.HasOne("OpenOsp.Model.Models.User", "User")
            .WithMany("Actions")
            .HasForeignKey("UserId")
            .OnDelete(DeleteBehavior.Cascade)
            .IsRequired();

        b.Navigation("User");
      });

      modelBuilder.Entity("OpenOsp.Model.Models.ActionEquipment", b => {
        b.HasOne("OpenOsp.Model.Models.Action", "Action")
            .WithMany("Equipment")
            .HasForeignKey("ActionId")
            .OnDelete(DeleteBehavior.NoAction)
            .IsRequired();

        b.HasOne("OpenOsp.Model.Models.Equipment", "Equipment")
            .WithMany("Actions")
            .HasForeignKey("EquipmentId")
            .OnDelete(DeleteBehavior.Cascade)
            .IsRequired();

        b.Navigation("Action");

        b.Navigation("Equipment");
      });

      modelBuilder.Entity("OpenOsp.Model.Models.ActionMember", b => {
        b.HasOne("OpenOsp.Model.Models.Action", "Action")
            .WithMany("Members")
            .HasForeignKey("ActionId")
            .OnDelete(DeleteBehavior.NoAction)
            .IsRequired();

        b.HasOne("OpenOsp.Model.Models.Member", "Member")
            .WithMany("Actions")
            .HasForeignKey("MemberId")
            .OnDelete(DeleteBehavior.Cascade)
            .IsRequired();

        b.Navigation("Action");

        b.Navigation("Member");
      });

      modelBuilder.Entity("OpenOsp.Model.Models.Equipment", b => {
        b.HasOne("OpenOsp.Model.Models.User", "User")
            .WithMany("Equipment")
            .HasForeignKey("UserId")
            .OnDelete(DeleteBehavior.Cascade)
            .IsRequired();

        b.Navigation("User");
      });

      modelBuilder.Entity("OpenOsp.Model.Models.Member", b => {
        b.HasOne("OpenOsp.Model.Models.User", "User")
            .WithMany("Members")
            .HasForeignKey("UserId")
            .OnDelete(DeleteBehavior.Cascade)
            .IsRequired();

        b.Navigation("User");
      });

      modelBuilder.Entity("OpenOsp.Model.Models.Action", b => {
        b.Navigation("Equipment");

        b.Navigation("Members");
      });

      modelBuilder.Entity("OpenOsp.Model.Models.Equipment", b => {
        b.Navigation("Actions");
      });

      modelBuilder.Entity("OpenOsp.Model.Models.Member", b => {
        b.Navigation("Actions");
      });

      modelBuilder.Entity("OpenOsp.Model.Models.User", b => {
        b.Navigation("Actions");

        b.Navigation("Equipment");

        b.Navigation("Members");
      });
#pragma warning restore 612, 618
    }
  }
}
