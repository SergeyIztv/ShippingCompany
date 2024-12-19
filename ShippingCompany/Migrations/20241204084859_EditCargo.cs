using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ShippingCompany.Migrations
{
    /// <inheritdoc />
    public partial class EditCargo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cargo_TypeOfCargo_Price",
                table: "Cargo");

            migrationBuilder.DropForeignKey(
                name: "FK_Cargo_UnitOfMeasurement_UnitOfMeasurementId",
                table: "Cargo");

            migrationBuilder.RenameColumn(
                name: "Price",
                table: "Cargo",
                newName: "TypeOfCargoId");

            migrationBuilder.RenameIndex(
                name: "IX_Cargo_Price",
                table: "Cargo",
                newName: "IX_Cargo_TypeOfCargoId");

            migrationBuilder.AlterColumn<long>(
                name: "UnitOfMeasurementId",
                table: "Cargo",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<long>(
                name: "TypeOfCargoId",
                table: "Cargo",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AddForeignKey(
                name: "FK_Cargo_TypeOfCargo_TypeOfCargoId",
                table: "Cargo",
                column: "TypeOfCargoId",
                principalTable: "TypeOfCargo",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Cargo_UnitOfMeasurement_UnitOfMeasurementId",
                table: "Cargo",
                column: "UnitOfMeasurementId",
                principalTable: "UnitOfMeasurement",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cargo_TypeOfCargo_TypeOfCargoId",
                table: "Cargo");

            migrationBuilder.DropForeignKey(
                name: "FK_Cargo_UnitOfMeasurement_UnitOfMeasurementId",
                table: "Cargo");

            migrationBuilder.RenameColumn(
                name: "TypeOfCargoId",
                table: "Cargo",
                newName: "Price");

            migrationBuilder.RenameIndex(
                name: "IX_Cargo_TypeOfCargoId",
                table: "Cargo",
                newName: "IX_Cargo_Price");

            migrationBuilder.AlterColumn<long>(
                name: "UnitOfMeasurementId",
                table: "Cargo",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "Price",
                table: "Cargo",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Cargo_TypeOfCargo_Price",
                table: "Cargo",
                column: "Price",
                principalTable: "TypeOfCargo",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Cargo_UnitOfMeasurement_UnitOfMeasurementId",
                table: "Cargo",
                column: "UnitOfMeasurementId",
                principalTable: "UnitOfMeasurement",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
