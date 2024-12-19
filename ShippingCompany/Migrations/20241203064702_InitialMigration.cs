using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ShippingCompany.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ClientCompanies_Banks_BankId",
                table: "ClientCompanies");

            migrationBuilder.DropForeignKey(
                name: "FK_Ports_Voyages_VoyageId",
                table: "Ports");

            migrationBuilder.DropIndex(
                name: "IX_Ports_VoyageId",
                table: "Ports");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Banks",
                table: "Banks");

            migrationBuilder.DropColumn(
                name: "PortsId",
                table: "Voyages");

            migrationBuilder.DropColumn(
                name: "VoyageId",
                table: "Ports");

            migrationBuilder.RenameTable(
                name: "Banks",
                newName: "Bank");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Ships",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Bank",
                table: "Bank",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ClientCompanies_Bank_BankId",
                table: "ClientCompanies",
                column: "BankId",
                principalTable: "Bank",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ClientCompanies_Bank_BankId",
                table: "ClientCompanies");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Bank",
                table: "Bank");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Ships");

            migrationBuilder.RenameTable(
                name: "Bank",
                newName: "Banks");

            migrationBuilder.AddColumn<List<long>>(
                name: "PortsId",
                table: "Voyages",
                type: "bigint[]",
                nullable: false);

            migrationBuilder.AddColumn<long>(
                name: "VoyageId",
                table: "Ports",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Banks",
                table: "Banks",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Ports_VoyageId",
                table: "Ports",
                column: "VoyageId");

            migrationBuilder.AddForeignKey(
                name: "FK_ClientCompanies_Banks_BankId",
                table: "ClientCompanies",
                column: "BankId",
                principalTable: "Banks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Ports_Voyages_VoyageId",
                table: "Ports",
                column: "VoyageId",
                principalTable: "Voyages",
                principalColumn: "Id");
        }
    }
}
