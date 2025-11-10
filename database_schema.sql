-- ============================================================================
-- Database Schema: Agent Hierarchy Management System
-- Database: PostgreSQL
-- Version: 1.0
-- Created: November 10, 2025
-- Description: Complete database schema with tables, constraints, and indexes
-- ============================================================================

-- ============================================================================
-- DROP EXISTING TABLES (if needed)
-- ============================================================================

-- Drop tables in reverse order of dependencies
DROP TABLE IF EXISTS "T_IMAGE" CASCADE;
DROP TABLE IF EXISTS "T_CLIENT_ROLE" CASCADE;
DROP TABLE IF EXISTS "T_CLIENT_CONTACT" CASCADE;
DROP TABLE IF EXISTS "T_CLIENT_ADDRESS" CASCADE;
DROP TABLE IF EXISTS "T_CLIENT" CASCADE;
DROP TABLE IF EXISTS "T_LICENSE" CASCADE;
DROP TABLE IF EXISTS "T_AGENT" CASCADE;
DROP TABLE IF EXISTS "T_HIERARCHY" CASCADE;
DROP TABLE IF EXISTS "T_RANK" CASCADE;

-- ============================================================================
-- AGENT MODULE TABLES
-- ============================================================================

-- ----------------------------------------------------------------------------
-- Table: T_RANK
-- Purpose: Define agent rank levels (AG, AL, AE)
-- ----------------------------------------------------------------------------
CREATE TABLE "T_RANK" (
    "ID" SERIAL PRIMARY KEY,
    "RANK_CODE" VARCHAR(10) NOT NULL UNIQUE,
    "RANK_NAME" VARCHAR(100) NOT NULL,
    "LEVEL" INTEGER NOT NULL,
    CONSTRAINT "CHK_RANK_LEVEL" CHECK ("LEVEL" BETWEEN 1 AND 3)
);

COMMENT ON TABLE "T_RANK" IS 'Agent rank levels';
COMMENT ON COLUMN "T_RANK"."ID" IS 'Primary key';
COMMENT ON COLUMN "T_RANK"."RANK_CODE" IS 'Rank code: AG, AL, AE';
COMMENT ON COLUMN "T_RANK"."RANK_NAME" IS 'Rank name';
COMMENT ON COLUMN "T_RANK"."LEVEL" IS 'Rank level: 1=AG, 2=AL, 3=AE';

-- ----------------------------------------------------------------------------
-- Table: T_HIERARCHY
-- Purpose: Define agent hierarchy levels (A1-A9)
-- ----------------------------------------------------------------------------
CREATE TABLE "T_HIERARCHY" (
    "ID" SERIAL PRIMARY KEY,
    "HIERARCHY_CODE" VARCHAR(10) NOT NULL UNIQUE,
    "HIERARCHY_NAME" VARCHAR(100) NOT NULL,
    "RANK_ID" INTEGER NOT NULL,
    "LEVEL" INTEGER NOT NULL,
    CONSTRAINT "CHK_HIERARCHY_LEVEL" CHECK ("LEVEL" BETWEEN 1 AND 9),
    CONSTRAINT "FK_HIERARCHY_RANK" FOREIGN KEY ("RANK_ID") 
        REFERENCES "T_RANK"("ID") ON DELETE RESTRICT ON UPDATE CASCADE
);

COMMENT ON TABLE "T_HIERARCHY" IS 'Agent hierarchy levels (A1-A9)';
COMMENT ON COLUMN "T_HIERARCHY"."ID" IS 'Primary key';
COMMENT ON COLUMN "T_HIERARCHY"."HIERARCHY_CODE" IS 'Hierarchy code: A1-A9';
COMMENT ON COLUMN "T_HIERARCHY"."HIERARCHY_NAME" IS 'Hierarchy name';
COMMENT ON COLUMN "T_HIERARCHY"."RANK_ID" IS 'Foreign key to T_RANK';
COMMENT ON COLUMN "T_HIERARCHY"."LEVEL" IS 'Hierarchy level: 1-9';

-- ----------------------------------------------------------------------------
-- Table: T_AGENT
-- Purpose: Agent information with self-referencing hierarchy
-- ----------------------------------------------------------------------------
CREATE TABLE "T_AGENT" (
    "ID" SERIAL PRIMARY KEY,
    "AGENT_CODE" VARCHAR(20) NOT NULL UNIQUE,
    "AGENT_NAME" VARCHAR(200) NOT NULL,
    "HIERARCHY_ID" INTEGER NOT NULL,
    "RANK_ID" INTEGER NOT NULL,
    "PARENT_AGENT_ID" INTEGER NULL,
    "IS_ACTIVE" BOOLEAN NOT NULL DEFAULT TRUE,
    "CREATED_DATE" TIMESTAMP WITH TIME ZONE NOT NULL DEFAULT CURRENT_TIMESTAMP,
    "UPDATED_DATE" TIMESTAMP WITH TIME ZONE NOT NULL DEFAULT CURRENT_TIMESTAMP,
    CONSTRAINT "FK_AGENT_HIERARCHY" FOREIGN KEY ("HIERARCHY_ID") 
        REFERENCES "T_HIERARCHY"("ID") ON DELETE RESTRICT ON UPDATE CASCADE,
    CONSTRAINT "FK_AGENT_RANK" FOREIGN KEY ("RANK_ID") 
        REFERENCES "T_RANK"("ID") ON DELETE RESTRICT ON UPDATE CASCADE,
    CONSTRAINT "FK_AGENT_PARENT" FOREIGN KEY ("PARENT_AGENT_ID") 
        REFERENCES "T_AGENT"("ID") ON DELETE RESTRICT ON UPDATE CASCADE
);

