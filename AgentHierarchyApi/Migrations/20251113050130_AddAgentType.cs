using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AgentHierarchyApi.Migrations
{
    public partial class AddAgentType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "AgentType",
                table: "Agents",
                type: "character varying(20)",
                maxLength: 20,
                nullable: false,
                defaultValue: "Agent");

            migrationBuilder.UpdateData(
                table: "Agents",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "AgentType", "CreatedDate", "UpdatedDate" },
                values: new object[] { "Agent", new DateTime(2025, 11, 13, 5, 1, 29, 168, DateTimeKind.Utc).AddTicks(8314), new DateTime(2025, 11, 13, 5, 1, 29, 168, DateTimeKind.Utc).AddTicks(8314) });

            migrationBuilder.UpdateData(
                table: "Agents",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "AgentType", "CreatedDate", "UpdatedDate" },
                values: new object[] { "Agent", new DateTime(2025, 11, 13, 5, 1, 29, 168, DateTimeKind.Utc).AddTicks(8314), new DateTime(2025, 11, 13, 5, 1, 29, 168, DateTimeKind.Utc).AddTicks(8314) });

            migrationBuilder.UpdateData(
                table: "Agents",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "AgentType", "CreatedDate", "UpdatedDate" },
                values: new object[] { "Agent", new DateTime(2025, 11, 13, 5, 1, 29, 168, DateTimeKind.Utc).AddTicks(8314), new DateTime(2025, 11, 13, 5, 1, 29, 168, DateTimeKind.Utc).AddTicks(8314) });

            migrationBuilder.UpdateData(
                table: "Agents",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "AgentType", "CreatedDate", "UpdatedDate" },
                values: new object[] { "Agent", new DateTime(2025, 11, 13, 5, 1, 29, 168, DateTimeKind.Utc).AddTicks(8314), new DateTime(2025, 11, 13, 5, 1, 29, 168, DateTimeKind.Utc).AddTicks(8314) });

            migrationBuilder.UpdateData(
                table: "Agents",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "AgentType", "CreatedDate", "UpdatedDate" },
                values: new object[] { "Agent", new DateTime(2025, 11, 13, 5, 1, 29, 168, DateTimeKind.Utc).AddTicks(8314), new DateTime(2025, 11, 13, 5, 1, 29, 168, DateTimeKind.Utc).AddTicks(8314) });

            migrationBuilder.UpdateData(
                table: "Agents",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "AgentType", "CreatedDate", "UpdatedDate" },
                values: new object[] { "Agent", new DateTime(2025, 11, 13, 5, 1, 29, 168, DateTimeKind.Utc).AddTicks(8314), new DateTime(2025, 11, 13, 5, 1, 29, 168, DateTimeKind.Utc).AddTicks(8314) });

            migrationBuilder.UpdateData(
                table: "Agents",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "AgentType", "CreatedDate", "UpdatedDate" },
                values: new object[] { "Agent", new DateTime(2025, 11, 13, 5, 1, 29, 168, DateTimeKind.Utc).AddTicks(8314), new DateTime(2025, 11, 13, 5, 1, 29, 168, DateTimeKind.Utc).AddTicks(8314) });

            migrationBuilder.UpdateData(
                table: "Agents",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "AgentType", "CreatedDate", "UpdatedDate" },
                values: new object[] { "Agent", new DateTime(2025, 11, 13, 5, 1, 29, 168, DateTimeKind.Utc).AddTicks(8314), new DateTime(2025, 11, 13, 5, 1, 29, 168, DateTimeKind.Utc).AddTicks(8314) });

            migrationBuilder.UpdateData(
                table: "T_CLIENT",
                keyColumn: "ID",
                keyValue: 1,
                columns: new[] { "CREATED_DATE", "UPDATED_DATE", "UUID" },
                values: new object[] { new DateTime(2025, 11, 13, 5, 1, 29, 168, DateTimeKind.Utc).AddTicks(8314), new DateTime(2025, 11, 13, 5, 1, 29, 168, DateTimeKind.Utc).AddTicks(8314), new Guid("454be0ec-008b-4b9e-a885-8bcb94b4b67c") });

            migrationBuilder.UpdateData(
                table: "T_CLIENT",
                keyColumn: "ID",
                keyValue: 2,
                columns: new[] { "CREATED_DATE", "UPDATED_DATE", "UUID" },
                values: new object[] { new DateTime(2025, 11, 13, 5, 1, 29, 168, DateTimeKind.Utc).AddTicks(8314), new DateTime(2025, 11, 13, 5, 1, 29, 168, DateTimeKind.Utc).AddTicks(8314), new Guid("bbedbcc0-5218-4733-b1e9-bef80926fb6a") });

            migrationBuilder.UpdateData(
                table: "T_CLIENT",
                keyColumn: "ID",
                keyValue: 3,
                columns: new[] { "CREATED_DATE", "UPDATED_DATE", "UUID" },
                values: new object[] { new DateTime(2025, 11, 13, 5, 1, 29, 168, DateTimeKind.Utc).AddTicks(8314), new DateTime(2025, 11, 13, 5, 1, 29, 168, DateTimeKind.Utc).AddTicks(8314), new Guid("a2f771a4-11fa-4e68-a4f2-ef02023f5606") });

            migrationBuilder.UpdateData(
                table: "T_CLIENT",
                keyColumn: "ID",
                keyValue: 4,
                columns: new[] { "CREATED_DATE", "UPDATED_DATE", "UUID" },
                values: new object[] { new DateTime(2025, 11, 13, 5, 1, 29, 168, DateTimeKind.Utc).AddTicks(8314), new DateTime(2025, 11, 13, 5, 1, 29, 168, DateTimeKind.Utc).AddTicks(8314), new Guid("beaf63d8-7905-4e53-926b-ff5693d59168") });

            migrationBuilder.UpdateData(
                table: "T_CLIENT_ADDRESS",
                keyColumn: "ID",
                keyValue: 1,
                columns: new[] { "CREATED_DATE", "UPDATED_DATE", "UUID" },
                values: new object[] { new DateTime(2025, 11, 13, 5, 1, 29, 168, DateTimeKind.Utc).AddTicks(8314), new DateTime(2025, 11, 13, 5, 1, 29, 168, DateTimeKind.Utc).AddTicks(8314), new Guid("e75085ff-f09b-4bf1-a30d-a5283086471c") });

            migrationBuilder.UpdateData(
                table: "T_CLIENT_ADDRESS",
                keyColumn: "ID",
                keyValue: 2,
                columns: new[] { "CREATED_DATE", "UPDATED_DATE", "UUID" },
                values: new object[] { new DateTime(2025, 11, 13, 5, 1, 29, 168, DateTimeKind.Utc).AddTicks(8314), new DateTime(2025, 11, 13, 5, 1, 29, 168, DateTimeKind.Utc).AddTicks(8314), new Guid("9ee3df49-39ce-4bcb-b077-b12923eedce5") });

            migrationBuilder.UpdateData(
                table: "T_CLIENT_ADDRESS",
                keyColumn: "ID",
                keyValue: 3,
                columns: new[] { "CREATED_DATE", "UPDATED_DATE", "UUID" },
                values: new object[] { new DateTime(2025, 11, 13, 5, 1, 29, 168, DateTimeKind.Utc).AddTicks(8314), new DateTime(2025, 11, 13, 5, 1, 29, 168, DateTimeKind.Utc).AddTicks(8314), new Guid("7961019a-7655-4163-8a87-3991ab3e707a") });

            migrationBuilder.UpdateData(
                table: "T_CLIENT_ADDRESS",
                keyColumn: "ID",
                keyValue: 4,
                columns: new[] { "CREATED_DATE", "UPDATED_DATE", "UUID" },
                values: new object[] { new DateTime(2025, 11, 13, 5, 1, 29, 168, DateTimeKind.Utc).AddTicks(8314), new DateTime(2025, 11, 13, 5, 1, 29, 168, DateTimeKind.Utc).AddTicks(8314), new Guid("f79a9cdd-7d35-482b-beed-3be6ed00484c") });

            migrationBuilder.UpdateData(
                table: "T_CLIENT_CONTACT",
                keyColumn: "ID",
                keyValue: 1,
                columns: new[] { "CREATED_DATE", "UPDATED_DATE", "UUID" },
                values: new object[] { new DateTime(2025, 11, 13, 5, 1, 29, 168, DateTimeKind.Utc).AddTicks(8314), new DateTime(2025, 11, 13, 5, 1, 29, 168, DateTimeKind.Utc).AddTicks(8314), new Guid("c90b6409-c173-4564-83d9-b263707b8e85") });

            migrationBuilder.UpdateData(
                table: "T_CLIENT_CONTACT",
                keyColumn: "ID",
                keyValue: 2,
                columns: new[] { "CREATED_DATE", "UPDATED_DATE", "UUID" },
                values: new object[] { new DateTime(2025, 11, 13, 5, 1, 29, 168, DateTimeKind.Utc).AddTicks(8314), new DateTime(2025, 11, 13, 5, 1, 29, 168, DateTimeKind.Utc).AddTicks(8314), new Guid("72238c74-fefb-405e-ab31-cb49111a149b") });

            migrationBuilder.UpdateData(
                table: "T_CLIENT_CONTACT",
                keyColumn: "ID",
                keyValue: 3,
                columns: new[] { "CREATED_DATE", "UPDATED_DATE", "UUID" },
                values: new object[] { new DateTime(2025, 11, 13, 5, 1, 29, 168, DateTimeKind.Utc).AddTicks(8314), new DateTime(2025, 11, 13, 5, 1, 29, 168, DateTimeKind.Utc).AddTicks(8314), new Guid("3e20db50-7e85-49bb-9683-055f63a44ac9") });

            migrationBuilder.UpdateData(
                table: "T_CLIENT_CONTACT",
                keyColumn: "ID",
                keyValue: 4,
                columns: new[] { "CREATED_DATE", "UPDATED_DATE", "UUID" },
                values: new object[] { new DateTime(2025, 11, 13, 5, 1, 29, 168, DateTimeKind.Utc).AddTicks(8314), new DateTime(2025, 11, 13, 5, 1, 29, 168, DateTimeKind.Utc).AddTicks(8314), new Guid("4b985348-937c-4414-82a6-c2dfbbc5f964") });

            migrationBuilder.UpdateData(
                table: "T_CLIENT_CONTACT",
                keyColumn: "ID",
                keyValue: 5,
                columns: new[] { "CREATED_DATE", "UPDATED_DATE", "UUID" },
                values: new object[] { new DateTime(2025, 11, 13, 5, 1, 29, 168, DateTimeKind.Utc).AddTicks(8314), new DateTime(2025, 11, 13, 5, 1, 29, 168, DateTimeKind.Utc).AddTicks(8314), new Guid("ff033502-f87c-42a4-9aac-6bed482d506b") });

            migrationBuilder.UpdateData(
                table: "T_CLIENT_CONTACT",
                keyColumn: "ID",
                keyValue: 6,
                columns: new[] { "CREATED_DATE", "UPDATED_DATE", "UUID" },
                values: new object[] { new DateTime(2025, 11, 13, 5, 1, 29, 168, DateTimeKind.Utc).AddTicks(8314), new DateTime(2025, 11, 13, 5, 1, 29, 168, DateTimeKind.Utc).AddTicks(8314), new Guid("808f4888-f9e9-49e0-83b1-1dd43d0bb351") });

            migrationBuilder.UpdateData(
                table: "T_CLIENT_CONTACT",
                keyColumn: "ID",
                keyValue: 7,
                columns: new[] { "CREATED_DATE", "UPDATED_DATE", "UUID" },
                values: new object[] { new DateTime(2025, 11, 13, 5, 1, 29, 168, DateTimeKind.Utc).AddTicks(8314), new DateTime(2025, 11, 13, 5, 1, 29, 168, DateTimeKind.Utc).AddTicks(8314), new Guid("035c6538-03e3-4915-aa8d-df16ec8e9baa") });

            migrationBuilder.UpdateData(
                table: "T_CLIENT_CONTACT",
                keyColumn: "ID",
                keyValue: 8,
                columns: new[] { "CREATED_DATE", "UPDATED_DATE", "UUID" },
                values: new object[] { new DateTime(2025, 11, 13, 5, 1, 29, 168, DateTimeKind.Utc).AddTicks(8314), new DateTime(2025, 11, 13, 5, 1, 29, 168, DateTimeKind.Utc).AddTicks(8314), new Guid("47769d03-bace-407d-9d4f-030fe2ce62a8") });

            migrationBuilder.UpdateData(
                table: "T_CLIENT_ROLE",
                keyColumn: "ID",
                keyValue: 1,
                columns: new[] { "CREATED_DATE", "UPDATED_DATE", "UUID" },
                values: new object[] { new DateTime(2025, 11, 13, 5, 1, 29, 168, DateTimeKind.Utc).AddTicks(8314), new DateTime(2025, 11, 13, 5, 1, 29, 168, DateTimeKind.Utc).AddTicks(8314), new Guid("72cd880b-0ff2-4dd2-8857-fbb5d2457383") });

            migrationBuilder.UpdateData(
                table: "T_CLIENT_ROLE",
                keyColumn: "ID",
                keyValue: 2,
                columns: new[] { "CREATED_DATE", "UPDATED_DATE", "UUID" },
                values: new object[] { new DateTime(2025, 11, 13, 5, 1, 29, 168, DateTimeKind.Utc).AddTicks(8314), new DateTime(2025, 11, 13, 5, 1, 29, 168, DateTimeKind.Utc).AddTicks(8314), new Guid("a3c46463-2e54-4814-8bb4-5ced0aca1e71") });

            migrationBuilder.UpdateData(
                table: "T_CLIENT_ROLE",
                keyColumn: "ID",
                keyValue: 3,
                columns: new[] { "CREATED_DATE", "UPDATED_DATE", "UUID" },
                values: new object[] { new DateTime(2025, 11, 13, 5, 1, 29, 168, DateTimeKind.Utc).AddTicks(8314), new DateTime(2025, 11, 13, 5, 1, 29, 168, DateTimeKind.Utc).AddTicks(8314), new Guid("83ebd3bf-41ee-4fbb-97e8-a7eed441b97d") });

            migrationBuilder.UpdateData(
                table: "T_CLIENT_ROLE",
                keyColumn: "ID",
                keyValue: 4,
                columns: new[] { "CREATED_DATE", "UPDATED_DATE", "UUID" },
                values: new object[] { new DateTime(2025, 11, 13, 5, 1, 29, 168, DateTimeKind.Utc).AddTicks(8314), new DateTime(2025, 11, 13, 5, 1, 29, 168, DateTimeKind.Utc).AddTicks(8314), new Guid("be6b97c1-c9e1-4f05-a059-0d0b69c5554c") });

            migrationBuilder.UpdateData(
                table: "T_CLIENT_ROLE",
                keyColumn: "ID",
                keyValue: 5,
                columns: new[] { "CREATED_DATE", "UPDATED_DATE", "UUID" },
                values: new object[] { new DateTime(2025, 11, 13, 5, 1, 29, 168, DateTimeKind.Utc).AddTicks(8314), new DateTime(2025, 11, 13, 5, 1, 29, 168, DateTimeKind.Utc).AddTicks(8314), new Guid("7609e168-e7c3-497b-bf9e-79d8e1cd0e6f") });

            migrationBuilder.UpdateData(
                table: "T_IMAGE",
                keyColumn: "ID",
                keyValue: 1,
                columns: new[] { "CREATED_DATE", "UPDATED_DATE" },
                values: new object[] { new DateTime(2025, 11, 13, 5, 1, 29, 168, DateTimeKind.Utc).AddTicks(8314), new DateTime(2025, 11, 13, 5, 1, 29, 168, DateTimeKind.Utc).AddTicks(8314) });

            migrationBuilder.UpdateData(
                table: "T_IMAGE",
                keyColumn: "ID",
                keyValue: 2,
                columns: new[] { "CREATED_DATE", "UPDATED_DATE" },
                values: new object[] { new DateTime(2025, 11, 13, 5, 1, 29, 168, DateTimeKind.Utc).AddTicks(8314), new DateTime(2025, 11, 13, 5, 1, 29, 168, DateTimeKind.Utc).AddTicks(8314) });

            migrationBuilder.UpdateData(
                table: "T_IMAGE",
                keyColumn: "ID",
                keyValue: 3,
                columns: new[] { "CREATED_DATE", "UPDATED_DATE" },
                values: new object[] { new DateTime(2025, 11, 13, 5, 1, 29, 168, DateTimeKind.Utc).AddTicks(8314), new DateTime(2025, 11, 13, 5, 1, 29, 168, DateTimeKind.Utc).AddTicks(8314) });

            migrationBuilder.UpdateData(
                table: "T_IMAGE",
                keyColumn: "ID",
                keyValue: 4,
                columns: new[] { "CREATED_DATE", "UPDATED_DATE" },
                values: new object[] { new DateTime(2025, 11, 13, 5, 1, 29, 168, DateTimeKind.Utc).AddTicks(8314), new DateTime(2025, 11, 13, 5, 1, 29, 168, DateTimeKind.Utc).AddTicks(8314) });

            migrationBuilder.UpdateData(
                table: "T_IMAGE",
                keyColumn: "ID",
                keyValue: 5,
                columns: new[] { "CREATED_DATE", "UPDATED_DATE" },
                values: new object[] { new DateTime(2025, 11, 13, 5, 1, 29, 168, DateTimeKind.Utc).AddTicks(8314), new DateTime(2025, 11, 13, 5, 1, 29, 168, DateTimeKind.Utc).AddTicks(8314) });

            migrationBuilder.UpdateData(
                table: "T_IMAGE",
                keyColumn: "ID",
                keyValue: 6,
                columns: new[] { "CREATED_DATE", "UPDATED_DATE" },
                values: new object[] { new DateTime(2025, 11, 13, 5, 1, 29, 168, DateTimeKind.Utc).AddTicks(8314), new DateTime(2025, 11, 13, 5, 1, 29, 168, DateTimeKind.Utc).AddTicks(8314) });

            migrationBuilder.UpdateData(
                table: "T_IMAGE",
                keyColumn: "ID",
                keyValue: 7,
                columns: new[] { "CREATED_DATE", "UPDATED_DATE" },
                values: new object[] { new DateTime(2025, 11, 13, 5, 1, 29, 168, DateTimeKind.Utc).AddTicks(8314), new DateTime(2025, 11, 13, 5, 1, 29, 168, DateTimeKind.Utc).AddTicks(8314) });

            migrationBuilder.CreateIndex(
                name: "IX_Agents_AgentType",
                table: "Agents",
                column: "AgentType");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Agents_AgentType",
                table: "Agents");

            migrationBuilder.DropColumn(
                name: "AgentType",
                table: "Agents");

            migrationBuilder.UpdateData(
                table: "Agents",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2025, 11, 10, 6, 53, 12, 276, DateTimeKind.Utc).AddTicks(5899), new DateTime(2025, 11, 10, 6, 53, 12, 276, DateTimeKind.Utc).AddTicks(5899) });

            migrationBuilder.UpdateData(
                table: "Agents",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2025, 11, 10, 6, 53, 12, 276, DateTimeKind.Utc).AddTicks(5899), new DateTime(2025, 11, 10, 6, 53, 12, 276, DateTimeKind.Utc).AddTicks(5899) });

            migrationBuilder.UpdateData(
                table: "Agents",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2025, 11, 10, 6, 53, 12, 276, DateTimeKind.Utc).AddTicks(5899), new DateTime(2025, 11, 10, 6, 53, 12, 276, DateTimeKind.Utc).AddTicks(5899) });

            migrationBuilder.UpdateData(
                table: "Agents",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2025, 11, 10, 6, 53, 12, 276, DateTimeKind.Utc).AddTicks(5899), new DateTime(2025, 11, 10, 6, 53, 12, 276, DateTimeKind.Utc).AddTicks(5899) });

            migrationBuilder.UpdateData(
                table: "Agents",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2025, 11, 10, 6, 53, 12, 276, DateTimeKind.Utc).AddTicks(5899), new DateTime(2025, 11, 10, 6, 53, 12, 276, DateTimeKind.Utc).AddTicks(5899) });

            migrationBuilder.UpdateData(
                table: "Agents",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2025, 11, 10, 6, 53, 12, 276, DateTimeKind.Utc).AddTicks(5899), new DateTime(2025, 11, 10, 6, 53, 12, 276, DateTimeKind.Utc).AddTicks(5899) });

            migrationBuilder.UpdateData(
                table: "Agents",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2025, 11, 10, 6, 53, 12, 276, DateTimeKind.Utc).AddTicks(5899), new DateTime(2025, 11, 10, 6, 53, 12, 276, DateTimeKind.Utc).AddTicks(5899) });

            migrationBuilder.UpdateData(
                table: "Agents",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2025, 11, 10, 6, 53, 12, 276, DateTimeKind.Utc).AddTicks(5899), new DateTime(2025, 11, 10, 6, 53, 12, 276, DateTimeKind.Utc).AddTicks(5899) });

            migrationBuilder.UpdateData(
                table: "T_CLIENT",
                keyColumn: "ID",
                keyValue: 1,
                columns: new[] { "CREATED_DATE", "UPDATED_DATE", "UUID" },
                values: new object[] { new DateTime(2025, 11, 10, 6, 53, 12, 276, DateTimeKind.Utc).AddTicks(5899), new DateTime(2025, 11, 10, 6, 53, 12, 276, DateTimeKind.Utc).AddTicks(5899), new Guid("4d72b511-3818-4b22-b7b7-cbf87240bf7c") });

            migrationBuilder.UpdateData(
                table: "T_CLIENT",
                keyColumn: "ID",
                keyValue: 2,
                columns: new[] { "CREATED_DATE", "UPDATED_DATE", "UUID" },
                values: new object[] { new DateTime(2025, 11, 10, 6, 53, 12, 276, DateTimeKind.Utc).AddTicks(5899), new DateTime(2025, 11, 10, 6, 53, 12, 276, DateTimeKind.Utc).AddTicks(5899), new Guid("040839bc-5426-490b-932e-96149c123866") });

            migrationBuilder.UpdateData(
                table: "T_CLIENT",
                keyColumn: "ID",
                keyValue: 3,
                columns: new[] { "CREATED_DATE", "UPDATED_DATE", "UUID" },
                values: new object[] { new DateTime(2025, 11, 10, 6, 53, 12, 276, DateTimeKind.Utc).AddTicks(5899), new DateTime(2025, 11, 10, 6, 53, 12, 276, DateTimeKind.Utc).AddTicks(5899), new Guid("8110c563-9f2f-4dc6-8047-9b74f110b2d1") });

            migrationBuilder.UpdateData(
                table: "T_CLIENT",
                keyColumn: "ID",
                keyValue: 4,
                columns: new[] { "CREATED_DATE", "UPDATED_DATE", "UUID" },
                values: new object[] { new DateTime(2025, 11, 10, 6, 53, 12, 276, DateTimeKind.Utc).AddTicks(5899), new DateTime(2025, 11, 10, 6, 53, 12, 276, DateTimeKind.Utc).AddTicks(5899), new Guid("d83be562-5c63-4218-a722-7e18eea71f1c") });

            migrationBuilder.UpdateData(
                table: "T_CLIENT_ADDRESS",
                keyColumn: "ID",
                keyValue: 1,
                columns: new[] { "CREATED_DATE", "UPDATED_DATE", "UUID" },
                values: new object[] { new DateTime(2025, 11, 10, 6, 53, 12, 276, DateTimeKind.Utc).AddTicks(5899), new DateTime(2025, 11, 10, 6, 53, 12, 276, DateTimeKind.Utc).AddTicks(5899), new Guid("3c5a42d7-5109-433a-898d-a13dbb736594") });

            migrationBuilder.UpdateData(
                table: "T_CLIENT_ADDRESS",
                keyColumn: "ID",
                keyValue: 2,
                columns: new[] { "CREATED_DATE", "UPDATED_DATE", "UUID" },
                values: new object[] { new DateTime(2025, 11, 10, 6, 53, 12, 276, DateTimeKind.Utc).AddTicks(5899), new DateTime(2025, 11, 10, 6, 53, 12, 276, DateTimeKind.Utc).AddTicks(5899), new Guid("2666bbfc-6fb1-4451-910f-c76529d38e7a") });

            migrationBuilder.UpdateData(
                table: "T_CLIENT_ADDRESS",
                keyColumn: "ID",
                keyValue: 3,
                columns: new[] { "CREATED_DATE", "UPDATED_DATE", "UUID" },
                values: new object[] { new DateTime(2025, 11, 10, 6, 53, 12, 276, DateTimeKind.Utc).AddTicks(5899), new DateTime(2025, 11, 10, 6, 53, 12, 276, DateTimeKind.Utc).AddTicks(5899), new Guid("d91ede4f-3eb5-40a6-bf46-90af5ee27cea") });

            migrationBuilder.UpdateData(
                table: "T_CLIENT_ADDRESS",
                keyColumn: "ID",
                keyValue: 4,
                columns: new[] { "CREATED_DATE", "UPDATED_DATE", "UUID" },
                values: new object[] { new DateTime(2025, 11, 10, 6, 53, 12, 276, DateTimeKind.Utc).AddTicks(5899), new DateTime(2025, 11, 10, 6, 53, 12, 276, DateTimeKind.Utc).AddTicks(5899), new Guid("54927243-accc-48f3-a5a2-4ffe33b4935d") });

            migrationBuilder.UpdateData(
                table: "T_CLIENT_CONTACT",
                keyColumn: "ID",
                keyValue: 1,
                columns: new[] { "CREATED_DATE", "UPDATED_DATE", "UUID" },
                values: new object[] { new DateTime(2025, 11, 10, 6, 53, 12, 276, DateTimeKind.Utc).AddTicks(5899), new DateTime(2025, 11, 10, 6, 53, 12, 276, DateTimeKind.Utc).AddTicks(5899), new Guid("429e5d16-e90e-4615-a9a9-060c3d3470b9") });

            migrationBuilder.UpdateData(
                table: "T_CLIENT_CONTACT",
                keyColumn: "ID",
                keyValue: 2,
                columns: new[] { "CREATED_DATE", "UPDATED_DATE", "UUID" },
                values: new object[] { new DateTime(2025, 11, 10, 6, 53, 12, 276, DateTimeKind.Utc).AddTicks(5899), new DateTime(2025, 11, 10, 6, 53, 12, 276, DateTimeKind.Utc).AddTicks(5899), new Guid("077fc481-a83c-4de8-904b-a2007493098d") });

            migrationBuilder.UpdateData(
                table: "T_CLIENT_CONTACT",
                keyColumn: "ID",
                keyValue: 3,
                columns: new[] { "CREATED_DATE", "UPDATED_DATE", "UUID" },
                values: new object[] { new DateTime(2025, 11, 10, 6, 53, 12, 276, DateTimeKind.Utc).AddTicks(5899), new DateTime(2025, 11, 10, 6, 53, 12, 276, DateTimeKind.Utc).AddTicks(5899), new Guid("cd9a2a8f-d3f2-49e6-82d7-ae4ba9eea31b") });

            migrationBuilder.UpdateData(
                table: "T_CLIENT_CONTACT",
                keyColumn: "ID",
                keyValue: 4,
                columns: new[] { "CREATED_DATE", "UPDATED_DATE", "UUID" },
                values: new object[] { new DateTime(2025, 11, 10, 6, 53, 12, 276, DateTimeKind.Utc).AddTicks(5899), new DateTime(2025, 11, 10, 6, 53, 12, 276, DateTimeKind.Utc).AddTicks(5899), new Guid("5c82baa7-c701-41f1-9139-0d6f5119e4cc") });

            migrationBuilder.UpdateData(
                table: "T_CLIENT_CONTACT",
                keyColumn: "ID",
                keyValue: 5,
                columns: new[] { "CREATED_DATE", "UPDATED_DATE", "UUID" },
                values: new object[] { new DateTime(2025, 11, 10, 6, 53, 12, 276, DateTimeKind.Utc).AddTicks(5899), new DateTime(2025, 11, 10, 6, 53, 12, 276, DateTimeKind.Utc).AddTicks(5899), new Guid("bc631174-b527-4925-beb9-dd63274a34e9") });

            migrationBuilder.UpdateData(
                table: "T_CLIENT_CONTACT",
                keyColumn: "ID",
                keyValue: 6,
                columns: new[] { "CREATED_DATE", "UPDATED_DATE", "UUID" },
                values: new object[] { new DateTime(2025, 11, 10, 6, 53, 12, 276, DateTimeKind.Utc).AddTicks(5899), new DateTime(2025, 11, 10, 6, 53, 12, 276, DateTimeKind.Utc).AddTicks(5899), new Guid("8180cf94-ab2c-4f14-b885-437c077e0891") });

            migrationBuilder.UpdateData(
                table: "T_CLIENT_CONTACT",
                keyColumn: "ID",
                keyValue: 7,
                columns: new[] { "CREATED_DATE", "UPDATED_DATE", "UUID" },
                values: new object[] { new DateTime(2025, 11, 10, 6, 53, 12, 276, DateTimeKind.Utc).AddTicks(5899), new DateTime(2025, 11, 10, 6, 53, 12, 276, DateTimeKind.Utc).AddTicks(5899), new Guid("5a6e2116-d940-4642-ad20-307a723b3fbb") });

            migrationBuilder.UpdateData(
                table: "T_CLIENT_CONTACT",
                keyColumn: "ID",
                keyValue: 8,
                columns: new[] { "CREATED_DATE", "UPDATED_DATE", "UUID" },
                values: new object[] { new DateTime(2025, 11, 10, 6, 53, 12, 276, DateTimeKind.Utc).AddTicks(5899), new DateTime(2025, 11, 10, 6, 53, 12, 276, DateTimeKind.Utc).AddTicks(5899), new Guid("da392db3-219d-4172-87f3-ecb624ae9c4b") });

            migrationBuilder.UpdateData(
                table: "T_CLIENT_ROLE",
                keyColumn: "ID",
                keyValue: 1,
                columns: new[] { "CREATED_DATE", "UPDATED_DATE", "UUID" },
                values: new object[] { new DateTime(2025, 11, 10, 6, 53, 12, 276, DateTimeKind.Utc).AddTicks(5899), new DateTime(2025, 11, 10, 6, 53, 12, 276, DateTimeKind.Utc).AddTicks(5899), new Guid("d82c86c7-6632-4a3e-8e85-b66e444c5a7e") });

            migrationBuilder.UpdateData(
                table: "T_CLIENT_ROLE",
                keyColumn: "ID",
                keyValue: 2,
                columns: new[] { "CREATED_DATE", "UPDATED_DATE", "UUID" },
                values: new object[] { new DateTime(2025, 11, 10, 6, 53, 12, 276, DateTimeKind.Utc).AddTicks(5899), new DateTime(2025, 11, 10, 6, 53, 12, 276, DateTimeKind.Utc).AddTicks(5899), new Guid("15e60968-f8a7-41aa-a248-dbd84613d589") });

            migrationBuilder.UpdateData(
                table: "T_CLIENT_ROLE",
                keyColumn: "ID",
                keyValue: 3,
                columns: new[] { "CREATED_DATE", "UPDATED_DATE", "UUID" },
                values: new object[] { new DateTime(2025, 11, 10, 6, 53, 12, 276, DateTimeKind.Utc).AddTicks(5899), new DateTime(2025, 11, 10, 6, 53, 12, 276, DateTimeKind.Utc).AddTicks(5899), new Guid("7e240e2d-2dff-4862-9784-59b568a71d32") });

            migrationBuilder.UpdateData(
                table: "T_CLIENT_ROLE",
                keyColumn: "ID",
                keyValue: 4,
                columns: new[] { "CREATED_DATE", "UPDATED_DATE", "UUID" },
                values: new object[] { new DateTime(2025, 11, 10, 6, 53, 12, 276, DateTimeKind.Utc).AddTicks(5899), new DateTime(2025, 11, 10, 6, 53, 12, 276, DateTimeKind.Utc).AddTicks(5899), new Guid("426645e0-f584-45d3-beaf-7136dffdd71a") });

            migrationBuilder.UpdateData(
                table: "T_CLIENT_ROLE",
                keyColumn: "ID",
                keyValue: 5,
                columns: new[] { "CREATED_DATE", "UPDATED_DATE", "UUID" },
                values: new object[] { new DateTime(2025, 11, 10, 6, 53, 12, 276, DateTimeKind.Utc).AddTicks(5899), new DateTime(2025, 11, 10, 6, 53, 12, 276, DateTimeKind.Utc).AddTicks(5899), new Guid("b7bb5fcd-1ba9-40ad-b8bd-39bded9b11f8") });

            migrationBuilder.UpdateData(
                table: "T_IMAGE",
                keyColumn: "ID",
                keyValue: 1,
                columns: new[] { "CREATED_DATE", "UPDATED_DATE" },
                values: new object[] { new DateTime(2025, 11, 10, 6, 53, 12, 276, DateTimeKind.Utc).AddTicks(5899), new DateTime(2025, 11, 10, 6, 53, 12, 276, DateTimeKind.Utc).AddTicks(5899) });

            migrationBuilder.UpdateData(
                table: "T_IMAGE",
                keyColumn: "ID",
                keyValue: 2,
                columns: new[] { "CREATED_DATE", "UPDATED_DATE" },
                values: new object[] { new DateTime(2025, 11, 10, 6, 53, 12, 276, DateTimeKind.Utc).AddTicks(5899), new DateTime(2025, 11, 10, 6, 53, 12, 276, DateTimeKind.Utc).AddTicks(5899) });

            migrationBuilder.UpdateData(
                table: "T_IMAGE",
                keyColumn: "ID",
                keyValue: 3,
                columns: new[] { "CREATED_DATE", "UPDATED_DATE" },
                values: new object[] { new DateTime(2025, 11, 10, 6, 53, 12, 276, DateTimeKind.Utc).AddTicks(5899), new DateTime(2025, 11, 10, 6, 53, 12, 276, DateTimeKind.Utc).AddTicks(5899) });

            migrationBuilder.UpdateData(
                table: "T_IMAGE",
                keyColumn: "ID",
                keyValue: 4,
                columns: new[] { "CREATED_DATE", "UPDATED_DATE" },
                values: new object[] { new DateTime(2025, 11, 10, 6, 53, 12, 276, DateTimeKind.Utc).AddTicks(5899), new DateTime(2025, 11, 10, 6, 53, 12, 276, DateTimeKind.Utc).AddTicks(5899) });

            migrationBuilder.UpdateData(
                table: "T_IMAGE",
                keyColumn: "ID",
                keyValue: 5,
                columns: new[] { "CREATED_DATE", "UPDATED_DATE" },
                values: new object[] { new DateTime(2025, 11, 10, 6, 53, 12, 276, DateTimeKind.Utc).AddTicks(5899), new DateTime(2025, 11, 10, 6, 53, 12, 276, DateTimeKind.Utc).AddTicks(5899) });

            migrationBuilder.UpdateData(
                table: "T_IMAGE",
                keyColumn: "ID",
                keyValue: 6,
                columns: new[] { "CREATED_DATE", "UPDATED_DATE" },
                values: new object[] { new DateTime(2025, 11, 10, 6, 53, 12, 276, DateTimeKind.Utc).AddTicks(5899), new DateTime(2025, 11, 10, 6, 53, 12, 276, DateTimeKind.Utc).AddTicks(5899) });

            migrationBuilder.UpdateData(
                table: "T_IMAGE",
                keyColumn: "ID",
                keyValue: 7,
                columns: new[] { "CREATED_DATE", "UPDATED_DATE" },
                values: new object[] { new DateTime(2025, 11, 10, 6, 53, 12, 276, DateTimeKind.Utc).AddTicks(5899), new DateTime(2025, 11, 10, 6, 53, 12, 276, DateTimeKind.Utc).AddTicks(5899) });
        }
    }
}
