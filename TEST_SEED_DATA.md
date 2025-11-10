# Test Commands for Seed Data

## Quick Verification Tests

### 1. Test Client with Roles and Images
```bash
# Get CLI0001 - should show client data, addresses, contacts, roles, and 2 images
curl -X GET "http://localhost:5000/api/Clients/code/CLI0001" | jq
```

Expected response should include:
- Client info (สมชาย ใจดี)
- 1 Address
- 2 Contacts
- **2 Roles** (POLICY_OWNER, INSURED)
- **2 Images** (Profile + ID Card with base64 data)

### 2. Test Images API
```bash
# Get all images for CLI0001
curl -X GET "http://localhost:5000/api/Images/ref/CLI0001" | jq

# Get specific image
curl -X GET "http://localhost:5000/api/Images/code/IMG0001" | jq

# Get all images
curl -X GET "http://localhost:5000/api/Images" | jq
```

### 3. Test Clients by Agent (with Images)
```bash
# Get first client for AG0001 - returns single client object (not array)
curl -X GET "http://localhost:5000/api/Clients/agent/AG0001" | jq
```

Expected: Single client object (CLI0001 - สมชาย ใจดี) with images

**Note:** This endpoint now returns only the **first client** for the agent (FirstOrDefault pattern), not an array of all clients.

### 4. Test Corporate Client
```bash
# Get CLI0003 (company) - should have 2 images (logo + registration)
curl -X GET "http://localhost:5000/api/Clients/code/CLI0003" | jq
```

Expected: Company data with 2 images

### 5. Test Image by Type
```bash
# Get passport images
curl -X GET "http://localhost:5000/api/Images/ref/CLI0004" | jq
```

Expected: 2 images (passport + signature)

## PowerShell Test Commands

```powershell
# Test with PowerShell
Invoke-RestMethod -Uri "http://localhost:5000/api/Clients/code/CLI0001" -Method Get | ConvertTo-Json -Depth 10

# Get images
Invoke-RestMethod -Uri "http://localhost:5000/api/Images/ref/CLI0001" -Method Get | ConvertTo-Json -Depth 5

# Get first client by agent (returns single object, not array)
Invoke-RestMethod -Uri "http://localhost:5000/api/Clients/agent/AG0001" -Method Get | ConvertTo-Json -Depth 10
```

## Swagger UI Testing
Open browser: **http://localhost:5000**

Test endpoints:
1. **GET /api/Clients/code/{clientCode}** with `CLI0001`
2. **GET /api/Images/ref/{refId}** with `CLI0001`
3. **GET /api/Clients/agent/{agentCode}** with `AG0001` (returns first client only)

## Data Verification Queries

### Check Roles Count
```bash
# Should return roles for all 4 clients (total 5 roles)
curl -X GET "http://localhost:5000/api/Clients" | jq '[.[] | {clientCode, rolesCount: (.roles | length)}]'
```

### Check Images Count
```bash
# Total images: 7 (2+1+2+2)
curl -X GET "http://localhost:5000/api/Images" | jq 'length'
```

### Verify Image Data
```bash
# Check if base64 data exists
curl -X GET "http://localhost:5000/api/Images/code/IMG0001" | jq '.imageBase64 != null'
```

## Expected Data Summary

| Client Code | Client Name | Roles | Images | Image Types |
|------------|-------------|-------|--------|-------------|
| CLI0001 | สมชาย ใจดี | 2 | 2 | PROFILE, ID_CARD |
| CLI0002 | สมหญิง รักดี | 1 | 1 | PROFILE |
| CLI0003 | บริษัท ไทยประกันภัย | 1 | 2 | COMPANY_LOGO, REGISTRATION |
| CLI0004 | John Smith | 1 | 2 | PASSPORT, SIGNATURE |

**Total:** 5 Roles, 7 Images

## Sample Response Structure

```json
{
  "id": 1,
  "clientCode": "CLI0001",
  "firstName": "สมชาย",
  "lastName": "ใจดี",
  "refId": "AG0001",
  "addresses": [...],
  "contacts": [...],
  "roles": [
    {
      "id": 1,
      "roleCode": "POLICY_OWNER",
      "policyNo": "POL001-2025",
      "referenceNo": "POL-2025-001",
      "remark": "Life Insurance Policy Owner"
    },
    {
      "id": 2,
      "roleCode": "INSURED",
      "policyNo": "POL001-2025",
      "remark": "Insured Person"
    }
  ],
  "images": [
    {
      "id": 1,
      "imageCode": "IMG0001",
      "imageTypeCode": "PROFILE",
      "fileName": "somchai_profile.jpg",
      "imageBase64": "iVBORw0KGgoAAAANSUhEUgAAAAEAAAAB...",
      "contentType": "image/jpeg",
      "isPrimary": true
    },
    {
      "id": 2,
      "imageCode": "IMG0002",
      "imageTypeCode": "ID_CARD",
      "fileName": "somchai_idcard.jpg",
      "imageBase64": "iVBORw0KGgoAAAANSUhEUgAAAAEAAAAB...",
      "contentType": "image/jpeg"
    }
  ]
}
```