COMMENT ON TABLE "T_AGENT" IS 'Insurance agents with hierarchical structure';
COMMENT ON COLUMN "T_AGENT"."ID" IS 'Primary key';
COMMENT ON COLUMN "T_AGENT"."AGENT_CODE" IS 'Unique agent code';
COMMENT ON COLUMN "T_AGENT"."AGENT_NAME" IS 'Agent name';
COMMENT ON COLUMN "T_AGENT"."HIERARCHY_ID" IS 'Foreign key to T_HIERARCHY';
COMMENT ON COLUMN "T_AGENT"."RANK_ID" IS 'Foreign key to T_RANK';
COMMENT ON COLUMN "T_AGENT"."PARENT_AGENT_ID" IS 'Self-reference to parent agent';
COMMENT ON COLUMN "T_AGENT"."IS_ACTIVE" IS 'Active status';
COMMENT ON COLUMN "T_AGENT"."CREATED_DATE" IS 'Record creation timestamp';
COMMENT ON COLUMN "T_AGENT"."UPDATED_DATE" IS 'Record update timestamp';

-- ----------------------------------------------------------------------------
-- Table: T_LICENSE
-- Purpose: Agent licenses
-- ----------------------------------------------------------------------------
CREATE TABLE "T_LICENSE" (
    "ID" SERIAL PRIMARY KEY,
    "AGENT_ID" INTEGER NOT NULL,
    "LICENSE_NUMBER" VARCHAR(50) NOT NULL UNIQUE,
    "ISSUE_DATE" DATE NOT NULL DEFAULT CURRENT_DATE,
    "EXPIRY_DATE" DATE NULL,
    "IS_ACTIVE" BOOLEAN NOT NULL DEFAULT TRUE,
    "CREATED_DATE" TIMESTAMP WITH TIME ZONE NOT NULL DEFAULT CURRENT_TIMESTAMP,
    "UPDATED_DATE" TIMESTAMP WITH TIME ZONE NOT NULL DEFAULT CURRENT_TIMESTAMP,
    CONSTRAINT "FK_LICENSE_AGENT" FOREIGN KEY ("AGENT_ID") 
        REFERENCES "T_AGENT"("ID") ON DELETE CASCADE ON UPDATE CASCADE
);

COMMENT ON TABLE "T_LICENSE" IS 'Agent license information';
COMMENT ON COLUMN "T_LICENSE"."ID" IS 'Primary key';
COMMENT ON COLUMN "T_LICENSE"."AGENT_ID" IS 'Foreign key to T_AGENT';
COMMENT ON COLUMN "T_LICENSE"."LICENSE_NUMBER" IS 'Unique license number';
COMMENT ON COLUMN "T_LICENSE"."ISSUE_DATE" IS 'License issue date';
COMMENT ON COLUMN "T_LICENSE"."EXPIRY_DATE" IS 'License expiry date';
COMMENT ON COLUMN "T_LICENSE"."IS_ACTIVE" IS 'Active status';
COMMENT ON COLUMN "T_LICENSE"."CREATED_DATE" IS 'Record creation timestamp';
COMMENT ON COLUMN "T_LICENSE"."UPDATED_DATE" IS 'Record update timestamp';

-- ============================================================================
-- CLIENT MODULE TABLES
-- ============================================================================

