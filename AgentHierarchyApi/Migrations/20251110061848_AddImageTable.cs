using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace AgentHierarchyApi.Migrations
{
    public partial class AddImageTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "T_IMAGE",
                columns: table => new
                {
                    ID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UUID = table.Column<Guid>(type: "uuid", nullable: false),
                    IMAGE_CODE = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    REF_ID = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    IMAGE_TYPE_CODE = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    IMAGE_CATEGORY = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    FILE_NAME = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    FILE_PATH = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: true),
                    FILE_URL = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: true),
                    CONTENT_TYPE = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    FILE_SIZE = table.Column<long>(type: "bigint", nullable: true),
                    WIDTH = table.Column<int>(type: "integer", nullable: true),
                    HEIGHT = table.Column<int>(type: "integer", nullable: true),
                    IMAGE_DATA = table.Column<byte[]>(type: "bytea", nullable: true),
                    THUMBNAIL_URL = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: true),
                    THUMBNAIL_DATA = table.Column<byte[]>(type: "bytea", nullable: true),
                    IS_PRIMARY = table.Column<bool>(type: "boolean", nullable: false),
                    DISPLAY_ORDER = table.Column<int>(type: "integer", nullable: true),
                    IS_ACTIVE = table.Column<bool>(type: "boolean", nullable: false),
                    REMARK = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: true),
                    CREATED_DATE = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CREATED_BY = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    UPDATED_DATE = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UPDATED_BY = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_T_IMAGE", x => x.ID);
                    table.ForeignKey(
                        name: "FK_T_IMAGE_T_CLIENT_REF_ID",
                        column: x => x.REF_ID,
                        principalTable: "T_CLIENT",
                        principalColumn: "CLIENT_CODE",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "Agents",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2025, 11, 10, 6, 18, 47, 467, DateTimeKind.Utc).AddTicks(4093), new DateTime(2025, 11, 10, 6, 18, 47, 467, DateTimeKind.Utc).AddTicks(4093) });

            migrationBuilder.UpdateData(
                table: "Agents",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2025, 11, 10, 6, 18, 47, 467, DateTimeKind.Utc).AddTicks(4093), new DateTime(2025, 11, 10, 6, 18, 47, 467, DateTimeKind.Utc).AddTicks(4093) });

            migrationBuilder.UpdateData(
                table: "Agents",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2025, 11, 10, 6, 18, 47, 467, DateTimeKind.Utc).AddTicks(4093), new DateTime(2025, 11, 10, 6, 18, 47, 467, DateTimeKind.Utc).AddTicks(4093) });

            migrationBuilder.UpdateData(
                table: "Agents",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2025, 11, 10, 6, 18, 47, 467, DateTimeKind.Utc).AddTicks(4093), new DateTime(2025, 11, 10, 6, 18, 47, 467, DateTimeKind.Utc).AddTicks(4093) });

            migrationBuilder.UpdateData(
                table: "Agents",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2025, 11, 10, 6, 18, 47, 467, DateTimeKind.Utc).AddTicks(4093), new DateTime(2025, 11, 10, 6, 18, 47, 467, DateTimeKind.Utc).AddTicks(4093) });

            migrationBuilder.UpdateData(
                table: "Agents",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2025, 11, 10, 6, 18, 47, 467, DateTimeKind.Utc).AddTicks(4093), new DateTime(2025, 11, 10, 6, 18, 47, 467, DateTimeKind.Utc).AddTicks(4093) });

            migrationBuilder.UpdateData(
                table: "Agents",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2025, 11, 10, 6, 18, 47, 467, DateTimeKind.Utc).AddTicks(4093), new DateTime(2025, 11, 10, 6, 18, 47, 467, DateTimeKind.Utc).AddTicks(4093) });

            migrationBuilder.UpdateData(
                table: "Agents",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2025, 11, 10, 6, 18, 47, 467, DateTimeKind.Utc).AddTicks(4093), new DateTime(2025, 11, 10, 6, 18, 47, 467, DateTimeKind.Utc).AddTicks(4093) });

            migrationBuilder.CreateIndex(
                name: "IX_T_IMAGE_IMAGE_CODE",
                table: "T_IMAGE",
                column: "IMAGE_CODE",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_T_IMAGE_REF_ID",
                table: "T_IMAGE",
                column: "REF_ID");

            migrationBuilder.CreateIndex(
                name: "IX_T_IMAGE_UUID",
                table: "T_IMAGE",
                column: "UUID",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "T_IMAGE");

            migrationBuilder.UpdateData(
                table: "Agents",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2025, 11, 10, 6, 2, 3, 502, DateTimeKind.Utc).AddTicks(6496), new DateTime(2025, 11, 10, 6, 2, 3, 502, DateTimeKind.Utc).AddTicks(6496) });

            migrationBuilder.UpdateData(
                table: "Agents",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2025, 11, 10, 6, 2, 3, 502, DateTimeKind.Utc).AddTicks(6496), new DateTime(2025, 11, 10, 6, 2, 3, 502, DateTimeKind.Utc).AddTicks(6496) });

            migrationBuilder.UpdateData(
                table: "Agents",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2025, 11, 10, 6, 2, 3, 502, DateTimeKind.Utc).AddTicks(6496), new DateTime(2025, 11, 10, 6, 2, 3, 502, DateTimeKind.Utc).AddTicks(6496) });

            migrationBuilder.UpdateData(
                table: "Agents",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2025, 11, 10, 6, 2, 3, 502, DateTimeKind.Utc).AddTicks(6496), new DateTime(2025, 11, 10, 6, 2, 3, 502, DateTimeKind.Utc).AddTicks(6496) });

            migrationBuilder.UpdateData(
                table: "Agents",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2025, 11, 10, 6, 2, 3, 502, DateTimeKind.Utc).AddTicks(6496), new DateTime(2025, 11, 10, 6, 2, 3, 502, DateTimeKind.Utc).AddTicks(6496) });

            migrationBuilder.UpdateData(
                table: "Agents",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2025, 11, 10, 6, 2, 3, 502, DateTimeKind.Utc).AddTicks(6496), new DateTime(2025, 11, 10, 6, 2, 3, 502, DateTimeKind.Utc).AddTicks(6496) });

            migrationBuilder.UpdateData(
                table: "Agents",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2025, 11, 10, 6, 2, 3, 502, DateTimeKind.Utc).AddTicks(6496), new DateTime(2025, 11, 10, 6, 2, 3, 502, DateTimeKind.Utc).AddTicks(6496) });

            migrationBuilder.UpdateData(
                table: "Agents",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2025, 11, 10, 6, 2, 3, 502, DateTimeKind.Utc).AddTicks(6496), new DateTime(2025, 11, 10, 6, 2, 3, 502, DateTimeKind.Utc).AddTicks(6496) });
        }
    }
}
