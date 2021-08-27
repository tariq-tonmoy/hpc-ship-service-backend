using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ShipService.Infrastructure.Ship.Cqrs.Repository.Sqlite.Migrations.ShipViewModelDb
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ShipViewModels",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    ShipId = table.Column<Guid>(type: "TEXT", nullable: false),
                    ShipName = table.Column<string>(type: "TEXT", nullable: false),
                    Code = table.Column<string>(type: "TEXT", nullable: false),
                    Version = table.Column<int>(type: "INTEGER", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "TEXT", nullable: false),
                    LastUpdatedBy = table.Column<Guid>(type: "TEXT", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    LastUpdatedDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    RolesAllowedToRead = table.Column<string>(type: "TEXT", nullable: true),
                    IsMarkedToDelete = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShipViewModels", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DimensionViewModels",
                columns: table => new
                {
                    ViewModelId = table.Column<Guid>(type: "TEXT", nullable: false),
                    DimensionId = table.Column<Guid>(type: "TEXT", nullable: false),
                    Height = table.Column<decimal>(type: "TEXT", nullable: false),
                    Width = table.Column<decimal>(type: "TEXT", nullable: false),
                    Unit = table.Column<string>(type: "TEXT", nullable: false),
                    ShipViewModelId = table.Column<Guid>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DimensionViewModels", x => x.ViewModelId);
                    table.ForeignKey(
                        name: "FK_DimensionViewModels_ShipViewModels_ShipViewModelId",
                        column: x => x.ShipViewModelId,
                        principalTable: "ShipViewModels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "ShipViewModels",
                columns: new[] { "Id", "Code", "CreatedBy", "CreatedDate", "IsMarkedToDelete", "LastUpdatedBy", "LastUpdatedDate", "RolesAllowedToRead", "ShipId", "ShipName", "Version" },
                values: new object[] { new Guid("98a0c57f-2f32-4ec1-b769-2bc4e51c4e37"), "AAAA-1111-A1", new Guid("b542ec68-c721-4455-8b04-54e8ca7e8462"), new DateTime(2021, 8, 27, 5, 22, 31, 455, DateTimeKind.Utc).AddTicks(9986), false, new Guid("570a38d6-c777-495a-9d1f-21174d038a16"), new DateTime(2021, 8, 27, 5, 22, 31, 455, DateTimeKind.Utc).AddTicks(9999), null, new Guid("851b7c67-462e-46d4-8ecf-8c75e53a6601"), "Ship 1", 1 });

            migrationBuilder.InsertData(
                table: "ShipViewModels",
                columns: new[] { "Id", "Code", "CreatedBy", "CreatedDate", "IsMarkedToDelete", "LastUpdatedBy", "LastUpdatedDate", "RolesAllowedToRead", "ShipId", "ShipName", "Version" },
                values: new object[] { new Guid("b308da0e-c000-4a35-8244-793f5699d7e7"), "BBBB-2222-B2", new Guid("c53a5a8f-8720-4091-83b0-22d65855c274"), new DateTime(2021, 8, 27, 5, 22, 31, 457, DateTimeKind.Utc).AddTicks(4353), false, new Guid("24245a26-262d-4158-9255-f449438124b8"), new DateTime(2021, 8, 27, 5, 22, 31, 457, DateTimeKind.Utc).AddTicks(4360), null, new Guid("851b7c67-462e-46d4-8ecf-8c75e53a6601"), "Ship 2", 1 });

            migrationBuilder.InsertData(
                table: "DimensionViewModels",
                columns: new[] { "ViewModelId", "DimensionId", "Height", "ShipViewModelId", "Unit", "Width" },
                values: new object[] { new Guid("ec4622fd-a610-4775-b3f0-ce2488f203f2"), new Guid("851b7c67-462e-46d4-8ecf-8c75e53a6602"), 1.1m, new Guid("98a0c57f-2f32-4ec1-b769-2bc4e51c4e37"), "Meters", 2.2m });

            migrationBuilder.InsertData(
                table: "DimensionViewModels",
                columns: new[] { "ViewModelId", "DimensionId", "Height", "ShipViewModelId", "Unit", "Width" },
                values: new object[] { new Guid("851b7c67-462e-46d4-8ecf-8c75e53a661d"), new Guid("851b7c67-462e-46d4-8ecf-8c75e53a6603"), 10.1m, new Guid("98a0c57f-2f32-4ec1-b769-2bc4e51c4e37"), "Feet", 2.2m });

            migrationBuilder.InsertData(
                table: "DimensionViewModels",
                columns: new[] { "ViewModelId", "DimensionId", "Height", "ShipViewModelId", "Unit", "Width" },
                values: new object[] { new Guid("ec4622fd-a610-4775-b3f0-ce2488f203f3"), new Guid("851b7c67-462e-46d4-8ecf-8c75e53a6602"), 1.1m, new Guid("b308da0e-c000-4a35-8244-793f5699d7e7"), "Meters", 2.2m });

            migrationBuilder.InsertData(
                table: "DimensionViewModels",
                columns: new[] { "ViewModelId", "DimensionId", "Height", "ShipViewModelId", "Unit", "Width" },
                values: new object[] { new Guid("851b7c67-462e-46d4-8ecf-8c75e53a661e"), new Guid("851b7c67-462e-46d4-8ecf-8c75e53a6603"), 10.1m, new Guid("b308da0e-c000-4a35-8244-793f5699d7e7"), "Feet", 2.2m });

            migrationBuilder.CreateIndex(
                name: "IX_DimensionViewModels_ShipViewModelId",
                table: "DimensionViewModels",
                column: "ShipViewModelId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DimensionViewModels");

            migrationBuilder.DropTable(
                name: "ShipViewModels");
        }
    }
}
