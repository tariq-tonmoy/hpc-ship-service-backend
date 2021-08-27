using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ShipService.Infrastructure.Ship.Cqrs.Repository.Sqlite.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ShipAggregateRoots",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    ShipName = table.Column<string>(type: "TEXT", nullable: false),
                    Code = table.Column<string>(type: "TEXT", nullable: false),
                    Version = table.Column<int>(type: "INTEGER", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "TEXT", nullable: false),
                    LastUpdatedBy = table.Column<Guid>(type: "TEXT", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    LastUpdatedDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    IsMarkedToDelete = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShipAggregateRoots", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ShipDimensions",
                columns: table => new
                {
                    DomainId = table.Column<Guid>(type: "TEXT", nullable: false),
                    DimensionId = table.Column<Guid>(type: "TEXT", nullable: false),
                    Height = table.Column<decimal>(type: "TEXT", nullable: false),
                    Width = table.Column<decimal>(type: "TEXT", nullable: false),
                    Unit = table.Column<string>(type: "TEXT", nullable: false),
                    ShipAggregateRootId = table.Column<Guid>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShipDimensions", x => x.DomainId);
                    table.ForeignKey(
                        name: "FK_ShipDimensions_ShipAggregateRoots_ShipAggregateRootId",
                        column: x => x.ShipAggregateRootId,
                        principalTable: "ShipAggregateRoots",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "ShipAggregateRoots",
                columns: new[] { "Id", "Code", "CreatedBy", "CreatedDate", "IsMarkedToDelete", "LastUpdatedBy", "LastUpdatedDate", "ShipName", "Version" },
                values: new object[] { new Guid("882637bc-050b-48d7-a802-88920c53036c"), "AAAA-1111-A1", new Guid("35e8f034-89c6-4329-b980-29a33a6024f1"), new DateTime(2021, 8, 26, 14, 45, 7, 612, DateTimeKind.Utc).AddTicks(5894), false, new Guid("399324f6-6a75-496c-92be-3d5b0ef5c278"), new DateTime(2021, 8, 26, 14, 45, 7, 612, DateTimeKind.Utc).AddTicks(5907), "Ship 1", 1 });

            migrationBuilder.InsertData(
                table: "ShipDimensions",
                columns: new[] { "DomainId", "DimensionId", "Height", "ShipAggregateRootId", "Unit", "Width" },
                values: new object[] { new Guid("5c07bacc-afa9-4931-8b5f-566cff2a05f0"), new Guid("5c07bacc-afa9-4931-8b5f-566cff2a05f0"), 1.1m, new Guid("882637bc-050b-48d7-a802-88920c53036c"), "Meters", 2.2m });

            migrationBuilder.InsertData(
                table: "ShipDimensions",
                columns: new[] { "DomainId", "DimensionId", "Height", "ShipAggregateRootId", "Unit", "Width" },
                values: new object[] { new Guid("255f68a0-d11f-4a45-ba13-afcfc258e276"), new Guid("255f68a0-d11f-4a45-ba13-afcfc258e276"), 121.1m, new Guid("882637bc-050b-48d7-a802-88920c53036c"), "Feet", 221.2m });

            migrationBuilder.CreateIndex(
                name: "IX_ShipDimensions_ShipAggregateRootId",
                table: "ShipDimensions",
                column: "ShipAggregateRootId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ShipDimensions");

            migrationBuilder.DropTable(
                name: "ShipAggregateRoots");
        }
    }
}
