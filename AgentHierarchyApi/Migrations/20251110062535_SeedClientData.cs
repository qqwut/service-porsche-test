using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AgentHierarchyApi.Migrations
{
    public partial class SeedClientData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.InsertData(
                table: "T_CLIENT",
                columns: new[] { "ID", "CLIENT_CODE", "CLIENT_TYPE_CODE", "CREATED_BY", "CREATED_DATE", "DATE_OF_BIRTH", "EDUCATION_LEVEL_CODE", "FIRST_NAME", "FIRST_NAME_EN", "GENDER_CODE", "IDENTITY_EXPIRY_DATE", "IDENTITY_NO", "IDENTITY_PERMANENT", "IDENTITY_TYPE", "IS_ACTIVE", "LANGUAGE_PREFERENCE_CODE", "LAST_NAME", "LAST_NAME_EN", "MARITAL_STATUS_CODE", "MIDDLE_NAME", "MIDDLE_NAME_EN", "NATIONALITY_CODE", "ORGANIZATION_BUSINESS_TYPE", "ORGANIZATION_NAME", "ORGANIZATION_NAME_EN", "ORGANIZATION_REGISTRATION_DATE", "PLACE_OF_BIRTH_CITY", "PLACE_OF_BIRTH_COUNTRY_CODE", "PREMIUM_CAPACITY", "PRIMARY_INCOME_LEVEL_CODE", "PRIMARY_INCOME_PER_YEAR", "PRIMARY_OCCUPATION_BUSINESS_TYPE", "PRIMARY_OCCUPATION_CODE", "PRIMARY_OCCUPATION_ORGANIZATION_NAME", "PRIMARY_OCCUPATION_POSITION_CODE", "RECEIVES_EMAIL_NEWS", "REF_ID", "RELIGION_CODE", "REMARK", "SECONDARY_INCOME_LEVEL_CODE", "SECONDARY_INCOME_PER_YEAR", "SECONDARY_OCCUPATION_BUSINESS_TYPE", "SECONDARY_OCCUPATION_CODE", "SECONDARY_OCCUPATION_ORGANIZATION_NAME", "SECONDARY_OCCUPATION_POSITION_CODE", "SUFFIX_NAME", "SUFFIX_NAME_EN", "TAX_ID", "TERMINATED_DATE", "TERMINATED_FLAG", "TERMINATED_REASON", "TITLE_CODE", "UPDATED_BY", "UPDATED_DATE", "UUID" },
                values: new object[,]
                {
                    { 1, "CLI0001", "INDIVIDUAL", null, new DateTime(2025, 11, 10, 6, 25, 34, 784, DateTimeKind.Utc).AddTicks(885), new DateTime(1985, 5, 15, 0, 0, 0, 0, DateTimeKind.Utc), null, "สมชาย", "Somchai", "M", null, null, null, "NATIONAL_ID", true, "TH", "ใจดี", "Jaidee", "MARRIED", null, null, "THA", null, null, null, null, null, null, 50000.00m, null, null, "TRADING", null, "ABC Trading Co., Ltd.", null, null, "AG0001", null, null, null, null, null, null, null, null, null, null, null, null, null, null, "MR", null, new DateTime(2025, 11, 10, 6, 25, 34, 784, DateTimeKind.Utc).AddTicks(885), new Guid("362473d6-f9a8-48f8-a23f-29159c20b642") },
                    { 2, "CLI0002", "INDIVIDUAL", null, new DateTime(2025, 11, 10, 6, 25, 34, 784, DateTimeKind.Utc).AddTicks(885), new DateTime(1990, 8, 20, 0, 0, 0, 0, DateTimeKind.Utc), null, "สมหญิง", "Somying", "F", null, null, null, "NATIONAL_ID", true, "TH", "รักดี", "Rakdee", "SINGLE", null, null, "THA", null, null, null, null, null, null, 75000.00m, null, null, "GOVERNMENT", null, "Ministry of Finance", null, null, "AG0001", null, null, null, null, null, null, null, null, null, null, null, null, null, null, "MRS", null, new DateTime(2025, 11, 10, 6, 25, 34, 784, DateTimeKind.Utc).AddTicks(885), new Guid("82e10ce0-cfb1-4954-a7a6-5f09bc757a5c") },
                    { 3, "CLI0003", "ORGANIZATION", null, new DateTime(2025, 11, 10, 6, 25, 34, 784, DateTimeKind.Utc).AddTicks(885), null, null, null, null, null, null, null, null, "TAX_ID", true, "TH", null, null, null, null, null, "THA", "INSURANCE", "บริษัท ไทยประกันภัย จำกัด", "Thai Insurance Company Limited", new DateTime(2010, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), null, null, 5000000.00m, null, null, null, null, null, null, null, "AE0001", null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, new DateTime(2025, 11, 10, 6, 25, 34, 784, DateTimeKind.Utc).AddTicks(885), new Guid("c594c291-a721-4ac8-904e-7c533fc53793") },
                    { 4, "CLI0004", "INDIVIDUAL", null, new DateTime(2025, 11, 10, 6, 25, 34, 784, DateTimeKind.Utc).AddTicks(885), new DateTime(1975, 3, 10, 0, 0, 0, 0, DateTimeKind.Utc), null, "John", "John", "M", null, null, null, "PASSPORT", true, "EN", "Smith", "Smith", "MARRIED", null, null, "USA", null, null, null, null, "New York", "USA", 200000.00m, null, null, "TECHNOLOGY", null, "Tech Global Inc.", null, null, "AE0001", null, null, null, null, null, null, null, null, null, null, null, null, null, null, "MR", null, new DateTime(2025, 11, 10, 6, 25, 34, 784, DateTimeKind.Utc).AddTicks(885), new Guid("b5cc999d-fc3a-4ee3-809b-3f0cd8c80d4e") }
                });

            migrationBuilder.InsertData(
                table: "T_CLIENT_ADDRESS",
                columns: new[] { "ID", "ADDRESS_ALLEY", "ADDRESS_DETAIL", "ADDRESS_MOO", "ADDRESS_NO", "ADDRESS_ROAD", "ADDRESS_TYPE_CODE", "ADDRESS_VILLAGE_BUILDING", "ADDRESS_WORKPLACE_NAME", "CLIENT_CODE", "COUNTRY_CODE", "CREATED_BY", "CREATED_DATE", "DISTRICT_CODE", "IS_PRIMARY", "POSTAL_CODE", "PROVINCE_CODE", "REMARK", "SUBDISTRICT_CODE", "UPDATED_BY", "UPDATED_DATE", "UUID" },
                values: new object[,]
                {
                    { 1, null, "ซอยลาดพร้าว 101", "5", "123/45", "ลาดพร้าว", "HOME", null, null, "CLI0001", "THA", null, new DateTime(2025, 11, 10, 6, 25, 34, 784, DateTimeKind.Utc).AddTicks(885), "1001", true, "10230", "10", null, "100101", null, new DateTime(2025, 11, 10, 6, 25, 34, 784, DateTimeKind.Utc).AddTicks(885), new Guid("499e9a32-413e-4b69-9fbd-a7ca89e59e3f") },
                    { 2, null, null, null, "567/89", "พระราม 9", "HOME", "หมู่บ้านสุขใจ", null, "CLI0002", "THA", null, new DateTime(2025, 11, 10, 6, 25, 34, 784, DateTimeKind.Utc).AddTicks(885), "1001", true, "10250", "10", null, "100102", null, new DateTime(2025, 11, 10, 6, 25, 34, 784, DateTimeKind.Utc).AddTicks(885), new Guid("b3146a79-9e21-4c5f-ba2c-2a1292395d91") },
                    { 3, null, null, null, "999", "สาทร", "OFFICE", "อาคารไทยประกัน ทาวเวอร์", null, "CLI0003", "THA", null, new DateTime(2025, 11, 10, 6, 25, 34, 784, DateTimeKind.Utc).AddTicks(885), "1002", true, "10120", "10", null, "100201", null, new DateTime(2025, 11, 10, 6, 25, 34, 784, DateTimeKind.Utc).AddTicks(885), new Guid("98c7ada3-86ba-4282-8072-e6bce45c5483") },
                    { 4, null, null, null, "88/12", "Sukhumvit", "HOME", "Luxury Condo", null, "CLI0004", "THA", null, new DateTime(2025, 11, 10, 6, 25, 34, 784, DateTimeKind.Utc).AddTicks(885), "1003", true, "10110", "10", null, "100301", null, new DateTime(2025, 11, 10, 6, 25, 34, 784, DateTimeKind.Utc).AddTicks(885), new Guid("2e45818a-f559-4115-8d67-874194e19130") }
                });

            migrationBuilder.InsertData(
                table: "T_CLIENT_CONTACT",
                columns: new[] { "ID", "CLIENT_CODE", "CONTACT_TYPE_CODE", "CONTACT_VALUE", "CREATED_BY", "CREATED_DATE", "IS_PRIMARY", "REMARK", "UPDATED_BY", "UPDATED_DATE", "UUID" },
                values: new object[,]
                {
                    { 1, "CLI0001", "MOBILE", "081-234-5678", "System", new DateTime(2025, 11, 10, 6, 25, 34, 784, DateTimeKind.Utc).AddTicks(885), true, null, "System", new DateTime(2025, 11, 10, 6, 25, 34, 784, DateTimeKind.Utc).AddTicks(885), new Guid("3bcca546-5f2e-43ac-bd07-9b4c646ad1d2") },
                    { 2, "CLI0001", "EMAIL", "somchai.j@email.com", "System", new DateTime(2025, 11, 10, 6, 25, 34, 784, DateTimeKind.Utc).AddTicks(885), false, null, "System", new DateTime(2025, 11, 10, 6, 25, 34, 784, DateTimeKind.Utc).AddTicks(885), new Guid("b43d9bf0-1fcd-407e-bfc1-52c504c580e0") },
                    { 3, "CLI0002", "MOBILE", "082-345-6789", "System", new DateTime(2025, 11, 10, 6, 25, 34, 784, DateTimeKind.Utc).AddTicks(885), true, null, "System", new DateTime(2025, 11, 10, 6, 25, 34, 784, DateTimeKind.Utc).AddTicks(885), new Guid("bd3f0b2c-04d2-410c-8136-1013149a819c") },
                    { 4, "CLI0002", "EMAIL", "somying.r@email.com", "System", new DateTime(2025, 11, 10, 6, 25, 34, 784, DateTimeKind.Utc).AddTicks(885), false, null, "System", new DateTime(2025, 11, 10, 6, 25, 34, 784, DateTimeKind.Utc).AddTicks(885), new Guid("bd6b8f84-e1c7-4dca-8813-629f3b44fe53") },
                    { 5, "CLI0003", "OFFICE_PHONE", "02-123-4567", "System", new DateTime(2025, 11, 10, 6, 25, 34, 784, DateTimeKind.Utc).AddTicks(885), true, null, "System", new DateTime(2025, 11, 10, 6, 25, 34, 784, DateTimeKind.Utc).AddTicks(885), new Guid("d6b1ecde-e59c-477c-b917-f55e51b950a6") },
                    { 6, "CLI0003", "EMAIL", "info@thaiinsurance.com", "System", new DateTime(2025, 11, 10, 6, 25, 34, 784, DateTimeKind.Utc).AddTicks(885), false, null, "System", new DateTime(2025, 11, 10, 6, 25, 34, 784, DateTimeKind.Utc).AddTicks(885), new Guid("f5295da3-f4fb-4c4f-ba4c-5d9196e56b27") },
                    { 7, "CLI0004", "MOBILE", "+1-555-1234", "System", new DateTime(2025, 11, 10, 6, 25, 34, 784, DateTimeKind.Utc).AddTicks(885), true, null, "System", new DateTime(2025, 11, 10, 6, 25, 34, 784, DateTimeKind.Utc).AddTicks(885), new Guid("f20ee3fe-027f-40d1-ac66-0c3d7d0e232a") },
                    { 8, "CLI0004", "EMAIL", "john.smith@techglobal.com", "System", new DateTime(2025, 11, 10, 6, 25, 34, 784, DateTimeKind.Utc).AddTicks(885), false, null, "System", new DateTime(2025, 11, 10, 6, 25, 34, 784, DateTimeKind.Utc).AddTicks(885), new Guid("214217f9-f592-4df6-a9c1-ac001c7e9018") }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "T_CLIENT_ADDRESS",
                keyColumn: "ID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "T_CLIENT_ADDRESS",
                keyColumn: "ID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "T_CLIENT_ADDRESS",
                keyColumn: "ID",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "T_CLIENT_ADDRESS",
                keyColumn: "ID",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "T_CLIENT_CONTACT",
                keyColumn: "ID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "T_CLIENT_CONTACT",
                keyColumn: "ID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "T_CLIENT_CONTACT",
                keyColumn: "ID",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "T_CLIENT_CONTACT",
                keyColumn: "ID",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "T_CLIENT_CONTACT",
                keyColumn: "ID",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "T_CLIENT_CONTACT",
                keyColumn: "ID",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "T_CLIENT_CONTACT",
                keyColumn: "ID",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "T_CLIENT_CONTACT",
                keyColumn: "ID",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "T_CLIENT",
                keyColumn: "ID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "T_CLIENT",
                keyColumn: "ID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "T_CLIENT",
                keyColumn: "ID",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "T_CLIENT",
                keyColumn: "ID",
                keyValue: 4);

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
        }
    }
}
