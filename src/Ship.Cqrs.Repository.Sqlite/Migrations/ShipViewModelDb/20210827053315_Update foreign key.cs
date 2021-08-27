using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ShipService.Infrastructure.Ship.Cqrs.Repository.Sqlite.Migrations.ShipViewModelDb
{
    public partial class Updateforeignkey : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DimensionViewModels_ShipViewModels_ShipViewModelId",
                table: "DimensionViewModels");

            migrationBuilder.AlterColumn<Guid>(
                name: "ShipViewModelId",
                table: "DimensionViewModels",
                type: "TEXT",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "ShipViewModels",
                keyColumn: "Id",
                keyValue: new Guid("98a0c57f-2f32-4ec1-b769-2bc4e51c4e37"),
                columns: new[] { "CreatedBy", "CreatedDate", "LastUpdatedBy", "LastUpdatedDate" },
                values: new object[] { new Guid("14de8cec-3b4c-40c2-a49f-60621387ae35"), new DateTime(2021, 8, 27, 5, 33, 14, 395, DateTimeKind.Utc).AddTicks(1492), new Guid("22e7a5cb-247a-4142-b53c-33ba1569d267"), new DateTime(2021, 8, 27, 5, 33, 14, 395, DateTimeKind.Utc).AddTicks(1505) });

            migrationBuilder.UpdateData(
                table: "ShipViewModels",
                keyColumn: "Id",
                keyValue: new Guid("b308da0e-c000-4a35-8244-793f5699d7e7"),
                columns: new[] { "CreatedBy", "CreatedDate", "LastUpdatedBy", "LastUpdatedDate" },
                values: new object[] { new Guid("e6bca4dc-f8a7-47cf-91cd-91b9db219c17"), new DateTime(2021, 8, 27, 5, 33, 14, 396, DateTimeKind.Utc).AddTicks(5355), new Guid("3af3e38c-83dc-4094-8035-34cd7a19787d"), new DateTime(2021, 8, 27, 5, 33, 14, 396, DateTimeKind.Utc).AddTicks(5366) });

            migrationBuilder.AddForeignKey(
                name: "FK_DimensionViewModels_ShipViewModels_ShipViewModelId",
                table: "DimensionViewModels",
                column: "ShipViewModelId",
                principalTable: "ShipViewModels",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DimensionViewModels_ShipViewModels_ShipViewModelId",
                table: "DimensionViewModels");

            migrationBuilder.AlterColumn<Guid>(
                name: "ShipViewModelId",
                table: "DimensionViewModels",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "TEXT");

            migrationBuilder.UpdateData(
                table: "ShipViewModels",
                keyColumn: "Id",
                keyValue: new Guid("98a0c57f-2f32-4ec1-b769-2bc4e51c4e37"),
                columns: new[] { "CreatedBy", "CreatedDate", "LastUpdatedBy", "LastUpdatedDate" },
                values: new object[] { new Guid("b542ec68-c721-4455-8b04-54e8ca7e8462"), new DateTime(2021, 8, 27, 5, 22, 31, 455, DateTimeKind.Utc).AddTicks(9986), new Guid("570a38d6-c777-495a-9d1f-21174d038a16"), new DateTime(2021, 8, 27, 5, 22, 31, 455, DateTimeKind.Utc).AddTicks(9999) });

            migrationBuilder.UpdateData(
                table: "ShipViewModels",
                keyColumn: "Id",
                keyValue: new Guid("b308da0e-c000-4a35-8244-793f5699d7e7"),
                columns: new[] { "CreatedBy", "CreatedDate", "LastUpdatedBy", "LastUpdatedDate" },
                values: new object[] { new Guid("c53a5a8f-8720-4091-83b0-22d65855c274"), new DateTime(2021, 8, 27, 5, 22, 31, 457, DateTimeKind.Utc).AddTicks(4353), new Guid("24245a26-262d-4158-9255-f449438124b8"), new DateTime(2021, 8, 27, 5, 22, 31, 457, DateTimeKind.Utc).AddTicks(4360) });

            migrationBuilder.AddForeignKey(
                name: "FK_DimensionViewModels_ShipViewModels_ShipViewModelId",
                table: "DimensionViewModels",
                column: "ShipViewModelId",
                principalTable: "ShipViewModels",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
