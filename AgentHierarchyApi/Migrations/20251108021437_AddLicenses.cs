using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace AgentHierarchyApi.Migrations
{
    public partial class AddLicenses : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Licenses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    AgentId = table.Column<int>(type: "integer", nullable: false),
                    LicenseNumber = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    IssueDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    ExpiryDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Licenses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Licenses_Agents_AgentId",
                        column: x => x.AgentId,
                        principalTable: "Agents",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "Agents",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2025, 11, 8, 2, 14, 36, 823, DateTimeKind.Utc).AddTicks(5292), new DateTime(2025, 11, 8, 2, 14, 36, 823, DateTimeKind.Utc).AddTicks(5292) });

            migrationBuilder.UpdateData(
                table: "Agents",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2025, 11, 8, 2, 14, 36, 823, DateTimeKind.Utc).AddTicks(5292), new DateTime(2025, 11, 8, 2, 14, 36, 823, DateTimeKind.Utc).AddTicks(5292) });

            migrationBuilder.UpdateData(
                table: "Agents",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2025, 11, 8, 2, 14, 36, 823, DateTimeKind.Utc).AddTicks(5292), new DateTime(2025, 11, 8, 2, 14, 36, 823, DateTimeKind.Utc).AddTicks(5292) });

            migrationBuilder.UpdateData(
                table: "Agents",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2025, 11, 8, 2, 14, 36, 823, DateTimeKind.Utc).AddTicks(5292), new DateTime(2025, 11, 8, 2, 14, 36, 823, DateTimeKind.Utc).AddTicks(5292) });

            migrationBuilder.UpdateData(
                table: "Agents",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2025, 11, 8, 2, 14, 36, 823, DateTimeKind.Utc).AddTicks(5292), new DateTime(2025, 11, 8, 2, 14, 36, 823, DateTimeKind.Utc).AddTicks(5292) });

            migrationBuilder.UpdateData(
                table: "Agents",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2025, 11, 8, 2, 14, 36, 823, DateTimeKind.Utc).AddTicks(5292), new DateTime(2025, 11, 8, 2, 14, 36, 823, DateTimeKind.Utc).AddTicks(5292) });

            migrationBuilder.CreateIndex(
                name: "IX_Licenses_AgentId",
                table: "Licenses",
                column: "AgentId");

            migrationBuilder.CreateIndex(
                name: "IX_Licenses_LicenseNumber",
                table: "Licenses",
                column: "LicenseNumber",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Licenses");

            migrationBuilder.UpdateData(
                table: "Agents",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2025, 11, 7, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 11, 7, 0, 0, 0, 0, DateTimeKind.Utc) });

            migrationBuilder.UpdateData(
                table: "Agents",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2025, 11, 7, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 11, 7, 0, 0, 0, 0, DateTimeKind.Utc) });

            migrationBuilder.UpdateData(
                table: "Agents",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2025, 11, 7, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 11, 7, 0, 0, 0, 0, DateTimeKind.Utc) });

            migrationBuilder.UpdateData(
                table: "Agents",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2025, 11, 7, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 11, 7, 0, 0, 0, 0, DateTimeKind.Utc) });

            migrationBuilder.UpdateData(
                table: "Agents",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2025, 11, 7, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 11, 7, 0, 0, 0, 0, DateTimeKind.Utc) });

            migrationBuilder.UpdateData(
                table: "Agents",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2025, 11, 7, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 11, 7, 0, 0, 0, 0, DateTimeKind.Utc) });
        }
    }
}
