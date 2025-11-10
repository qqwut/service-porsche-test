using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace AgentHierarchyApi.Migrations
{
    public partial class AddClientTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddUniqueConstraint(
                name: "AK_Agents_AgentCode",
                table: "Agents",
                column: "AgentCode");

            migrationBuilder.CreateTable(
                name: "T_CLIENT",
                columns: table => new
                {
                    ID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UUID = table.Column<Guid>(type: "uuid", nullable: false),
                    CLIENT_CODE = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    CLIENT_TYPE_CODE = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    IDENTITY_TYPE = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    IDENTITY_NO = table.Column<byte[]>(type: "bytea", nullable: true),
                    IDENTITY_PERMANENT = table.Column<bool>(type: "boolean", nullable: true),
                    IDENTITY_EXPIRY_DATE = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    TITLE_CODE = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    ORGANIZATION_NAME = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: true),
                    FIRST_NAME = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    MIDDLE_NAME = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    LAST_NAME = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    SUFFIX_NAME = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    ORGANIZATION_NAME_EN = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: true),
                    FIRST_NAME_EN = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    MIDDLE_NAME_EN = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    LAST_NAME_EN = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    SUFFIX_NAME_EN = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    NATIONALITY_CODE = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    PLACE_OF_BIRTH_COUNTRY_CODE = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    PLACE_OF_BIRTH_CITY = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    ORGANIZATION_REGISTRATION_DATE = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    DATE_OF_BIRTH = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    GENDER_CODE = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    RELIGION_CODE = table.Column<byte[]>(type: "bytea", nullable: true),
                    MARITAL_STATUS_CODE = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    EDUCATION_LEVEL_CODE = table.Column<byte[]>(type: "bytea", nullable: true),
                    PRIMARY_OCCUPATION_CODE = table.Column<byte[]>(type: "bytea", nullable: true),
                    PRIMARY_OCCUPATION_POSITION_CODE = table.Column<byte[]>(type: "bytea", nullable: true),
                    PRIMARY_OCCUPATION_BUSINESS_TYPE = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    PRIMARY_OCCUPATION_ORGANIZATION_NAME = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    PRIMARY_INCOME_LEVEL_CODE = table.Column<byte[]>(type: "bytea", nullable: true),
                    PRIMARY_INCOME_PER_YEAR = table.Column<byte[]>(type: "bytea", nullable: true),
                    SECONDARY_OCCUPATION_CODE = table.Column<byte[]>(type: "bytea", nullable: true),
                    SECONDARY_OCCUPATION_POSITION_CODE = table.Column<byte[]>(type: "bytea", nullable: true),
                    SECONDARY_OCCUPATION_BUSINESS_TYPE = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    SECONDARY_OCCUPATION_ORGANIZATION_NAME = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    SECONDARY_INCOME_LEVEL_CODE = table.Column<byte[]>(type: "bytea", nullable: true),
                    SECONDARY_INCOME_PER_YEAR = table.Column<byte[]>(type: "bytea", nullable: true),
                    PREMIUM_CAPACITY = table.Column<decimal>(type: "numeric(15,2)", precision: 15, scale: 2, nullable: true),
                    LANGUAGE_PREFERENCE_CODE = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    RECEIVES_EMAIL_NEWS = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    ORGANIZATION_BUSINESS_TYPE = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    TAX_ID = table.Column<byte[]>(type: "bytea", nullable: true),
                    TERMINATED_FLAG = table.Column<bool>(type: "boolean", nullable: true),
                    TERMINATED_DATE = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    TERMINATED_REASON = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    IS_ACTIVE = table.Column<bool>(type: "boolean", nullable: false),
                    REMARK = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: true),
                    CREATED_DATE = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CREATED_BY = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    UPDATED_DATE = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UPDATED_BY = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    REF_ID = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_T_CLIENT", x => x.ID);
                    table.UniqueConstraint("AK_T_CLIENT_CLIENT_CODE", x => x.CLIENT_CODE);
                    table.ForeignKey(
                        name: "FK_T_CLIENT_Agents_REF_ID",
                        column: x => x.REF_ID,
                        principalTable: "Agents",
                        principalColumn: "AgentCode",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "T_CLIENT_ADDRESS",
                columns: table => new
                {
                    ID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UUID = table.Column<Guid>(type: "uuid", nullable: false),
                    CLIENT_CODE = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    ADDRESS_TYPE_CODE = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    ADDRESS_WORKPLACE_NAME = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    ADDRESS_NO = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    ADDRESS_MOO = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: true),
                    ADDRESS_DETAIL = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: true),
                    ADDRESS_VILLAGE_BUILDING = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    ADDRESS_ALLEY = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    ADDRESS_ROAD = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    SUBDISTRICT_CODE = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    DISTRICT_CODE = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    PROVINCE_CODE = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    POSTAL_CODE = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: false),
                    COUNTRY_CODE = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    IS_PRIMARY = table.Column<bool>(type: "boolean", nullable: false),
                    REMARK = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: true),
                    CREATED_DATE = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CREATED_BY = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    UPDATED_DATE = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UPDATED_BY = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_T_CLIENT_ADDRESS", x => x.ID);
                    table.ForeignKey(
                        name: "FK_T_CLIENT_ADDRESS_T_CLIENT_CLIENT_CODE",
                        column: x => x.CLIENT_CODE,
                        principalTable: "T_CLIENT",
                        principalColumn: "CLIENT_CODE",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "T_CLIENT_CONTACT",
                columns: table => new
                {
                    ID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UUID = table.Column<Guid>(type: "uuid", nullable: false),
                    CLIENT_CODE = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    CONTACT_TYPE_CODE = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    CONTACT_VALUE = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    IS_PRIMARY = table.Column<bool>(type: "boolean", nullable: false),
                    REMARK = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: true),
                    CREATED_DATE = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CREATED_BY = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    UPDATED_DATE = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UPDATED_BY = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_T_CLIENT_CONTACT", x => x.ID);
                    table.ForeignKey(
                        name: "FK_T_CLIENT_CONTACT_T_CLIENT_CLIENT_CODE",
                        column: x => x.CLIENT_CODE,
                        principalTable: "T_CLIENT",
                        principalColumn: "CLIENT_CODE",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "T_CLIENT_ROLE",
                columns: table => new
                {
                    ID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UUID = table.Column<Guid>(type: "uuid", nullable: false),
                    CLIENT_CODE = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    ROLE_CODE = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    REFERENCE_NO = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    POLICY_NO = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    EFFECTIVE_DATE = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    EXPIRY_DATE = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    ROLE_SEQ_NO = table.Column<int>(type: "integer", nullable: true),
                    IS_ACTIVE = table.Column<bool>(type: "boolean", nullable: false),
                    REMARK = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: true),
                    CREATED_DATE = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CREATED_BY = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    UPDATED_DATE = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UPDATED_BY = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_T_CLIENT_ROLE", x => x.ID);
                    table.ForeignKey(
                        name: "FK_T_CLIENT_ROLE_T_CLIENT_CLIENT_CODE",
                        column: x => x.CLIENT_CODE,
                        principalTable: "T_CLIENT",
                        principalColumn: "CLIENT_CODE",
                        onDelete: ReferentialAction.Cascade);
                });

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

            migrationBuilder.CreateIndex(
                name: "IX_T_CLIENT_CLIENT_CODE",
                table: "T_CLIENT",
                column: "CLIENT_CODE",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_T_CLIENT_REF_ID",
                table: "T_CLIENT",
                column: "REF_ID");

            migrationBuilder.CreateIndex(
                name: "IX_T_CLIENT_UUID",
                table: "T_CLIENT",
                column: "UUID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_T_CLIENT_ADDRESS_CLIENT_CODE",
                table: "T_CLIENT_ADDRESS",
                column: "CLIENT_CODE");

            migrationBuilder.CreateIndex(
                name: "IX_T_CLIENT_ADDRESS_UUID",
                table: "T_CLIENT_ADDRESS",
                column: "UUID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_T_CLIENT_CONTACT_CLIENT_CODE",
                table: "T_CLIENT_CONTACT",
                column: "CLIENT_CODE");

            migrationBuilder.CreateIndex(
                name: "IX_T_CLIENT_CONTACT_UUID",
                table: "T_CLIENT_CONTACT",
                column: "UUID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_T_CLIENT_ROLE_CLIENT_CODE",
                table: "T_CLIENT_ROLE",
                column: "CLIENT_CODE");

            migrationBuilder.CreateIndex(
                name: "IX_T_CLIENT_ROLE_UUID",
                table: "T_CLIENT_ROLE",
                column: "UUID",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "T_CLIENT_ADDRESS");

            migrationBuilder.DropTable(
                name: "T_CLIENT_CONTACT");

            migrationBuilder.DropTable(
                name: "T_CLIENT_ROLE");

            migrationBuilder.DropTable(
                name: "T_CLIENT");

            migrationBuilder.DropUniqueConstraint(
                name: "AK_Agents_AgentCode",
                table: "Agents");

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
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2025, 11, 10, 5, 53, 19, 93, DateTimeKind.Utc).AddTicks(7352), new DateTime(2025, 11, 10, 5, 53, 19, 93, DateTimeKind.Utc).AddTicks(7352) });

            migrationBuilder.UpdateData(
                table: "Agents",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2025, 11, 10, 5, 53, 19, 93, DateTimeKind.Utc).AddTicks(7352), new DateTime(2025, 11, 10, 5, 53, 19, 93, DateTimeKind.Utc).AddTicks(7352) });

            migrationBuilder.UpdateData(
                table: "Agents",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2025, 11, 10, 5, 53, 19, 93, DateTimeKind.Utc).AddTicks(7352), new DateTime(2025, 11, 10, 5, 53, 19, 93, DateTimeKind.Utc).AddTicks(7352) });

            migrationBuilder.UpdateData(
                table: "Agents",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2025, 11, 10, 5, 53, 19, 93, DateTimeKind.Utc).AddTicks(7352), new DateTime(2025, 11, 10, 5, 53, 19, 93, DateTimeKind.Utc).AddTicks(7352) });
        }
    }
}
