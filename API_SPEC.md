# Agent Hierarchy API — Specification (EN/TH)

Base URL (Development):

* HTTPS: <https://localhost:5001>
* HTTP: <http://localhost:5000>

Authentication:

* None (Development). CORS Policy: AllowAll

Content-Type:

* application/json

Error Format:

* 400 Bad Request — Validation message string
* 404 Not Found — Error message string
* 500 Internal Server Error — Error message string

---

## Data Models

### Rank

* id: number
* rankCode: string (AG|AL|AE)
* rankName: string
* level: number

### Hierarchy

* id: number
* hierarchyCode: string (A1-A9)
* hierarchyName: string
* rankId: number
* level: number

### Agent

* id: number
* agentCode: string (unique)
* agentName: string
* hierarchyId: number
* parentAgentId: number | null
* rankId: number
* isActive: boolean
* createdDate: string (ISO 8601, UTC)
* updatedDate: string (ISO 8601, UTC)

DTOs (responses)

* AgentDto: { id, agentCode, agentName, hierarchyCode, rankCode, parentAgentId, parentAgentCode, isActive }
* AgentHierarchyTreeDto: { id, agentCode, agentName, hierarchyCode, rankCode, children: AgentHierarchyTreeDto[] }
* AgentUpwardTreeDto: { id, agentCode, agentName, hierarchyCode, rankCode, parentAgentId, parent: AgentUpwardTreeDto | null }

### License

* id: number
* agentId: number (FK Agent)
* licenseNumber: string (unique)
* issueDate: string (ISO 8601, UTC)
* expiryDate: string | null (ISO 8601, UTC)
* isActive: boolean
* createdDate: string (ISO 8601, UTC)
* updatedDate: string (ISO 8601, UTC)

---

## Ranks

### GET /api/ranks

* Description: Get all ranks ordered by level
* Response: 200 OK — Rank[]

### GET /api/ranks/{rankCode}

* Description: Get rank by code (AG|AL|AE)
* Response: 200 OK — Rank
* 404 Not Found — if not exists

---

## Hierarchies

### GET /api/hierarchies

* Description: Get all hierarchies ordered by level
* Response: 200 OK — Hierarchy[]

### GET /api/hierarchies/{hierarchyCode}

* Description: Get hierarchy by code (A1-A9)
* Response: 200 OK — Hierarchy
* 404 Not Found — if not exists

### GET /api/hierarchies/rank/{rankCode}

* Description: Get hierarchies by rank code (AG|AL|AE)
* Response: 200 OK — Hierarchy[]

---

## Agents

### GET /api/agents

* Description: Get all active agents
* Response: 200 OK — AgentDto[]

### GET /api/agents/{id}

* Description: Get agent by ID
* Response: 200 OK — AgentDto
* 404 Not Found — if not exists

### GET /api/agents/code/{agentCode}

* Description: Get agent by code
* Response: 200 OK — AgentDto
* 404 Not Found — if not exists

### GET /api/agents/rank/{rankCode}

* Description: Filter agents by rank (AG|AL|AE)
* Response: 200 OK — AgentDto[]

### GET /api/agents/hierarchy/{hierarchyCode}

* Description: Filter agents by hierarchy (A1-A9)
* Response: 200 OK — AgentDto[]

### GET /api/agents/hierarchy-tree?rootAgentId={id}

* Description: Get hierarchy tree; if rootAgentId omitted and multiple roots, returns a virtual root
* Response: 200 OK — AgentHierarchyTreeDto

### GET /api/agents/hierarchy-tree/code/{agentCode}

* Description: Get hierarchy tree starting from agent code
* Response: 200 OK — AgentHierarchyTreeDto

### GET /api/agents/upward-tree/code/{agentCode}

* Description: Get upward path from agent to top level
* Response: 200 OK — AgentUpwardTreeDto

### POST /api/agents

* Description: Create agent
* Request Body (AgentCreateDto):

```json
{
  "agentCode": "AG0004",
  "agentName": "General Agent 4",
  "hierarchyCode": "A3",
  "parentAgentId": 2
}
```

* Responses:
  * 201 Created — AgentDto
  * 400 Bad Request — validation failure (duplicate code, invalid hierarchy rules)

### PUT /api/agents/{id}

* Description: Update agent
* Request Body (AgentUpdateDto):

```json
{
  "agentName": "Updated Name",
  "hierarchyCode": "A3",
  "parentAgentId": 2,
  "isActive": true
}
```

* Responses:
  * 200 OK — AgentDto
  * 404 Not Found — if not exists

### DELETE /api/agents/{id}

* Description: Soft delete agent
* Response: 204 No Content | 404 Not Found

---

## Licenses

Notes:

* Dates must be UTC or will be normalized to UTC server-side.
* LicenseNumber must be unique.

### GET /api/licenses

* Description: Get all active licenses
* Response: 200 OK — LicenseDto[]

### GET /api/licenses/{id}

* Description: Get license by id
* Response: 200 OK — LicenseDto | 404 Not Found

### GET /api/licenses/agent/{agentId}

* Description: Get licenses for a given agent
* Response: 200 OK — LicenseDto[]

### POST /api/licenses

* Description: Create new license
* Request Body (LicenseCreateDto):

```json
{
  "agentId": 4,
  "licenseNumber": "LIC-AG0001",
  "issueDate": "2025-11-08",
  "expiryDate": "2026-11-08"
}
```

* Responses:
  * 201 Created — LicenseDto
  * 400 Bad Request — validation failure (duplicate, date range)

### PUT /api/licenses/{id}

* Description: Update license
* Request Body (LicenseUpdateDto):

```json
{
  "licenseNumber": "LIC-AG0001-UPDATED",
  "issueDate": "2025-11-09",
  "expiryDate": "2026-11-09",
  "isActive": true
}
```

* Responses:
  * 200 OK — LicenseDto
  * 404 Not Found — if not exists

### DELETE /api/licenses/{id}

* Description: Soft delete license
* Response: 204 No Content | 404 Not Found

---

## Examples (curl)

### Create Agent

```bash
curl -k -X POST https://localhost:5001/api/agents \
  -H "Content-Type: application/json" \
  -d '{
    "agentCode": "AG0004",
    "agentName": "General Agent 4",
    "hierarchyCode": "A3",
    "parentAgentId": 2
  }'
```

### Create License

```bash
curl -k -X POST https://localhost:5001/api/licenses \
  -H "Content-Type: application/json" \
  -d '{
    "agentId": 4,
    "licenseNumber": "LIC-AG0001",
    "issueDate": "2025-11-08",
    "expiryDate": "2026-11-08"
  }'
```

---

## สเปค API (ภาษาไทยย่อ)

Base URL (Dev): <https://localhost:5001>

รูปแบบข้อมูล: JSON

รูปแบบ Error: 400 / 404 / 500 (ข้อความเป็นสตริง)

ทรัพยากรหลัก:

* Rank (AG, AL, AE)
* Hierarchy (A1-A9)
* Agent (โครงสร้างลำดับชั้น AE > AL > AG)
* License (ใบอนุญาตผูกกับ Agent)

หมายเหตุ License:

* วันที่ควรเป็น UTC (หรือระบบจะปรับเป็น UTC ให้)
* เลขใบอนุญาตต้องไม่ซ้ำ

ดูตัวอย่างการเรียกในส่วน Examples ด้านบน