-- ----------------------------------------------------------------------------
-- Table: T_CLIENT
-- Purpose: Client information (individual or organization)
-- ----------------------------------------------------------------------------
CREATE TABLE "T_CLIENT" (
    "ID" SERIAL PRIMARY KEY,
    "UUID" UUID NOT NULL UNIQUE DEFAULT gen_random_uuid(),
    "CLIENT_CODE" VARCHAR(20) NOT NULL UNIQUE,
    "CLIENT_TYPE_CODE" VARCHAR(20) NULL,
    "IDENTITY_TYPE" VARCHAR(20) NULL,
    "IDENTITY_NO" BYTEA NULL,
    "IDENTITY_PERMANENT" BOOLEAN NULL,
    "IDENTITY_EXPIRY_DATE" DATE NULL,
    "TITLE_CODE" VARCHAR(10) NULL,
    "ORGANIZATION_NAME" VARCHAR(200) NULL,
    "FIRST_NAME" VARCHAR(100) NULL,
    "MIDDLE_NAME" VARCHAR(100) NULL,
    "LAST_NAME" VARCHAR(100) NULL,
    "SUFFIX_NAME" VARCHAR(50) NULL,
    "ORGANIZATION_NAME_EN" VARCHAR(200) NULL,
    "FIRST_NAME_EN" VARCHAR(100) NULL,
    "MIDDLE_NAME_EN" VARCHAR(100) NULL,
    "LAST_NAME_EN" VARCHAR(100) NULL,
    "SUFFIX_NAME_EN" VARCHAR(50) NULL,
    "NATIONALITY_CODE" VARCHAR(3) NULL,
    "PLACE_OF_BIRTH_COUNTRY_CODE" VARCHAR(3) NULL,
    "PLACE_OF_BIRTH_CITY" VARCHAR(100) NULL,
    "ORGANIZATION_REGISTRATION_DATE" DATE NULL,
    "DATE_OF_BIRTH" DATE NULL,
    "GENDER_CODE" VARCHAR(1) NULL,
    "RELIGION_CODE" BYTEA NULL,
    "MARITAL_STATUS_CODE" VARCHAR(10) NULL,
    "EDUCATION_LEVEL_CODE" BYTEA NULL,
    "PRIMARY_OCCUPATION_CODE" BYTEA NULL,
    "PRIMARY_OCCUPATION_POSITION_CODE" BYTEA NULL,
    "PRIMARY_OCCUPATION_BUSINESS_TYPE" VARCHAR(100) NULL,
    "PRIMARY_OCCUPATION_ORGANIZATION_NAME" VARCHAR(200) NULL,
    "PRIMARY_INCOME_LEVEL_CODE" BYTEA NULL,
    "PRIMARY_INCOME_PER_YEAR" BYTEA NULL,
    "SECONDARY_OCCUPATION_CODE" BYTEA NULL,
    "SECONDARY_OCCUPATION_POSITION_CODE" BYTEA NULL,
    "SECONDARY_OCCUPATION_BUSINESS_TYPE" VARCHAR(100) NULL,
    "SECONDARY_OCCUPATION_ORGANIZATION_NAME" VARCHAR(200) NULL,
    "SECONDARY_INCOME_LEVEL_CODE" BYTEA NULL,
    "SECONDARY_INCOME_PER_YEAR" BYTEA NULL,
    "PREMIUM_CAPACITY" DECIMAL(18,2) NULL,
    "LANGUAGE_PREFERENCE_CODE" VARCHAR(10) NULL,
    "RECEIVES_EMAIL_NEWS" VARCHAR(1) NULL,
    "ORGANIZATION_BUSINESS_TYPE" VARCHAR(100) NULL,
    "TAX_ID" BYTEA NULL,
    "TERMINATED_FLAG" BOOLEAN NULL,
    "TERMINATED_DATE" DATE NULL,
    "TERMINATED_REASON" VARCHAR(500) NULL,
    "IS_ACTIVE" BOOLEAN NOT NULL DEFAULT TRUE,
    "REMARK" TEXT NULL,
    "CREATED_DATE" TIMESTAMP WITH TIME ZONE NOT NULL DEFAULT CURRENT_TIMESTAMP,
    "CREATED_BY" VARCHAR(100) NULL,
    "UPDATED_DATE" TIMESTAMP WITH TIME ZONE NOT NULL DEFAULT CURRENT_TIMESTAMP,
    "UPDATED_BY" VARCHAR(100) NULL,
    "REF_ID" VARCHAR(20) NULL,
    CONSTRAINT "FK_CLIENT_AGENT" FOREIGN KEY ("REF_ID") 
        REFERENCES "T_AGENT"("AGENT_CODE") ON DELETE SET NULL ON UPDATE CASCADE,
    CONSTRAINT "CHK_CLIENT_TYPE" CHECK ("CLIENT_TYPE_CODE" IN ('INDIVIDUAL', 'ORGANIZATION') OR "CLIENT_TYPE_CODE" IS NULL),
    CONSTRAINT "CHK_GENDER" CHECK ("GENDER_CODE" IN ('M', 'F', 'O') OR "GENDER_CODE" IS NULL)
);

COMMENT ON TABLE "T_CLIENT" IS 'Client information (individual or organization)';
COMMENT ON COLUMN "T_CLIENT"."ID" IS 'Primary key';
COMMENT ON COLUMN "T_CLIENT"."UUID" IS 'Unique identifier (UUID)';
COMMENT ON COLUMN "T_CLIENT"."CLIENT_CODE" IS 'Unique client code';
COMMENT ON COLUMN "T_CLIENT"."CLIENT_TYPE_CODE" IS 'Client type: INDIVIDUAL, ORGANIZATION';
COMMENT ON COLUMN "T_CLIENT"."FIRST_NAME" IS 'First name (for individuals)';
COMMENT ON COLUMN "T_CLIENT"."LAST_NAME" IS 'Last name (for individuals)';
COMMENT ON COLUMN "T_CLIENT"."ORGANIZATION_NAME" IS 'Organization name (for organizations)';
COMMENT ON COLUMN "T_CLIENT"."DATE_OF_BIRTH" IS 'Date of birth';
COMMENT ON COLUMN "T_CLIENT"."GENDER_CODE" IS 'Gender: M, F, O';
COMMENT ON COLUMN "T_CLIENT"."NATIONALITY_CODE" IS 'Nationality code (ISO 3166-1 alpha-3)';
COMMENT ON COLUMN "T_CLIENT"."REF_ID" IS 'Reference to agent (AGENT_CODE)';
COMMENT ON COLUMN "T_CLIENT"."IS_ACTIVE" IS 'Active status';
COMMENT ON COLUMN "T_CLIENT"."CREATED_DATE" IS 'Record creation timestamp';
COMMENT ON COLUMN "T_CLIENT"."UPDATED_DATE" IS 'Record update timestamp';

