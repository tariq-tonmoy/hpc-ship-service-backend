using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ShipService.External.NotificationHost.Migrations
{
    public partial class Updateconstructor : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "NotificationClients",
                keyColumn: "Id",
                keyValue: new Guid("07226db8-e7c3-423d-980b-63c7795f89f5"));

            migrationBuilder.InsertData(
                table: "NotificationClients",
                columns: new[] { "Id", "ClientId", "CorrelationId", "CreatedBy", "CreatedDate", "IsMarkedToDelete", "LastUpdatedBy", "LastUpdatedDate", "RolesAllowedToRead", "Version" },
                values: new object[] { new Guid("43d1f414-64bf-4418-a8f0-da2731df799b"), "abcd", new Guid("82bd1940-564d-4cbf-9335-d61ae6280505"), new Guid("001b42f5-18a7-480c-b41c-5c21082b20ec"), new DateTime(2021, 8, 27, 10, 12, 35, 265, DateTimeKind.Utc).AddTicks(2893), false, new Guid("adc344cf-e155-471d-beb2-f49412ee52ab"), new DateTime(2021, 8, 27, 10, 12, 35, 265, DateTimeKind.Utc).AddTicks(2909), "", 1 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "NotificationClients",
                keyColumn: "Id",
                keyValue: new Guid("43d1f414-64bf-4418-a8f0-da2731df799b"));

            migrationBuilder.InsertData(
                table: "NotificationClients",
                columns: new[] { "Id", "ClientId", "CorrelationId", "CreatedBy", "CreatedDate", "IsMarkedToDelete", "LastUpdatedBy", "LastUpdatedDate", "RolesAllowedToRead", "Version" },
                values: new object[] { new Guid("07226db8-e7c3-423d-980b-63c7795f89f5"), "abcd", new Guid("87238a3f-4a0b-4d39-9f78-40bb34e345d1"), new Guid("b2b8527c-d62d-4e03-bb23-21bb20d43a36"), new DateTime(2021, 8, 27, 9, 10, 40, 872, DateTimeKind.Utc).AddTicks(5449), false, new Guid("ae567feb-f008-4055-bf46-4767090ef661"), new DateTime(2021, 8, 27, 9, 10, 40, 872, DateTimeKind.Utc).AddTicks(5463), "", 1 });
        }
    }
}
