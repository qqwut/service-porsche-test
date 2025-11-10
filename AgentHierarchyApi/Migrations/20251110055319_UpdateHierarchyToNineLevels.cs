using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AgentHierarchyApi.Migrations
{
    public partial class UpdateHierarchyToNineLevels : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Agents",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2025, 11, 10, 5, 53, 19, 93, DateTimeKind.Utc).AddTicks(7352), new DateTime(2025, 11, 10, 5, 53, 19, 93, DateTimeKind.Utc).AddTicks(7352) });

            migrationBuilder.UpdateData(
                table: "Agents",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2025, 11, 10, 5, 53, 19, 93, DateTimeKind.Utc).AddTicks(7352), new DateTime(2025, 11, 10, 5, 53, 19, 93, DateTimeKind.Utc).AddTicks(7352) });

            migrationBuilder.UpdateData(
                table: "Agents",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2025, 11, 10, 5, 53, 19, 93, DateTimeKind.Utc).AddTicks(7352), new DateTime(2025, 11, 10, 5, 53, 19, 93, DateTimeKind.Utc).AddTicks(7352) });

            migrationBuilder.UpdateData(
                table: "Agents",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2025, 11, 10, 5, 53, 19, 93, DateTimeKind.Utc).AddTicks(7352), new DateTime(2025, 11, 10, 5, 53, 19, 93, DateTimeKind.Utc).AddTicks(7352) });

            migrationBuilder.UpdateData(
                table: "Agents",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedDate", "ParentAgentId", "UpdatedDate" },
                values: new object[] { new DateTime(2025, 11, 10, 5, 53, 19, 93, DateTimeKind.Utc).AddTicks(7352), 4, new DateTime(2025, 11, 10, 5, 53, 19, 93, DateTimeKind.Utc).AddTicks(7352) });

            migrationBuilder.UpdateData(
                table: "Agents",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "AgentCode", "AgentName", "CreatedDate", "HierarchyId", "ParentAgentId", "RankId", "UpdatedDate" },
                values: new object[] { "AL0003", "Leader Agent A4", new DateTime(2025, 11, 10, 5, 53, 19, 93, DateTimeKind.Utc).AddTicks(7352), 4, 5, 2, new DateTime(2025, 11, 10, 5, 53, 19, 93, DateTimeKind.Utc).AddTicks(7352) });

            migrationBuilder.UpdateData(
                table: "Agents",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "AgentCode", "AgentName", "CreatedDate", "ParentAgentId", "UpdatedDate" },
                values: new object[] { "AG0001", "General Agent A1-1", new DateTime(2025, 11, 10, 5, 53, 19, 93, DateTimeKind.Utc).AddTicks(7352), 6, new DateTime(2025, 11, 10, 5, 53, 19, 93, DateTimeKind.Utc).AddTicks(7352) });

            migrationBuilder.InsertData(
                table: "Agents",
                columns: new[] { "Id", "AgentCode", "AgentName", "CreatedDate", "HierarchyId", "IsActive", "ParentAgentId", "RankId", "UpdatedDate" },
                values: new object[] { 8, "AG0002", "General Agent A1-2", new DateTime(2025, 11, 10, 5, 53, 19, 93, DateTimeKind.Utc).AddTicks(7352), 1, true, 6, 1, new DateTime(2025, 11, 10, 5, 53, 19, 93, DateTimeKind.Utc).AddTicks(7352) });

            migrationBuilder.UpdateData(
                table: "Hierarchies",
                keyColumn: "Id",
                keyValue: 2,
                column: "Level",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Hierarchies",
                keyColumn: "Id",
                keyValue: 3,
                column: "Level",
                value: 3);

            migrationBuilder.UpdateData(
                table: "Hierarchies",
                keyColumn: "Id",
                keyValue: 4,
                column: "Level",
                value: 4);

            migrationBuilder.UpdateData(
                table: "Hierarchies",
                keyColumn: "Id",
                keyValue: 5,
                column: "Level",
                value: 5);

            migrationBuilder.UpdateData(
                table: "Hierarchies",
                keyColumn: "Id",
                keyValue: 6,
                column: "Level",
                value: 6);

            migrationBuilder.UpdateData(
                table: "Hierarchies",
                keyColumn: "Id",
                keyValue: 7,
                column: "Level",
                value: 7);

            migrationBuilder.UpdateData(
                table: "Hierarchies",
                keyColumn: "Id",
                keyValue: 8,
                column: "Level",
                value: 8);

            migrationBuilder.UpdateData(
                table: "Hierarchies",
                keyColumn: "Id",
                keyValue: 9,
                column: "Level",
                value: 9);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Agents",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.UpdateData(
                table: "Agents",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2025, 11, 10, 5, 45, 30, 868, DateTimeKind.Utc).AddTicks(8185), new DateTime(2025, 11, 10, 5, 45, 30, 868, DateTimeKind.Utc).AddTicks(8185) });

            migrationBuilder.UpdateData(
                table: "Agents",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2025, 11, 10, 5, 45, 30, 868, DateTimeKind.Utc).AddTicks(8185), new DateTime(2025, 11, 10, 5, 45, 30, 868, DateTimeKind.Utc).AddTicks(8185) });

            migrationBuilder.UpdateData(
                table: "Agents",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2025, 11, 10, 5, 45, 30, 868, DateTimeKind.Utc).AddTicks(8185), new DateTime(2025, 11, 10, 5, 45, 30, 868, DateTimeKind.Utc).AddTicks(8185) });

            migrationBuilder.UpdateData(
                table: "Agents",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2025, 11, 10, 5, 45, 30, 868, DateTimeKind.Utc).AddTicks(8185), new DateTime(2025, 11, 10, 5, 45, 30, 868, DateTimeKind.Utc).AddTicks(8185) });

            migrationBuilder.UpdateData(
                table: "Agents",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedDate", "ParentAgentId", "UpdatedDate" },
                values: new object[] { new DateTime(2025, 11, 10, 5, 45, 30, 868, DateTimeKind.Utc).AddTicks(8185), 3, new DateTime(2025, 11, 10, 5, 45, 30, 868, DateTimeKind.Utc).AddTicks(8185) });

            migrationBuilder.UpdateData(
                table: "Agents",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "AgentCode", "AgentName", "CreatedDate", "HierarchyId", "ParentAgentId", "RankId", "UpdatedDate" },
                values: new object[] { "AG0001", "General Agent A1-1", new DateTime(2025, 11, 10, 5, 45, 30, 868, DateTimeKind.Utc).AddTicks(8185), 1, 4, 1, new DateTime(2025, 11, 10, 5, 45, 30, 868, DateTimeKind.Utc).AddTicks(8185) });

            migrationBuilder.UpdateData(
                table: "Agents",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "AgentCode", "AgentName", "CreatedDate", "ParentAgentId", "UpdatedDate" },
                values: new object[] { "AG0002", "General Agent A1-2", new DateTime(2025, 11, 10, 5, 45, 30, 868, DateTimeKind.Utc).AddTicks(8185), 5, new DateTime(2025, 11, 10, 5, 45, 30, 868, DateTimeKind.Utc).AddTicks(8185) });

            migrationBuilder.UpdateData(
                table: "Hierarchies",
                keyColumn: "Id",
                keyValue: 2,
                column: "Level",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Hierarchies",
                keyColumn: "Id",
                keyValue: 3,
                column: "Level",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Hierarchies",
                keyColumn: "Id",
                keyValue: 4,
                column: "Level",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Hierarchies",
                keyColumn: "Id",
                keyValue: 5,
                column: "Level",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Hierarchies",
                keyColumn: "Id",
                keyValue: 6,
                column: "Level",
                value: 3);

            migrationBuilder.UpdateData(
                table: "Hierarchies",
                keyColumn: "Id",
                keyValue: 7,
                column: "Level",
                value: 4);

            migrationBuilder.UpdateData(
                table: "Hierarchies",
                keyColumn: "Id",
                keyValue: 8,
                column: "Level",
                value: 5);

            migrationBuilder.UpdateData(
                table: "Hierarchies",
                keyColumn: "Id",
                keyValue: 9,
                column: "Level",
                value: 6);
        }
    }
}