-- ----------------------------------------------------------------------------
-- Table: T_CLIENT_ADDRESS
-- Purpose: Client addresses
-- ----------------------------------------------------------------------------
CREATE TABLE "T_CLIENT_ADDRESS" (
    "ID" SERIAL PRIMARY KEY,
    "UUID" UUID NOT NULL UNIQUE DEFAULT gen_random_uuid(),
    "CLIENT_CODE" VARCHAR(20) NOT NULL,
    "ADDRESS_TYPE_CODE" VARCHAR(20) NULL,
    "ADDRESS_WORKPLACE_NAME" VARCHAR(200) NULL,
    "ADDRESS_NO" VARCHAR(50) NULL,
    "ADDRESS_MOO" VARCHAR(10) NULL,
    "ADDRESS_DETAIL" VARCHAR(200) NULL,
    "ADDRESS_VILLAGE_BUILDING" VARCHAR(200) NULL,
    "ADDRESS_ALLEY" VARCHAR(100) NULL,
    "ADDRESS_ROAD" VARCHAR(100) NULL,
    "SUBDISTRICT_CODE" VARCHAR(10) NOT NULL,
    "DISTRICT_CODE" VARCHAR(10) NOT NULL,
    "PROVINCE_CODE" VARCHAR(10) NOT NULL,
    "POSTAL_CODE" VARCHAR(10) NOT NULL,
    "COUNTRY_CODE" VARCHAR(3) NOT NULL DEFAULT 'THA',
    "IS_PRIMARY" BOOLEAN NOT NULL DEFAULT FALSE,
    "REMARK" TEXT NULL,
    "CREATED_DATE" TIMESTAMP WITH TIME ZONE NOT NULL DEFAULT CURRENT_TIMESTAMP,
    "CREATED_BY" VARCHAR(100) NULL,
    "UPDATED_DATE" TIMESTAMP WITH TIME ZONE NOT NULL DEFAULT CURRENT_TIMESTAMP,
    "UPDATED_BY" VARCHAR(100) NULL,
    CONSTRAINT "FK_ADDRESS_CLIENT" FOREIGN KEY ("CLIENT_CODE") 
        REFERENCES "T_CLIENT"("CLIENT_CODE") ON DELETE CASCADE ON UPDATE CASCADE
);

COMMENT ON TABLE "T_CLIENT_ADDRESS" IS 'Client address information';
COMMENT ON COLUMN "T_CLIENT_ADDRESS"."ID" IS 'Primary key';
COMMENT ON COLUMN "T_CLIENT_ADDRESS"."UUID" IS 'Unique identifier (UUID)';
COMMENT ON COLUMN "T_CLIENT_ADDRESS"."CLIENT_CODE" IS 'Foreign key to T_CLIENT';
COMMENT ON COLUMN "T_CLIENT_ADDRESS"."ADDRESS_TYPE_CODE" IS 'Address type: HOME, OFFICE, WORK, SHIPPING, BILLING';
COMMENT ON COLUMN "T_CLIENT_ADDRESS"."ADDRESS_NO" IS 'House/building number';
COMMENT ON COLUMN "T_CLIENT_ADDRESS"."ADDRESS_MOO" IS 'Village number (Moo)';
COMMENT ON COLUMN "T_CLIENT_ADDRESS"."SUBDISTRICT_CODE" IS 'Subdistrict code';
COMMENT ON COLUMN "T_CLIENT_ADDRESS"."DISTRICT_CODE" IS 'District code';
COMMENT ON COLUMN "T_CLIENT_ADDRESS"."PROVINCE_CODE" IS 'Province code';
COMMENT ON COLUMN "T_CLIENT_ADDRESS"."POSTAL_CODE" IS 'Postal code';
COMMENT ON COLUMN "T_CLIENT_ADDRESS"."COUNTRY_CODE" IS 'Country code (ISO 3166-1 alpha-3)';
COMMENT ON COLUMN "T_CLIENT_ADDRESS"."IS_PRIMARY" IS 'Primary address flag';
COMMENT ON COLUMN "T_CLIENT_ADDRESS"."CREATED_DATE" IS 'Record creation timestamp';
COMMENT ON COLUMN "T_CLIENT_ADDRESS"."UPDATED_DATE" IS 'Record update timestamp';

-- ----------------------------------------------------------------------------
-- Table: T_CLIENT_CONTACT
-- Purpose: Client contact information
-- ----------------------------------------------------------------------------
CREATE TABLE "T_CLIENT_CONTACT" (
    "ID" SERIAL PRIMARY KEY,
    "UUID" UUID NOT NULL UNIQUE DEFAULT gen_random_uuid(),
    "CLIENT_CODE" VARCHAR(20) NOT NULL,
    "CONTACT_TYPE_CODE" VARCHAR(20) NULL,
    "CONTACT_VALUE" VARCHAR(200) NOT NULL,
    "IS_PRIMARY" BOOLEAN NOT NULL DEFAULT FALSE,
    "REMARK" TEXT NULL,
    "CREATED_DATE" TIMESTAMP WITH TIME ZONE NOT NULL DEFAULT CURRENT_TIMESTAMP,
    "CREATED_BY" VARCHAR(100) NOT NULL DEFAULT 'System',
    "UPDATED_DATE" TIMESTAMP WITH TIME ZONE NOT NULL DEFAULT CURRENT_TIMESTAMP,
    "UPDATED_BY" VARCHAR(100) NOT NULL DEFAULT 'System',
    CONSTRAINT "FK_CONTACT_CLIENT" FOREIGN KEY ("CLIENT_CODE") 
        REFERENCES "T_CLIENT"("CLIENT_CODE") ON DELETE CASCADE ON UPDATE CASCADE
);

