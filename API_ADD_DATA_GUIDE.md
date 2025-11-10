# คู่มือการเพิ่มข้อมูลผ่าน API

## สารบัญ
1. [เพิ่ม Agent](#1-เพิ่ม-agent)
2. [เพิ่ม Client](#2-เพิ่ม-client)
3. [เพิ่ม Client Contact](#3-เพิ่ม-client-contact)
4. [เพิ่ม Client Role](#4-เพิ่ม-client-role)
5. [เพิ่ม Client Address](#5-เพิ่ม-client-address)
6. [เพิ่ม Image](#6-เพิ่ม-image)
7. [ตัวอย่างการใช้งานแบบครบวงจร](#7-ตัวอย่างการใช้งานแบบครบวงจร)

---

## 1. เพิ่ม Agent

### Endpoint
```
POST /api/Agents
Content-Type: application/json
```

### Request Body Schema

```json
{
  "agentCode": "string (required, unique)",
  "agentName": "string (required)",
  "hierarchyCode": "string (required)",
  "parentAgentId": "number (optional, null for top-level)"
}
```

### กฎการสร้าง Agent

**Hierarchy และ Rank:**
- A1, A2, A3 → Rank AG (Agent General)
- A4, A5, A6 → Rank AL (Agent Leader)
- A7, A8, A9 → Rank AE (Agent Executive)

**Hierarchy Structure:**
```
A9 (AE) ← Top Level
└─ A8 (AE)
   └─ A7 (AE)
      └─ A6 (AL)
         └─ A5 (AL)
            └─ A4 (AL)
               └─ A1 (AG) ← Bottom Level
```

### ตัวอย่างการสร้าง Agent

#### ตัวอย่างที่ 1: สร้าง Agent Executive (AE) - Top Level

**Request:**
```bash
curl -X POST "http://localhost:5000/api/Agents" \
  -H "Content-Type: application/json" \
  -d '{
    "agentCode": "AE0010",
    "agentName": "นายสมชาย ผู้บริหาร",
    "hierarchyCode": "A9",
    "parentAgentId": null
  }'
```

**PowerShell:**
```powershell
$body = @{
    agentCode = "AE0010"
    agentName = "นายสมชาย ผู้บริหาร"
    hierarchyCode = "A9"
    parentAgentId = $null
} | ConvertTo-Json

Invoke-RestMethod -Uri "http://localhost:5000/api/Agents" `
    -Method Post `
    -Body $body `
    -ContentType "application/json"
```

**Response:** `201 Created`
```json
{
  "id": 10,
  "agentCode": "AE0010",
  "agentName": "นายสมชาย ผู้บริหาร",
  "hierarchyCode": "A9",
  "rankCode": "AE",
  "parentAgentId": null,
  "parentAgentCode": null,
  "isActive": true
}
```

#### ตัวอย่างที่ 2: สร้าง Agent Leader (AL) - ภายใต้ AE

**Request:**
```json
{
  "agentCode": "AL0020",
  "agentName": "นางสาวสมหญิง หัวหน้าทีม",
  "hierarchyCode": "A6",
  "parentAgentId": 10
}
```

**Response:** `201 Created`
```json
{
  "id": 11,
  "agentCode": "AL0020",
  "agentName": "นางสาวสมหญิง หัวหน้าทีม",
  "hierarchyCode": "A6",
  "rankCode": "AL",
  "parentAgentId": 10,
  "parentAgentCode": "AE0010",
  "isActive": true
}
```

#### ตัวอย่างที่ 3: สร้าง Agent General (AG) - ภายใต้ AL

**Request:**
```json
{
  "agentCode": "AG0030",
  "agentName": "นายวิชัย ตัวแทนทั่วไป",
  "hierarchyCode": "A1",
  "parentAgentId": 11
}
```

**Response:** `201 Created`
```json
{
  "id": 12,
  "agentCode": "AG0030",
  "agentName": "นายวิชัย ตัวแทนทั่วไป",
  "hierarchyCode": "A1",
  "rankCode": "AG",
  "parentAgentId": 11,
  "parentAgentCode": "AL0020",
  "isActive": true
}
```

---

## 2. เพิ่ม Client

### Endpoint
```
POST /api/Clients
Content-Type: application/json
```

### Request Body Schema

```json
{
  "clientCode": "string (required, unique)",
  "clientTypeCode": "string (optional: INDIVIDUAL, ORGANIZATION)",
  "firstName": "string (optional)",
  "lastName": "string (optional)",
  "organizationName": "string (optional)",
  "dateOfBirth": "datetime (optional)",
  "genderCode": "string (optional: M, F, O)",
  "nationalityCode": "string (optional: THA, USA, etc.)",
  "refId": "string (optional, AgentCode)",
  "addresses": [
    {
      "addressTypeCode": "string (optional: HOME, OFFICE, etc.)",
      "addressNo": "string (optional)",
      "subdistrictCode": "string (required)",
      "districtCode": "string (required)",
      "provinceCode": "string (required)",
      "postalCode": "string (required)",
      "isPrimary": "boolean (optional, default: false)"
    }
  ],
  "contacts": [
    {
      "contactTypeCode": "string (optional: MOBILE, EMAIL, etc.)",
      "contactValue": "string (required)",
      "isPrimary": "boolean (optional, default: false)"
    }
  ]
}
```

### ตัวอย่างการสร้าง Client

#### ตัวอย่างที่ 1: สร้าง Client บุคคลธรรมดา (พร้อม Address และ Contact)

**Request:**
```bash
curl -X POST "http://localhost:5000/api/Clients" \
  -H "Content-Type: application/json" \
  -d '{
    "clientCode": "CLI0010",
    "clientTypeCode": "INDIVIDUAL",
    "firstName": "สมชาย",
    "lastName": "ใจดี",
    "dateOfBirth": "1985-05-15T00:00:00Z",
    "genderCode": "M",
    "nationalityCode": "THA",
    "refId": "AG0001",
    "addresses": [
      {
        "addressTypeCode": "HOME",
        "addressNo": "123/45",
        "subdistrictCode": "100101",
        "districtCode": "1001",
        "provinceCode": "10",
        "postalCode": "10230",
        "isPrimary": true
      }
    ],
    "contacts": [
      {
        "contactTypeCode": "MOBILE",
        "contactValue": "081-234-5678",
        "isPrimary": true
      },
      {
        "contactTypeCode": "EMAIL",
        "contactValue": "somchai@email.com",
        "isPrimary": false
      }
    ]
  }'
```

**PowerShell:**
```powershell
$body = @{
    clientCode = "CLI0010"
    clientTypeCode = "INDIVIDUAL"
    firstName = "สมชาย"
    lastName = "ใจดี"
    dateOfBirth = "1985-05-15T00:00:00Z"
    genderCode = "M"
    nationalityCode = "THA"
    refId = "AG0001"
    addresses = @(
        @{
            addressTypeCode = "HOME"
            addressNo = "123/45"
            subdistrictCode = "100101"
            districtCode = "1001"
            provinceCode = "10"
            postalCode = "10230"
            isPrimary = $true
        }
    )
    contacts = @(
        @{
            contactTypeCode = "MOBILE"
            contactValue = "081-234-5678"
            isPrimary = $true
        },
        @{
            contactTypeCode = "EMAIL"
            contactValue = "somchai@email.com"
            isPrimary = $false
        }
    )
} | ConvertTo-Json -Depth 10

Invoke-RestMethod -Uri "http://localhost:5000/api/Clients" `
    -Method Post `
    -Body $body `
    -ContentType "application/json"
```

**Response:** `201 Created`
```json
{
  "id": 5,
  "clientCode": "CLI0010",
  "clientTypeCode": "INDIVIDUAL",
  "firstName": "สมชาย",
  "lastName": "ใจดี",
  "dateOfBirth": "1985-05-15T00:00:00Z",
  "genderCode": "M",
  "nationalityCode": "THA",
  "refId": "AG0001",
  "isActive": true,
  "addresses": [
    {
      "id": 5,
      "clientCode": "CLI0010",
      "addressTypeCode": "HOME",
      "addressNo": "123/45",
      "subdistrictCode": "100101",
      "districtCode": "1001",
      "provinceCode": "10",
      "postalCode": "10230",
      "isPrimary": true
    }
  ],
  "contacts": [
    {
      "id": 9,
      "clientCode": "CLI0010",
      "contactTypeCode": "MOBILE",
      "contactValue": "081-234-5678",
      "isPrimary": true
    },
    {
      "id": 10,
      "clientCode": "CLI0010",
      "contactTypeCode": "EMAIL",
      "contactValue": "somchai@email.com",
      "isPrimary": false
    }
  ],
  "roles": [],
  "images": []
}
```

#### ตัวอย่างที่ 2: สร้าง Client นิติบุคคล (บริษัท)

**Request:**
```json
{
  "clientCode": "CLI0011",
  "clientTypeCode": "ORGANIZATION",
  "organizationName": "บริษัท ไทยประกันภัย จำกัด",
  "nationalityCode": "THA",
  "refId": "AE0001",
  "addresses": [
    {
      "addressTypeCode": "OFFICE",
      "addressNo": "999",
      "subdistrictCode": "100201",
      "districtCode": "1002",
      "provinceCode": "10",
      "postalCode": "10120",
      "isPrimary": true
    }
  ],
  "contacts": [
    {
      "contactTypeCode": "OFFICE_PHONE",
      "contactValue": "02-123-4567",
      "isPrimary": true
    },
    {
      "contactTypeCode": "EMAIL",
      "contactValue": "info@thaiinsurance.com",
      "isPrimary": false
    }
  ]
}
```

#### ตัวอย่างที่ 3: สร้าง Client ชาวต่างชาติ

**Request:**
```json
{
  "clientCode": "CLI0012",
  "clientTypeCode": "INDIVIDUAL",
  "firstName": "John",
  "lastName": "Smith",
  "dateOfBirth": "1975-03-10T00:00:00Z",
  "genderCode": "M",
  "nationalityCode": "USA",
  "refId": "AE0001",
  "contacts": [
    {
      "contactTypeCode": "MOBILE",
      "contactValue": "+1-555-1234",
      "isPrimary": true
    }
  ]
}
```

---

## 3. เพิ่ม Client Contact

**หมายเหตุ:** ปัจจุบันต้องเพิ่ม Contact ผ่านการสร้าง Client หรือ Update Client เท่านั้น ไม่มี endpoint แยกสำหรับ Contact โดยตรง

### วิธีเพิ่ม Contact ให้ Client ที่มีอยู่แล้ว

ใช้ `PUT /api/Clients/{id}` แต่ต้อง update ข้อมูล Client ทั้งหมด

**ทางเลือก:** ขอให้ทีมพัฒนาเพิ่ม endpoint ใหม่
```
POST /api/Clients/{clientId}/Contacts
PUT /api/Clients/{clientId}/Contacts/{contactId}
DELETE /api/Clients/{clientId}/Contacts/{contactId}
```

### Contact Type Codes (ตัวอย่าง)
- `MOBILE` - โทรศัพท์มือถือ
- `OFFICE_PHONE` - โทรศัพท์สำนักงาน
- `HOME_PHONE` - โทรศัพท์บ้าน
- `EMAIL` - อีเมล
- `LINE` - LINE ID
- `FAX` - แฟกซ์

---

## 4. เพิ่ม Client Role

**หมายเหตุ:** ปัจจุบันต้องเพิ่ม Role ผ่านฐานข้อมูลโดยตรง หรือขอให้ทีมพัฒนาเพิ่ม API endpoint

### ตัวอย่าง SQL สำหรับเพิ่ม Role
```sql
INSERT INTO "T_CLIENT_ROLE" (
    "CLIENT_CODE",
    "ROLE_CODE",
    "POLICY_NO",
    "REFERENCE_NO",
    "EFFECTIVE_DATE",
    "EXPIRY_DATE",
    "ROLE_SEQ_NO",
    "IS_ACTIVE",
    "REMARK",
    "CREATED_BY",
    "UPDATED_BY",
    "CREATED_DATE",
    "UPDATED_DATE",
    "UUID"
) VALUES (
    'CLI0010',
    'POLICY_OWNER',
    'POL001-2025',
    'POL-2025-001',
    '2025-01-01',
    '2026-01-01',
    1,
    true,
    'เจ้าของกรมธรรม์',
    'System',
    'System',
    NOW(),
    NOW(),
    gen_random_uuid()
);
```

### Role Type Codes (ตัวอย่าง)
- `POLICY_OWNER` - เจ้าของกรมธรรม์
- `INSURED` - ผู้เอาประกัน
- `BENEFICIARY` - ผู้รับประโยชน์
- `PAYOR` - ผู้ชำระเบี้ย
- `CORPORATE_CLIENT` - ลูกค้าองค์กร

**แนะนำ:** ขอให้ทีมพัฒนาเพิ่ม endpoint ใหม่
```
POST /api/Clients/{clientId}/Roles
PUT /api/Clients/{clientId}/Roles/{roleId}
DELETE /api/Clients/{clientId}/Roles/{roleId}
```

---

## 5. เพิ่ม Client Address

**หมายเหตุ:** ปัจจุบันต้องเพิ่ม Address ผ่านการสร้าง Client หรือ Update Client เท่านั้น

### Address Type Codes (ตัวอย่าง)
- `HOME` - บ้าน
- `OFFICE` - สำนักงาน
- `WORK` - ที่ทำงาน
- `SHIPPING` - ที่จัดส่ง
- `BILLING` - ที่เรียกเก็บเงิน

### ตัวอย่างข้อมูล Address แบบละเอียด

```json
{
  "addressTypeCode": "HOME",
  "addressWorkplaceName": null,
  "addressNo": "123/45",
  "addressMoo": "5",
  "addressDetail": "ซอยลาดพร้าว 101",
  "addressVillageBuilding": "หมู่บ้านสุขใจ",
  "addressAlley": null,
  "addressRoad": "ลาดพร้าว",
  "subdistrictCode": "100101",
  "districtCode": "1001",
  "provinceCode": "10",
  "postalCode": "10230",
  "countryCode": "THA",
  "isPrimary": true,
  "remark": "บ้านเลขที่ติดถนนใหญ่"
}
```

**แนะนำ:** ขอให้ทีมพัฒนาเพิ่ม endpoint ใหม่
```
POST /api/Clients/{clientId}/Addresses
PUT /api/Clients/{clientId}/Addresses/{addressId}
DELETE /api/Clients/{clientId}/Addresses/{addressId}
```

---

## 6. เพิ่ม Image

### Endpoint
```
POST /api/Images
Content-Type: application/json
```

### Request Body Schema

```json
{
  "imageCode": "string (required, unique)",
  "refId": "string (required, ClientCode)",
  "imageTypeCode": "string (optional)",
  "imageCategory": "string (optional)",
  "fileName": "string (optional)",
  "imageBase64": "string (required, base64 encoded image)",
  "contentType": "string (optional, MIME type)",
  "width": "number (optional)",
  "height": "number (optional)",
  "thumbnailBase64": "string (optional)",
  "isPrimary": "boolean (optional, default: false)",
  "displayOrder": "number (optional)",
  "isActive": "boolean (optional, default: true)",
  "remark": "string (optional)",
  "createdBy": "string (optional)"
}
```

### ตัวอย่างการเพิ่ม Image

#### ตัวอย่างที่ 1: อัพโหลดรูปโปรไฟล์

**JavaScript:**
```javascript
// แปลงไฟล์เป็น base64
const fileInput = document.getElementById('fileInput');
const file = fileInput.files[0];

const reader = new FileReader();
reader.readAsDataURL(file);
reader.onload = async () => {
  const base64String = reader.result.split(',')[1]; // ตัด data:image/jpeg;base64,
  
  const response = await fetch('http://localhost:5000/api/Images', {
    method: 'POST',
    headers: { 'Content-Type': 'application/json' },
    body: JSON.stringify({
      imageCode: 'IMG' + Date.now(),
      refId: 'CLI0010',
      imageTypeCode: 'PROFILE',
      imageCategory: 'PERSONAL',
      fileName: file.name,
      imageBase64: base64String,
      contentType: file.type,
      width: 800,
      height: 600,
      isPrimary: true,
      isActive: true,
      createdBy: 'User'
    })
  });
  
  const result = await response.json();
  console.log('Image uploaded:', result);
};
```

**cURL (Linux/Mac):**
```bash
# แปลงรูปเป็น base64
BASE64_IMAGE=$(base64 -w 0 profile.jpg)

curl -X POST "http://localhost:5000/api/Images" \
  -H "Content-Type: application/json" \
  -d '{
    "imageCode": "IMG0010",
    "refId": "CLI0010",
    "imageTypeCode": "PROFILE",
    "imageCategory": "PERSONAL",
    "fileName": "profile.jpg",
    "imageBase64": "'$BASE64_IMAGE'",
    "contentType": "image/jpeg",
    "isPrimary": true,
    "isActive": true
  }'
```

**PowerShell:**
```powershell
# แปลงรูปเป็น base64
$imageBytes = [System.IO.File]::ReadAllBytes("C:\path\to\profile.jpg")
$base64Image = [System.Convert]::ToBase64String($imageBytes)

$body = @{
    imageCode = "IMG0010"
    refId = "CLI0010"
    imageTypeCode = "PROFILE"
    imageCategory = "PERSONAL"
    fileName = "profile.jpg"
    imageBase64 = $base64Image
    contentType = "image/jpeg"
    width = 800
    height = 600
    isPrimary = $true
    isActive = $true
    createdBy = "User"
} | ConvertTo-Json

Invoke-RestMethod -Uri "http://localhost:5000/api/Images" `
    -Method Post `
    -Body $body `
    -ContentType "application/json"
```

**Response:** `201 Created`
```json
{
  "id": 8,
  "imageCode": "IMG0010",
  "refId": "CLI0010",
  "imageTypeCode": "PROFILE",
  "imageCategory": "PERSONAL",
  "fileName": "profile.jpg",
  "imageBase64": "iVBORw0KGgoAAAANSUhEUgAAAAEAAAAB...",
  "contentType": "image/jpeg",
  "fileSize": 123456,
  "width": 800,
  "height": 600,
  "isPrimary": true,
  "displayOrder": null,
  "isActive": true,
  "remark": null,
  "createdDate": "2025-11-10T10:30:00Z",
  "updatedDate": "2025-11-10T10:30:00Z"
}
```

#### ตัวอย่างที่ 2: อัพโหลดบัตรประชาชน

**Request:**
```json
{
  "imageCode": "IMG0011",
  "refId": "CLI0010",
  "imageTypeCode": "ID_CARD",
  "imageCategory": "DOCUMENT",
  "fileName": "id_card_front.jpg",
  "imageBase64": "base64_encoded_string_here...",
  "contentType": "image/jpeg",
  "width": 1024,
  "height": 768,
  "isPrimary": false,
  "displayOrder": 2,
  "isActive": true,
  "remark": "หน้าบัตรประชาชน"
}
```

#### ตัวอย่างที่ 3: อัพโหลดเอกสารประกอบ (PDF แปลงเป็น Image)

**Request:**
```json
{
  "imageCode": "IMG0012",
  "refId": "CLI0011",
  "imageTypeCode": "REGISTRATION",
  "imageCategory": "DOCUMENT",
  "fileName": "company_registration.pdf.jpg",
  "imageBase64": "base64_encoded_string_here...",
  "contentType": "image/jpeg",
  "width": 1200,
  "height": 1600,
  "isPrimary": false,
  "displayOrder": 1,
  "isActive": true,
  "remark": "เอกสารจดทะเบียนบริษัท"
}
```

### Image Type Codes (ตัวอย่าง)
- `PROFILE` - รูปโปรไฟล์
- `ID_CARD` - บัตรประชาชน
- `PASSPORT` - หนังสือเดินทาง
- `COMPANY_LOGO` - โลโก้บริษัท
- `REGISTRATION` - เอกสารจดทะเบียน
- `SIGNATURE` - ลายเซ็น
- `HOUSE_REGISTRATION` - ทะเบียนบ้าน
- `DRIVING_LICENSE` - ใบขับขี่

### Image Categories (ตัวอย่าง)
- `PERSONAL` - ส่วนบุคคล
- `DOCUMENT` - เอกสาร
- `CORPORATE` - องค์กร
- `VERIFICATION` - ยืนยันตัวตน

---

## 7. ตัวอย่างการใช้งานแบบครบวงจร

### สถานการณ์: สร้างข้อมูลตัวแทนและลูกค้าใหม่ทั้งระบบ

#### ขั้นตอนที่ 1: สร้าง Agent Executive (AE)

```bash
POST /api/Agents
{
  "agentCode": "AE0020",
  "agentName": "นายสมศักดิ์ ผู้บริหาร",
  "hierarchyCode": "A9",
  "parentAgentId": null
}

# Response: { "id": 20, "agentCode": "AE0020", ... }
```

#### ขั้นตอนที่ 2: สร้าง Agent Leader (AL) ภายใต้ AE

```bash
POST /api/Agents
{
  "agentCode": "AL0021",
  "agentName": "นางสาวมานี หัวหน้าทีม",
  "hierarchyCode": "A6",
  "parentAgentId": 20
}

# Response: { "id": 21, "agentCode": "AL0021", ... }
```

#### ขั้นตอนที่ 3: สร้าง Agent General (AG) ภายใต้ AL

```bash
POST /api/Agents
{
  "agentCode": "AG0022",
  "agentName": "นายวิชัย ตัวแทนขาย",
  "hierarchyCode": "A1",
  "parentAgentId": 21
}

# Response: { "id": 22, "agentCode": "AG0022", ... }
```

#### ขั้นตอนที่ 4: สร้าง Client พร้อมข้อมูลครบถ้วน

```bash
POST /api/Clients
{
  "clientCode": "CLI0020",
  "clientTypeCode": "INDIVIDUAL",
  "firstName": "สมชาย",
  "lastName": "มีสุข",
  "dateOfBirth": "1990-01-15T00:00:00Z",
  "genderCode": "M",
  "nationalityCode": "THA",
  "refId": "AG0022",
  "addresses": [
    {
      "addressTypeCode": "HOME",
      "addressNo": "99/99",
      "subdistrictCode": "100101",
      "districtCode": "1001",
      "provinceCode": "10",
      "postalCode": "10230",
      "isPrimary": true
    }
  ],
  "contacts": [
    {
      "contactTypeCode": "MOBILE",
      "contactValue": "089-999-9999",
      "isPrimary": true
    },
    {
      "contactTypeCode": "EMAIL",
      "contactValue": "somchai.m@email.com",
      "isPrimary": false
    }
  ]
}

# Response: { "id": 20, "clientCode": "CLI0020", ... }
```

#### ขั้นตอนที่ 5: เพิ่มรูปโปรไฟล์ให้ Client

```javascript
// JavaScript Example
const uploadProfileImage = async (clientCode, imageFile) => {
  const reader = new FileReader();
  reader.readAsDataURL(imageFile);
  
  reader.onload = async () => {
    const base64 = reader.result.split(',')[1];
    
    const response = await fetch('http://localhost:5000/api/Images', {
      method: 'POST',
      headers: { 'Content-Type': 'application/json' },
      body: JSON.stringify({
        imageCode: 'IMG-' + clientCode + '-PROFILE',
        refId: clientCode,
        imageTypeCode: 'PROFILE',
        imageCategory: 'PERSONAL',
        fileName: imageFile.name,
        imageBase64: base64,
        contentType: imageFile.type,
        isPrimary: true,
        isActive: true
      })
    });
    
    return await response.json();
  };
};

// เรียกใช้
await uploadProfileImage('CLI0020', profileImageFile);
```

#### ขั้นตอนที่ 6: เพิ่มรูปบัตรประชาชน

```javascript
await uploadDocumentImage('CLI0020', idCardFile, 'ID_CARD');
```

#### ขั้นตอนที่ 7: ตรวจสอบข้อมูลที่สร้าง

```bash
# ดูข้อมูล Client พร้อมรูปภาพ
GET /api/Clients/code/CLI0020

# ดูโครงสร้าง Agent
GET /api/Agents/hierarchy-tree?rootAgentId=20

# ดูรูปภาพทั้งหมดของ Client
GET /api/Images/ref/CLI0020
```

---

## ข้อมูลเพิ่มเติม

### Validation Rules

#### Agent:
- `agentCode` ต้องไม่ซ้ำกัน
- `hierarchyCode` ต้องมีในระบบ (A1-A9)
- Hierarchy ต้องถูกต้องตามลำดับชั้น (AG < AL < AE)

#### Client:
- `clientCode` ต้องไม่ซ้ำกัน
- `refId` (AgentCode) ต้องมีอยู่ในระบบ
- ถ้าเป็น INDIVIDUAL ควรมี firstName, lastName
- ถ้าเป็น ORGANIZATION ควรมี organizationName

#### Image:
- `imageCode` ต้องไม่ซ้ำกัน
- `imageBase64` ต้องเป็น base64 string ที่ถูกต้อง
- `refId` (ClientCode) ต้องมีอยู่ในระบบ
- ขนาดไฟล์แนะนำไม่เกิน 5MB

### Error Codes

| Status Code | ความหมาย | ตัวอย่าง |
|-------------|----------|----------|
| 201 | สร้างสำเร็จ | POST สำเร็จ |
| 400 | ข้อมูลไม่ถูกต้อง | Validation error, duplicate code |
| 404 | ไม่พบข้อมูล | Agent/Client ไม่มีในระบบ |
| 500 | Server error | ข้อผิดพลาดของระบบ |

### Tips สำหรับการใช้งาน

1. **ตรวจสอบข้อมูลก่อนส่ง:** ใช้ Swagger UI ที่ `http://localhost:5000` ทดสอบก่อน

2. **จัดการรูปภาพ:**
   - แปลงเป็น base64 ก่อนส่ง
   - ตรวจสอบขนาดไฟล์ไม่ให้ใหญ่เกินไป
   - ใช้ content type ที่ถูกต้อง (image/jpeg, image/png)

3. **Transaction:** 
   - สร้าง Agent ก่อน Client
   - สร้าง Client ก่อนเพิ่มรูปภาพ

4. **ข้อมูลที่จำเป็น:**
   - Agent: agentCode, agentName, hierarchyCode
   - Client: clientCode, refId (AgentCode)
   - Image: imageCode, refId (ClientCode), imageBase64

---

**Last Updated:** November 10, 2025

**API Base URL:** `http://localhost:5000`

**Swagger UI:** `http://localhost:5000`
