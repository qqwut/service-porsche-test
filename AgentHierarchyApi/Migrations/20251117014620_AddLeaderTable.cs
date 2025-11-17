using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace AgentHierarchyApi.Migrations
{
    public partial class AddLeaderTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "leaders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    RefId = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    PromoteType = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    Affiliation = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    Branch = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    RefLicense = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    RefCompany = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    LastRank = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreatedBy = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    UpdatedBy = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_leaders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_leaders_agents_RefId",
                        column: x => x.RefId,
                        principalTable: "agents",
                        principalColumn: "AgentCode",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.UpdateData(
                table: "agents",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2025, 11, 17, 1, 46, 18, 882, DateTimeKind.Utc).AddTicks(4869), new DateTime(2025, 11, 17, 1, 46, 18, 882, DateTimeKind.Utc).AddTicks(4869) });

            migrationBuilder.UpdateData(
                table: "agents",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2025, 11, 17, 1, 46, 18, 882, DateTimeKind.Utc).AddTicks(4869), new DateTime(2025, 11, 17, 1, 46, 18, 882, DateTimeKind.Utc).AddTicks(4869) });

            migrationBuilder.UpdateData(
                table: "agents",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2025, 11, 17, 1, 46, 18, 882, DateTimeKind.Utc).AddTicks(4869), new DateTime(2025, 11, 17, 1, 46, 18, 882, DateTimeKind.Utc).AddTicks(4869) });

            migrationBuilder.UpdateData(
                table: "agents",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2025, 11, 17, 1, 46, 18, 882, DateTimeKind.Utc).AddTicks(4869), new DateTime(2025, 11, 17, 1, 46, 18, 882, DateTimeKind.Utc).AddTicks(4869) });

            migrationBuilder.UpdateData(
                table: "agents",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2025, 11, 17, 1, 46, 18, 882, DateTimeKind.Utc).AddTicks(4869), new DateTime(2025, 11, 17, 1, 46, 18, 882, DateTimeKind.Utc).AddTicks(4869) });

            migrationBuilder.UpdateData(
                table: "agents",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2025, 11, 17, 1, 46, 18, 882, DateTimeKind.Utc).AddTicks(4869), new DateTime(2025, 11, 17, 1, 46, 18, 882, DateTimeKind.Utc).AddTicks(4869) });

            migrationBuilder.UpdateData(
                table: "agents",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2025, 11, 17, 1, 46, 18, 882, DateTimeKind.Utc).AddTicks(4869), new DateTime(2025, 11, 17, 1, 46, 18, 882, DateTimeKind.Utc).AddTicks(4869) });

            migrationBuilder.UpdateData(
                table: "agents",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2025, 11, 17, 1, 46, 18, 882, DateTimeKind.Utc).AddTicks(4869), new DateTime(2025, 11, 17, 1, 46, 18, 882, DateTimeKind.Utc).AddTicks(4869) });

            migrationBuilder.UpdateData(
                table: "t_client",
                keyColumn: "ID",
                keyValue: 1,
                columns: new[] { "CREATED_DATE", "UPDATED_DATE", "UUID" },
                values: new object[] { new DateTime(2025, 11, 17, 1, 46, 18, 882, DateTimeKind.Utc).AddTicks(4869), new DateTime(2025, 11, 17, 1, 46, 18, 882, DateTimeKind.Utc).AddTicks(4869), new Guid("e2f22da8-7973-45d4-b52b-c79b3c813273") });

            migrationBuilder.UpdateData(
                table: "t_client",
                keyColumn: "ID",
                keyValue: 2,
                columns: new[] { "CREATED_DATE", "UPDATED_DATE", "UUID" },
                values: new object[] { new DateTime(2025, 11, 17, 1, 46, 18, 882, DateTimeKind.Utc).AddTicks(4869), new DateTime(2025, 11, 17, 1, 46, 18, 882, DateTimeKind.Utc).AddTicks(4869), new Guid("afaa935b-8590-46b3-ab6b-7093d2ca9120") });

            migrationBuilder.UpdateData(
                table: "t_client",
                keyColumn: "ID",
                keyValue: 3,
                columns: new[] { "CREATED_DATE", "UPDATED_DATE", "UUID" },
                values: new object[] { new DateTime(2025, 11, 17, 1, 46, 18, 882, DateTimeKind.Utc).AddTicks(4869), new DateTime(2025, 11, 17, 1, 46, 18, 882, DateTimeKind.Utc).AddTicks(4869), new Guid("4d1937fa-a55a-46e8-835d-0b4c77cc799d") });

            migrationBuilder.UpdateData(
                table: "t_client",
                keyColumn: "ID",
                keyValue: 4,
                columns: new[] { "CREATED_DATE", "UPDATED_DATE", "UUID" },
                values: new object[] { new DateTime(2025, 11, 17, 1, 46, 18, 882, DateTimeKind.Utc).AddTicks(4869), new DateTime(2025, 11, 17, 1, 46, 18, 882, DateTimeKind.Utc).AddTicks(4869), new Guid("acebdb8f-54eb-4e72-b669-bab2901ff86a") });

            migrationBuilder.UpdateData(
                table: "t_client_address",
                keyColumn: "ID",
                keyValue: 1,
                columns: new[] { "CREATED_DATE", "UPDATED_DATE", "UUID" },
                values: new object[] { new DateTime(2025, 11, 17, 1, 46, 18, 882, DateTimeKind.Utc).AddTicks(4869), new DateTime(2025, 11, 17, 1, 46, 18, 882, DateTimeKind.Utc).AddTicks(4869), new Guid("0eaf8977-9053-4b60-bfa9-9f116135cf66") });

            migrationBuilder.UpdateData(
                table: "t_client_address",
                keyColumn: "ID",
                keyValue: 2,
                columns: new[] { "CREATED_DATE", "UPDATED_DATE", "UUID" },
                values: new object[] { new DateTime(2025, 11, 17, 1, 46, 18, 882, DateTimeKind.Utc).AddTicks(4869), new DateTime(2025, 11, 17, 1, 46, 18, 882, DateTimeKind.Utc).AddTicks(4869), new Guid("f61d1b58-88b6-4eb0-af1b-607a63e7e808") });

            migrationBuilder.UpdateData(
                table: "t_client_address",
                keyColumn: "ID",
                keyValue: 3,
                columns: new[] { "CREATED_DATE", "UPDATED_DATE", "UUID" },
                values: new object[] { new DateTime(2025, 11, 17, 1, 46, 18, 882, DateTimeKind.Utc).AddTicks(4869), new DateTime(2025, 11, 17, 1, 46, 18, 882, DateTimeKind.Utc).AddTicks(4869), new Guid("005b7037-1d7a-45c6-b2f5-8c8efa883b20") });

            migrationBuilder.UpdateData(
                table: "t_client_address",
                keyColumn: "ID",
                keyValue: 4,
                columns: new[] { "CREATED_DATE", "UPDATED_DATE", "UUID" },
                values: new object[] { new DateTime(2025, 11, 17, 1, 46, 18, 882, DateTimeKind.Utc).AddTicks(4869), new DateTime(2025, 11, 17, 1, 46, 18, 882, DateTimeKind.Utc).AddTicks(4869), new Guid("dff46b72-756d-49d9-ba6e-9c648c16785c") });

            migrationBuilder.UpdateData(
                table: "t_client_contact",
                keyColumn: "ID",
                keyValue: 1,
                columns: new[] { "CREATED_DATE", "UPDATED_DATE", "UUID" },
                values: new object[] { new DateTime(2025, 11, 17, 1, 46, 18, 882, DateTimeKind.Utc).AddTicks(4869), new DateTime(2025, 11, 17, 1, 46, 18, 882, DateTimeKind.Utc).AddTicks(4869), new Guid("9eea259b-df4e-4b90-b4ea-27c8190ca9e0") });

            migrationBuilder.UpdateData(
                table: "t_client_contact",
                keyColumn: "ID",
                keyValue: 2,
                columns: new[] { "CREATED_DATE", "UPDATED_DATE", "UUID" },
                values: new object[] { new DateTime(2025, 11, 17, 1, 46, 18, 882, DateTimeKind.Utc).AddTicks(4869), new DateTime(2025, 11, 17, 1, 46, 18, 882, DateTimeKind.Utc).AddTicks(4869), new Guid("21eb8b53-5fea-480f-bdc8-8068a8c9a133") });

            migrationBuilder.UpdateData(
                table: "t_client_contact",
                keyColumn: "ID",
                keyValue: 3,
                columns: new[] { "CREATED_DATE", "UPDATED_DATE", "UUID" },
                values: new object[] { new DateTime(2025, 11, 17, 1, 46, 18, 882, DateTimeKind.Utc).AddTicks(4869), new DateTime(2025, 11, 17, 1, 46, 18, 882, DateTimeKind.Utc).AddTicks(4869), new Guid("8ef10ceb-8b6e-4ea1-aa8a-5c333213a4ec") });

            migrationBuilder.UpdateData(
                table: "t_client_contact",
                keyColumn: "ID",
                keyValue: 4,
                columns: new[] { "CREATED_DATE", "UPDATED_DATE", "UUID" },
                values: new object[] { new DateTime(2025, 11, 17, 1, 46, 18, 882, DateTimeKind.Utc).AddTicks(4869), new DateTime(2025, 11, 17, 1, 46, 18, 882, DateTimeKind.Utc).AddTicks(4869), new Guid("6da7fcba-f5bc-438f-ac04-ae7672d42e61") });

            migrationBuilder.UpdateData(
                table: "t_client_contact",
                keyColumn: "ID",
                keyValue: 5,
                columns: new[] { "CREATED_DATE", "UPDATED_DATE", "UUID" },
                values: new object[] { new DateTime(2025, 11, 17, 1, 46, 18, 882, DateTimeKind.Utc).AddTicks(4869), new DateTime(2025, 11, 17, 1, 46, 18, 882, DateTimeKind.Utc).AddTicks(4869), new Guid("dedeb1dd-a5f6-464a-b485-2541579deaaf") });

            migrationBuilder.UpdateData(
                table: "t_client_contact",
                keyColumn: "ID",
                keyValue: 6,
                columns: new[] { "CREATED_DATE", "UPDATED_DATE", "UUID" },
                values: new object[] { new DateTime(2025, 11, 17, 1, 46, 18, 882, DateTimeKind.Utc).AddTicks(4869), new DateTime(2025, 11, 17, 1, 46, 18, 882, DateTimeKind.Utc).AddTicks(4869), new Guid("5231458b-e6d5-4cb7-890a-2c6aabd216da") });

            migrationBuilder.UpdateData(
                table: "t_client_contact",
                keyColumn: "ID",
                keyValue: 7,
                columns: new[] { "CREATED_DATE", "UPDATED_DATE", "UUID" },
                values: new object[] { new DateTime(2025, 11, 17, 1, 46, 18, 882, DateTimeKind.Utc).AddTicks(4869), new DateTime(2025, 11, 17, 1, 46, 18, 882, DateTimeKind.Utc).AddTicks(4869), new Guid("18bea912-e905-4e8c-8e44-5b2207b75374") });

            migrationBuilder.UpdateData(
                table: "t_client_contact",
                keyColumn: "ID",
                keyValue: 8,
                columns: new[] { "CREATED_DATE", "UPDATED_DATE", "UUID" },
                values: new object[] { new DateTime(2025, 11, 17, 1, 46, 18, 882, DateTimeKind.Utc).AddTicks(4869), new DateTime(2025, 11, 17, 1, 46, 18, 882, DateTimeKind.Utc).AddTicks(4869), new Guid("4b3b9387-c89d-4fb1-aff7-5ab03b4c0cb9") });

            migrationBuilder.UpdateData(
                table: "t_client_role",
                keyColumn: "ID",
                keyValue: 1,
                columns: new[] { "CREATED_DATE", "UPDATED_DATE", "UUID" },
                values: new object[] { new DateTime(2025, 11, 17, 1, 46, 18, 882, DateTimeKind.Utc).AddTicks(4869), new DateTime(2025, 11, 17, 1, 46, 18, 882, DateTimeKind.Utc).AddTicks(4869), new Guid("d9c7519d-0a6a-4608-9a77-72456fb28153") });

            migrationBuilder.UpdateData(
                table: "t_client_role",
                keyColumn: "ID",
                keyValue: 2,
                columns: new[] { "CREATED_DATE", "UPDATED_DATE", "UUID" },
                values: new object[] { new DateTime(2025, 11, 17, 1, 46, 18, 882, DateTimeKind.Utc).AddTicks(4869), new DateTime(2025, 11, 17, 1, 46, 18, 882, DateTimeKind.Utc).AddTicks(4869), new Guid("9d475f72-4a58-41e6-b1ad-b1790a34bd37") });

            migrationBuilder.UpdateData(
                table: "t_client_role",
                keyColumn: "ID",
                keyValue: 3,
                columns: new[] { "CREATED_DATE", "UPDATED_DATE", "UUID" },
                values: new object[] { new DateTime(2025, 11, 17, 1, 46, 18, 882, DateTimeKind.Utc).AddTicks(4869), new DateTime(2025, 11, 17, 1, 46, 18, 882, DateTimeKind.Utc).AddTicks(4869), new Guid("12cece51-64d2-4825-9863-48d7908f6dca") });

            migrationBuilder.UpdateData(
                table: "t_client_role",
                keyColumn: "ID",
                keyValue: 4,
                columns: new[] { "CREATED_DATE", "UPDATED_DATE", "UUID" },
                values: new object[] { new DateTime(2025, 11, 17, 1, 46, 18, 882, DateTimeKind.Utc).AddTicks(4869), new DateTime(2025, 11, 17, 1, 46, 18, 882, DateTimeKind.Utc).AddTicks(4869), new Guid("7fbf19c1-172d-4b0e-9d8d-7b45a9666309") });

            migrationBuilder.UpdateData(
                table: "t_client_role",
                keyColumn: "ID",
                keyValue: 5,
                columns: new[] { "CREATED_DATE", "UPDATED_DATE", "UUID" },
                values: new object[] { new DateTime(2025, 11, 17, 1, 46, 18, 882, DateTimeKind.Utc).AddTicks(4869), new DateTime(2025, 11, 17, 1, 46, 18, 882, DateTimeKind.Utc).AddTicks(4869), new Guid("c7139b7f-f363-4f3d-9507-5c06dd7e4c9c") });

            migrationBuilder.UpdateData(
                table: "t_image",
                keyColumn: "ID",
                keyValue: 1,
                columns: new[] { "CREATED_DATE", "UPDATED_DATE" },
                values: new object[] { new DateTime(2025, 11, 17, 1, 46, 18, 882, DateTimeKind.Utc).AddTicks(4869), new DateTime(2025, 11, 17, 1, 46, 18, 882, DateTimeKind.Utc).AddTicks(4869) });

            migrationBuilder.UpdateData(
                table: "t_image",
                keyColumn: "ID",
                keyValue: 2,
                columns: new[] { "CREATED_DATE", "UPDATED_DATE" },
                values: new object[] { new DateTime(2025, 11, 17, 1, 46, 18, 882, DateTimeKind.Utc).AddTicks(4869), new DateTime(2025, 11, 17, 1, 46, 18, 882, DateTimeKind.Utc).AddTicks(4869) });

            migrationBuilder.UpdateData(
                table: "t_image",
                keyColumn: "ID",
                keyValue: 3,
                columns: new[] { "CREATED_DATE", "UPDATED_DATE" },
                values: new object[] { new DateTime(2025, 11, 17, 1, 46, 18, 882, DateTimeKind.Utc).AddTicks(4869), new DateTime(2025, 11, 17, 1, 46, 18, 882, DateTimeKind.Utc).AddTicks(4869) });

            migrationBuilder.UpdateData(
                table: "t_image",
                keyColumn: "ID",
                keyValue: 4,
                columns: new[] { "CREATED_DATE", "UPDATED_DATE" },
                values: new object[] { new DateTime(2025, 11, 17, 1, 46, 18, 882, DateTimeKind.Utc).AddTicks(4869), new DateTime(2025, 11, 17, 1, 46, 18, 882, DateTimeKind.Utc).AddTicks(4869) });

            migrationBuilder.UpdateData(
                table: "t_image",
                keyColumn: "ID",
                keyValue: 5,
                columns: new[] { "CREATED_DATE", "UPDATED_DATE" },
                values: new object[] { new DateTime(2025, 11, 17, 1, 46, 18, 882, DateTimeKind.Utc).AddTicks(4869), new DateTime(2025, 11, 17, 1, 46, 18, 882, DateTimeKind.Utc).AddTicks(4869) });

            migrationBuilder.UpdateData(
                table: "t_image",
                keyColumn: "ID",
                keyValue: 6,
                columns: new[] { "CREATED_DATE", "UPDATED_DATE" },
                values: new object[] { new DateTime(2025, 11, 17, 1, 46, 18, 882, DateTimeKind.Utc).AddTicks(4869), new DateTime(2025, 11, 17, 1, 46, 18, 882, DateTimeKind.Utc).AddTicks(4869) });

            migrationBuilder.UpdateData(
                table: "t_image",
                keyColumn: "ID",
                keyValue: 7,
                columns: new[] { "CREATED_DATE", "UPDATED_DATE" },
                values: new object[] { new DateTime(2025, 11, 17, 1, 46, 18, 882, DateTimeKind.Utc).AddTicks(4869), new DateTime(2025, 11, 17, 1, 46, 18, 882, DateTimeKind.Utc).AddTicks(4869) });

            migrationBuilder.CreateIndex(
                name: "IX_leaders_LastRank",
                table: "leaders",
                column: "LastRank");

            migrationBuilder.CreateIndex(
                name: "IX_leaders_PromoteType",
                table: "leaders",
                column: "PromoteType");

            migrationBuilder.CreateIndex(
                name: "IX_leaders_RefId",
                table: "leaders",
                column: "RefId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "leaders");

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
        }
    }
}