COMMENT ON TABLE "T_CLIENT_CONTACT" IS 'Client contact information';
COMMENT ON COLUMN "T_CLIENT_CONTACT"."ID" IS 'Primary key';
COMMENT ON COLUMN "T_CLIENT_CONTACT"."UUID" IS 'Unique identifier (UUID)';
COMMENT ON COLUMN "T_CLIENT_CONTACT"."CLIENT_CODE" IS 'Foreign key to T_CLIENT';
COMMENT ON COLUMN "T_CLIENT_CONTACT"."CONTACT_TYPE_CODE" IS 'Contact type: MOBILE, EMAIL, LINE, OFFICE_PHONE, HOME_PHONE, FAX';
COMMENT ON COLUMN "T_CLIENT_CONTACT"."CONTACT_VALUE" IS 'Contact value (phone, email, etc.)';
COMMENT ON COLUMN "T_CLIENT_CONTACT"."IS_PRIMARY" IS 'Primary contact flag';
COMMENT ON COLUMN "T_CLIENT_CONTACT"."CREATED_DATE" IS 'Record creation timestamp';
COMMENT ON COLUMN "T_CLIENT_CONTACT"."UPDATED_DATE" IS 'Record update timestamp';

-- ----------------------------------------------------------------------------
-- Table: T_CLIENT_ROLE
-- Purpose: Client roles in policies
-- ----------------------------------------------------------------------------
CREATE TABLE "T_CLIENT_ROLE" (
    "ID" SERIAL PRIMARY KEY,
    "UUID" UUID NOT NULL UNIQUE DEFAULT gen_random_uuid(),
    "CLIENT_CODE" VARCHAR(20) NOT NULL,
    "ROLE_CODE" VARCHAR(50) NULL,
    "REFERENCE_NO" VARCHAR(50) NULL,
    "POLICY_NO" VARCHAR(50) NULL,
    "EFFECTIVE_DATE" DATE NULL,
    "EXPIRY_DATE" DATE NULL,
    "ROLE_SEQ_NO" INTEGER NULL,
    "IS_ACTIVE" BOOLEAN NOT NULL DEFAULT TRUE,
    "REMARK" TEXT NULL,
    "CREATED_DATE" TIMESTAMP WITH TIME ZONE NOT NULL DEFAULT CURRENT_TIMESTAMP,
    "CREATED_BY" VARCHAR(100) NOT NULL DEFAULT 'System',
    "UPDATED_DATE" TIMESTAMP WITH TIME ZONE NOT NULL DEFAULT CURRENT_TIMESTAMP,
    "UPDATED_BY" VARCHAR(100) NOT NULL DEFAULT 'System',
    CONSTRAINT "FK_ROLE_CLIENT" FOREIGN KEY ("CLIENT_CODE") 
        REFERENCES "T_CLIENT"("CLIENT_CODE") ON DELETE CASCADE ON UPDATE CASCADE
);

COMMENT ON TABLE "T_CLIENT_ROLE" IS 'Client roles in insurance policies';
COMMENT ON COLUMN "T_CLIENT_ROLE"."ID" IS 'Primary key';
COMMENT ON COLUMN "T_CLIENT_ROLE"."UUID" IS 'Unique identifier (UUID)';
COMMENT ON COLUMN "T_CLIENT_ROLE"."CLIENT_CODE" IS 'Foreign key to T_CLIENT';
COMMENT ON COLUMN "T_CLIENT_ROLE"."ROLE_CODE" IS 'Role code: POLICY_OWNER, INSURED, BENEFICIARY, PAYOR, CORPORATE_CLIENT';
COMMENT ON COLUMN "T_CLIENT_ROLE"."REFERENCE_NO" IS 'Reference document number';
COMMENT ON COLUMN "T_CLIENT_ROLE"."POLICY_NO" IS 'Policy number';
COMMENT ON COLUMN "T_CLIENT_ROLE"."EFFECTIVE_DATE" IS 'Role effective date';
COMMENT ON COLUMN "T_CLIENT_ROLE"."EXPIRY_DATE" IS 'Role expiry date';
COMMENT ON COLUMN "T_CLIENT_ROLE"."ROLE_SEQ_NO" IS 'Role sequence number';
COMMENT ON COLUMN "T_CLIENT_ROLE"."IS_ACTIVE" IS 'Active status';
COMMENT ON COLUMN "T_CLIENT_ROLE"."CREATED_DATE" IS 'Record creation timestamp';
COMMENT ON COLUMN "T_CLIENT_ROLE"."UPDATED_DATE" IS 'Record update timestamp';

