using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AgentHierarchyApi.Migrations
{
    public partial class RenameTablesToLowercase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Agents_Agents_ParentAgentId",
                table: "Agents");

            migrationBuilder.DropForeignKey(
                name: "FK_Agents_Hierarchies_HierarchyId",
                table: "Agents");

            migrationBuilder.DropForeignKey(
                name: "FK_Agents_Ranks_RankId",
                table: "Agents");

            migrationBuilder.DropForeignKey(
                name: "FK_Hierarchies_Ranks_RankId",
                table: "Hierarchies");

            migrationBuilder.DropForeignKey(
                name: "FK_Licenses_Agents_AgentId",
                table: "Licenses");

            migrationBuilder.DropForeignKey(
                name: "FK_T_CLIENT_Agents_REF_ID",
                table: "T_CLIENT");

            migrationBuilder.DropForeignKey(
                name: "FK_T_CLIENT_ADDRESS_T_CLIENT_CLIENT_CODE",
                table: "T_CLIENT_ADDRESS");

            migrationBuilder.DropForeignKey(
                name: "FK_T_CLIENT_CONTACT_T_CLIENT_CLIENT_CODE",
                table: "T_CLIENT_CONTACT");

            migrationBuilder.DropForeignKey(
                name: "FK_T_CLIENT_ROLE_T_CLIENT_CLIENT_CODE",
                table: "T_CLIENT_ROLE");

            migrationBuilder.DropForeignKey(
                name: "FK_T_IMAGE_T_CLIENT_REF_ID",
                table: "T_IMAGE");

            migrationBuilder.DropPrimaryKey(
                name: "PK_T_IMAGE",
                table: "T_IMAGE");

            migrationBuilder.DropPrimaryKey(
                name: "PK_T_CLIENT_ROLE",
                table: "T_CLIENT_ROLE");

            migrationBuilder.DropPrimaryKey(
                name: "PK_T_CLIENT_CONTACT",
                table: "T_CLIENT_CONTACT");

            migrationBuilder.DropPrimaryKey(
                name: "PK_T_CLIENT_ADDRESS",
                table: "T_CLIENT_ADDRESS");

            migrationBuilder.DropUniqueConstraint(
                name: "AK_T_CLIENT_CLIENT_CODE",
                table: "T_CLIENT");

            migrationBuilder.DropPrimaryKey(
                name: "PK_T_CLIENT",
                table: "T_CLIENT");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Ranks",
                table: "Ranks");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Licenses",
                table: "Licenses");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Hierarchies",
                table: "Hierarchies");

            migrationBuilder.DropUniqueConstraint(
                name: "AK_Agents_AgentCode",
                table: "Agents");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Agents",
                table: "Agents");

            migrationBuilder.RenameTable(
                name: "T_IMAGE",
                newName: "t_image");

            migrationBuilder.RenameTable(
                name: "T_CLIENT_ROLE",
                newName: "t_client_role");

            migrationBuilder.RenameTable(
                name: "T_CLIENT_CONTACT",
                newName: "t_client_contact");

            migrationBuilder.RenameTable(
                name: "T_CLIENT_ADDRESS",
                newName: "t_client_address");

            migrationBuilder.RenameTable(
                name: "T_CLIENT",
                newName: "t_client");

            migrationBuilder.RenameTable(
                name: "Ranks",
                newName: "ranks");

            migrationBuilder.RenameTable(
                name: "Licenses",
                newName: "licenses");

            migrationBuilder.RenameTable(
                name: "Hierarchies",
                newName: "hierarchies");

            migrationBuilder.RenameTable(
                name: "Agents",
                newName: "agents");

            migrationBuilder.RenameIndex(
                name: "IX_T_IMAGE_UUID",
                table: "t_image",
                newName: "IX_t_image_UUID");

            migrationBuilder.RenameIndex(
                name: "IX_T_IMAGE_REF_ID",
                table: "t_image",
                newName: "IX_t_image_REF_ID");

            migrationBuilder.RenameIndex(
                name: "IX_T_IMAGE_IMAGE_CODE",
                table: "t_image",
                newName: "IX_t_image_IMAGE_CODE");

            migrationBuilder.RenameIndex(
                name: "IX_T_CLIENT_ROLE_UUID",
                table: "t_client_role",
                newName: "IX_t_client_role_UUID");

            migrationBuilder.RenameIndex(
                name: "IX_T_CLIENT_ROLE_CLIENT_CODE",
                table: "t_client_role",
                newName: "IX_t_client_role_CLIENT_CODE");

            migrationBuilder.RenameIndex(
                name: "IX_T_CLIENT_CONTACT_UUID",
                table: "t_client_contact",
                newName: "IX_t_client_contact_UUID");

            migrationBuilder.RenameIndex(
                name: "IX_T_CLIENT_CONTACT_CLIENT_CODE",
                table: "t_client_contact",
                newName: "IX_t_client_contact_CLIENT_CODE");

            migrationBuilder.RenameIndex(
                name: "IX_T_CLIENT_ADDRESS_UUID",
                table: "t_client_address",
                newName: "IX_t_client_address_UUID");

            migrationBuilder.RenameIndex(
                name: "IX_T_CLIENT_ADDRESS_CLIENT_CODE",
                table: "t_client_address",
                newName: "IX_t_client_address_CLIENT_CODE");

            migrationBuilder.RenameIndex(
                name: "IX_T_CLIENT_UUID",
                table: "t_client",
                newName: "IX_t_client_UUID");

            migrationBuilder.RenameIndex(
                name: "IX_T_CLIENT_REF_ID",
                table: "t_client",
                newName: "IX_t_client_REF_ID");

            migrationBuilder.RenameIndex(
                name: "IX_T_CLIENT_CLIENT_CODE",
                table: "t_client",
                newName: "IX_t_client_CLIENT_CODE");

            migrationBuilder.RenameIndex(
                name: "IX_Ranks_RankCode",
                table: "ranks",
                newName: "IX_ranks_RankCode");

            migrationBuilder.RenameIndex(
                name: "IX_Licenses_LicenseNumber",
                table: "licenses",
                newName: "IX_licenses_LicenseNumber");

            migrationBuilder.RenameIndex(
                name: "IX_Licenses_AgentId",
                table: "licenses",
                newName: "IX_licenses_AgentId");

            migrationBuilder.RenameIndex(
                name: "IX_Hierarchies_RankId",
                table: "hierarchies",
                newName: "IX_hierarchies_RankId");

            migrationBuilder.RenameIndex(
                name: "IX_Hierarchies_HierarchyCode",
                table: "hierarchies",
                newName: "IX_hierarchies_HierarchyCode");

            migrationBuilder.RenameIndex(
                name: "IX_Agents_RankId",
                table: "agents",
                newName: "IX_agents_RankId");

            migrationBuilder.RenameIndex(
                name: "IX_Agents_ParentAgentId",
                table: "agents",
                newName: "IX_agents_ParentAgentId");

            migrationBuilder.RenameIndex(
                name: "IX_Agents_HierarchyId",
                table: "agents",
                newName: "IX_agents_HierarchyId");

            migrationBuilder.RenameIndex(
                name: "IX_Agents_AgentType",
                table: "agents",
                newName: "IX_agents_AgentType");

            migrationBuilder.RenameIndex(
                name: "IX_Agents_AgentCode",
                table: "agents",
                newName: "IX_agents_AgentCode");

            migrationBuilder.AddPrimaryKey(
                name: "PK_t_image",
                table: "t_image",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_t_client_role",
                table: "t_client_role",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_t_client_contact",
                table: "t_client_contact",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_t_client_address",
                table: "t_client_address",
                column: "ID");

            migrationBuilder.AddUniqueConstraint(
                name: "AK_t_client_CLIENT_CODE",
                table: "t_client",
                column: "CLIENT_CODE");

            migrationBuilder.AddPrimaryKey(
                name: "PK_t_client",
                table: "t_client",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ranks",
                table: "ranks",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_licenses",
                table: "licenses",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_hierarchies",
                table: "hierarchies",
                column: "Id");

            migrationBuilder.AddUniqueConstraint(
                name: "AK_agents_AgentCode",
                table: "agents",
                column: "AgentCode");

            migrationBuilder.AddPrimaryKey(
                name: "PK_agents",
                table: "agents",
                column: "Id");

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

            migrationBuilder.AddForeignKey(
                name: "FK_agents_agents_ParentAgentId",
                table: "agents",
                column: "ParentAgentId",
                principalTable: "agents",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_agents_hierarchies_HierarchyId",
                table: "agents",
                column: "HierarchyId",
                principalTable: "hierarchies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_agents_ranks_RankId",
                table: "agents",
                column: "RankId",
                principalTable: "ranks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_hierarchies_ranks_RankId",
                table: "hierarchies",
                column: "RankId",
                principalTable: "ranks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_licenses_agents_AgentId",
                table: "licenses",
                column: "AgentId",
                principalTable: "agents",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_t_client_agents_REF_ID",
                table: "t_client",
                column: "REF_ID",
                principalTable: "agents",
                principalColumn: "AgentCode",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_t_client_address_t_client_CLIENT_CODE",
                table: "t_client_address",
                column: "CLIENT_CODE",
                principalTable: "t_client",
                principalColumn: "CLIENT_CODE",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_t_client_contact_t_client_CLIENT_CODE",
                table: "t_client_contact",
                column: "CLIENT_CODE",
                principalTable: "t_client",
                principalColumn: "CLIENT_CODE",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_t_client_role_t_client_CLIENT_CODE",
                table: "t_client_role",
                column: "CLIENT_CODE",
                principalTable: "t_client",
                principalColumn: "CLIENT_CODE",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_t_image_t_client_REF_ID",
                table: "t_image",
                column: "REF_ID",
                principalTable: "t_client",
                principalColumn: "CLIENT_CODE",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_agents_agents_ParentAgentId",
                table: "agents");

            migrationBuilder.DropForeignKey(
                name: "FK_agents_hierarchies_HierarchyId",
                table: "agents");

            migrationBuilder.DropForeignKey(
                name: "FK_agents_ranks_RankId",
                table: "agents");

            migrationBuilder.DropForeignKey(
                name: "FK_hierarchies_ranks_RankId",
                table: "hierarchies");

            migrationBuilder.DropForeignKey(
                name: "FK_licenses_agents_AgentId",
                table: "licenses");

            migrationBuilder.DropForeignKey(
                name: "FK_t_client_agents_REF_ID",
                table: "t_client");

            migrationBuilder.DropForeignKey(
                name: "FK_t_client_address_t_client_CLIENT_CODE",
                table: "t_client_address");

            migrationBuilder.DropForeignKey(
                name: "FK_t_client_contact_t_client_CLIENT_CODE",
                table: "t_client_contact");

            migrationBuilder.DropForeignKey(
                name: "FK_t_client_role_t_client_CLIENT_CODE",
                table: "t_client_role");

            migrationBuilder.DropForeignKey(
                name: "FK_t_image_t_client_REF_ID",
                table: "t_image");

            migrationBuilder.DropPrimaryKey(
                name: "PK_t_image",
                table: "t_image");

            migrationBuilder.DropPrimaryKey(
                name: "PK_t_client_role",
                table: "t_client_role");

            migrationBuilder.DropPrimaryKey(
                name: "PK_t_client_contact",
                table: "t_client_contact");

            migrationBuilder.DropPrimaryKey(
                name: "PK_t_client_address",
                table: "t_client_address");

            migrationBuilder.DropUniqueConstraint(
                name: "AK_t_client_CLIENT_CODE",
                table: "t_client");

            migrationBuilder.DropPrimaryKey(
                name: "PK_t_client",
                table: "t_client");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ranks",
                table: "ranks");

            migrationBuilder.DropPrimaryKey(
                name: "PK_licenses",
                table: "licenses");

            migrationBuilder.DropPrimaryKey(
                name: "PK_hierarchies",
                table: "hierarchies");

            migrationBuilder.DropUniqueConstraint(
                name: "AK_agents_AgentCode",
                table: "agents");

            migrationBuilder.DropPrimaryKey(
                name: "PK_agents",
                table: "agents");

            migrationBuilder.RenameTable(
                name: "t_image",
                newName: "T_IMAGE");

            migrationBuilder.RenameTable(
                name: "t_client_role",
                newName: "T_CLIENT_ROLE");

            migrationBuilder.RenameTable(
                name: "t_client_contact",
                newName: "T_CLIENT_CONTACT");

            migrationBuilder.RenameTable(
                name: "t_client_address",
                newName: "T_CLIENT_ADDRESS");

            migrationBuilder.RenameTable(
                name: "t_client",
                newName: "T_CLIENT");

            migrationBuilder.RenameTable(
                name: "ranks",
                newName: "Ranks");

            migrationBuilder.RenameTable(
                name: "licenses",
                newName: "Licenses");

            migrationBuilder.RenameTable(
                name: "hierarchies",
                newName: "Hierarchies");

            migrationBuilder.RenameTable(
                name: "agents",
                newName: "Agents");

            migrationBuilder.RenameIndex(
                name: "IX_t_image_UUID",
                table: "T_IMAGE",
                newName: "IX_T_IMAGE_UUID");

            migrationBuilder.RenameIndex(
                name: "IX_t_image_REF_ID",
                table: "T_IMAGE",
                newName: "IX_T_IMAGE_REF_ID");

            migrationBuilder.RenameIndex(
                name: "IX_t_image_IMAGE_CODE",
                table: "T_IMAGE",
                newName: "IX_T_IMAGE_IMAGE_CODE");

            migrationBuilder.RenameIndex(
                name: "IX_t_client_role_UUID",
                table: "T_CLIENT_ROLE",
                newName: "IX_T_CLIENT_ROLE_UUID");

            migrationBuilder.RenameIndex(
                name: "IX_t_client_role_CLIENT_CODE",
                table: "T_CLIENT_ROLE",
                newName: "IX_T_CLIENT_ROLE_CLIENT_CODE");

            migrationBuilder.RenameIndex(
                name: "IX_t_client_contact_UUID",
                table: "T_CLIENT_CONTACT",
                newName: "IX_T_CLIENT_CONTACT_UUID");

            migrationBuilder.RenameIndex(
                name: "IX_t_client_contact_CLIENT_CODE",
                table: "T_CLIENT_CONTACT",
                newName: "IX_T_CLIENT_CONTACT_CLIENT_CODE");

            migrationBuilder.RenameIndex(
                name: "IX_t_client_address_UUID",
                table: "T_CLIENT_ADDRESS",
                newName: "IX_T_CLIENT_ADDRESS_UUID");

            migrationBuilder.RenameIndex(
                name: "IX_t_client_address_CLIENT_CODE",
                table: "T_CLIENT_ADDRESS",
                newName: "IX_T_CLIENT_ADDRESS_CLIENT_CODE");

            migrationBuilder.RenameIndex(
                name: "IX_t_client_UUID",
                table: "T_CLIENT",
                newName: "IX_T_CLIENT_UUID");

            migrationBuilder.RenameIndex(
                name: "IX_t_client_REF_ID",
                table: "T_CLIENT",
                newName: "IX_T_CLIENT_REF_ID");

            migrationBuilder.RenameIndex(
                name: "IX_t_client_CLIENT_CODE",
                table: "T_CLIENT",
                newName: "IX_T_CLIENT_CLIENT_CODE");

            migrationBuilder.RenameIndex(
                name: "IX_ranks_RankCode",
                table: "Ranks",
                newName: "IX_Ranks_RankCode");

            migrationBuilder.RenameIndex(
                name: "IX_licenses_LicenseNumber",
                table: "Licenses",
                newName: "IX_Licenses_LicenseNumber");

            migrationBuilder.RenameIndex(
                name: "IX_licenses_AgentId",
                table: "Licenses",
                newName: "IX_Licenses_AgentId");

            migrationBuilder.RenameIndex(
                name: "IX_hierarchies_RankId",
                table: "Hierarchies",
                newName: "IX_Hierarchies_RankId");

            migrationBuilder.RenameIndex(
                name: "IX_hierarchies_HierarchyCode",
                table: "Hierarchies",
                newName: "IX_Hierarchies_HierarchyCode");

            migrationBuilder.RenameIndex(
                name: "IX_agents_RankId",
                table: "Agents",
                newName: "IX_Agents_RankId");

            migrationBuilder.RenameIndex(
                name: "IX_agents_ParentAgentId",
                table: "Agents",
                newName: "IX_Agents_ParentAgentId");

            migrationBuilder.RenameIndex(
                name: "IX_agents_HierarchyId",
                table: "Agents",
                newName: "IX_Agents_HierarchyId");

            migrationBuilder.RenameIndex(
                name: "IX_agents_AgentType",
                table: "Agents",
                newName: "IX_Agents_AgentType");

            migrationBuilder.RenameIndex(
                name: "IX_agents_AgentCode",
                table: "Agents",
                newName: "IX_Agents_AgentCode");

            migrationBuilder.AddPrimaryKey(
                name: "PK_T_IMAGE",
                table: "T_IMAGE",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_T_CLIENT_ROLE",
                table: "T_CLIENT_ROLE",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_T_CLIENT_CONTACT",
                table: "T_CLIENT_CONTACT",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_T_CLIENT_ADDRESS",
                table: "T_CLIENT_ADDRESS",
                column: "ID");

            migrationBuilder.AddUniqueConstraint(
                name: "AK_T_CLIENT_CLIENT_CODE",
                table: "T_CLIENT",
                column: "CLIENT_CODE");

            migrationBuilder.AddPrimaryKey(
                name: "PK_T_CLIENT",
                table: "T_CLIENT",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Ranks",
                table: "Ranks",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Licenses",
                table: "Licenses",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Hierarchies",
                table: "Hierarchies",
                column: "Id");

            migrationBuilder.AddUniqueConstraint(
                name: "AK_Agents_AgentCode",
                table: "Agents",
                column: "AgentCode");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Agents",
                table: "Agents",
                column: "Id");

            migrationBuilder.UpdateData(
                table: "Agents",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2025, 11, 13, 5, 1, 29, 168, DateTimeKind.Utc).AddTicks(8314), new DateTime(2025, 11, 13, 5, 1, 29, 168, DateTimeKind.Utc).AddTicks(8314) });

            migrationBuilder.UpdateData(
                table: "Agents",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2025, 11, 13, 5, 1, 29, 168, DateTimeKind.Utc).AddTicks(8314), new DateTime(2025, 11, 13, 5, 1, 29, 168, DateTimeKind.Utc).AddTicks(8314) });

            migrationBuilder.UpdateData(
                table: "Agents",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2025, 11, 13, 5, 1, 29, 168, DateTimeKind.Utc).AddTicks(8314), new DateTime(2025, 11, 13, 5, 1, 29, 168, DateTimeKind.Utc).AddTicks(8314) });

            migrationBuilder.UpdateData(
                table: "Agents",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2025, 11, 13, 5, 1, 29, 168, DateTimeKind.Utc).AddTicks(8314), new DateTime(2025, 11, 13, 5, 1, 29, 168, DateTimeKind.Utc).AddTicks(8314) });

            migrationBuilder.UpdateData(
                table: "Agents",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2025, 11, 13, 5, 1, 29, 168, DateTimeKind.Utc).AddTicks(8314), new DateTime(2025, 11, 13, 5, 1, 29, 168, DateTimeKind.Utc).AddTicks(8314) });

            migrationBuilder.UpdateData(
                table: "Agents",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2025, 11, 13, 5, 1, 29, 168, DateTimeKind.Utc).AddTicks(8314), new DateTime(2025, 11, 13, 5, 1, 29, 168, DateTimeKind.Utc).AddTicks(8314) });

            migrationBuilder.UpdateData(
                table: "Agents",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2025, 11, 13, 5, 1, 29, 168, DateTimeKind.Utc).AddTicks(8314), new DateTime(2025, 11, 13, 5, 1, 29, 168, DateTimeKind.Utc).AddTicks(8314) });

            migrationBuilder.UpdateData(
                table: "Agents",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2025, 11, 13, 5, 1, 29, 168, DateTimeKind.Utc).AddTicks(8314), new DateTime(2025, 11, 13, 5, 1, 29, 168, DateTimeKind.Utc).AddTicks(8314) });

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

            migrationBuilder.AddForeignKey(
                name: "FK_Agents_Agents_ParentAgentId",
                table: "Agents",
                column: "ParentAgentId",
                principalTable: "Agents",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Agents_Hierarchies_HierarchyId",
                table: "Agents",
                column: "HierarchyId",
                principalTable: "Hierarchies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Agents_Ranks_RankId",
                table: "Agents",
                column: "RankId",
                principalTable: "Ranks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Hierarchies_Ranks_RankId",
                table: "Hierarchies",
                column: "RankId",
                principalTable: "Ranks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Licenses_Agents_AgentId",
                table: "Licenses",
                column: "AgentId",
                principalTable: "Agents",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_T_CLIENT_Agents_REF_ID",
                table: "T_CLIENT",
                column: "REF_ID",
                principalTable: "Agents",
                principalColumn: "AgentCode",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_T_CLIENT_ADDRESS_T_CLIENT_CLIENT_CODE",
                table: "T_CLIENT_ADDRESS",
                column: "CLIENT_CODE",
                principalTable: "T_CLIENT",
                principalColumn: "CLIENT_CODE",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_T_CLIENT_CONTACT_T_CLIENT_CLIENT_CODE",
                table: "T_CLIENT_CONTACT",
                column: "CLIENT_CODE",
                principalTable: "T_CLIENT",
                principalColumn: "CLIENT_CODE",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_T_CLIENT_ROLE_T_CLIENT_CLIENT_CODE",
                table: "T_CLIENT_ROLE",
                column: "CLIENT_CODE",
                principalTable: "T_CLIENT",
                principalColumn: "CLIENT_CODE",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_T_IMAGE_T_CLIENT_REF_ID",
                table: "T_IMAGE",
                column: "REF_ID",
                principalTable: "T_CLIENT",
                principalColumn: "CLIENT_CODE",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
