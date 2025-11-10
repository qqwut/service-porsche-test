# API Update - Client Endpoint Changes

## Change Summary

### Modified Endpoint: `GET /api/Clients/agent/{agentCode}`

**Previous Behavior:**
- Returned an **array** of all clients belonging to the specified agent
- Return type: `IEnumerable<ClientDto>`
- Example: AG0001 would return [CLI0001, CLI0002]

**New Behavior:**
- Returns **single client** (first client only) using FirstOrDefault pattern
- Return type: `ClientDto` (nullable)
- Example: AG0001 now returns only CLI0001
- Returns `404 Not Found` if no client exists for the agent

---

## API Endpoint Details

### GET /api/Clients/agent/{agentCode}

**Description:** Get the first client associated with the specified agent code (with base64 images included)

**URL:** `http://localhost:5000/api/Clients/agent/{agentCode}`

**Method:** `GET`

**URL Parameters:**
- `agentCode` (string, required) - The unique agent code (e.g., "AG0001", "AE0001")

**Success Response:**

**Code:** `200 OK`

**Content:**
```json
{
  "id": 1,
  "clientCode": "CLI0001",
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
      "id": 1,
      "clientCode": "CLI0001",
      "addressTypeCode": "HOME",
      "addressNo": "123/45",
      "postalCode": "10230",
      "isPrimary": true
    }
  ],
  "contacts": [
    {
      "id": 1,
      "clientCode": "CLI0001",
      "contactTypeCode": "MOBILE",
      "contactValue": "081-234-5678",
      "isPrimary": true
    },
    {
      "id": 2,
      "clientCode": "CLI0001",
      "contactTypeCode": "EMAIL",
      "contactValue": "somchai.j@email.com",
      "isPrimary": false
    }
  ],
  "roles": [
    {
      "id": 1,
      "clientCode": "CLI0001",
      "roleCode": "POLICY_OWNER",
      "policyNo": "POL001-2025",
      "referenceNo": "POL-2025-001"
    },
    {
      "id": 2,
      "clientCode": "CLI0001",
      "roleCode": "INSURED",
      "policyNo": "POL001-2025"
    }
  ],
  "images": [
    {
      "id": 1,
      "imageCode": "IMG0001",
      "refId": "CLI0001",
      "imageTypeCode": "PROFILE",
      "imageCategory": "PERSONAL",
      "fileName": "somchai_profile.jpg",
      "imageBase64": "iVBORw0KGgoAAAANSUhEUgAAAAEAAAAB...",
      "contentType": "image/jpeg",
      "fileSize": 70,
      "width": 800,
      "height": 600,
      "isPrimary": true,
      "isActive": true
    },
    {
      "id": 2,
      "imageCode": "IMG0002",
      "refId": "CLI0001",
      "imageTypeCode": "ID_CARD",
      "imageCategory": "DOCUMENT",
      "fileName": "somchai_idcard.jpg",
      "imageBase64": "iVBORw0KGgoAAAANSUhEUgAAAAEAAAAB...",
      "contentType": "image/jpeg",
      "fileSize": 70,
      "isPrimary": false,
      "isActive": true
    }
  ]
}
```

**Error Response:**

**Code:** `404 Not Found`

**Content:**
```json
"No client found for agent code 'AG9999'"
```

**OR**

**Code:** `500 Internal Server Error`

**Content:**
```json
"An error occurred while retrieving the client"
```

---

## Usage Examples

### cURL
```bash
# Get first client for agent AG0001
curl -X GET "http://localhost:5000/api/Clients/agent/AG0001"

# With formatted output
curl -X GET "http://localhost:5000/api/Clients/agent/AG0001" | jq
```

### PowerShell
```powershell
# Get first client for agent
Invoke-RestMethod -Uri "http://localhost:5000/api/Clients/agent/AG0001" -Method Get

# With formatted output
Invoke-RestMethod -Uri "http://localhost:5000/api/Clients/agent/AG0001" -Method Get | ConvertTo-Json -Depth 10
```

