﻿// <auto-generated />
using System;
using dhanman.money.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace dhanman.money.Persistence.Migrations.Application
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20230805145456_authentication_updates")]
    partial class authentication_updates
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("dhanman.money.Domain.Authorization.Role", b =>
                {
                    b.Property<string>("Name")
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)")
                        .HasColumnName("name");

                    b.Property<string>("Description")
                        .HasMaxLength(200)
                        .HasColumnType("character varying(200)")
                        .HasColumnName("description");

                    b.HasKey("Name")
                        .HasName("pk_roles");

                    b.ToTable("roles", (string)null);
                });

            modelBuilder.Entity("dhanman.money.Domain.Authorization.UserPaidModules", b =>
                {
                    b.Property<Guid>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("user_id");

                    b.Property<long>("PaidModules")
                        .HasColumnType("bigint")
                        .HasColumnName("paid_modules");

                    b.HasKey("UserId")
                        .HasName("pk_user_roles");

                    b.ToTable("user_roles", (string)null);
                });

            modelBuilder.Entity("dhanman.money.Domain.Authorization.UserRole", b =>
                {
                    b.Property<Guid>("UserId")
                        .HasColumnType("uuid")
                        .HasColumnName("user_id");

                    b.Property<string>("RoleName")
                        .HasColumnType("text")
                        .HasColumnName("role_name");

                    b.HasKey("UserId", "RoleName")
                        .HasName("pk_user_paid_modules");

                    b.ToTable("user_paid_modules", (string)null);
                });

            modelBuilder.Entity("dhanman.money.Domain.Entities.Customers.Customer", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<Guid>("CreatedBy")
                        .HasColumnType("uuid")
                        .HasColumnName("created_by");

                    b.Property<DateTime>("CreatedOnUtc")
                        .HasColumnType("timestamp")
                        .HasColumnName("created_on_utc");

                    b.Property<DateTime?>("DeletedOnUtc")
                        .HasColumnType("timestamp")
                        .HasColumnName("deleted_on_utc");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)")
                        .HasColumnName("email");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)")
                        .HasColumnName("first_name");

                    b.Property<bool>("IsDeleted")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("boolean")
                        .HasDefaultValue(false)
                        .HasColumnName("is_deleted");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)")
                        .HasColumnName("last_name");

                    b.Property<Guid?>("ModifiedBy")
                        .HasColumnType("uuid")
                        .HasColumnName("modified_by");

                    b.Property<DateTime?>("ModifiedOnUtc")
                        .HasColumnType("timestamp")
                        .HasColumnName("modified_on_utc");

                    b.HasKey("Id")
                        .HasName("pk_customers");

                    b.ToTable("customers", (string)null);
                });

            modelBuilder.Entity("dhanman.money.Domain.Entities.InvoicePayments.InvoicePayment", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<decimal>("Amount")
                        .HasColumnType("decimal")
                        .HasColumnName("amount");

                    b.Property<Guid>("COAId")
                        .HasColumnType("uuid")
                        .HasColumnName("coa_id");

                    b.Property<Guid>("ClientId")
                        .HasColumnType("uuid")
                        .HasColumnName("client_id");

                    b.Property<Guid>("CreatedBy")
                        .HasColumnType("uuid")
                        .HasColumnName("created_by");

                    b.Property<DateTime>("CreatedOnUtc")
                        .HasColumnType("timestamp")
                        .HasColumnName("created_on_utc");

                    b.Property<DateTime?>("DeletedOnUtc")
                        .HasColumnType("timestamp")
                        .HasColumnName("deleted_on_utc");

                    b.Property<Guid>("InvoiceHeaderId")
                        .HasColumnType("uuid")
                        .HasColumnName("invoice_header_id");

                    b.Property<bool>("IsDeleted")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("boolean")
                        .HasDefaultValue(false)
                        .HasColumnName("is_deleted");

                    b.Property<Guid?>("ModifiedBy")
                        .HasColumnType("uuid")
                        .HasColumnName("modified_by");

                    b.Property<DateTime?>("ModifiedOnUtc")
                        .HasColumnType("timestamp")
                        .HasColumnName("modified_on_utc");

                    b.Property<Guid>("TransactionId")
                        .HasColumnType("uuid")
                        .HasColumnName("transaction_id");

                    b.HasKey("Id")
                        .HasName("pk_invoice_payments");

                    b.ToTable("invoice_payments", (string)null);
                });

            modelBuilder.Entity("dhanman.money.Domain.Entities.InvoiceStatuses.InvoiceStatus", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<Guid>("ClientId")
                        .HasColumnType("uuid")
                        .HasColumnName("client_id");

                    b.Property<Guid>("CreatedBy")
                        .HasColumnType("uuid")
                        .HasColumnName("created_by");

                    b.Property<DateTime>("CreatedOnUtc")
                        .HasColumnType("timestamp")
                        .HasColumnName("created_on_utc");

                    b.Property<DateTime?>("DeletedOnUtc")
                        .HasColumnType("timestamp")
                        .HasColumnName("deleted_on_utc");

                    b.Property<bool>("IsDeleted")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("boolean")
                        .HasDefaultValue(false)
                        .HasColumnName("is_deleted");

                    b.Property<Guid?>("ModifiedBy")
                        .HasColumnType("uuid")
                        .HasColumnName("modified_by");

                    b.Property<DateTime?>("ModifiedOnUtc")
                        .HasColumnType("timestamp")
                        .HasColumnName("modified_on_utc");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)")
                        .HasColumnName("name");

                    b.HasKey("Id")
                        .HasName("pk_invoice_statuses");

                    b.ToTable("invoice_statuses", (string)null);
                });

            modelBuilder.Entity("dhanman.money.Domain.Entities.Users.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<Guid>("CreatedBy")
                        .HasColumnType("uuid")
                        .HasColumnName("created_by");

                    b.Property<DateTime>("CreatedOnUtc")
                        .HasColumnType("timestamp")
                        .HasColumnName("created_on_utc");

                    b.Property<DateTime?>("DeletedOnUtc")
                        .HasColumnType("timestamp")
                        .HasColumnName("deleted_on_utc");

                    b.Property<bool>("IsDeleted")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("boolean")
                        .HasDefaultValue(false)
                        .HasColumnName("is_deleted");

                    b.Property<Guid?>("ModifiedBy")
                        .HasColumnType("uuid")
                        .HasColumnName("modified_by");

                    b.Property<DateTime?>("ModifiedOnUtc")
                        .HasColumnType("timestamp")
                        .HasColumnName("modified_on_utc");

                    b.Property<string>("_passwordHash")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("password_hash");

                    b.HasKey("Id")
                        .HasName("pk_users");

                    b.ToTable("users", (string)null);
                });

            modelBuilder.Entity("dhanman.money.Domain.Entities.Users.User", b =>
                {
                    b.OwnsOne("dhanman.money.Domain.Entities.Customers.Email", "Email", b1 =>
                        {
                            b1.Property<Guid>("UserId")
                                .HasColumnType("uuid")
                                .HasColumnName("id");

                            b1.Property<string>("Value")
                                .IsRequired()
                                .HasMaxLength(256)
                                .HasColumnType("character varying(256)")
                                .HasColumnName("email");

                            b1.HasKey("UserId");

                            b1.ToTable("users");

                            b1.WithOwner()
                                .HasForeignKey("UserId")
                                .HasConstraintName("fk_users_users_id");
                        });

                    b.OwnsOne("dhanman.money.Domain.Entities.Customers.FirstName", "FirstName", b1 =>
                        {
                            b1.Property<Guid>("UserId")
                                .HasColumnType("uuid")
                                .HasColumnName("id");

                            b1.Property<string>("Value")
                                .IsRequired()
                                .HasMaxLength(100)
                                .HasColumnType("character varying(100)")
                                .HasColumnName("first_name");

                            b1.HasKey("UserId");

                            b1.ToTable("users");

                            b1.WithOwner()
                                .HasForeignKey("UserId")
                                .HasConstraintName("fk_users_users_id");
                        });

                    b.OwnsOne("dhanman.money.Domain.Entities.Customers.LastName", "LastName", b1 =>
                        {
                            b1.Property<Guid>("UserId")
                                .HasColumnType("uuid")
                                .HasColumnName("id");

                            b1.Property<string>("Value")
                                .IsRequired()
                                .HasMaxLength(100)
                                .HasColumnType("character varying(100)")
                                .HasColumnName("last_name");

                            b1.HasKey("UserId");

                            b1.ToTable("users");

                            b1.WithOwner()
                                .HasForeignKey("UserId")
                                .HasConstraintName("fk_users_users_id");
                        });

                    b.Navigation("Email")
                        .IsRequired();

                    b.Navigation("FirstName")
                        .IsRequired();

                    b.Navigation("LastName")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
