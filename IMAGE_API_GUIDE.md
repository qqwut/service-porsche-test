# Image API Documentation

## Overview
Complete CRUD API for managing images with base64 encoding/decoding. Images are linked to Clients via `RefId = ClientCode`.

## Endpoints

### 1. Image CRUD Operations

#### GET /api/Images
Get all images
```json
Response: [
  {
    "id": 1,
    "imageCode": "IMG0001",
    "refId": "CLI0001",
    "imageTypeCode": "PROFILE",
    "imageCategory": "PERSONAL",
    "fileName": "profile.jpg",
    "imageBase64": "base64encodeddata...",
    "contentType": "image/jpeg",
    "fileSize": 123456,
    "width": 800,
    "height": 600,
    "thumbnailBase64": "base64thumbnaildata...",
    "isPrimary": true,
    "displayOrder": 1,
    "isActive": true,
    "remark": null,
    "createdDate": "2025-11-10T06:30:00Z",
    "updatedDate": "2025-11-10T06:30:00Z"
  }
]
```

#### GET /api/Images/{id}
Get image by ID

#### GET /api/Images/code/{imageCode}
Get image by image code

#### GET /api/Images/ref/{refId}
Get all images by reference ID (ClientCode)
```bash
GET /api/Images/ref/CLI0001
```

#### POST /api/Images
Create a new image
```json
Request Body:
{
  "imageCode": "IMG0001",
  "refId": "CLI0001",
  "imageTypeCode": "PROFILE",
  "imageCategory": "PERSONAL",
  "fileName": "profile.jpg",
  "imageBase64": "/9j/4AAQSkZJRgABAQEAYABgAAD...",  // Base64 encoded image
  "contentType": "image/jpeg",
  "width": 800,
  "height": 600,
  "thumbnailBase64": "base64data...",  // Optional
  "isPrimary": true,
  "displayOrder": 1,
  "isActive": true,
  "remark": "Profile picture",
  "createdBy": "System"
}
```

#### PUT /api/Images/{id}
Update an existing image
```json
Request Body:
{
  "fileName": "updated_profile.jpg",
  "imageTypeCode": "PROFILE",
  "imageBase64": "newbase64data...",  // Optional - only if updating image data
  "isPrimary": true,
  "isActive": true,
  "updatedBy": "Admin"
}
```

#### DELETE /api/Images/{id}
Delete an image

### 2. Client Endpoints with Images (Enhanced)

#### GET /api/Clients/code/{clientCode}
Get client by code **with base64 images**
```bash
GET /api/Clients/code/CLI0001

Response:
{
  "id": 1,
  "clientCode": "CLI0001",
  "firstName": "สมชาย",
  "lastName": "ใจดี",
  "refId": "AG0001",
  "addresses": [...],
  "contacts": [...],
  "roles": [...],
  "images": [  // ✨ Images with base64 data
    {
      "id": 1,
      "imageCode": "IMG0001",
      "refId": "CLI0001",
      "imageTypeCode": "PROFILE",
      "fileName": "profile.jpg",
      "imageBase64": "/9j/4AAQSkZJRgABAQEAYABgAAD...",
      "contentType": "image/jpeg",
      "fileSize": 123456,
      "isPrimary": true,
      "isActive": true
    }
  ]
}
```

#### GET /api/Clients/agent/{agentCode}
Get **first client** by agent code **with base64 images** (returns single client, not array)
```bash
GET /api/Clients/agent/AG0001

Response: {
  "id": 1,
  "clientCode": "CLI0001",
  "firstName": "สมชาย",
  "refId": "AG0001",
  "addresses": [...],
  "contacts": [...],
  "roles": [...],
  "images": [  // ✨ Images with base64 data
    {
      "imageCode": "IMG0001",
      "imageBase64": "base64data...",
      ...
    }
  ]
}

Note: If agent has multiple clients, only the first one is returned.
Returns 404 if no client found for the agent.
```

## Image Type Codes (Examples)
- `PROFILE` - Profile picture
- `ID_CARD` - ID card image
- `PASSPORT` - Passport image
- `SIGNATURE` - Signature image
- `DOCUMENT` - General document

## Image Categories (Examples)
- `PERSONAL` - Personal images
- `DOCUMENT` - Document images
- `VERIFICATION` - Verification images

## Usage Example

