﻿// <auto-generated />
using System;
using DesafioPaschoalotto.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace DesafioPaschoalotto.Infrastructure.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("DesafioPaschoalotto.Domain.Entities.Contact", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Cell")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("cell");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("phone");

                    b.Property<int>("UserId")
                        .HasColumnType("integer")
                        .HasColumnName("userid");

                    b.HasKey("Id")
                        .HasName("pk_contacts");

                    b.HasIndex("UserId")
                        .IsUnique()
                        .HasDatabaseName("ix_contacts_userid");

                    b.ToTable("contacts", (string)null);
                });

            modelBuilder.Entity("DesafioPaschoalotto.Domain.Entities.Document", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("varchar(10)")
                        .HasColumnName("type");

                    b.Property<int>("UserId")
                        .HasColumnType("integer")
                        .HasColumnName("userid");

                    b.Property<string>("Value")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("value");

                    b.HasKey("Id")
                        .HasName("pk_documents");

                    b.HasIndex("UserId")
                        .IsUnique()
                        .HasDatabaseName("ix_documents_userid");

                    b.ToTable("documents", (string)null);
                });

            modelBuilder.Entity("DesafioPaschoalotto.Domain.Entities.Location", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("city");

                    b.Property<string>("Country")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("country");

                    b.Property<string>("Latitude")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("latitude");

                    b.Property<string>("Longitude")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("longitude");

                    b.Property<int>("Number")
                        .HasColumnType("integer")
                        .HasColumnName("number");

                    b.Property<string>("PostCode")
                        .IsRequired()
                        .HasColumnType("varchar(50)")
                        .HasColumnName("postcode");

                    b.Property<string>("State")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("state");

                    b.Property<string>("Street")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("street");

                    b.Property<string>("TimeZone")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("timezone");

                    b.Property<string>("TimeZoneOffSet")
                        .IsRequired()
                        .HasColumnType("varchar(20)")
                        .HasColumnName("timezoneoffset");

                    b.Property<int>("UserId")
                        .HasColumnType("integer")
                        .HasColumnName("userid");

                    b.HasKey("Id")
                        .HasName("pk_locations");

                    b.HasIndex("UserId")
                        .IsUnique()
                        .HasDatabaseName("ix_locations_userid");

                    b.ToTable("locations", (string)null);
                });

            modelBuilder.Entity("DesafioPaschoalotto.Domain.Entities.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("BirthDate")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("birthdate");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("varchar(255)")
                        .HasColumnName("email");

                    b.Property<string>("ImagePath")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("imagepath");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar(255)")
                        .HasColumnName("name");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("password");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("varchar(10)")
                        .HasColumnName("title");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("username");

                    b.HasKey("Id")
                        .HasName("pk_users");

                    b.HasIndex("Email")
                        .IsUnique()
                        .HasDatabaseName("ix_email");

                    b.HasIndex("UserName")
                        .IsUnique()
                        .HasDatabaseName("ix_username");

                    b.ToTable("users", (string)null);
                });

            modelBuilder.Entity("DesafioPaschoalotto.Domain.Entities.Contact", b =>
                {
                    b.HasOne("DesafioPaschoalotto.Domain.Entities.User", "User")
                        .WithOne("Contact")
                        .HasForeignKey("DesafioPaschoalotto.Domain.Entities.Contact", "UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_contacts_users_userid");

                    b.Navigation("User");
                });

            modelBuilder.Entity("DesafioPaschoalotto.Domain.Entities.Document", b =>
                {
                    b.HasOne("DesafioPaschoalotto.Domain.Entities.User", "User")
                        .WithOne("Document")
                        .HasForeignKey("DesafioPaschoalotto.Domain.Entities.Document", "UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_documents_users_userid");

                    b.Navigation("User");
                });

            modelBuilder.Entity("DesafioPaschoalotto.Domain.Entities.Location", b =>
                {
                    b.HasOne("DesafioPaschoalotto.Domain.Entities.User", "User")
                        .WithOne("Location")
                        .HasForeignKey("DesafioPaschoalotto.Domain.Entities.Location", "UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_locations_users_userid");

                    b.Navigation("User");
                });

            modelBuilder.Entity("DesafioPaschoalotto.Domain.Entities.User", b =>
                {
                    b.Navigation("Contact")
                        .IsRequired();

                    b.Navigation("Document")
                        .IsRequired();

                    b.Navigation("Location")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
