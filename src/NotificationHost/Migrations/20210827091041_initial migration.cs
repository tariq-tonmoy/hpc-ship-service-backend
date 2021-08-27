using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ShipService.External.NotificationHost.Migrations
{
    public partial class initialmigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "NotificationClients",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    CorrelationId = table.Column<Guid>(type: "TEXT", nullable: false),
                    ClientId = table.Column<string>(type: "TEXT", nullable: false),
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
                    table.PrimaryKey("PK_NotificationClients", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "NotificationClients",
                columns: new[] { "Id", "ClientId", "CorrelationId", "CreatedBy", "CreatedDate", "IsMarkedToDelete", "LastUpdatedBy", "LastUpdatedDate", "RolesAllowedToRead", "Version" },
                values: new object[] { new Guid("07226db8-e7c3-423d-980b-63c7795f89f5"), "abcd", new Guid("87238a3f-4a0b-4d39-9f78-40bb34e345d1"), new Guid("b2b8527c-d62d-4e03-bb23-21bb20d43a36"), new DateTime(2021, 8, 27, 9, 10, 40, 872, DateTimeKind.Utc).AddTicks(5449), false, new Guid("ae567feb-f008-4055-bf46-4767090ef661"), new DateTime(2021, 8, 27, 9, 10, 40, 872, DateTimeKind.Utc).AddTicks(5463), "", 1 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "NotificationClients");
        }
    }
}
