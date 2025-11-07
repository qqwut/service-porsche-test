using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace AgentHierarchyApi.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Ranks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    RankCode = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: false),
                    RankName = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    Level = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ranks", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Hierarchies",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    HierarchyCode = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: false),
                    HierarchyName = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    RankId = table.Column<int>(type: "integer", nullable: false),
                    Level = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hierarchies", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Hierarchies_Ranks_RankId",
                        column: x => x.RankId,
                        principalTable: "Ranks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Agents",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    AgentCode = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    AgentName = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    HierarchyId = table.Column<int>(type: "integer", nullable: false),
                    ParentAgentId = table.Column<int>(type: "integer", nullable: true),
                    RankId = table.Column<int>(type: "integer", nullable: false),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Agents", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Agents_Hierarchies_HierarchyId",
                        column: x => x.HierarchyId,
                        principalTable: "Hierarchies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Agents_Ranks_RankId",
                        column: x => x.RankId,
                        principalTable: "Ranks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Agents_Agents_ParentAgentId",
                        column: x => x.ParentAgentId,
                        principalTable: "Agents",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Agents_AgentCode",
                table: "Agents",
                column: "AgentCode",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Agents_HierarchyId",
                table: "Agents",
                column: "HierarchyId");

            migrationBuilder.CreateIndex(
                name: "IX_Agents_ParentAgentId",
                table: "Agents",
                column: "ParentAgentId");

            migrationBuilder.CreateIndex(
                name: "IX_Agents_RankId",
                table: "Agents",
                column: "RankId");

            migrationBuilder.CreateIndex(
                name: "IX_Hierarchies_HierarchyCode",
                table: "Hierarchies",
                column: "HierarchyCode",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Hierarchies_RankId",
                table: "Hierarchies",
                column: "RankId");

            migrationBuilder.CreateIndex(
                name: "IX_Ranks_RankCode",
                table: "Ranks",
                column: "RankCode",
                unique: true);

            // Seed data
            migrationBuilder.InsertData(
                table: "Ranks",
                columns: new[] { "Id", "RankCode", "RankName", "Level" },
                values: new object[,]
                {
                    { 1, "AG", "Agent General", 1 },
                    { 2, "AL", "Agent Leader", 2 },
                    { 3, "AE", "Agent Executive", 3 }
                });

            migrationBuilder.InsertData(
                table: "Hierarchies",
                columns: new[] { "Id", "HierarchyCode", "HierarchyName", "RankId", "Level" },
                values: new object[,]
                {
                    { 1, "A1", "Hierarchy A1", 1, 1 },
                    { 2, "A2", "Hierarchy A2", 1, 2 },
                    { 3, "A3", "Hierarchy A3", 1, 3 },
                    { 4, "A4", "Hierarchy A4", 2, 4 },
                    { 5, "A5", "Hierarchy A5", 2, 5 },
                    { 6, "A6", "Hierarchy A6", 2, 6 },
                    { 7, "A7", "Hierarchy A7", 3, 7 },
                    { 8, "A8", "Hierarchy A8", 3, 8 },
                    { 9, "A9", "Hierarchy A9", 3, 9 }
                });

            var now = DateTime.UtcNow;
            migrationBuilder.InsertData(
                table: "Agents",
                columns: new[] { "Id", "AgentCode", "AgentName", "HierarchyId", "ParentAgentId", "RankId", "IsActive", "CreatedDate", "UpdatedDate" },
                values: new object[,]
                {
                    { 1, "AE0001", "Executive Agent 1", 9, null, 3, true, now, now },
                    { 2, "AL0001", "Leader Agent 1", 6, 1, 2, true, now, now },
                    { 3, "AL0002", "Leader Agent 2", 5, 1, 2, true, now, now },
                    { 4, "AG0001", "General Agent 1", 3, 2, 1, true, now, now },
                    { 5, "AG0002", "General Agent 2", 2, 2, 1, true, now, now },
                    { 6, "AG0003", "General Agent 3", 1, 3, 1, true, now, now }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Agents");

            migrationBuilder.DropTable(
                name: "Hierarchies");

            migrationBuilder.DropTable(
                name: "Ranks");
        }
    }
}
