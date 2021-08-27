using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ShipService.External.Infrastructure.Authentication.Cqrs.Repository.Sqlite.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AuthenticationViewModels",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Username = table.Column<string>(type: "TEXT", nullable: false),
                    Password = table.Column<string>(type: "TEXT", nullable: false),
                    Role = table.Column<string>(type: "TEXT", nullable: false),
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
                    table.PrimaryKey("PK_AuthenticationViewModels", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "AuthenticationViewModels",
                columns: new[] { "Id", "CreatedBy", "CreatedDate", "IsMarkedToDelete", "LastUpdatedBy", "LastUpdatedDate", "Password", "Role", "RolesAllowedToRead", "Username", "Version" },
                values: new object[] { new Guid("b03bfb27-3bfb-4457-b0d8-f1c4675a4862"), new Guid("c780c7bc-c02f-4386-85fb-d954f56ef048"), new DateTime(2021, 8, 25, 19, 35, 6, 538, DateTimeKind.Utc).AddTicks(9639), false, new Guid("dc934453-c9d4-4880-8af3-8f8951cbc75b"), new DateTime(2021, 8, 25, 19, 35, 6, 538, DateTimeKind.Utc).AddTicks(9652), "Abc123", "Admin", "", "test_admin1@yopmail.com", 1 });

            migrationBuilder.InsertData(
                table: "AuthenticationViewModels",
                columns: new[] { "Id", "CreatedBy", "CreatedDate", "IsMarkedToDelete", "LastUpdatedBy", "LastUpdatedDate", "Password", "Role", "RolesAllowedToRead", "Username", "Version" },
                values: new object[] { new Guid("0799cc7f-4df9-48a8-910d-097750ae51ac"), new Guid("a9778730-5e11-4697-a8b6-a7fb8f61f243"), new DateTime(2021, 8, 25, 19, 35, 6, 540, DateTimeKind.Utc).AddTicks(6724), false, new Guid("f3ac08ae-86e3-40b8-b884-b2373072f30b"), new DateTime(2021, 8, 25, 19, 35, 6, 540, DateTimeKind.Utc).AddTicks(6730), "Abc123", "Admin", "", "test_admin2@yopmail.com", 1 });

            migrationBuilder.InsertData(
                table: "AuthenticationViewModels",
                columns: new[] { "Id", "CreatedBy", "CreatedDate", "IsMarkedToDelete", "LastUpdatedBy", "LastUpdatedDate", "Password", "Role", "RolesAllowedToRead", "Username", "Version" },
                values: new object[] { new Guid("ef15d4ba-5672-490f-8159-5917bebac241"), new Guid("1104fc0a-ded8-482e-b68e-155558dd3174"), new DateTime(2021, 8, 25, 19, 35, 6, 540, DateTimeKind.Utc).AddTicks(6875), false, new Guid("af4f0f74-d5e6-4c74-87f9-9bff8bb2167b"), new DateTime(2021, 8, 25, 19, 35, 6, 540, DateTimeKind.Utc).AddTicks(6878), "Abc123", "User", "", "test_user1@yopmail.com", 1 });

            migrationBuilder.InsertData(
                table: "AuthenticationViewModels",
                columns: new[] { "Id", "CreatedBy", "CreatedDate", "IsMarkedToDelete", "LastUpdatedBy", "LastUpdatedDate", "Password", "Role", "RolesAllowedToRead", "Username", "Version" },
                values: new object[] { new Guid("ae014d45-f533-4618-b092-32fec0a3d5eb"), new Guid("e027ae6e-55eb-435c-831d-d0e42ee599bc"), new DateTime(2021, 8, 25, 19, 35, 6, 540, DateTimeKind.Utc).AddTicks(6902), false, new Guid("e132c05b-a1e7-422a-8bb1-f7bf811c66f0"), new DateTime(2021, 8, 25, 19, 35, 6, 540, DateTimeKind.Utc).AddTicks(6904), "Abc123", "User", "", "test_user2@yopmail.com", 1 });

            migrationBuilder.InsertData(
                table: "AuthenticationViewModels",
                columns: new[] { "Id", "CreatedBy", "CreatedDate", "IsMarkedToDelete", "LastUpdatedBy", "LastUpdatedDate", "Password", "Role", "RolesAllowedToRead", "Username", "Version" },
                values: new object[] { new Guid("7b2cfc7a-a17d-48f5-92f9-16b4b26ae10f"), new Guid("67a8c346-df6f-41f3-aaad-70c86916812a"), new DateTime(2021, 8, 25, 19, 35, 6, 540, DateTimeKind.Utc).AddTicks(6923), false, new Guid("bf255083-5dc5-4ad3-af16-3119b715e502"), new DateTime(2021, 8, 25, 19, 35, 6, 540, DateTimeKind.Utc).AddTicks(6930), "Abc123", "Anonymous", "", "test_anon1@yopmail.com", 1 });

            migrationBuilder.InsertData(
                table: "AuthenticationViewModels",
                columns: new[] { "Id", "CreatedBy", "CreatedDate", "IsMarkedToDelete", "LastUpdatedBy", "LastUpdatedDate", "Password", "Role", "RolesAllowedToRead", "Username", "Version" },
                values: new object[] { new Guid("a610c2c1-400d-4742-b1d8-58122f66c044"), new Guid("06dd95c3-b348-4e34-970f-0cc26d412eaa"), new DateTime(2021, 8, 25, 19, 35, 6, 540, DateTimeKind.Utc).AddTicks(6959), false, new Guid("87cfd8a5-b96b-4799-80c7-236b2f9268fa"), new DateTime(2021, 8, 25, 19, 35, 6, 540, DateTimeKind.Utc).AddTicks(6961), "Abc123", "Anonymous", "", "test_anon2@yopmail.com", 1 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AuthenticationViewModels");
        }
    }
}