-- ----------------------------------------------------------------------------
-- Table: T_IMAGE
-- Purpose: Client images and documents
-- ----------------------------------------------------------------------------
CREATE TABLE "T_IMAGE" (
    "ID" SERIAL PRIMARY KEY,
    "UUID" UUID NOT NULL UNIQUE DEFAULT gen_random_uuid(),
    "IMAGE_CODE" VARCHAR(50) NOT NULL UNIQUE,
    "REF_ID" VARCHAR(20) NULL,
    "IMAGE_TYPE_CODE" VARCHAR(20) NULL,
    "IMAGE_CATEGORY" VARCHAR(20) NULL,
    "FILE_NAME" VARCHAR(200) NULL,
    "FILE_PATH" VARCHAR(500) NULL,
    "FILE_URL" VARCHAR(500) NULL,
    "CONTENT_TYPE" VARCHAR(50) NULL,
    "FILE_SIZE" BIGINT NULL,
    "WIDTH" INTEGER NULL,
    "HEIGHT" INTEGER NULL,
    "IMAGE_DATA" BYTEA NULL,
    "THUMBNAIL_URL" VARCHAR(500) NULL,
    "THUMBNAIL_DATA" BYTEA NULL,
    "IS_PRIMARY" BOOLEAN NOT NULL DEFAULT FALSE,
    "DISPLAY_ORDER" INTEGER NULL,
    "IS_ACTIVE" BOOLEAN NOT NULL DEFAULT TRUE,
    "REMARK" TEXT NULL,
    "CREATED_DATE" TIMESTAMP WITH TIME ZONE NOT NULL DEFAULT CURRENT_TIMESTAMP,
    "CREATED_BY" VARCHAR(100) NULL,
    "UPDATED_DATE" TIMESTAMP WITH TIME ZONE NOT NULL DEFAULT CURRENT_TIMESTAMP,
    "UPDATED_BY" VARCHAR(100) NULL,
    CONSTRAINT "FK_IMAGE_CLIENT" FOREIGN KEY ("REF_ID") 
        REFERENCES "T_CLIENT"("CLIENT_CODE") ON DELETE CASCADE ON UPDATE CASCADE
);

COMMENT ON TABLE "T_IMAGE" IS 'Client images and documents';
COMMENT ON COLUMN "T_IMAGE"."ID" IS 'Primary key';
COMMENT ON COLUMN "T_IMAGE"."UUID" IS 'Unique identifier (UUID)';
COMMENT ON COLUMN "T_IMAGE"."IMAGE_CODE" IS 'Unique image code';
COMMENT ON COLUMN "T_IMAGE"."REF_ID" IS 'Reference to client (CLIENT_CODE)';
COMMENT ON COLUMN "T_IMAGE"."IMAGE_TYPE_CODE" IS 'Image type: PROFILE, ID_CARD, PASSPORT, COMPANY_LOGO, REGISTRATION, SIGNATURE';
COMMENT ON COLUMN "T_IMAGE"."IMAGE_CATEGORY" IS 'Image category: PERSONAL, DOCUMENT, CORPORATE';
COMMENT ON COLUMN "T_IMAGE"."FILE_NAME" IS 'Original file name';
COMMENT ON COLUMN "T_IMAGE"."CONTENT_TYPE" IS 'MIME type (image/jpeg, image/png, etc.)';
COMMENT ON COLUMN "T_IMAGE"."FILE_SIZE" IS 'File size in bytes';
COMMENT ON COLUMN "T_IMAGE"."WIDTH" IS 'Image width in pixels';
COMMENT ON COLUMN "T_IMAGE"."HEIGHT" IS 'Image height in pixels';
COMMENT ON COLUMN "T_IMAGE"."IMAGE_DATA" IS 'Binary image data (BYTEA)';
COMMENT ON COLUMN "T_IMAGE"."THUMBNAIL_DATA" IS 'Binary thumbnail data (BYTEA)';
COMMENT ON COLUMN "T_IMAGE"."IS_PRIMARY" IS 'Primary image flag';
COMMENT ON COLUMN "T_IMAGE"."DISPLAY_ORDER" IS 'Display order';
COMMENT ON COLUMN "T_IMAGE"."IS_ACTIVE" IS 'Active status';
COMMENT ON COLUMN "T_IMAGE"."CREATED_DATE" IS 'Record creation timestamp';
COMMENT ON COLUMN "T_IMAGE"."UPDATED_DATE" IS 'Record update timestamp';

-- ============================================================================
-- INDEXES
-- ============================================================================

-- Agent Module Indexes
CREATE INDEX "idx_agent_code" ON "T_AGENT"("AGENT_CODE");
CREATE INDEX "idx_agent_hierarchy" ON "T_AGENT"("HIERARCHY_ID");
CREATE INDEX "idx_agent_rank" ON "T_AGENT"("RANK_ID");
CREATE INDEX "idx_agent_parent" ON "T_AGENT"("PARENT_AGENT_ID");
CREATE INDEX "idx_agent_active" ON "T_AGENT"("IS_ACTIVE");
CREATE INDEX "idx_license_agent" ON "T_LICENSE"("AGENT_ID");
CREATE INDEX "idx_license_number" ON "T_LICENSE"("LICENSE_NUMBER");

-- Client Module Indexes
CREATE INDEX "idx_client_code" ON "T_CLIENT"("CLIENT_CODE");
CREATE INDEX "idx_client_refid" ON "T_CLIENT"("REF_ID");
CREATE INDEX "idx_client_type" ON "T_CLIENT"("CLIENT_TYPE_CODE");
CREATE INDEX "idx_client_active" ON "T_CLIENT"("IS_ACTIVE");
CREATE INDEX "idx_address_client" ON "T_CLIENT_ADDRESS"("CLIENT_CODE");
CREATE INDEX "idx_address_primary" ON "T_CLIENT_ADDRESS"("IS_PRIMARY") WHERE "IS_PRIMARY" = TRUE;
CREATE INDEX "idx_contact_client" ON "T_CLIENT_CONTACT"("CLIENT_CODE");
CREATE INDEX "idx_contact_primary" ON "T_CLIENT_CONTACT"("IS_PRIMARY") WHERE "IS_PRIMARY" = TRUE;
CREATE INDEX "idx_role_client" ON "T_CLIENT_ROLE"("CLIENT_CODE");
CREATE INDEX "idx_role_policy" ON "T_CLIENT_ROLE"("POLICY_NO");
CREATE INDEX "idx_image_refid" ON "T_IMAGE"("REF_ID");
CREATE INDEX "idx_image_code" ON "T_IMAGE"("IMAGE_CODE");
CREATE INDEX "idx_image_type" ON "T_IMAGE"("IMAGE_TYPE_CODE");
CREATE INDEX "idx_image_primary" ON "T_IMAGE"("IS_PRIMARY") WHERE "IS_PRIMARY" = TRUE;

