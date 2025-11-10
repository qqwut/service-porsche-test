# Seed Data Summary

## ✅ Successfully Added Sample Data

### Client Roles (5 records)

#### CLI0001 - สมชาย ใจดี
1. **POLICY_OWNER** - Life Insurance Policy Owner
   - Policy: POL001-2025
   - Reference: POL-2025-001
   - Period: 2025-01-01 to 2026-01-01

2. **INSURED** - Insured Person
   - Policy: POL001-2025
   - Reference: POL-2025-001
   - Period: 2025-01-01 to 2026-01-01

#### CLI0002 - สมหญิง รักดี
3. **BENEFICIARY** - Primary Beneficiary - Spouse
   - Policy: POL001-2025
   - Reference: POL-2025-001
   - Period: 2025-01-01 to 2026-01-01

#### CLI0003 - บริษัท ไทยประกันภัย
4. **CORPORATE_CLIENT** - Corporate Insurance Client
   - Policy: CORP001-2025
   - Reference: CORP-2025-001
   - Period: 2025-01-01 to 2026-01-01

#### CLI0004 - John Smith
5. **POLICY_OWNER** - Expatriate Policy Owner
   - Policy: POL002-2025
   - Reference: POL-2025-002
   - Period: 2025-02-01 to 2026-02-01

---

### Images (7 records)

#### CLI0001 - สมชาย ใจดี (2 images)
1. **IMG0001** - Profile Picture
   - Type: PROFILE
   - Category: PERSONAL
   - File: somchai_profile.jpg
   - Primary: ✓
   - Size: 70 bytes (sample)

2. **IMG0002** - National ID Card
   - Type: ID_CARD
   - Category: DOCUMENT
   - File: somchai_idcard.jpg
   - Size: 70 bytes (sample)

#### CLI0002 - สมหญิง รักดี (1 image)
3. **IMG0003** - Profile Picture
   - Type: PROFILE
   - Category: PERSONAL
   - File: somying_profile.jpg
   - Primary: ✓
   - Size: 70 bytes (sample)

#### CLI0003 - บริษัท ไทยประกันภัย (2 images)
4. **IMG0004** - Company Logo
   - Type: COMPANY_LOGO
   - Category: CORPORATE
   - File: thai_insurance_logo.png
   - Primary: ✓
   - Size: 70 bytes (sample)

5. **IMG0005** - Company Registration
   - Type: REGISTRATION
   - Category: DOCUMENT
   - File: company_registration.pdf.jpg
   - Size: 70 bytes (sample)

#### CLI0004 - John Smith (2 images)
6. **IMG0006** - Passport Photo
   - Type: PASSPORT
   - Category: DOCUMENT
   - File: john_passport.jpg
   - Primary: ✓
   - Size: 70 bytes (sample)

7. **IMG0007** - Digital Signature
   - Type: SIGNATURE
   - Category: VERIFICATION
   - File: john_signature.png
   - Size: 70 bytes (sample)

---

## Test API Endpoints

### Get Client with Roles and Images
```bash
# Get CLI0001 with all related data
curl http://localhost:5000/api/Clients/code/CLI0001

# Expected: Client data + 2 images + roles + addresses + contacts
```

### Get Images for a Client
```bash
# Get all images for CLI0001
curl http://localhost:5000/api/Images/ref/CLI0001

# Expected: 2 images (profile + ID card) with base64 data
```

### Get Clients by Agent (with images)
```bash
# Get all clients for AG0001
curl http://localhost:5000/api/Clients/agent/AG0001

# Expected: CLI0001 and CLI0002 with their images
```

### Get Specific Image
```bash
# Get IMG0001 (Somchai's profile)
curl http://localhost:5000/api/Images/code/IMG0001

# Expected: Full image details with base64 data
```

## Role Codes Reference
- `POLICY_OWNER` - Owner of the insurance policy
- `INSURED` - The insured person
- `BENEFICIARY` - Beneficiary of the policy
- `CORPORATE_CLIENT` - Corporate/organizational client

## Image Type Codes Reference
- `PROFILE` - Profile picture
- `ID_CARD` - National ID card
- `PASSPORT` - Passport document
- `COMPANY_LOGO` - Company logo
- `REGISTRATION` - Registration document
- `SIGNATURE` - Digital signature

## Image Categories Reference
- `PERSONAL` - Personal photos
- `DOCUMENT` - Document images
- `CORPORATE` - Corporate/business images
- `VERIFICATION` - Verification images

## Database Tables Updated
✅ **T_CLIENT_ROLE** - 5 records added
✅ **T_IMAGE** - 7 records added

## Notes
- All images use sample PNG data (1x1 pixel) for demonstration
- In production, replace with actual image uploads via POST /api/Images
- Images are automatically converted to/from base64 in API responses
- All DateTime values are in UTC
- Images are linked to clients via RefId = ClientCode
