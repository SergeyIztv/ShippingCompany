using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace ShippingCompany.Migrations
{
    /// <inheritdoc />
    public partial class DeleteCargoShipment : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_CargoShipment",
                table: "CargoShipment");

            migrationBuilder.AddColumn<DateTime>(
                name: "ArrivalDate",
                table: "Voyage",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DepartureDate",
                table: "Voyage",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "Id",
                table: "CargoShipment",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AddColumn<long>(
                name: "ShipmentId",
                table: "Cargo",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_CargoShipment",
                table: "CargoShipment",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_CargoShipment_CargoId",
                table: "CargoShipment",
                column: "CargoId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_CargoShipment",
                table: "CargoShipment");

            migrationBuilder.DropIndex(
                name: "IX_CargoShipment_CargoId",
                table: "CargoShipment");

            migrationBuilder.DropColumn(
                name: "ArrivalDate",
                table: "Voyage");

            migrationBuilder.DropColumn(
                name: "DepartureDate",
                table: "Voyage");

            migrationBuilder.DropColumn(
                name: "ShipmentId",
                table: "Cargo");

            migrationBuilder.AlterColumn<long>(
                name: "Id",
                table: "CargoShipment",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint")
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AddPrimaryKey(
                name: "PK_CargoShipment",
                table: "CargoShipment",
                columns: new[] { "CargoId", "ShipmentId" });
        }
    }
}
