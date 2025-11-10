using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AgentHierarchyApi.Migrations
{
    public partial class SeedClientRoleAndImageData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.InsertData(
                table: "T_CLIENT_ROLE",
                columns: new[] { "ID", "CLIENT_CODE", "CREATED_BY", "CREATED_DATE", "EFFECTIVE_DATE", "EXPIRY_DATE", "IS_ACTIVE", "POLICY_NO", "REFERENCE_NO", "REMARK", "ROLE_CODE", "ROLE_SEQ_NO", "UPDATED_BY", "UPDATED_DATE", "UUID" },
                values: new object[,]
                {
                    { 1, "CLI0001", "System", new DateTime(2025, 11, 10, 6, 53, 12, 276, DateTimeKind.Utc).AddTicks(5899), new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), true, "POL001-2025", "POL-2025-001", "Life Insurance Policy Owner", "POLICY_OWNER", 1, "System", new DateTime(2025, 11, 10, 6, 53, 12, 276, DateTimeKind.Utc).AddTicks(5899), new Guid("d82c86c7-6632-4a3e-8e85-b66e444c5a7e") },
                    { 2, "CLI0001", "System", new DateTime(2025, 11, 10, 6, 53, 12, 276, DateTimeKind.Utc).AddTicks(5899), new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), true, "POL001-2025", "POL-2025-001", "Insured Person", "INSURED", 1, "System", new DateTime(2025, 11, 10, 6, 53, 12, 276, DateTimeKind.Utc).AddTicks(5899), new Guid("15e60968-f8a7-41aa-a248-dbd84613d589") },
                    { 3, "CLI0002", "System", new DateTime(2025, 11, 10, 6, 53, 12, 276, DateTimeKind.Utc).AddTicks(5899), new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), true, "POL001-2025", "POL-2025-001", "Primary Beneficiary - Spouse", "BENEFICIARY", 1, "System", new DateTime(2025, 11, 10, 6, 53, 12, 276, DateTimeKind.Utc).AddTicks(5899), new Guid("7e240e2d-2dff-4862-9784-59b568a71d32") },
                    { 4, "CLI0003", "System", new DateTime(2025, 11, 10, 6, 53, 12, 276, DateTimeKind.Utc).AddTicks(5899), new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), true, "CORP001-2025", "CORP-2025-001", "Corporate Insurance Client", "CORPORATE_CLIENT", 1, "System", new DateTime(2025, 11, 10, 6, 53, 12, 276, DateTimeKind.Utc).AddTicks(5899), new Guid("426645e0-f584-45d3-beaf-7136dffdd71a") },
                    { 5, "CLI0004", "System", new DateTime(2025, 11, 10, 6, 53, 12, 276, DateTimeKind.Utc).AddTicks(5899), new DateTime(2025, 2, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2026, 2, 1, 0, 0, 0, 0, DateTimeKind.Utc), true, "POL002-2025", "POL-2025-002", "Expatriate Policy Owner", "POLICY_OWNER", 1, "System", new DateTime(2025, 11, 10, 6, 53, 12, 276, DateTimeKind.Utc).AddTicks(5899), new Guid("b7bb5fcd-1ba9-40ad-b8bd-39bded9b11f8") }
                });

            migrationBuilder.InsertData(
                table: "T_IMAGE",
                columns: new[] { "ID", "CONTENT_TYPE", "CREATED_BY", "CREATED_DATE", "DISPLAY_ORDER", "FILE_NAME", "FILE_PATH", "FILE_SIZE", "FILE_URL", "HEIGHT", "IMAGE_CATEGORY", "IMAGE_CODE", "IMAGE_DATA", "IMAGE_TYPE_CODE", "IS_ACTIVE", "IS_PRIMARY", "REF_ID", "REMARK", "THUMBNAIL_DATA", "THUMBNAIL_URL", "UPDATED_BY", "UPDATED_DATE", "UUID", "WIDTH" },
                values: new object[,]
                {
                    { 1, "image/jpeg", "System", new DateTime(2025, 11, 10, 6, 53, 12, 276, DateTimeKind.Utc).AddTicks(5899), 1, "somchai_profile.jpg", null, 70L, null, 600, "PERSONAL", "IMG0001", new byte[] { 137, 80, 78, 71, 13, 10, 26, 10, 0, 0, 0, 13, 73, 72, 68, 82, 0, 0, 0, 1, 0, 0, 0, 1, 8, 6, 0, 0, 0, 31, 21, 196, 137, 0, 0, 0, 13, 73, 68, 65, 84, 120, 218, 99, 252, 255, 159, 161, 30, 0, 7, 130, 2, 127, 61, 200, 72, 239, 0, 0, 0, 0, 73, 69, 78, 68, 174, 66, 96, 130 }, "PROFILE", true, true, "CLI0001", "Profile picture", new byte[] { 137, 80, 78, 71, 13, 10, 26, 10, 0, 0, 0, 13, 73, 72, 68, 82, 0, 0, 0, 1, 0, 0, 0, 1, 8, 6, 0, 0, 0, 31, 21, 196, 137, 0, 0, 0, 13, 73, 68, 65, 84, 120, 218, 99, 100, 248, 207, 80, 15, 0, 3, 134, 1, 128, 90, 52, 125, 107, 0, 0, 0, 0, 73, 69, 78, 68, 174, 66, 96, 130 }, null, "System", new DateTime(2025, 11, 10, 6, 53, 12, 276, DateTimeKind.Utc).AddTicks(5899), new Guid("11111111-1111-1111-1111-111111111111"), 800 },
                    { 2, "image/jpeg", "System", new DateTime(2025, 11, 10, 6, 53, 12, 276, DateTimeKind.Utc).AddTicks(5899), 2, "somchai_idcard.jpg", null, 70L, null, 768, "DOCUMENT", "IMG0002", new byte[] { 137, 80, 78, 71, 13, 10, 26, 10, 0, 0, 0, 13, 73, 72, 68, 82, 0, 0, 0, 1, 0, 0, 0, 1, 8, 6, 0, 0, 0, 31, 21, 196, 137, 0, 0, 0, 13, 73, 68, 65, 84, 120, 218, 99, 252, 255, 159, 161, 30, 0, 7, 130, 2, 127, 61, 200, 72, 239, 0, 0, 0, 0, 73, 69, 78, 68, 174, 66, 96, 130 }, "ID_CARD", true, false, "CLI0001", "National ID Card", new byte[] { 137, 80, 78, 71, 13, 10, 26, 10, 0, 0, 0, 13, 73, 72, 68, 82, 0, 0, 0, 1, 0, 0, 0, 1, 8, 6, 0, 0, 0, 31, 21, 196, 137, 0, 0, 0, 13, 73, 68, 65, 84, 120, 218, 99, 100, 248, 207, 80, 15, 0, 3, 134, 1, 128, 90, 52, 125, 107, 0, 0, 0, 0, 73, 69, 78, 68, 174, 66, 96, 130 }, null, "System", new DateTime(2025, 11, 10, 6, 53, 12, 276, DateTimeKind.Utc).AddTicks(5899), new Guid("22222222-2222-2222-2222-222222222222"), 1024 },
                    { 3, "image/jpeg", "System", new DateTime(2025, 11, 10, 6, 53, 12, 276, DateTimeKind.Utc).AddTicks(5899), 1, "somying_profile.jpg", null, 70L, null, 600, "PERSONAL", "IMG0003", new byte[] { 137, 80, 78, 71, 13, 10, 26, 10, 0, 0, 0, 13, 73, 72, 68, 82, 0, 0, 0, 1, 0, 0, 0, 1, 8, 6, 0, 0, 0, 31, 21, 196, 137, 0, 0, 0, 13, 73, 68, 65, 84, 120, 218, 99, 252, 255, 159, 161, 30, 0, 7, 130, 2, 127, 61, 200, 72, 239, 0, 0, 0, 0, 73, 69, 78, 68, 174, 66, 96, 130 }, "PROFILE", true, true, "CLI0002", "Profile picture", new byte[] { 137, 80, 78, 71, 13, 10, 26, 10, 0, 0, 0, 13, 73, 72, 68, 82, 0, 0, 0, 1, 0, 0, 0, 1, 8, 6, 0, 0, 0, 31, 21, 196, 137, 0, 0, 0, 13, 73, 68, 65, 84, 120, 218, 99, 100, 248, 207, 80, 15, 0, 3, 134, 1, 128, 90, 52, 125, 107, 0, 0, 0, 0, 73, 69, 78, 68, 174, 66, 96, 130 }, null, "System", new DateTime(2025, 11, 10, 6, 53, 12, 276, DateTimeKind.Utc).AddTicks(5899), new Guid("33333333-3333-3333-3333-333333333333"), 800 },
                    { 4, "image/png", "System", new DateTime(2025, 11, 10, 6, 53, 12, 276, DateTimeKind.Utc).AddTicks(5899), 1, "thai_insurance_logo.png", null, 70L, null, 400, "CORPORATE", "IMG0004", new byte[] { 137, 80, 78, 71, 13, 10, 26, 10, 0, 0, 0, 13, 73, 72, 68, 82, 0, 0, 0, 1, 0, 0, 0, 1, 8, 6, 0, 0, 0, 31, 21, 196, 137, 0, 0, 0, 13, 73, 68, 65, 84, 120, 218, 99, 252, 255, 159, 161, 30, 0, 7, 130, 2, 127, 61, 200, 72, 239, 0, 0, 0, 0, 73, 69, 78, 68, 174, 66, 96, 130 }, "COMPANY_LOGO", true, true, "CLI0003", "Company Logo", new byte[] { 137, 80, 78, 71, 13, 10, 26, 10, 0, 0, 0, 13, 73, 72, 68, 82, 0, 0, 0, 1, 0, 0, 0, 1, 8, 6, 0, 0, 0, 31, 21, 196, 137, 0, 0, 0, 13, 73, 68, 65, 84, 120, 218, 99, 100, 248, 207, 80, 15, 0, 3, 134, 1, 128, 90, 52, 125, 107, 0, 0, 0, 0, 73, 69, 78, 68, 174, 66, 96, 130 }, null, "System", new DateTime(2025, 11, 10, 6, 53, 12, 276, DateTimeKind.Utc).AddTicks(5899), new Guid("44444444-4444-4444-4444-444444444444"), 400 },
                    { 5, "image/jpeg", "System", new DateTime(2025, 11, 10, 6, 53, 12, 276, DateTimeKind.Utc).AddTicks(5899), 2, "company_registration.pdf.jpg", null, 70L, null, 1600, "DOCUMENT", "IMG0005", new byte[] { 137, 80, 78, 71, 13, 10, 26, 10, 0, 0, 0, 13, 73, 72, 68, 82, 0, 0, 0, 1, 0, 0, 0, 1, 8, 6, 0, 0, 0, 31, 21, 196, 137, 0, 0, 0, 13, 73, 68, 65, 84, 120, 218, 99, 252, 255, 159, 161, 30, 0, 7, 130, 2, 127, 61, 200, 72, 239, 0, 0, 0, 0, 73, 69, 78, 68, 174, 66, 96, 130 }, "REGISTRATION", true, false, "CLI0003", "Company Registration Document", new byte[] { 137, 80, 78, 71, 13, 10, 26, 10, 0, 0, 0, 13, 73, 72, 68, 82, 0, 0, 0, 1, 0, 0, 0, 1, 8, 6, 0, 0, 0, 31, 21, 196, 137, 0, 0, 0, 13, 73, 68, 65, 84, 120, 218, 99, 100, 248, 207, 80, 15, 0, 3, 134, 1, 128, 90, 52, 125, 107, 0, 0, 0, 0, 73, 69, 78, 68, 174, 66, 96, 130 }, null, "System", new DateTime(2025, 11, 10, 6, 53, 12, 276, DateTimeKind.Utc).AddTicks(5899), new Guid("55555555-5555-5555-5555-555555555555"), 1200 },
                    { 6, "image/jpeg", "System", new DateTime(2025, 11, 10, 6, 53, 12, 276, DateTimeKind.Utc).AddTicks(5899), 1, "john_passport.jpg", null, 70L, null, 768, "DOCUMENT", "IMG0006", new byte[] { 137, 80, 78, 71, 13, 10, 26, 10, 0, 0, 0, 13, 73, 72, 68, 82, 0, 0, 0, 1, 0, 0, 0, 1, 8, 6, 0, 0, 0, 31, 21, 196, 137, 0, 0, 0, 13, 73, 68, 65, 84, 120, 218, 99, 252, 255, 159, 161, 30, 0, 7, 130, 2, 127, 61, 200, 72, 239, 0, 0, 0, 0, 73, 69, 78, 68, 174, 66, 96, 130 }, "PASSPORT", true, true, "CLI0004", "Passport Photo Page", new byte[] { 137, 80, 78, 71, 13, 10, 26, 10, 0, 0, 0, 13, 73, 72, 68, 82, 0, 0, 0, 1, 0, 0, 0, 1, 8, 6, 0, 0, 0, 31, 21, 196, 137, 0, 0, 0, 13, 73, 68, 65, 84, 120, 218, 99, 100, 248, 207, 80, 15, 0, 3, 134, 1, 128, 90, 52, 125, 107, 0, 0, 0, 0, 73, 69, 78, 68, 174, 66, 96, 130 }, null, "System", new DateTime(2025, 11, 10, 6, 53, 12, 276, DateTimeKind.Utc).AddTicks(5899), new Guid("66666666-6666-6666-6666-666666666666"), 1024 },
                    { 7, "image/png", "System", new DateTime(2025, 11, 10, 6, 53, 12, 276, DateTimeKind.Utc).AddTicks(5899), 2, "john_signature.png", null, 70L, null, 200, "VERIFICATION", "IMG0007", new byte[] { 137, 80, 78, 71, 13, 10, 26, 10, 0, 0, 0, 13, 73, 72, 68, 82, 0, 0, 0, 1, 0, 0, 0, 1, 8, 6, 0, 0, 0, 31, 21, 196, 137, 0, 0, 0, 13, 73, 68, 65, 84, 120, 218, 99, 252, 255, 159, 161, 30, 0, 7, 130, 2, 127, 61, 200, 72, 239, 0, 0, 0, 0, 73, 69, 78, 68, 174, 66, 96, 130 }, "SIGNATURE", true, false, "CLI0004", "Digital Signature", new byte[] { 137, 80, 78, 71, 13, 10, 26, 10, 0, 0, 0, 13, 73, 72, 68, 82, 0, 0, 0, 1, 0, 0, 0, 1, 8, 6, 0, 0, 0, 31, 21, 196, 137, 0, 0, 0, 13, 73, 68, 65, 84, 120, 218, 99, 100, 248, 207, 80, 15, 0, 3, 134, 1, 128, 90, 52, 125, 107, 0, 0, 0, 0, 73, 69, 78, 68, 174, 66, 96, 130 }, null, "System", new DateTime(2025, 11, 10, 6, 53, 12, 276, DateTimeKind.Utc).AddTicks(5899), new Guid("77777777-7777-7777-7777-777777777777"), 400 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "T_CLIENT_ROLE",
                keyColumn: "ID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "T_CLIENT_ROLE",
                keyColumn: "ID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "T_CLIENT_ROLE",
                keyColumn: "ID",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "T_CLIENT_ROLE",
                keyColumn: "ID",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "T_CLIENT_ROLE",
                keyColumn: "ID",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "T_IMAGE",
                keyColumn: "ID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "T_IMAGE",
                keyColumn: "ID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "T_IMAGE",
                keyColumn: "ID",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "T_IMAGE",
                keyColumn: "ID",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "T_IMAGE",
                keyColumn: "ID",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "T_IMAGE",
                keyColumn: "ID",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "T_IMAGE",
                keyColumn: "ID",
                keyValue: 7);

            migrationBuilder.UpdateData(
                table: "Agents",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2025, 11, 10, 6, 25, 34, 784, DateTimeKind.Utc).AddTicks(885), new DateTime(2025, 11, 10, 6, 25, 34, 784, DateTimeKind.Utc).AddTicks(885) });

            migrationBuilder.UpdateData(
                table: "Agents",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2025, 11, 10, 6, 25, 34, 784, DateTimeKind.Utc).AddTicks(885), new DateTime(2025, 11, 10, 6, 25, 34, 784, DateTimeKind.Utc).AddTicks(885) });

            migrationBuilder.UpdateData(
                table: "Agents",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2025, 11, 10, 6, 25, 34, 784, DateTimeKind.Utc).AddTicks(885), new DateTime(2025, 11, 10, 6, 25, 34, 784, DateTimeKind.Utc).AddTicks(885) });

            migrationBuilder.UpdateData(
                table: "Agents",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2025, 11, 10, 6, 25, 34, 784, DateTimeKind.Utc).AddTicks(885), new DateTime(2025, 11, 10, 6, 25, 34, 784, DateTimeKind.Utc).AddTicks(885) });

            migrationBuilder.UpdateData(
                table: "Agents",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2025, 11, 10, 6, 25, 34, 784, DateTimeKind.Utc).AddTicks(885), new DateTime(2025, 11, 10, 6, 25, 34, 784, DateTimeKind.Utc).AddTicks(885) });

            migrationBuilder.UpdateData(
                table: "Agents",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2025, 11, 10, 6, 25, 34, 784, DateTimeKind.Utc).AddTicks(885), new DateTime(2025, 11, 10, 6, 25, 34, 784, DateTimeKind.Utc).AddTicks(885) });

            migrationBuilder.UpdateData(
                table: "Agents",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2025, 11, 10, 6, 25, 34, 784, DateTimeKind.Utc).AddTicks(885), new DateTime(2025, 11, 10, 6, 25, 34, 784, DateTimeKind.Utc).AddTicks(885) });

            migrationBuilder.UpdateData(
                table: "Agents",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2025, 11, 10, 6, 25, 34, 784, DateTimeKind.Utc).AddTicks(885), new DateTime(2025, 11, 10, 6, 25, 34, 784, DateTimeKind.Utc).AddTicks(885) });

            migrationBuilder.UpdateData(
                table: "T_CLIENT",
                keyColumn: "ID",
                keyValue: 1,
                columns: new[] { "CREATED_DATE", "UPDATED_DATE", "UUID" },
                values: new object[] { new DateTime(2025, 11, 10, 6, 25, 34, 784, DateTimeKind.Utc).AddTicks(885), new DateTime(2025, 11, 10, 6, 25, 34, 784, DateTimeKind.Utc).AddTicks(885), new Guid("362473d6-f9a8-48f8-a23f-29159c20b642") });

            migrationBuilder.UpdateData(
                table: "T_CLIENT",
                keyColumn: "ID",
                keyValue: 2,
                columns: new[] { "CREATED_DATE", "UPDATED_DATE", "UUID" },
                values: new object[] { new DateTime(2025, 11, 10, 6, 25, 34, 784, DateTimeKind.Utc).AddTicks(885), new DateTime(2025, 11, 10, 6, 25, 34, 784, DateTimeKind.Utc).AddTicks(885), new Guid("82e10ce0-cfb1-4954-a7a6-5f09bc757a5c") });

            migrationBuilder.UpdateData(
                table: "T_CLIENT",
                keyColumn: "ID",
                keyValue: 3,
                columns: new[] { "CREATED_DATE", "UPDATED_DATE", "UUID" },
                values: new object[] { new DateTime(2025, 11, 10, 6, 25, 34, 784, DateTimeKind.Utc).AddTicks(885), new DateTime(2025, 11, 10, 6, 25, 34, 784, DateTimeKind.Utc).AddTicks(885), new Guid("c594c291-a721-4ac8-904e-7c533fc53793") });

            migrationBuilder.UpdateData(
                table: "T_CLIENT",
                keyColumn: "ID",
                keyValue: 4,
                columns: new[] { "CREATED_DATE", "UPDATED_DATE", "UUID" },
                values: new object[] { new DateTime(2025, 11, 10, 6, 25, 34, 784, DateTimeKind.Utc).AddTicks(885), new DateTime(2025, 11, 10, 6, 25, 34, 784, DateTimeKind.Utc).AddTicks(885), new Guid("b5cc999d-fc3a-4ee3-809b-3f0cd8c80d4e") });

            migrationBuilder.UpdateData(
                table: "T_CLIENT_ADDRESS",
                keyColumn: "ID",
                keyValue: 1,
                columns: new[] { "CREATED_DATE", "UPDATED_DATE", "UUID" },
                values: new object[] { new DateTime(2025, 11, 10, 6, 25, 34, 784, DateTimeKind.Utc).AddTicks(885), new DateTime(2025, 11, 10, 6, 25, 34, 784, DateTimeKind.Utc).AddTicks(885), new Guid("499e9a32-413e-4b69-9fbd-a7ca89e59e3f") });

            migrationBuilder.UpdateData(
                table: "T_CLIENT_ADDRESS",
                keyColumn: "ID",
                keyValue: 2,
                columns: new[] { "CREATED_DATE", "UPDATED_DATE", "UUID" },
                values: new object[] { new DateTime(2025, 11, 10, 6, 25, 34, 784, DateTimeKind.Utc).AddTicks(885), new DateTime(2025, 11, 10, 6, 25, 34, 784, DateTimeKind.Utc).AddTicks(885), new Guid("b3146a79-9e21-4c5f-ba2c-2a1292395d91") });

            migrationBuilder.UpdateData(
                table: "T_CLIENT_ADDRESS",
                keyColumn: "ID",
                keyValue: 3,
                columns: new[] { "CREATED_DATE", "UPDATED_DATE", "UUID" },
                values: new object[] { new DateTime(2025, 11, 10, 6, 25, 34, 784, DateTimeKind.Utc).AddTicks(885), new DateTime(2025, 11, 10, 6, 25, 34, 784, DateTimeKind.Utc).AddTicks(885), new Guid("98c7ada3-86ba-4282-8072-e6bce45c5483") });

            migrationBuilder.UpdateData(
                table: "T_CLIENT_ADDRESS",
                keyColumn: "ID",
                keyValue: 4,
                columns: new[] { "CREATED_DATE", "UPDATED_DATE", "UUID" },
                values: new object[] { new DateTime(2025, 11, 10, 6, 25, 34, 784, DateTimeKind.Utc).AddTicks(885), new DateTime(2025, 11, 10, 6, 25, 34, 784, DateTimeKind.Utc).AddTicks(885), new Guid("2e45818a-f559-4115-8d67-874194e19130") });

            migrationBuilder.UpdateData(
                table: "T_CLIENT_CONTACT",
                keyColumn: "ID",
                keyValue: 1,
                columns: new[] { "CREATED_DATE", "UPDATED_DATE", "UUID" },
                values: new object[] { new DateTime(2025, 11, 10, 6, 25, 34, 784, DateTimeKind.Utc).AddTicks(885), new DateTime(2025, 11, 10, 6, 25, 34, 784, DateTimeKind.Utc).AddTicks(885), new Guid("3bcca546-5f2e-43ac-bd07-9b4c646ad1d2") });

            migrationBuilder.UpdateData(
                table: "T_CLIENT_CONTACT",
                keyColumn: "ID",
                keyValue: 2,
                columns: new[] { "CREATED_DATE", "UPDATED_DATE", "UUID" },
                values: new object[] { new DateTime(2025, 11, 10, 6, 25, 34, 784, DateTimeKind.Utc).AddTicks(885), new DateTime(2025, 11, 10, 6, 25, 34, 784, DateTimeKind.Utc).AddTicks(885), new Guid("b43d9bf0-1fcd-407e-bfc1-52c504c580e0") });

            migrationBuilder.UpdateData(
                table: "T_CLIENT_CONTACT",
                keyColumn: "ID",
                keyValue: 3,
                columns: new[] { "CREATED_DATE", "UPDATED_DATE", "UUID" },
                values: new object[] { new DateTime(2025, 11, 10, 6, 25, 34, 784, DateTimeKind.Utc).AddTicks(885), new DateTime(2025, 11, 10, 6, 25, 34, 784, DateTimeKind.Utc).AddTicks(885), new Guid("bd3f0b2c-04d2-410c-8136-1013149a819c") });

            migrationBuilder.UpdateData(
                table: "T_CLIENT_CONTACT",
                keyColumn: "ID",
                keyValue: 4,
                columns: new[] { "CREATED_DATE", "UPDATED_DATE", "UUID" },
                values: new object[] { new DateTime(2025, 11, 10, 6, 25, 34, 784, DateTimeKind.Utc).AddTicks(885), new DateTime(2025, 11, 10, 6, 25, 34, 784, DateTimeKind.Utc).AddTicks(885), new Guid("bd6b8f84-e1c7-4dca-8813-629f3b44fe53") });

            migrationBuilder.UpdateData(
                table: "T_CLIENT_CONTACT",
                keyColumn: "ID",
                keyValue: 5,
                columns: new[] { "CREATED_DATE", "UPDATED_DATE", "UUID" },
                values: new object[] { new DateTime(2025, 11, 10, 6, 25, 34, 784, DateTimeKind.Utc).AddTicks(885), new DateTime(2025, 11, 10, 6, 25, 34, 784, DateTimeKind.Utc).AddTicks(885), new Guid("d6b1ecde-e59c-477c-b917-f55e51b950a6") });

            migrationBuilder.UpdateData(
                table: "T_CLIENT_CONTACT",
                keyColumn: "ID",
                keyValue: 6,
                columns: new[] { "CREATED_DATE", "UPDATED_DATE", "UUID" },
                values: new object[] { new DateTime(2025, 11, 10, 6, 25, 34, 784, DateTimeKind.Utc).AddTicks(885), new DateTime(2025, 11, 10, 6, 25, 34, 784, DateTimeKind.Utc).AddTicks(885), new Guid("f5295da3-f4fb-4c4f-ba4c-5d9196e56b27") });

            migrationBuilder.UpdateData(
                table: "T_CLIENT_CONTACT",
                keyColumn: "ID",
                keyValue: 7,
                columns: new[] { "CREATED_DATE", "UPDATED_DATE", "UUID" },
                values: new object[] { new DateTime(2025, 11, 10, 6, 25, 34, 784, DateTimeKind.Utc).AddTicks(885), new DateTime(2025, 11, 10, 6, 25, 34, 784, DateTimeKind.Utc).AddTicks(885), new Guid("f20ee3fe-027f-40d1-ac66-0c3d7d0e232a") });

            migrationBuilder.UpdateData(
                table: "T_CLIENT_CONTACT",
                keyColumn: "ID",
                keyValue: 8,
                columns: new[] { "CREATED_DATE", "UPDATED_DATE", "UUID" },
                values: new object[] { new DateTime(2025, 11, 10, 6, 25, 34, 784, DateTimeKind.Utc).AddTicks(885), new DateTime(2025, 11, 10, 6, 25, 34, 784, DateTimeKind.Utc).AddTicks(885), new Guid("214217f9-f592-4df6-a9c1-ac001c7e9018") });
        }
    }
}