-- ============================================================================
-- INITIAL DATA - RANK TABLE
-- ============================================================================

INSERT INTO "T_RANK" ("RANK_CODE", "RANK_NAME", "LEVEL") VALUES
('AG', 'Agent General', 1),
('AL', 'Agent Leader', 2),
('AE', 'Agent Executive', 3);

-- ============================================================================
-- INITIAL DATA - HIERARCHY TABLE
-- ============================================================================

INSERT INTO "T_HIERARCHY" ("HIERARCHY_CODE", "HIERARCHY_NAME", "RANK_ID", "LEVEL") VALUES
('A1', 'Agent Level 1', (SELECT "ID" FROM "T_RANK" WHERE "RANK_CODE" = 'AG'), 1),
('A2', 'Agent Level 2', (SELECT "ID" FROM "T_RANK" WHERE "RANK_CODE" = 'AG'), 2),
('A3', 'Agent Level 3', (SELECT "ID" FROM "T_RANK" WHERE "RANK_CODE" = 'AG'), 3),
('A4', 'Leader Level 1', (SELECT "ID" FROM "T_RANK" WHERE "RANK_CODE" = 'AL'), 4),
('A5', 'Leader Level 2', (SELECT "ID" FROM "T_RANK" WHERE "RANK_CODE" = 'AL'), 5),
('A6', 'Leader Level 3', (SELECT "ID" FROM "T_RANK" WHERE "RANK_CODE" = 'AL'), 6),
('A7', 'Executive Level 1', (SELECT "ID" FROM "T_RANK" WHERE "RANK_CODE" = 'AE'), 7),
('A8', 'Executive Level 2', (SELECT "ID" FROM "T_RANK" WHERE "RANK_CODE" = 'AE'), 8),
('A9', 'Executive Level 3', (SELECT "ID" FROM "T_RANK" WHERE "RANK_CODE" = 'AE'), 9);

-- ============================================================================
-- FUNCTIONS AND TRIGGERS
-- ============================================================================

-- Function to update UPDATED_DATE automatically
CREATE OR REPLACE FUNCTION update_updated_date_column()
RETURNS TRIGGER AS $$
BEGIN
    NEW."UPDATED_DATE" = CURRENT_TIMESTAMP;
    RETURN NEW;
END;
$$ LANGUAGE plpgsql;

-- Apply trigger to all tables with UPDATED_DATE column
CREATE TRIGGER "trg_agent_updated_date"
    BEFORE UPDATE ON "T_AGENT"
    FOR EACH ROW
    EXECUTE FUNCTION update_updated_date_column();

CREATE TRIGGER "trg_license_updated_date"
    BEFORE UPDATE ON "T_LICENSE"
    FOR EACH ROW
    EXECUTE FUNCTION update_updated_date_column();

CREATE TRIGGER "trg_client_updated_date"
    BEFORE UPDATE ON "T_CLIENT"
    FOR EACH ROW
    EXECUTE FUNCTION update_updated_date_column();

CREATE TRIGGER "trg_client_address_updated_date"
    BEFORE UPDATE ON "T_CLIENT_ADDRESS"
    FOR EACH ROW
    EXECUTE FUNCTION update_updated_date_column();

CREATE TRIGGER "trg_client_contact_updated_date"
    BEFORE UPDATE ON "T_CLIENT_CONTACT"
    FOR EACH ROW
    EXECUTE FUNCTION update_updated_date_column();

CREATE TRIGGER "trg_client_role_updated_date"
    BEFORE UPDATE ON "T_CLIENT_ROLE"
    FOR EACH ROW
    EXECUTE FUNCTION update_updated_date_column();

CREATE TRIGGER "trg_image_updated_date"
    BEFORE UPDATE ON "T_IMAGE"
    FOR EACH ROW
    EXECUTE FUNCTION update_updated_date_column();

-- ============================================================================
-- VIEWS (Optional - for easier querying)
-- ============================================================================

-- View: Agent with complete hierarchy information
CREATE OR REPLACE VIEW "V_AGENT_HIERARCHY" AS
SELECT 
    a."ID",
    a."AGENT_CODE",
    a."AGENT_NAME",
    h."HIERARCHY_CODE",
    h."HIERARCHY_NAME",
    r."RANK_CODE",
    r."RANK_NAME",
    r."LEVEL" AS "RANK_LEVEL",
    h."LEVEL" AS "HIERARCHY_LEVEL",
    a."PARENT_AGENT_ID",
    pa."AGENT_CODE" AS "PARENT_AGENT_CODE",
    pa."AGENT_NAME" AS "PARENT_AGENT_NAME",
    a."IS_ACTIVE",
    a."CREATED_DATE",
    a."UPDATED_DATE"
FROM "T_AGENT" a
INNER JOIN "T_HIERARCHY" h ON a."HIERARCHY_ID" = h."ID"
INNER JOIN "T_RANK" r ON a."RANK_ID" = r."ID"
LEFT JOIN "T_AGENT" pa ON a."PARENT_AGENT_ID" = pa."ID";

