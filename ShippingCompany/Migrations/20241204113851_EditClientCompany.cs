﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ShippingCompany.Migrations
{
    /// <inheritdoc />
    public partial class EditClientCompany : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CompanyRole",
                table: "ClientCompany");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CompanyRole",
                table: "ClientCompany",
                type: "integer",
                nullable: true);
        }
    }
}