### 1. Upload an image for a client
```javascript
// Convert image file to base64
const file = document.getElementById('imageInput').files[0];
const reader = new FileReader();
reader.readAsDataURL(file);
reader.onload = async () => {
  const base64 = reader.result.split(',')[1]; // Remove data:image/jpeg;base64,
  
  const response = await fetch('http://localhost:5000/api/Images', {
    method: 'POST',
    headers: { 'Content-Type': 'application/json' },
    body: JSON.stringify({
      imageCode: 'IMG' + Date.now(),
      refId: 'CLI0001',
      imageTypeCode: 'PROFILE',
      imageCategory: 'PERSONAL',
      fileName: file.name,
      imageBase64: base64,
      contentType: file.type,
      isPrimary: true,
      isActive: true,
      createdBy: 'User'
    })
  });
  
  const result = await response.json();
  console.log('Image uploaded:', result);
};
```

### 2. Get client with images and display them
```javascript
const response = await fetch('http://localhost:5000/api/Clients/code/CLI0001');
const client = await response.json();

// Display images
client.images.forEach(img => {
  const imgElement = document.createElement('img');
  imgElement.src = `data:${img.contentType};base64,${img.imageBase64}`;
  imgElement.alt = img.fileName;
  document.body.appendChild(imgElement);
});
```

### 3. Get all clients of an agent with their images
```javascript
const response = await fetch('http://localhost:5000/api/Clients/agent/AG0001');
const client = await response.json(); // Now returns single client object, not array

console.log(`Client: ${client.firstName} ${client.lastName}`);
console.log(`Images: ${client.images?.length || 0}`);

if (client.images) {
  client.images.forEach(img => {
    console.log(`  - ${img.fileName} (${img.imageTypeCode})`);
  });
}
```

## Testing with cURL

### Create an image
```bash
# First, convert an image to base64 (on Linux/Mac)
BASE64_IMAGE=$(base64 -w 0 myimage.jpg)

# Or on Windows PowerShell
# $BASE64_IMAGE = [Convert]::ToBase64String([IO.File]::ReadAllBytes("myimage.jpg"))

curl -X POST http://localhost:5000/api/Images \
  -H "Content-Type: application/json" \
  -d '{
    "imageCode": "IMG0001",
    "refId": "CLI0001",
    "imageTypeCode": "PROFILE",
    "fileName": "profile.jpg",
    "imageBase64": "'$BASE64_IMAGE'",
    "contentType": "image/jpeg",
    "isPrimary": true,
    "isActive": true
  }'
```

### Get client with images
```bash
curl http://localhost:5000/api/Clients/code/CLI0001
```

### Get all clients of agent with images
```bash
curl http://localhost:5000/api/Clients/agent/AG0001

# Note: Returns single client object (first client for the agent)
# Previously returned an array of clients
```

## Database Schema
```sql
-- T_IMAGE table structure
CREATE TABLE "T_IMAGE" (
    "ID" serial PRIMARY KEY,
    "UUID" uuid NOT NULL,
    "IMAGE_CODE" varchar NOT NULL UNIQUE,
    "REF_ID" varchar,  -- Links to CLIENT_CODE
    "IMAGE_TYPE_CODE" varchar,
    "IMAGE_CATEGORY" varchar,
    "FILE_NAME" varchar,
    "FILE_PATH" varchar,
    "FILE_URL" varchar,
    "CONTENT_TYPE" varchar,  -- MIME type
    "FILE_SIZE" bigint,
    "WIDTH" int,
    "HEIGHT" int,
    "IMAGE_DATA" bytea,  -- Binary image data
    "THUMBNAIL_URL" varchar,
    "THUMBNAIL_DATA" bytea,
    "IS_PRIMARY" boolean DEFAULT false,
    "DISPLAY_ORDER" int,
    "IS_ACTIVE" boolean DEFAULT true,
    "REMARK" text,
    "CREATED_DATE" timestamptz NOT NULL,
    "CREATED_BY" varchar,
    "UPDATED_DATE" timestamptz NOT NULL,
    "UPDATED_BY" varchar,
    FOREIGN KEY ("REF_ID") REFERENCES "T_CLIENT"("CLIENT_CODE")
);
```

## Notes
- Images are automatically converted between base64 (API) and binary (Database)
- FileSize is automatically calculated when creating/updating images
- Images are filtered by `IsActive = true` when querying by RefId
- All DateTime values are stored in UTC
- Maximum recommended image size: 5MB (adjust in application settings if needed)
- Thumbnails are optional and stored separately