COMMENT ON VIEW "V_AGENT_HIERARCHY" IS 'Agent information with complete hierarchy details';

-- View: Client with agent information
CREATE OR REPLACE VIEW "V_CLIENT_WITH_AGENT" AS
SELECT 
    c."ID",
    c."CLIENT_CODE",
    c."CLIENT_TYPE_CODE",
    COALESCE(c."ORGANIZATION_NAME", c."FIRST_NAME" || ' ' || c."LAST_NAME") AS "CLIENT_NAME",
    c."FIRST_NAME",
    c."LAST_NAME",
    c."ORGANIZATION_NAME",
    c."DATE_OF_BIRTH",
    c."GENDER_CODE",
    c."NATIONALITY_CODE",
    c."REF_ID" AS "AGENT_CODE",
    a."AGENT_NAME",
    r."RANK_CODE" AS "AGENT_RANK",
    h."HIERARCHY_CODE" AS "AGENT_HIERARCHY",
    c."IS_ACTIVE",
    c."CREATED_DATE",
    c."UPDATED_DATE"
FROM "T_CLIENT" c
LEFT JOIN "T_AGENT" a ON c."REF_ID" = a."AGENT_CODE"
LEFT JOIN "T_RANK" r ON a."RANK_ID" = r."ID"
LEFT JOIN "T_HIERARCHY" h ON a."HIERARCHY_ID" = h."ID";

COMMENT ON VIEW "V_CLIENT_WITH_AGENT" IS 'Client information with managing agent details';

-- ============================================================================
-- SECURITY (Optional - create roles and permissions)
-- ============================================================================

-- Create read-only role
-- CREATE ROLE readonly_user;
-- GRANT CONNECT ON DATABASE your_database_name TO readonly_user;
-- GRANT USAGE ON SCHEMA public TO readonly_user;
-- GRANT SELECT ON ALL TABLES IN SCHEMA public TO readonly_user;
-- GRANT SELECT ON ALL SEQUENCES IN SCHEMA public TO readonly_user;

-- Create read-write role
-- CREATE ROLE readwrite_user;
-- GRANT CONNECT ON DATABASE your_database_name TO readwrite_user;
-- GRANT USAGE ON SCHEMA public TO readwrite_user;
-- GRANT SELECT, INSERT, UPDATE, DELETE ON ALL TABLES IN SCHEMA public TO readwrite_user;
-- GRANT USAGE, SELECT ON ALL SEQUENCES IN SCHEMA public TO readwrite_user;

-- ============================================================================
-- COMPLETION
-- ============================================================================

-- Verify table creation
SELECT 
    table_name,
    CASE 
        WHEN table_name LIKE 'T_%' THEN 'Table'
        WHEN table_name LIKE 'V_%' THEN 'View'
        ELSE 'Other'
    END AS object_type
FROM information_schema.tables 
WHERE table_schema = 'public' 
    AND table_name IN (
        'T_RANK', 'T_HIERARCHY', 'T_AGENT', 'T_LICENSE',
        'T_CLIENT', 'T_CLIENT_ADDRESS', 'T_CLIENT_CONTACT', 
        'T_CLIENT_ROLE', 'T_IMAGE',
        'V_AGENT_HIERARCHY', 'V_CLIENT_WITH_AGENT'
    )
ORDER BY object_type, table_name;

-- Display initial data counts
SELECT 'T_RANK' AS table_name, COUNT(*) AS record_count FROM "T_RANK"
UNION ALL
SELECT 'T_HIERARCHY', COUNT(*) FROM "T_HIERARCHY"
UNION ALL
SELECT 'T_AGENT', COUNT(*) FROM "T_AGENT"
UNION ALL
SELECT 'T_LICENSE', COUNT(*) FROM "T_LICENSE"
UNION ALL
SELECT 'T_CLIENT', COUNT(*) FROM "T_CLIENT"
UNION ALL
SELECT 'T_CLIENT_ADDRESS', COUNT(*) FROM "T_CLIENT_ADDRESS"
UNION ALL
SELECT 'T_CLIENT_CONTACT', COUNT(*) FROM "T_CLIENT_CONTACT"
UNION ALL
SELECT 'T_CLIENT_ROLE', COUNT(*) FROM "T_CLIENT_ROLE"
UNION ALL
SELECT 'T_IMAGE', COUNT(*) FROM "T_IMAGE";

-- ============================================================================
-- END OF SCRIPT
-- ============================================================================

COMMENT ON DATABASE postgres IS 'Agent Hierarchy Management System - Insurance Agent and Client Management';

-- Success message
DO $$
BEGIN
    RAISE NOTICE '============================================================';
    RAISE NOTICE 'Database schema created successfully!';
    RAISE NOTICE 'Tables: 9 (T_RANK, T_HIERARCHY, T_AGENT, T_LICENSE, T_CLIENT, T_CLIENT_ADDRESS, T_CLIENT_CONTACT, T_CLIENT_ROLE, T_IMAGE)';
    RAISE NOTICE 'Views: 2 (V_AGENT_HIERARCHY, V_CLIENT_WITH_AGENT)';
    RAISE NOTICE 'Indexes: 20+ performance indexes created';
    RAISE NOTICE 'Triggers: 7 auto-update triggers for UPDATED_DATE';
    RAISE NOTICE 'Initial Data: 3 Ranks, 9 Hierarchies inserted';
    RAISE NOTICE '============================================================';
END $$;
