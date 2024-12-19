﻿// <auto-generated />
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using ShippingCompany.data;

#nullable disable

namespace ShippingCompany.Migrations
{
    [DbContext(typeof(ShippingCompanyDbContext))]
    [Migration("20241126140426_InitialCreate")]
    partial class InitialCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("ShippingCompany.domain.entities.Bank", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Banks");
                });

            modelBuilder.Entity("ShippingCompany.domain.entities.Cargo", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<float>("DeclaredCargo")
                        .HasColumnType("real");

                    b.Property<float>("InsuredCargo")
                        .HasColumnType("real");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<long>("TypeOfCargoId")
                        .HasColumnType("bigint");

                    b.Property<long>("UnitOfMeasurementId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("TypeOfCargoId");

                    b.HasIndex("UnitOfMeasurementId");

                    b.ToTable("Cargos");
                });

            modelBuilder.Entity("ShippingCompany.domain.entities.ClientCompany", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<long>("BankId")
                        .HasColumnType("bigint");

                    b.Property<int>("CompanyRole")
                        .HasColumnType("integer");

                    b.Property<string>("HouseNumber")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("IndividualTaxpayerNumber")
                        .HasColumnType("integer");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("OfficeNumber")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<long>("StreetId")
                        .HasColumnType("bigint");

                    b.Property<long>("TownId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("BankId");

                    b.HasIndex("StreetId");

                    b.HasIndex("TownId");

                    b.ToTable("ClientCompanies");
                });

            modelBuilder.Entity("ShippingCompany.domain.entities.Port", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<long?>("VoyageId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("VoyageId");

                    b.ToTable("Ports");
                });

            modelBuilder.Entity("ShippingCompany.domain.entities.Ship", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<string>("FullNameOfCaptain")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("PhotoPath")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<long>("PortId")
                        .HasColumnType("bigint");

                    b.Property<string>("RegistrationNumber")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("ShipType")
                        .HasColumnType("integer");

                    b.Property<int>("Tonnage")
                        .HasColumnType("integer");

                    b.Property<int>("YearOfBuilt")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("PortId");

                    b.ToTable("Ships");
                });

            modelBuilder.Entity("ShippingCompany.domain.entities.Shipment", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<DateTime>("ArrivalDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("CustomsBatchNumber")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("CustomsDeclarationNumber")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("DepartureDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<long>("DestinationPortId")
                        .HasColumnType("bigint");

                    b.Property<long>("ReceivingCompanyId")
                        .HasColumnType("bigint");

                    b.Property<long>("SendingCompanyId")
                        .HasColumnType("bigint");

                    b.Property<long>("SourcePortId")
                        .HasColumnType("bigint");

                    b.Property<long>("VoyageId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("DestinationPortId");

                    b.HasIndex("ReceivingCompanyId");

                    b.HasIndex("SendingCompanyId");

                    b.HasIndex("SourcePortId");

                    b.HasIndex("VoyageId");

                    b.ToTable("Shipments");
                });

            modelBuilder.Entity("ShippingCompany.domain.entities.Street", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Streets");
                });

            modelBuilder.Entity("ShippingCompany.domain.entities.Town", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Towns");
                });

            modelBuilder.Entity("ShippingCompany.domain.entities.TypeOfCargo", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("TypeOfCargos");
                });

            modelBuilder.Entity("ShippingCompany.domain.entities.UnitOfMeasurement", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("UnitOfMeasurements");
                });

            modelBuilder.Entity("ShippingCompany.domain.entities.Voyage", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<long>("DestinationPortId")
                        .HasColumnType("bigint");

                    b.Property<List<long>>("PortsId")
                        .IsRequired()
                        .HasColumnType("bigint[]");

                    b.Property<long>("ShipId")
                        .HasColumnType("bigint");

                    b.Property<long>("SourcePortId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("DestinationPortId");

                    b.HasIndex("ShipId");

                    b.HasIndex("SourcePortId");

                    b.ToTable("Voyages");
                });

            modelBuilder.Entity("ShippingCompany.domain.entities.Cargo", b =>
                {
                    b.HasOne("ShippingCompany.domain.entities.TypeOfCargo", "TypeOfCargo")
                        .WithMany()
                        .HasForeignKey("TypeOfCargoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ShippingCompany.domain.entities.UnitOfMeasurement", "UnitOfMeasurement")
                        .WithMany()
                        .HasForeignKey("UnitOfMeasurementId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("TypeOfCargo");

                    b.Navigation("UnitOfMeasurement");
                });

            modelBuilder.Entity("ShippingCompany.domain.entities.ClientCompany", b =>
                {
                    b.HasOne("ShippingCompany.domain.entities.Bank", "Bank")
                        .WithMany()
                        .HasForeignKey("BankId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ShippingCompany.domain.entities.Street", "Street")
                        .WithMany()
                        .HasForeignKey("StreetId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ShippingCompany.domain.entities.Town", "Town")
                        .WithMany()
                        .HasForeignKey("TownId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Bank");

                    b.Navigation("Street");

                    b.Navigation("Town");
                });

            modelBuilder.Entity("ShippingCompany.domain.entities.Port", b =>
                {
                    b.HasOne("ShippingCompany.domain.entities.Voyage", null)
                        .WithMany("Ports")
                        .HasForeignKey("VoyageId");
                });

            modelBuilder.Entity("ShippingCompany.domain.entities.Ship", b =>
                {
                    b.HasOne("ShippingCompany.domain.entities.Port", "Port")
                        .WithMany()
                        .HasForeignKey("PortId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Port");
                });

            modelBuilder.Entity("ShippingCompany.domain.entities.Shipment", b =>
                {
                    b.HasOne("ShippingCompany.domain.entities.Port", "DestinationPort")
                        .WithMany()
                        .HasForeignKey("DestinationPortId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ShippingCompany.domain.entities.ClientCompany", "ReceivingCompany")
                        .WithMany()
                        .HasForeignKey("ReceivingCompanyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ShippingCompany.domain.entities.ClientCompany", "SendingCompany")
                        .WithMany()
                        .HasForeignKey("SendingCompanyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ShippingCompany.domain.entities.Port", "SourcePort")
                        .WithMany()
                        .HasForeignKey("SourcePortId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ShippingCompany.domain.entities.Voyage", "Voyage")
                        .WithMany()
                        .HasForeignKey("VoyageId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("DestinationPort");

                    b.Navigation("ReceivingCompany");

                    b.Navigation("SendingCompany");

                    b.Navigation("SourcePort");

                    b.Navigation("Voyage");
                });

            modelBuilder.Entity("ShippingCompany.domain.entities.Voyage", b =>
                {
                    b.HasOne("ShippingCompany.domain.entities.Port", "DestinationPort")
                        .WithMany()
                        .HasForeignKey("DestinationPortId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ShippingCompany.domain.entities.Ship", "Ship")
                        .WithMany()
                        .HasForeignKey("ShipId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ShippingCompany.domain.entities.Port", "SourcePort")
                        .WithMany()
                        .HasForeignKey("SourcePortId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("DestinationPort");

                    b.Navigation("Ship");

                    b.Navigation("SourcePort");
                });

            modelBuilder.Entity("ShippingCompany.domain.entities.Voyage", b =>
                {
                    b.Navigation("Ports");
                });
#pragma warning restore 612, 618
        }
    }
}
