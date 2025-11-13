using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AgentHierarchyApi.Migrations
{
    public partial class AddLeaderCodeToAgent : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "LeaderCode",
                table: "agents",
                type: "character varying(20)",
                maxLength: 20,
                nullable: true);

            migrationBuilder.UpdateData(
                table: "agents",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2025, 11, 13, 9, 10, 37, 45, DateTimeKind.Utc).AddTicks(7176), new DateTime(2025, 11, 13, 9, 10, 37, 45, DateTimeKind.Utc).AddTicks(7176) });

            migrationBuilder.UpdateData(
                table: "agents",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2025, 11, 13, 9, 10, 37, 45, DateTimeKind.Utc).AddTicks(7176), new DateTime(2025, 11, 13, 9, 10, 37, 45, DateTimeKind.Utc).AddTicks(7176) });

            migrationBuilder.UpdateData(
                table: "agents",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2025, 11, 13, 9, 10, 37, 45, DateTimeKind.Utc).AddTicks(7176), new DateTime(2025, 11, 13, 9, 10, 37, 45, DateTimeKind.Utc).AddTicks(7176) });

            migrationBuilder.UpdateData(
                table: "agents",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2025, 11, 13, 9, 10, 37, 45, DateTimeKind.Utc).AddTicks(7176), new DateTime(2025, 11, 13, 9, 10, 37, 45, DateTimeKind.Utc).AddTicks(7176) });

            migrationBuilder.UpdateData(
                table: "agents",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2025, 11, 13, 9, 10, 37, 45, DateTimeKind.Utc).AddTicks(7176), new DateTime(2025, 11, 13, 9, 10, 37, 45, DateTimeKind.Utc).AddTicks(7176) });

            migrationBuilder.UpdateData(
                table: "agents",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2025, 11, 13, 9, 10, 37, 45, DateTimeKind.Utc).AddTicks(7176), new DateTime(2025, 11, 13, 9, 10, 37, 45, DateTimeKind.Utc).AddTicks(7176) });

            migrationBuilder.UpdateData(
                table: "agents",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2025, 11, 13, 9, 10, 37, 45, DateTimeKind.Utc).AddTicks(7176), new DateTime(2025, 11, 13, 9, 10, 37, 45, DateTimeKind.Utc).AddTicks(7176) });

            migrationBuilder.UpdateData(
                table: "agents",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2025, 11, 13, 9, 10, 37, 45, DateTimeKind.Utc).AddTicks(7176), new DateTime(2025, 11, 13, 9, 10, 37, 45, DateTimeKind.Utc).AddTicks(7176) });

            migrationBuilder.UpdateData(
                table: "t_client",
                keyColumn: "ID",
                keyValue: 1,
                columns: new[] { "CREATED_DATE", "UPDATED_DATE", "UUID" },
                values: new object[] { new DateTime(2025, 11, 13, 9, 10, 37, 45, DateTimeKind.Utc).AddTicks(7176), new DateTime(2025, 11, 13, 9, 10, 37, 45, DateTimeKind.Utc).AddTicks(7176), new Guid("1f8d0f1a-548d-442b-9bd9-e1232073f137") });

            migrationBuilder.UpdateData(
                table: "t_client",
                keyColumn: "ID",
                keyValue: 2,
                columns: new[] { "CREATED_DATE", "UPDATED_DATE", "UUID" },
                values: new object[] { new DateTime(2025, 11, 13, 9, 10, 37, 45, DateTimeKind.Utc).AddTicks(7176), new DateTime(2025, 11, 13, 9, 10, 37, 45, DateTimeKind.Utc).AddTicks(7176), new Guid("150d0663-1f23-45d3-99ac-5971a9cefcb3") });

            migrationBuilder.UpdateData(
                table: "t_client",
                keyColumn: "ID",
                keyValue: 3,
                columns: new[] { "CREATED_DATE", "UPDATED_DATE", "UUID" },
                values: new object[] { new DateTime(2025, 11, 13, 9, 10, 37, 45, DateTimeKind.Utc).AddTicks(7176), new DateTime(2025, 11, 13, 9, 10, 37, 45, DateTimeKind.Utc).AddTicks(7176), new Guid("bd080399-3157-4c3f-9dc5-069e2ea237bb") });

            migrationBuilder.UpdateData(
                table: "t_client",
                keyColumn: "ID",
                keyValue: 4,
                columns: new[] { "CREATED_DATE", "UPDATED_DATE", "UUID" },
                values: new object[] { new DateTime(2025, 11, 13, 9, 10, 37, 45, DateTimeKind.Utc).AddTicks(7176), new DateTime(2025, 11, 13, 9, 10, 37, 45, DateTimeKind.Utc).AddTicks(7176), new Guid("5402c760-253a-475f-a537-59d0d67ee232") });

            migrationBuilder.UpdateData(
                table: "t_client_address",
                keyColumn: "ID",
                keyValue: 1,
                columns: new[] { "CREATED_DATE", "UPDATED_DATE", "UUID" },
                values: new object[] { new DateTime(2025, 11, 13, 9, 10, 37, 45, DateTimeKind.Utc).AddTicks(7176), new DateTime(2025, 11, 13, 9, 10, 37, 45, DateTimeKind.Utc).AddTicks(7176), new Guid("1a7fad59-c8c1-4784-8e9e-3b88e9116a4d") });

            migrationBuilder.UpdateData(
                table: "t_client_address",
                keyColumn: "ID",
                keyValue: 2,
                columns: new[] { "CREATED_DATE", "UPDATED_DATE", "UUID" },
                values: new object[] { new DateTime(2025, 11, 13, 9, 10, 37, 45, DateTimeKind.Utc).AddTicks(7176), new DateTime(2025, 11, 13, 9, 10, 37, 45, DateTimeKind.Utc).AddTicks(7176), new Guid("0d10ceed-1904-4f72-8063-b8de35987662") });

            migrationBuilder.UpdateData(
                table: "t_client_address",
                keyColumn: "ID",
                keyValue: 3,
                columns: new[] { "CREATED_DATE", "UPDATED_DATE", "UUID" },
                values: new object[] { new DateTime(2025, 11, 13, 9, 10, 37, 45, DateTimeKind.Utc).AddTicks(7176), new DateTime(2025, 11, 13, 9, 10, 37, 45, DateTimeKind.Utc).AddTicks(7176), new Guid("65b6d912-10cf-4061-989b-539a79be9b02") });

            migrationBuilder.UpdateData(
                table: "t_client_address",
                keyColumn: "ID",
                keyValue: 4,
                columns: new[] { "CREATED_DATE", "UPDATED_DATE", "UUID" },
                values: new object[] { new DateTime(2025, 11, 13, 9, 10, 37, 45, DateTimeKind.Utc).AddTicks(7176), new DateTime(2025, 11, 13, 9, 10, 37, 45, DateTimeKind.Utc).AddTicks(7176), new Guid("979e71b5-e2c5-44d8-bdef-7ddf0f79e1d6") });

            migrationBuilder.UpdateData(
                table: "t_client_contact",
                keyColumn: "ID",
                keyValue: 1,
                columns: new[] { "CREATED_DATE", "UPDATED_DATE", "UUID" },
                values: new object[] { new DateTime(2025, 11, 13, 9, 10, 37, 45, DateTimeKind.Utc).AddTicks(7176), new DateTime(2025, 11, 13, 9, 10, 37, 45, DateTimeKind.Utc).AddTicks(7176), new Guid("6d5909ae-010e-4016-bee9-2ca04907605d") });

            migrationBuilder.UpdateData(
                table: "t_client_contact",
                keyColumn: "ID",
                keyValue: 2,
                columns: new[] { "CREATED_DATE", "UPDATED_DATE", "UUID" },
                values: new object[] { new DateTime(2025, 11, 13, 9, 10, 37, 45, DateTimeKind.Utc).AddTicks(7176), new DateTime(2025, 11, 13, 9, 10, 37, 45, DateTimeKind.Utc).AddTicks(7176), new Guid("e7f9f4bd-b7a6-445b-9146-ce4c62e091a7") });

            migrationBuilder.UpdateData(
                table: "t_client_contact",
                keyColumn: "ID",
                keyValue: 3,
                columns: new[] { "CREATED_DATE", "UPDATED_DATE", "UUID" },
                values: new object[] { new DateTime(2025, 11, 13, 9, 10, 37, 45, DateTimeKind.Utc).AddTicks(7176), new DateTime(2025, 11, 13, 9, 10, 37, 45, DateTimeKind.Utc).AddTicks(7176), new Guid("1820f6e9-c76d-4380-9621-a45fe5ef6dfe") });

            migrationBuilder.UpdateData(
                table: "t_client_contact",
                keyColumn: "ID",
                keyValue: 4,
                columns: new[] { "CREATED_DATE", "UPDATED_DATE", "UUID" },
                values: new object[] { new DateTime(2025, 11, 13, 9, 10, 37, 45, DateTimeKind.Utc).AddTicks(7176), new DateTime(2025, 11, 13, 9, 10, 37, 45, DateTimeKind.Utc).AddTicks(7176), new Guid("4e418ee5-04dd-47fc-8372-fbffb5ae48d4") });

            migrationBuilder.UpdateData(
                table: "t_client_contact",
                keyColumn: "ID",
                keyValue: 5,
                columns: new[] { "CREATED_DATE", "UPDATED_DATE", "UUID" },
                values: new object[] { new DateTime(2025, 11, 13, 9, 10, 37, 45, DateTimeKind.Utc).AddTicks(7176), new DateTime(2025, 11, 13, 9, 10, 37, 45, DateTimeKind.Utc).AddTicks(7176), new Guid("29f9268d-b012-4b39-9473-46b5cea7e0f1") });

            migrationBuilder.UpdateData(
                table: "t_client_contact",
                keyColumn: "ID",
                keyValue: 6,
                columns: new[] { "CREATED_DATE", "UPDATED_DATE", "UUID" },
                values: new object[] { new DateTime(2025, 11, 13, 9, 10, 37, 45, DateTimeKind.Utc).AddTicks(7176), new DateTime(2025, 11, 13, 9, 10, 37, 45, DateTimeKind.Utc).AddTicks(7176), new Guid("45e53000-0efc-44e9-9a26-0233c92d1639") });

            migrationBuilder.UpdateData(
                table: "t_client_contact",
                keyColumn: "ID",
                keyValue: 7,
                columns: new[] { "CREATED_DATE", "UPDATED_DATE", "UUID" },
                values: new object[] { new DateTime(2025, 11, 13, 9, 10, 37, 45, DateTimeKind.Utc).AddTicks(7176), new DateTime(2025, 11, 13, 9, 10, 37, 45, DateTimeKind.Utc).AddTicks(7176), new Guid("f303958f-6ece-4ee2-8897-6fc34cf7edce") });

            migrationBuilder.UpdateData(
                table: "t_client_contact",
                keyColumn: "ID",
                keyValue: 8,
                columns: new[] { "CREATED_DATE", "UPDATED_DATE", "UUID" },
                values: new object[] { new DateTime(2025, 11, 13, 9, 10, 37, 45, DateTimeKind.Utc).AddTicks(7176), new DateTime(2025, 11, 13, 9, 10, 37, 45, DateTimeKind.Utc).AddTicks(7176), new Guid("60db4a13-6513-4b13-b8e0-93fd728bd5bb") });

            migrationBuilder.UpdateData(
                table: "t_client_role",
                keyColumn: "ID",
                keyValue: 1,
                columns: new[] { "CREATED_DATE", "UPDATED_DATE", "UUID" },
                values: new object[] { new DateTime(2025, 11, 13, 9, 10, 37, 45, DateTimeKind.Utc).AddTicks(7176), new DateTime(2025, 11, 13, 9, 10, 37, 45, DateTimeKind.Utc).AddTicks(7176), new Guid("66c11b5f-b802-4afe-a412-d8e33ebeade1") });

            migrationBuilder.UpdateData(
                table: "t_client_role",
                keyColumn: "ID",
                keyValue: 2,
                columns: new[] { "CREATED_DATE", "UPDATED_DATE", "UUID" },
                values: new object[] { new DateTime(2025, 11, 13, 9, 10, 37, 45, DateTimeKind.Utc).AddTicks(7176), new DateTime(2025, 11, 13, 9, 10, 37, 45, DateTimeKind.Utc).AddTicks(7176), new Guid("a3d185b7-4b18-471b-a055-58b6ba0cb497") });

            migrationBuilder.UpdateData(
                table: "t_client_role",
                keyColumn: "ID",
                keyValue: 3,
                columns: new[] { "CREATED_DATE", "UPDATED_DATE", "UUID" },
                values: new object[] { new DateTime(2025, 11, 13, 9, 10, 37, 45, DateTimeKind.Utc).AddTicks(7176), new DateTime(2025, 11, 13, 9, 10, 37, 45, DateTimeKind.Utc).AddTicks(7176), new Guid("5acef5af-a3e2-40b9-9c0b-1b4092df7083") });

            migrationBuilder.UpdateData(
                table: "t_client_role",
                keyColumn: "ID",
                keyValue: 4,
                columns: new[] { "CREATED_DATE", "UPDATED_DATE", "UUID" },
                values: new object[] { new DateTime(2025, 11, 13, 9, 10, 37, 45, DateTimeKind.Utc).AddTicks(7176), new DateTime(2025, 11, 13, 9, 10, 37, 45, DateTimeKind.Utc).AddTicks(7176), new Guid("5698af4b-a98b-4e79-93e5-dcac5c607457") });

            migrationBuilder.UpdateData(
                table: "t_client_role",
                keyColumn: "ID",
                keyValue: 5,
                columns: new[] { "CREATED_DATE", "UPDATED_DATE", "UUID" },
                values: new object[] { new DateTime(2025, 11, 13, 9, 10, 37, 45, DateTimeKind.Utc).AddTicks(7176), new DateTime(2025, 11, 13, 9, 10, 37, 45, DateTimeKind.Utc).AddTicks(7176), new Guid("2a75e855-f8d0-4bb6-9098-1160b1677bab") });

            migrationBuilder.UpdateData(
                table: "t_image",
                keyColumn: "ID",
                keyValue: 1,
                columns: new[] { "CREATED_DATE", "UPDATED_DATE" },
                values: new object[] { new DateTime(2025, 11, 13, 9, 10, 37, 45, DateTimeKind.Utc).AddTicks(7176), new DateTime(2025, 11, 13, 9, 10, 37, 45, DateTimeKind.Utc).AddTicks(7176) });

            migrationBuilder.UpdateData(
                table: "t_image",
                keyColumn: "ID",
                keyValue: 2,
                columns: new[] { "CREATED_DATE", "UPDATED_DATE" },
                values: new object[] { new DateTime(2025, 11, 13, 9, 10, 37, 45, DateTimeKind.Utc).AddTicks(7176), new DateTime(2025, 11, 13, 9, 10, 37, 45, DateTimeKind.Utc).AddTicks(7176) });

            migrationBuilder.UpdateData(
                table: "t_image",
                keyColumn: "ID",
                keyValue: 3,
                columns: new[] { "CREATED_DATE", "UPDATED_DATE" },
                values: new object[] { new DateTime(2025, 11, 13, 9, 10, 37, 45, DateTimeKind.Utc).AddTicks(7176), new DateTime(2025, 11, 13, 9, 10, 37, 45, DateTimeKind.Utc).AddTicks(7176) });

            migrationBuilder.UpdateData(
                table: "t_image",
                keyColumn: "ID",
                keyValue: 4,
                columns: new[] { "CREATED_DATE", "UPDATED_DATE" },
                values: new object[] { new DateTime(2025, 11, 13, 9, 10, 37, 45, DateTimeKind.Utc).AddTicks(7176), new DateTime(2025, 11, 13, 9, 10, 37, 45, DateTimeKind.Utc).AddTicks(7176) });

            migrationBuilder.UpdateData(
                table: "t_image",
                keyColumn: "ID",
                keyValue: 5,
                columns: new[] { "CREATED_DATE", "UPDATED_DATE" },
                values: new object[] { new DateTime(2025, 11, 13, 9, 10, 37, 45, DateTimeKind.Utc).AddTicks(7176), new DateTime(2025, 11, 13, 9, 10, 37, 45, DateTimeKind.Utc).AddTicks(7176) });

            migrationBuilder.UpdateData(
                table: "t_image",
                keyColumn: "ID",
                keyValue: 6,
                columns: new[] { "CREATED_DATE", "UPDATED_DATE" },
                values: new object[] { new DateTime(2025, 11, 13, 9, 10, 37, 45, DateTimeKind.Utc).AddTicks(7176), new DateTime(2025, 11, 13, 9, 10, 37, 45, DateTimeKind.Utc).AddTicks(7176) });

            migrationBuilder.UpdateData(
                table: "t_image",
                keyColumn: "ID",
                keyValue: 7,
                columns: new[] { "CREATED_DATE", "UPDATED_DATE" },
                values: new object[] { new DateTime(2025, 11, 13, 9, 10, 37, 45, DateTimeKind.Utc).AddTicks(7176), new DateTime(2025, 11, 13, 9, 10, 37, 45, DateTimeKind.Utc).AddTicks(7176) });

            migrationBuilder.CreateIndex(
                name: "IX_agents_LeaderCode",
                table: "agents",
                column: "LeaderCode");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_agents_LeaderCode",
                table: "agents");

            migrationBuilder.DropColumn(
                name: "LeaderCode",
                table: "agents");

            migrationBuilder.UpdateData(
                table: "agents",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2025, 11, 13, 7, 33, 52, 758, DateTimeKind.Utc).AddTicks(6572), new DateTime(2025, 11, 13, 7, 33, 52, 758, DateTimeKind.Utc).AddTicks(6572) });

            migrationBuilder.UpdateData(
                table: "agents",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2025, 11, 13, 7, 33, 52, 758, DateTimeKind.Utc).AddTicks(6572), new DateTime(2025, 11, 13, 7, 33, 52, 758, DateTimeKind.Utc).AddTicks(6572) });

            migrationBuilder.UpdateData(
                table: "agents",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2025, 11, 13, 7, 33, 52, 758, DateTimeKind.Utc).AddTicks(6572), new DateTime(2025, 11, 13, 7, 33, 52, 758, DateTimeKind.Utc).AddTicks(6572) });

            migrationBuilder.UpdateData(
                table: "agents",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2025, 11, 13, 7, 33, 52, 758, DateTimeKind.Utc).AddTicks(6572), new DateTime(2025, 11, 13, 7, 33, 52, 758, DateTimeKind.Utc).AddTicks(6572) });

            migrationBuilder.UpdateData(
                table: "agents",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2025, 11, 13, 7, 33, 52, 758, DateTimeKind.Utc).AddTicks(6572), new DateTime(2025, 11, 13, 7, 33, 52, 758, DateTimeKind.Utc).AddTicks(6572) });

            migrationBuilder.UpdateData(
                table: "agents",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2025, 11, 13, 7, 33, 52, 758, DateTimeKind.Utc).AddTicks(6572), new DateTime(2025, 11, 13, 7, 33, 52, 758, DateTimeKind.Utc).AddTicks(6572) });

            migrationBuilder.UpdateData(
                table: "agents",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2025, 11, 13, 7, 33, 52, 758, DateTimeKind.Utc).AddTicks(6572), new DateTime(2025, 11, 13, 7, 33, 52, 758, DateTimeKind.Utc).AddTicks(6572) });

            migrationBuilder.UpdateData(
                table: "agents",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2025, 11, 13, 7, 33, 52, 758, DateTimeKind.Utc).AddTicks(6572), new DateTime(2025, 11, 13, 7, 33, 52, 758, DateTimeKind.Utc).AddTicks(6572) });

            migrationBuilder.UpdateData(
                table: "t_client",
                keyColumn: "ID",
                keyValue: 1,
                columns: new[] { "CREATED_DATE", "UPDATED_DATE", "UUID" },
                values: new object[] { new DateTime(2025, 11, 13, 7, 33, 52, 758, DateTimeKind.Utc).AddTicks(6572), new DateTime(2025, 11, 13, 7, 33, 52, 758, DateTimeKind.Utc).AddTicks(6572), new Guid("f1f13a14-fd2b-447b-9d1f-0fee40109708") });

            migrationBuilder.UpdateData(
                table: "t_client",
                keyColumn: "ID",
                keyValue: 2,
                columns: new[] { "CREATED_DATE", "UPDATED_DATE", "UUID" },
                values: new object[] { new DateTime(2025, 11, 13, 7, 33, 52, 758, DateTimeKind.Utc).AddTicks(6572), new DateTime(2025, 11, 13, 7, 33, 52, 758, DateTimeKind.Utc).AddTicks(6572), new Guid("951b5c30-6e4b-46cf-bcd9-3f239d645257") });

            migrationBuilder.UpdateData(
                table: "t_client",
                keyColumn: "ID",
                keyValue: 3,
                columns: new[] { "CREATED_DATE", "UPDATED_DATE", "UUID" },
                values: new object[] { new DateTime(2025, 11, 13, 7, 33, 52, 758, DateTimeKind.Utc).AddTicks(6572), new DateTime(2025, 11, 13, 7, 33, 52, 758, DateTimeKind.Utc).AddTicks(6572), new Guid("d479251e-5c10-4799-8b17-2ee8b0693384") });

            migrationBuilder.UpdateData(
                table: "t_client",
                keyColumn: "ID",
                keyValue: 4,
                columns: new[] { "CREATED_DATE", "UPDATED_DATE", "UUID" },
                values: new object[] { new DateTime(2025, 11, 13, 7, 33, 52, 758, DateTimeKind.Utc).AddTicks(6572), new DateTime(2025, 11, 13, 7, 33, 52, 758, DateTimeKind.Utc).AddTicks(6572), new Guid("f5580962-f2a6-4543-94ea-82f5504f5300") });

            migrationBuilder.UpdateData(
                table: "t_client_address",
                keyColumn: "ID",
                keyValue: 1,
                columns: new[] { "CREATED_DATE", "UPDATED_DATE", "UUID" },
                values: new object[] { new DateTime(2025, 11, 13, 7, 33, 52, 758, DateTimeKind.Utc).AddTicks(6572), new DateTime(2025, 11, 13, 7, 33, 52, 758, DateTimeKind.Utc).AddTicks(6572), new Guid("74a56c8c-fedb-43aa-b812-e8a0a2c437bb") });

            migrationBuilder.UpdateData(
                table: "t_client_address",
                keyColumn: "ID",
                keyValue: 2,
                columns: new[] { "CREATED_DATE", "UPDATED_DATE", "UUID" },
                values: new object[] { new DateTime(2025, 11, 13, 7, 33, 52, 758, DateTimeKind.Utc).AddTicks(6572), new DateTime(2025, 11, 13, 7, 33, 52, 758, DateTimeKind.Utc).AddTicks(6572), new Guid("5c4f5e0a-1fef-4187-bddf-d48592c5acd7") });

            migrationBuilder.UpdateData(
                table: "t_client_address",
                keyColumn: "ID",
                keyValue: 3,
                columns: new[] { "CREATED_DATE", "UPDATED_DATE", "UUID" },
                values: new object[] { new DateTime(2025, 11, 13, 7, 33, 52, 758, DateTimeKind.Utc).AddTicks(6572), new DateTime(2025, 11, 13, 7, 33, 52, 758, DateTimeKind.Utc).AddTicks(6572), new Guid("d0827811-b210-4213-85c0-04727c93d610") });

            migrationBuilder.UpdateData(
                table: "t_client_address",
                keyColumn: "ID",
                keyValue: 4,
                columns: new[] { "CREATED_DATE", "UPDATED_DATE", "UUID" },
                values: new object[] { new DateTime(2025, 11, 13, 7, 33, 52, 758, DateTimeKind.Utc).AddTicks(6572), new DateTime(2025, 11, 13, 7, 33, 52, 758, DateTimeKind.Utc).AddTicks(6572), new Guid("f396c579-5a74-4ffd-8fdc-c3216038c664") });

            migrationBuilder.UpdateData(
                table: "t_client_contact",
                keyColumn: "ID",
                keyValue: 1,
                columns: new[] { "CREATED_DATE", "UPDATED_DATE", "UUID" },
                values: new object[] { new DateTime(2025, 11, 13, 7, 33, 52, 758, DateTimeKind.Utc).AddTicks(6572), new DateTime(2025, 11, 13, 7, 33, 52, 758, DateTimeKind.Utc).AddTicks(6572), new Guid("6920f8c9-83a2-4959-8963-7dcd036f5bd8") });

            migrationBuilder.UpdateData(
                table: "t_client_contact",
                keyColumn: "ID",
                keyValue: 2,
                columns: new[] { "CREATED_DATE", "UPDATED_DATE", "UUID" },
                values: new object[] { new DateTime(2025, 11, 13, 7, 33, 52, 758, DateTimeKind.Utc).AddTicks(6572), new DateTime(2025, 11, 13, 7, 33, 52, 758, DateTimeKind.Utc).AddTicks(6572), new Guid("909f9788-a942-4fb3-9680-07d2173bb689") });

            migrationBuilder.UpdateData(
                table: "t_client_contact",
                keyColumn: "ID",
                keyValue: 3,
                columns: new[] { "CREATED_DATE", "UPDATED_DATE", "UUID" },
                values: new object[] { new DateTime(2025, 11, 13, 7, 33, 52, 758, DateTimeKind.Utc).AddTicks(6572), new DateTime(2025, 11, 13, 7, 33, 52, 758, DateTimeKind.Utc).AddTicks(6572), new Guid("83d8d0ed-9fe3-4fbc-b4bc-c186974d9623") });

            migrationBuilder.UpdateData(
                table: "t_client_contact",
                keyColumn: "ID",
                keyValue: 4,
                columns: new[] { "CREATED_DATE", "UPDATED_DATE", "UUID" },
                values: new object[] { new DateTime(2025, 11, 13, 7, 33, 52, 758, DateTimeKind.Utc).AddTicks(6572), new DateTime(2025, 11, 13, 7, 33, 52, 758, DateTimeKind.Utc).AddTicks(6572), new Guid("d81eabd6-cca6-44cd-801a-ca1ce0bfb0d7") });

            migrationBuilder.UpdateData(
                table: "t_client_contact",
                keyColumn: "ID",
                keyValue: 5,
                columns: new[] { "CREATED_DATE", "UPDATED_DATE", "UUID" },
                values: new object[] { new DateTime(2025, 11, 13, 7, 33, 52, 758, DateTimeKind.Utc).AddTicks(6572), new DateTime(2025, 11, 13, 7, 33, 52, 758, DateTimeKind.Utc).AddTicks(6572), new Guid("8787ce73-3a22-4899-bcea-9d94d98d8a15") });

            migrationBuilder.UpdateData(
                table: "t_client_contact",
                keyColumn: "ID",
                keyValue: 6,
                columns: new[] { "CREATED_DATE", "UPDATED_DATE", "UUID" },
                values: new object[] { new DateTime(2025, 11, 13, 7, 33, 52, 758, DateTimeKind.Utc).AddTicks(6572), new DateTime(2025, 11, 13, 7, 33, 52, 758, DateTimeKind.Utc).AddTicks(6572), new Guid("64e32a99-e720-4fd1-8226-efa830a2c159") });

            migrationBuilder.UpdateData(
                table: "t_client_contact",
                keyColumn: "ID",
                keyValue: 7,
                columns: new[] { "CREATED_DATE", "UPDATED_DATE", "UUID" },
                values: new object[] { new DateTime(2025, 11, 13, 7, 33, 52, 758, DateTimeKind.Utc).AddTicks(6572), new DateTime(2025, 11, 13, 7, 33, 52, 758, DateTimeKind.Utc).AddTicks(6572), new Guid("f161e6de-680f-49b9-8461-62cc2b98ee34") });

            migrationBuilder.UpdateData(
                table: "t_client_contact",
                keyColumn: "ID",
                keyValue: 8,
                columns: new[] { "CREATED_DATE", "UPDATED_DATE", "UUID" },
                values: new object[] { new DateTime(2025, 11, 13, 7, 33, 52, 758, DateTimeKind.Utc).AddTicks(6572), new DateTime(2025, 11, 13, 7, 33, 52, 758, DateTimeKind.Utc).AddTicks(6572), new Guid("a2d37620-8a91-4092-8629-5a486a745177") });

            migrationBuilder.UpdateData(
                table: "t_client_role",
                keyColumn: "ID",
                keyValue: 1,
                columns: new[] { "CREATED_DATE", "UPDATED_DATE", "UUID" },
                values: new object[] { new DateTime(2025, 11, 13, 7, 33, 52, 758, DateTimeKind.Utc).AddTicks(6572), new DateTime(2025, 11, 13, 7, 33, 52, 758, DateTimeKind.Utc).AddTicks(6572), new Guid("8253eeea-27d2-4475-a054-fb57ef32a2bd") });

            migrationBuilder.UpdateData(
                table: "t_client_role",
                keyColumn: "ID",
                keyValue: 2,
                columns: new[] { "CREATED_DATE", "UPDATED_DATE", "UUID" },
                values: new object[] { new DateTime(2025, 11, 13, 7, 33, 52, 758, DateTimeKind.Utc).AddTicks(6572), new DateTime(2025, 11, 13, 7, 33, 52, 758, DateTimeKind.Utc).AddTicks(6572), new Guid("16679ad2-043e-4488-9469-4ac355234d75") });

            migrationBuilder.UpdateData(
                table: "t_client_role",
                keyColumn: "ID",
                keyValue: 3,
                columns: new[] { "CREATED_DATE", "UPDATED_DATE", "UUID" },
                values: new object[] { new DateTime(2025, 11, 13, 7, 33, 52, 758, DateTimeKind.Utc).AddTicks(6572), new DateTime(2025, 11, 13, 7, 33, 52, 758, DateTimeKind.Utc).AddTicks(6572), new Guid("630a012a-ae3e-4730-878e-e45ba4067ac2") });

            migrationBuilder.UpdateData(
                table: "t_client_role",
                keyColumn: "ID",
                keyValue: 4,
                columns: new[] { "CREATED_DATE", "UPDATED_DATE", "UUID" },
                values: new object[] { new DateTime(2025, 11, 13, 7, 33, 52, 758, DateTimeKind.Utc).AddTicks(6572), new DateTime(2025, 11, 13, 7, 33, 52, 758, DateTimeKind.Utc).AddTicks(6572), new Guid("21cd99ee-9a23-496e-9db8-7d92558df176") });

            migrationBuilder.UpdateData(
                table: "t_client_role",
                keyColumn: "ID",
                keyValue: 5,
                columns: new[] { "CREATED_DATE", "UPDATED_DATE", "UUID" },
                values: new object[] { new DateTime(2025, 11, 13, 7, 33, 52, 758, DateTimeKind.Utc).AddTicks(6572), new DateTime(2025, 11, 13, 7, 33, 52, 758, DateTimeKind.Utc).AddTicks(6572), new Guid("617e8b42-aea7-4db5-8426-6343e6da7db9") });

            migrationBuilder.UpdateData(
                table: "t_image",
                keyColumn: "ID",
                keyValue: 1,
                columns: new[] { "CREATED_DATE", "UPDATED_DATE" },
                values: new object[] { new DateTime(2025, 11, 13, 7, 33, 52, 758, DateTimeKind.Utc).AddTicks(6572), new DateTime(2025, 11, 13, 7, 33, 52, 758, DateTimeKind.Utc).AddTicks(6572) });

            migrationBuilder.UpdateData(
                table: "t_image",
                keyColumn: "ID",
                keyValue: 2,
                columns: new[] { "CREATED_DATE", "UPDATED_DATE" },
                values: new object[] { new DateTime(2025, 11, 13, 7, 33, 52, 758, DateTimeKind.Utc).AddTicks(6572), new DateTime(2025, 11, 13, 7, 33, 52, 758, DateTimeKind.Utc).AddTicks(6572) });

            migrationBuilder.UpdateData(
                table: "t_image",
                keyColumn: "ID",
                keyValue: 3,
                columns: new[] { "CREATED_DATE", "UPDATED_DATE" },
                values: new object[] { new DateTime(2025, 11, 13, 7, 33, 52, 758, DateTimeKind.Utc).AddTicks(6572), new DateTime(2025, 11, 13, 7, 33, 52, 758, DateTimeKind.Utc).AddTicks(6572) });

            migrationBuilder.UpdateData(
                table: "t_image",
                keyColumn: "ID",
                keyValue: 4,
                columns: new[] { "CREATED_DATE", "UPDATED_DATE" },
                values: new object[] { new DateTime(2025, 11, 13, 7, 33, 52, 758, DateTimeKind.Utc).AddTicks(6572), new DateTime(2025, 11, 13, 7, 33, 52, 758, DateTimeKind.Utc).AddTicks(6572) });

            migrationBuilder.UpdateData(
                table: "t_image",
                keyColumn: "ID",
                keyValue: 5,
                columns: new[] { "CREATED_DATE", "UPDATED_DATE" },
                values: new object[] { new DateTime(2025, 11, 13, 7, 33, 52, 758, DateTimeKind.Utc).AddTicks(6572), new DateTime(2025, 11, 13, 7, 33, 52, 758, DateTimeKind.Utc).AddTicks(6572) });

            migrationBuilder.UpdateData(
                table: "t_image",
                keyColumn: "ID",
                keyValue: 6,
                columns: new[] { "CREATED_DATE", "UPDATED_DATE" },
                values: new object[] { new DateTime(2025, 11, 13, 7, 33, 52, 758, DateTimeKind.Utc).AddTicks(6572), new DateTime(2025, 11, 13, 7, 33, 52, 758, DateTimeKind.Utc).AddTicks(6572) });

            migrationBuilder.UpdateData(
                table: "t_image",
                keyColumn: "ID",
                keyValue: 7,
                columns: new[] { "CREATED_DATE", "UPDATED_DATE" },
                values: new object[] { new DateTime(2025, 11, 13, 7, 33, 52, 758, DateTimeKind.Utc).AddTicks(6572), new DateTime(2025, 11, 13, 7, 33, 52, 758, DateTimeKind.Utc).AddTicks(6572) });
        }
    }
}
