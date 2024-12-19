using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace ShippingCompany.Migrations
{
    /// <inheritdoc />
    public partial class AddNewTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cargos_TypeOfCargos_TypeOfCargoId",
                table: "Cargos");

            migrationBuilder.DropForeignKey(
                name: "FK_Cargos_UnitOfMeasurements_UnitOfMeasurementId",
                table: "Cargos");

            migrationBuilder.DropForeignKey(
                name: "FK_ClientCompanies_Bank_BankId",
                table: "ClientCompanies");

            migrationBuilder.DropForeignKey(
                name: "FK_ClientCompanies_Streets_StreetId",
                table: "ClientCompanies");

            migrationBuilder.DropForeignKey(
                name: "FK_ClientCompanies_Towns_TownId",
                table: "ClientCompanies");

            migrationBuilder.DropForeignKey(
                name: "FK_Shipments_ClientCompanies_ReceivingCompanyId",
                table: "Shipments");

            migrationBuilder.DropForeignKey(
                name: "FK_Shipments_ClientCompanies_SendingCompanyId",
                table: "Shipments");

            migrationBuilder.DropForeignKey(
                name: "FK_Shipments_Ports_DestinationPortId",
                table: "Shipments");

            migrationBuilder.DropForeignKey(
                name: "FK_Shipments_Ports_SourcePortId",
                table: "Shipments");

            migrationBuilder.DropForeignKey(
                name: "FK_Shipments_Voyages_VoyageId",
                table: "Shipments");

            migrationBuilder.DropForeignKey(
                name: "FK_Ships_Ports_PortId",
                table: "Ships");

            migrationBuilder.DropForeignKey(
                name: "FK_Voyages_Ports_DestinationPortId",
                table: "Voyages");

            migrationBuilder.DropForeignKey(
                name: "FK_Voyages_Ports_SourcePortId",
                table: "Voyages");

            migrationBuilder.DropForeignKey(
                name: "FK_Voyages_Ships_ShipId",
                table: "Voyages");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Voyages",
                table: "Voyages");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UnitOfMeasurements",
                table: "UnitOfMeasurements");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TypeOfCargos",
                table: "TypeOfCargos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Towns",
                table: "Towns");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Streets",
                table: "Streets");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Ships",
                table: "Ships");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Shipments",
                table: "Shipments");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Ports",
                table: "Ports");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ClientCompanies",
                table: "ClientCompanies");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Cargos",
                table: "Cargos");

            migrationBuilder.RenameTable(
                name: "Voyages",
                newName: "Voyage");

            migrationBuilder.RenameTable(
                name: "UnitOfMeasurements",
                newName: "UnitOfMeasurement");

            migrationBuilder.RenameTable(
                name: "TypeOfCargos",
                newName: "TypeOfCargo");

            migrationBuilder.RenameTable(
                name: "Towns",
                newName: "Town");

            migrationBuilder.RenameTable(
                name: "Streets",
                newName: "Street");

            migrationBuilder.RenameTable(
                name: "Ships",
                newName: "Ship");

            migrationBuilder.RenameTable(
                name: "Shipments",
                newName: "Shipment");

            migrationBuilder.RenameTable(
                name: "Ports",
                newName: "Port");

            migrationBuilder.RenameTable(
                name: "ClientCompanies",
                newName: "ClientCompany");

            migrationBuilder.RenameTable(
                name: "Cargos",
                newName: "Cargo");

            migrationBuilder.RenameColumn(
                name: "DestinationPortId",
                table: "Voyage",
                newName: "DestinatinPortId");

            migrationBuilder.RenameIndex(
                name: "IX_Voyages_SourcePortId",
                table: "Voyage",
                newName: "IX_Voyage_SourcePortId");

            migrationBuilder.RenameIndex(
                name: "IX_Voyages_ShipId",
                table: "Voyage",
                newName: "IX_Voyage_ShipId");

            migrationBuilder.RenameIndex(
                name: "IX_Voyages_DestinationPortId",
                table: "Voyage",
                newName: "IX_Voyage_DestinatinPortId");

            migrationBuilder.RenameIndex(
                name: "IX_Ships_PortId",
                table: "Ship",
                newName: "IX_Ship_PortId");

            migrationBuilder.RenameIndex(
                name: "IX_Shipments_VoyageId",
                table: "Shipment",
                newName: "IX_Shipment_VoyageId");

            migrationBuilder.RenameIndex(
                name: "IX_Shipments_SourcePortId",
                table: "Shipment",
                newName: "IX_Shipment_SourcePortId");

            migrationBuilder.RenameIndex(
                name: "IX_Shipments_SendingCompanyId",
                table: "Shipment",
                newName: "IX_Shipment_SendingCompanyId");

            migrationBuilder.RenameIndex(
                name: "IX_Shipments_ReceivingCompanyId",
                table: "Shipment",
                newName: "IX_Shipment_ReceivingCompanyId");

            migrationBuilder.RenameIndex(
                name: "IX_Shipments_DestinationPortId",
                table: "Shipment",
                newName: "IX_Shipment_DestinationPortId");

            migrationBuilder.RenameColumn(
                name: "IndividualTaxpayerNumber",
                table: "ClientCompany",
                newName: "IndividualTaxplayerNumber");

            migrationBuilder.RenameIndex(
                name: "IX_ClientCompanies_TownId",
                table: "ClientCompany",
                newName: "IX_ClientCompany_TownId");

            migrationBuilder.RenameIndex(
                name: "IX_ClientCompanies_StreetId",
                table: "ClientCompany",
                newName: "IX_ClientCompany_StreetId");

            migrationBuilder.RenameIndex(
                name: "IX_ClientCompanies_BankId",
                table: "ClientCompany",
                newName: "IX_ClientCompany_BankId");

            migrationBuilder.RenameColumn(
                name: "TypeOfCargoId",
                table: "Cargo",
                newName: "Price");

            migrationBuilder.RenameIndex(
                name: "IX_Cargos_UnitOfMeasurementId",
                table: "Cargo",
                newName: "IX_Cargo_UnitOfMeasurementId");

            migrationBuilder.RenameIndex(
                name: "IX_Cargos_TypeOfCargoId",
                table: "Cargo",
                newName: "IX_Cargo_Price");

            migrationBuilder.AlterColumn<long>(
                name: "SourcePortId",
                table: "Voyage",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<long>(
                name: "ShipId",
                table: "Voyage",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<long>(
                name: "DestinatinPortId",
                table: "Voyage",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<int>(
                name: "ShipType",
                table: "Ship",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<long>(
                name: "PortId",
                table: "Ship",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<long>(
                name: "VoyageId",
                table: "Shipment",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<long>(
                name: "SourcePortId",
                table: "Shipment",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<long>(
                name: "SendingCompanyId",
                table: "Shipment",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<long>(
                name: "ReceivingCompanyId",
                table: "Shipment",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<long>(
                name: "DestinationPortId",
                table: "Shipment",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DepartureDate",
                table: "Shipment",
                type: "timestamp with time zone",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone");

            migrationBuilder.AlterColumn<DateTime>(
                name: "ArrivalDate",
                table: "Shipment",
                type: "timestamp with time zone",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone");

            migrationBuilder.AlterColumn<long>(
                name: "TownId",
                table: "ClientCompany",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<long>(
                name: "StreetId",
                table: "ClientCompany",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<int>(
                name: "CompanyRole",
                table: "ClientCompany",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<long>(
                name: "BankId",
                table: "ClientCompany",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Voyage",
                table: "Voyage",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UnitOfMeasurement",
                table: "UnitOfMeasurement",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TypeOfCargo",
                table: "TypeOfCargo",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Town",
                table: "Town",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Street",
                table: "Street",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Ship",
                table: "Ship",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Shipment",
                table: "Shipment",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Port",
                table: "Port",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ClientCompany",
                table: "ClientCompany",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Cargo",
                table: "Cargo",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "CargoShipment",
                columns: table => new
                {
                    CargoId = table.Column<long>(type: "bigint", nullable: false),
                    ShipmentId = table.Column<long>(type: "bigint", nullable: false),
                    Id = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CargoShipment", x => new { x.CargoId, x.ShipmentId });
                    table.ForeignKey(
                        name: "FK_CargoShipment_Cargo_CargoId",
                        column: x => x.CargoId,
                        principalTable: "Cargo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CargoShipment_Shipment_ShipmentId",
                        column: x => x.ShipmentId,
                        principalTable: "Shipment",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MenuItems",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ParentItemId = table.Column<long>(type: "bigint", nullable: true),
                    Name = table.Column<string>(type: "text", nullable: false),
                    NameOfDll = table.Column<string>(type: "text", nullable: false),
                    NameOfFunction = table.Column<string>(type: "text", nullable: false),
                    SequenceNumber = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MenuItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MenuItems_MenuItems_ParentItemId",
                        column: x => x.ParentItemId,
                        principalTable: "MenuItems",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ShipTypeOfCargos",
                columns: table => new
                {
                    ShipId = table.Column<long>(type: "bigint", nullable: false),
                    TypeOfCargoId = table.Column<long>(type: "bigint", nullable: false),
                    Id = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShipTypeOfCargos", x => new { x.ShipId, x.TypeOfCargoId });
                    table.ForeignKey(
                        name: "FK_ShipTypeOfCargos_Ship_TypeOfCargoId",
                        column: x => x.TypeOfCargoId,
                        principalTable: "Ship",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ShipTypeOfCargos_TypeOfCargo_ShipId",
                        column: x => x.ShipId,
                        principalTable: "TypeOfCargo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Login = table.Column<string>(type: "text", nullable: false),
                    PasswordHash = table.Column<string>(type: "text", nullable: false),
                    Salt = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "VoyagePorts",
                columns: table => new
                {
                    VoyageId = table.Column<long>(type: "bigint", nullable: false),
                    PortId = table.Column<long>(type: "bigint", nullable: false),
                    Id = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VoyagePorts", x => new { x.VoyageId, x.PortId });
                    table.ForeignKey(
                        name: "FK_VoyagePorts_Port_VoyageId",
                        column: x => x.VoyageId,
                        principalTable: "Port",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_VoyagePorts_Voyage_PortId",
                        column: x => x.PortId,
                        principalTable: "Voyage",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserMenuItem",
                columns: table => new
                {
                    UserId = table.Column<long>(type: "bigint", nullable: false),
                    MenuItemId = table.Column<long>(type: "bigint", nullable: false),
                    Id = table.Column<long>(type: "bigint", nullable: false),
                    CanRead = table.Column<bool>(type: "boolean", nullable: false),
                    CanWrite = table.Column<bool>(type: "boolean", nullable: false),
                    CanEdit = table.Column<bool>(type: "boolean", nullable: false),
                    CanDelete = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserMenuItem", x => new { x.UserId, x.MenuItemId });
                    table.ForeignKey(
                        name: "FK_UserMenuItem_MenuItems_UserId",
                        column: x => x.UserId,
                        principalTable: "MenuItems",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserMenuItem_User_MenuItemId",
                        column: x => x.MenuItemId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CargoShipment_ShipmentId",
                table: "CargoShipment",
                column: "ShipmentId");

            migrationBuilder.CreateIndex(
                name: "IX_MenuItems_ParentItemId",
                table: "MenuItems",
                column: "ParentItemId");

            migrationBuilder.CreateIndex(
                name: "IX_ShipTypeOfCargos_TypeOfCargoId",
                table: "ShipTypeOfCargos",
                column: "TypeOfCargoId");

            migrationBuilder.CreateIndex(
                name: "IX_UserMenuItem_MenuItemId",
                table: "UserMenuItem",
                column: "MenuItemId");

            migrationBuilder.CreateIndex(
                name: "IX_VoyagePorts_PortId",
                table: "VoyagePorts",
                column: "PortId");

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

            migrationBuilder.AddForeignKey(
                name: "FK_ClientCompany_Bank_BankId",
                table: "ClientCompany",
                column: "BankId",
                principalTable: "Bank",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ClientCompany_Street_StreetId",
                table: "ClientCompany",
                column: "StreetId",
                principalTable: "Street",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ClientCompany_Town_TownId",
                table: "ClientCompany",
                column: "TownId",
                principalTable: "Town",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Ship_Port_PortId",
                table: "Ship",
                column: "PortId",
                principalTable: "Port",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Shipment_ClientCompany_ReceivingCompanyId",
                table: "Shipment",
                column: "ReceivingCompanyId",
                principalTable: "ClientCompany",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Shipment_ClientCompany_SendingCompanyId",
                table: "Shipment",
                column: "SendingCompanyId",
                principalTable: "ClientCompany",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Shipment_Port_DestinationPortId",
                table: "Shipment",
                column: "DestinationPortId",
                principalTable: "Port",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Shipment_Port_SourcePortId",
                table: "Shipment",
                column: "SourcePortId",
                principalTable: "Port",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Shipment_Voyage_VoyageId",
                table: "Shipment",
                column: "VoyageId",
                principalTable: "Voyage",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Voyage_Port_DestinatinPortId",
                table: "Voyage",
                column: "DestinatinPortId",
                principalTable: "Port",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Voyage_Port_SourcePortId",
                table: "Voyage",
                column: "SourcePortId",
                principalTable: "Port",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Voyage_Ship_ShipId",
                table: "Voyage",
                column: "ShipId",
                principalTable: "Ship",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cargo_TypeOfCargo_Price",
                table: "Cargo");

            migrationBuilder.DropForeignKey(
                name: "FK_Cargo_UnitOfMeasurement_UnitOfMeasurementId",
                table: "Cargo");

            migrationBuilder.DropForeignKey(
                name: "FK_ClientCompany_Bank_BankId",
                table: "ClientCompany");

            migrationBuilder.DropForeignKey(
                name: "FK_ClientCompany_Street_StreetId",
                table: "ClientCompany");

            migrationBuilder.DropForeignKey(
                name: "FK_ClientCompany_Town_TownId",
                table: "ClientCompany");

            migrationBuilder.DropForeignKey(
                name: "FK_Ship_Port_PortId",
                table: "Ship");

            migrationBuilder.DropForeignKey(
                name: "FK_Shipment_ClientCompany_ReceivingCompanyId",
                table: "Shipment");

            migrationBuilder.DropForeignKey(
                name: "FK_Shipment_ClientCompany_SendingCompanyId",
                table: "Shipment");

            migrationBuilder.DropForeignKey(
                name: "FK_Shipment_Port_DestinationPortId",
                table: "Shipment");

            migrationBuilder.DropForeignKey(
                name: "FK_Shipment_Port_SourcePortId",
                table: "Shipment");

            migrationBuilder.DropForeignKey(
                name: "FK_Shipment_Voyage_VoyageId",
                table: "Shipment");

            migrationBuilder.DropForeignKey(
                name: "FK_Voyage_Port_DestinatinPortId",
                table: "Voyage");

            migrationBuilder.DropForeignKey(
                name: "FK_Voyage_Port_SourcePortId",
                table: "Voyage");

            migrationBuilder.DropForeignKey(
                name: "FK_Voyage_Ship_ShipId",
                table: "Voyage");

            migrationBuilder.DropTable(
                name: "CargoShipment");

            migrationBuilder.DropTable(
                name: "ShipTypeOfCargos");

            migrationBuilder.DropTable(
                name: "UserMenuItem");

            migrationBuilder.DropTable(
                name: "VoyagePorts");

            migrationBuilder.DropTable(
                name: "MenuItems");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Voyage",
                table: "Voyage");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UnitOfMeasurement",
                table: "UnitOfMeasurement");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TypeOfCargo",
                table: "TypeOfCargo");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Town",
                table: "Town");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Street",
                table: "Street");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Shipment",
                table: "Shipment");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Ship",
                table: "Ship");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Port",
                table: "Port");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ClientCompany",
                table: "ClientCompany");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Cargo",
                table: "Cargo");

            migrationBuilder.RenameTable(
                name: "Voyage",
                newName: "Voyages");

            migrationBuilder.RenameTable(
                name: "UnitOfMeasurement",
                newName: "UnitOfMeasurements");

            migrationBuilder.RenameTable(
                name: "TypeOfCargo",
                newName: "TypeOfCargos");

            migrationBuilder.RenameTable(
                name: "Town",
                newName: "Towns");

            migrationBuilder.RenameTable(
                name: "Street",
                newName: "Streets");

            migrationBuilder.RenameTable(
                name: "Shipment",
                newName: "Shipments");

            migrationBuilder.RenameTable(
                name: "Ship",
                newName: "Ships");

            migrationBuilder.RenameTable(
                name: "Port",
                newName: "Ports");

            migrationBuilder.RenameTable(
                name: "ClientCompany",
                newName: "ClientCompanies");

            migrationBuilder.RenameTable(
                name: "Cargo",
                newName: "Cargos");

            migrationBuilder.RenameColumn(
                name: "DestinatinPortId",
                table: "Voyages",
                newName: "DestinationPortId");

            migrationBuilder.RenameIndex(
                name: "IX_Voyage_SourcePortId",
                table: "Voyages",
                newName: "IX_Voyages_SourcePortId");

            migrationBuilder.RenameIndex(
                name: "IX_Voyage_ShipId",
                table: "Voyages",
                newName: "IX_Voyages_ShipId");

            migrationBuilder.RenameIndex(
                name: "IX_Voyage_DestinatinPortId",
                table: "Voyages",
                newName: "IX_Voyages_DestinationPortId");

            migrationBuilder.RenameIndex(
                name: "IX_Shipment_VoyageId",
                table: "Shipments",
                newName: "IX_Shipments_VoyageId");

            migrationBuilder.RenameIndex(
                name: "IX_Shipment_SourcePortId",
                table: "Shipments",
                newName: "IX_Shipments_SourcePortId");

            migrationBuilder.RenameIndex(
                name: "IX_Shipment_SendingCompanyId",
                table: "Shipments",
                newName: "IX_Shipments_SendingCompanyId");

            migrationBuilder.RenameIndex(
                name: "IX_Shipment_ReceivingCompanyId",
                table: "Shipments",
                newName: "IX_Shipments_ReceivingCompanyId");

            migrationBuilder.RenameIndex(
                name: "IX_Shipment_DestinationPortId",
                table: "Shipments",
                newName: "IX_Shipments_DestinationPortId");

            migrationBuilder.RenameIndex(
                name: "IX_Ship_PortId",
                table: "Ships",
                newName: "IX_Ships_PortId");

            migrationBuilder.RenameColumn(
                name: "IndividualTaxplayerNumber",
                table: "ClientCompanies",
                newName: "IndividualTaxpayerNumber");

            migrationBuilder.RenameIndex(
                name: "IX_ClientCompany_TownId",
                table: "ClientCompanies",
                newName: "IX_ClientCompanies_TownId");

            migrationBuilder.RenameIndex(
                name: "IX_ClientCompany_StreetId",
                table: "ClientCompanies",
                newName: "IX_ClientCompanies_StreetId");

            migrationBuilder.RenameIndex(
                name: "IX_ClientCompany_BankId",
                table: "ClientCompanies",
                newName: "IX_ClientCompanies_BankId");

            migrationBuilder.RenameColumn(
                name: "Price",
                table: "Cargos",
                newName: "TypeOfCargoId");

            migrationBuilder.RenameIndex(
                name: "IX_Cargo_UnitOfMeasurementId",
                table: "Cargos",
                newName: "IX_Cargos_UnitOfMeasurementId");

            migrationBuilder.RenameIndex(
                name: "IX_Cargo_Price",
                table: "Cargos",
                newName: "IX_Cargos_TypeOfCargoId");

            migrationBuilder.AlterColumn<long>(
                name: "SourcePortId",
                table: "Voyages",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "ShipId",
                table: "Voyages",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "DestinationPortId",
                table: "Voyages",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "VoyageId",
                table: "Shipments",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "SourcePortId",
                table: "Shipments",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "SendingCompanyId",
                table: "Shipments",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "ReceivingCompanyId",
                table: "Shipments",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "DestinationPortId",
                table: "Shipments",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "DepartureDate",
                table: "Shipments",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "ArrivalDate",
                table: "Shipments",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ShipType",
                table: "Ships",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "PortId",
                table: "Ships",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "TownId",
                table: "ClientCompanies",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "StreetId",
                table: "ClientCompanies",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "CompanyRole",
                table: "ClientCompanies",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "BankId",
                table: "ClientCompanies",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Voyages",
                table: "Voyages",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UnitOfMeasurements",
                table: "UnitOfMeasurements",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TypeOfCargos",
                table: "TypeOfCargos",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Towns",
                table: "Towns",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Streets",
                table: "Streets",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Shipments",
                table: "Shipments",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Ships",
                table: "Ships",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Ports",
                table: "Ports",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ClientCompanies",
                table: "ClientCompanies",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Cargos",
                table: "Cargos",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Cargos_TypeOfCargos_TypeOfCargoId",
                table: "Cargos",
                column: "TypeOfCargoId",
                principalTable: "TypeOfCargos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Cargos_UnitOfMeasurements_UnitOfMeasurementId",
                table: "Cargos",
                column: "UnitOfMeasurementId",
                principalTable: "UnitOfMeasurements",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ClientCompanies_Bank_BankId",
                table: "ClientCompanies",
                column: "BankId",
                principalTable: "Bank",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ClientCompanies_Streets_StreetId",
                table: "ClientCompanies",
                column: "StreetId",
                principalTable: "Streets",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ClientCompanies_Towns_TownId",
                table: "ClientCompanies",
                column: "TownId",
                principalTable: "Towns",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Shipments_ClientCompanies_ReceivingCompanyId",
                table: "Shipments",
                column: "ReceivingCompanyId",
                principalTable: "ClientCompanies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Shipments_ClientCompanies_SendingCompanyId",
                table: "Shipments",
                column: "SendingCompanyId",
                principalTable: "ClientCompanies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Shipments_Ports_DestinationPortId",
                table: "Shipments",
                column: "DestinationPortId",
                principalTable: "Ports",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Shipments_Ports_SourcePortId",
                table: "Shipments",
                column: "SourcePortId",
                principalTable: "Ports",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Shipments_Voyages_VoyageId",
                table: "Shipments",
                column: "VoyageId",
                principalTable: "Voyages",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Ships_Ports_PortId",
                table: "Ships",
                column: "PortId",
                principalTable: "Ports",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Voyages_Ports_DestinationPortId",
                table: "Voyages",
                column: "DestinationPortId",
                principalTable: "Ports",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Voyages_Ports_SourcePortId",
                table: "Voyages",
                column: "SourcePortId",
                principalTable: "Ports",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Voyages_Ships_ShipId",
                table: "Voyages",
                column: "ShipId",
                principalTable: "Ships",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