### JavaScript (Fetch API)
```javascript
// Get first client by agent code
const response = await fetch('http://localhost:5000/api/Clients/agent/AG0001');

if (response.ok) {
  const client = await response.json(); // Single object, not array
  console.log(`Client: ${client.firstName} ${client.lastName}`);
  console.log(`Images: ${client.images?.length || 0}`);
  
  // Display images
  if (client.images) {
    client.images.forEach(img => {
      const imgElement = document.createElement('img');
      imgElement.src = `data:${img.contentType};base64,${img.imageBase64}`;
      document.body.appendChild(imgElement);
    });
  }
} else if (response.status === 404) {
  console.log('No client found for this agent');
}
```

### C# (HttpClient)
```csharp
using var client = new HttpClient();
var response = await client.GetAsync("http://localhost:5000/api/Clients/agent/AG0001");

if (response.IsSuccessStatusCode)
{
    var clientDto = await response.Content.ReadFromJsonAsync<ClientDto>();
    Console.WriteLine($"Client: {clientDto.FirstName} {clientDto.LastName}");
    Console.WriteLine($"Images: {clientDto.Images?.Count ?? 0}");
}
else if (response.StatusCode == HttpStatusCode.NotFound)
{
    Console.WriteLine("No client found for this agent");
}
```

---

## Breaking Changes

⚠️ **IMPORTANT:** This is a **breaking change** for existing API consumers.

### What You Need to Update:

1. **Change expected response type:**
   - **Before:** Expected an array `ClientDto[]`
   - **After:** Expect a single object `ClientDto` or null

2. **Update array handling:**
   - **Before:** Loop through results with `forEach`, `map`, etc.
   - **After:** Handle single object directly

3. **Handle 404 errors:**
   - New endpoint returns `404` when no client exists
   - Previous version returned empty array `[]`

### Migration Examples:

**Before (Previous API):**
```javascript
const response = await fetch('/api/Clients/agent/AG0001');
const clients = await response.json(); // Array

clients.forEach(client => {
  console.log(client.clientCode);
});
```

**After (New API):**
```javascript
const response = await fetch('/api/Clients/agent/AG0001');

if (response.ok) {
  const client = await response.json(); // Single object
  console.log(client.clientCode);
} else if (response.status === 404) {
  console.log('No client found');
}
```

---

## Rationale

This change was made because:
1. **AgentCode is unique per client** - Each client belongs to only one agent
2. **FirstOrDefault pattern** - Returns the first match or null, which is more appropriate for unique relationships
3. **Consistent with single-resource pattern** - Similar to other endpoints like `/api/Clients/code/{clientCode}`
4. **Performance** - No need to load multiple clients when only one is expected

---

## Related Endpoints (Unchanged)

These endpoints remain unchanged and continue to work as before:

- `GET /api/Clients` - Get all clients (returns array)
- `GET /api/Clients/{id}` - Get client by ID (returns single object)
- `GET /api/Clients/code/{clientCode}` - Get client by code (returns single object)
- `POST /api/Clients` - Create new client
- `PUT /api/Clients/{id}` - Update client
- `DELETE /api/Clients/{id}` - Delete client

---

## Testing

### Test with Seed Data

The database includes sample data:
- **AG0001** has 2 clients: CLI0001, CLI0002
  - Endpoint will return only **CLI0001** (first client)
- **AE0001** has 2 clients: CLI0003, CLI0004
  - Endpoint will return only **CLI0003** (first client)

### Test Commands
```bash
# Should return CLI0001 (สมชาย ใจดี)
curl http://localhost:5000/api/Clients/agent/AG0001

# Should return CLI0003 (บริษัท ไทยประกันภัย จำกัด)
curl http://localhost:5000/api/Clients/agent/AE0001

# Should return 404
curl http://localhost:5000/api/Clients/agent/AG9999
```

---

## Support

If you need to retrieve **all clients** for an agent, you can:
1. Use `GET /api/Clients` and filter by `refId` on the client side
2. Request a new endpoint like `GET /api/Clients/agent/{agentCode}/all` if needed

---

**Last Updated:** November 10, 2025

**API Version:** v1.0

**Base URL:** `http://localhost:5000`
