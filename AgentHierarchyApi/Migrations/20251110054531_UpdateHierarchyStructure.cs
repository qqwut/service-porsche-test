using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AgentHierarchyApi.Migrations
{
    public partial class UpdateHierarchyStructure : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Agents",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "AgentName", "CreatedDate", "UpdatedDate" },
                values: new object[] { "Executive Agent A9", new DateTime(2025, 11, 10, 5, 45, 30, 868, DateTimeKind.Utc).AddTicks(8185), new DateTime(2025, 11, 10, 5, 45, 30, 868, DateTimeKind.Utc).AddTicks(8185) });

            migrationBuilder.UpdateData(
                table: "Agents",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "AgentCode", "AgentName", "CreatedDate", "HierarchyId", "RankId", "UpdatedDate" },
                values: new object[] { "AE0002", "Executive Agent A8", new DateTime(2025, 11, 10, 5, 45, 30, 868, DateTimeKind.Utc).AddTicks(8185), 8, 3, new DateTime(2025, 11, 10, 5, 45, 30, 868, DateTimeKind.Utc).AddTicks(8185) });

            migrationBuilder.UpdateData(
                table: "Agents",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "AgentCode", "AgentName", "CreatedDate", "HierarchyId", "ParentAgentId", "RankId", "UpdatedDate" },
                values: new object[] { "AE0003", "Executive Agent A7", new DateTime(2025, 11, 10, 5, 45, 30, 868, DateTimeKind.Utc).AddTicks(8185), 7, 2, 3, new DateTime(2025, 11, 10, 5, 45, 30, 868, DateTimeKind.Utc).AddTicks(8185) });

            migrationBuilder.UpdateData(
                table: "Agents",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "AgentCode", "AgentName", "CreatedDate", "HierarchyId", "ParentAgentId", "RankId", "UpdatedDate" },
                values: new object[] { "AL0001", "Leader Agent A6", new DateTime(2025, 11, 10, 5, 45, 30, 868, DateTimeKind.Utc).AddTicks(8185), 6, 3, 2, new DateTime(2025, 11, 10, 5, 45, 30, 868, DateTimeKind.Utc).AddTicks(8185) });

            migrationBuilder.UpdateData(
                table: "Agents",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "AgentCode", "AgentName", "CreatedDate", "HierarchyId", "ParentAgentId", "RankId", "UpdatedDate" },
                values: new object[] { "AL0002", "Leader Agent A5", new DateTime(2025, 11, 10, 5, 45, 30, 868, DateTimeKind.Utc).AddTicks(8185), 5, 3, 2, new DateTime(2025, 11, 10, 5, 45, 30, 868, DateTimeKind.Utc).AddTicks(8185) });

            migrationBuilder.UpdateData(
                table: "Agents",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "AgentCode", "AgentName", "CreatedDate", "ParentAgentId", "UpdatedDate" },
                values: new object[] { "AG0001", "General Agent A1-1", new DateTime(2025, 11, 10, 5, 45, 30, 868, DateTimeKind.Utc).AddTicks(8185), 4, new DateTime(2025, 11, 10, 5, 45, 30, 868, DateTimeKind.Utc).AddTicks(8185) });

            migrationBuilder.InsertData(
                table: "Agents",
                columns: new[] { "Id", "AgentCode", "AgentName", "CreatedDate", "HierarchyId", "IsActive", "ParentAgentId", "RankId", "UpdatedDate" },
                values: new object[] { 7, "AG0002", "General Agent A1-2", new DateTime(2025, 11, 10, 5, 45, 30, 868, DateTimeKind.Utc).AddTicks(8185), 1, true, 5, 1, new DateTime(2025, 11, 10, 5, 45, 30, 868, DateTimeKind.Utc).AddTicks(8185) });

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Agents",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.UpdateData(
                table: "Agents",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "AgentName", "CreatedDate", "UpdatedDate" },
                values: new object[] { "Executive Agent 1", new DateTime(2025, 11, 8, 2, 14, 36, 823, DateTimeKind.Utc).AddTicks(5292), new DateTime(2025, 11, 8, 2, 14, 36, 823, DateTimeKind.Utc).AddTicks(5292) });

            migrationBuilder.UpdateData(
                table: "Agents",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "AgentCode", "AgentName", "CreatedDate", "HierarchyId", "RankId", "UpdatedDate" },
                values: new object[] { "AL0001", "Leader Agent 1", new DateTime(2025, 11, 8, 2, 14, 36, 823, DateTimeKind.Utc).AddTicks(5292), 6, 2, new DateTime(2025, 11, 8, 2, 14, 36, 823, DateTimeKind.Utc).AddTicks(5292) });

            migrationBuilder.UpdateData(
                table: "Agents",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "AgentCode", "AgentName", "CreatedDate", "HierarchyId", "ParentAgentId", "RankId", "UpdatedDate" },
                values: new object[] { "AL0002", "Leader Agent 2", new DateTime(2025, 11, 8, 2, 14, 36, 823, DateTimeKind.Utc).AddTicks(5292), 5, 1, 2, new DateTime(2025, 11, 8, 2, 14, 36, 823, DateTimeKind.Utc).AddTicks(5292) });

            migrationBuilder.UpdateData(
                table: "Agents",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "AgentCode", "AgentName", "CreatedDate", "HierarchyId", "ParentAgentId", "RankId", "UpdatedDate" },
                values: new object[] { "AG0001", "General Agent 1", new DateTime(2025, 11, 8, 2, 14, 36, 823, DateTimeKind.Utc).AddTicks(5292), 3, 2, 1, new DateTime(2025, 11, 8, 2, 14, 36, 823, DateTimeKind.Utc).AddTicks(5292) });

            migrationBuilder.UpdateData(
                table: "Agents",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "AgentCode", "AgentName", "CreatedDate", "HierarchyId", "ParentAgentId", "RankId", "UpdatedDate" },
                values: new object[] { "AG0002", "General Agent 2", new DateTime(2025, 11, 8, 2, 14, 36, 823, DateTimeKind.Utc).AddTicks(5292), 2, 2, 1, new DateTime(2025, 11, 8, 2, 14, 36, 823, DateTimeKind.Utc).AddTicks(5292) });

            migrationBuilder.UpdateData(
                table: "Agents",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "AgentCode", "AgentName", "CreatedDate", "ParentAgentId", "UpdatedDate" },
                values: new object[] { "AG0003", "General Agent 3", new DateTime(2025, 11, 8, 2, 14, 36, 823, DateTimeKind.Utc).AddTicks(5292), 3, new DateTime(2025, 11, 8, 2, 14, 36, 823, DateTimeKind.Utc).AddTicks(5292) });

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
    }
}
