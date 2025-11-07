# API Examples and Response Samples

## Table of Contents
1. [Get All Agents](#1-get-all-agents)
2. [Get Agent by ID](#2-get-agent-by-id)
3. [Get Agent by Code](#3-get-agent-by-code)
4. [Get Agents by Rank](#4-get-agents-by-rank)
5. [Get Agents by Hierarchy](#5-get-agents-by-hierarchy)
6. [Get Hierarchy Tree](#6-get-hierarchy-tree)
7. [Create Agent](#7-create-agent)
8. [Update Agent](#8-update-agent)
9. [Delete Agent](#9-delete-agent)
10. [Get All Ranks](#10-get-all-ranks)
11. [Get All Hierarchies](#11-get-all-hierarchies)

---

## 1. Get All Agents

**Request:**
```http
GET /api/agents
```

**Response:** `200 OK`
```json
[
  {
    "id": 1,
    "agentCode": "AE0001",
    "agentName": "Executive Agent 1",
    "hierarchyCode": "A9",
    "rankCode": "AE",
    "parentAgentId": null,
    "parentAgentCode": null,
    "isActive": true
  },
  {
    "id": 2,
    "agentCode": "AL0001",
    "agentName": "Leader Agent 1",
    "hierarchyCode": "A6",
    "rankCode": "AL",
    "parentAgentId": 1,
    "parentAgentCode": "AE0001",
    "isActive": true
  },
  {
    "id": 4,
    "agentCode": "AG0001",
    "agentName": "General Agent 1",
    "hierarchyCode": "A3",
    "rankCode": "AG",
    "parentAgentId": 2,
    "parentAgentCode": "AL0001",
    "isActive": true
  }
]
```

---

## 2. Get Agent by ID

**Request:**
```http
GET /api/agents/1
```

**Response:** `200 OK`
```json
{
  "id": 1,
  "agentCode": "AE0001",
  "agentName": "Executive Agent 1",
  "hierarchyCode": "A9",
  "rankCode": "AE",
  "parentAgentId": null,
  "parentAgentCode": null,
  "isActive": true
}
```

**Error Response:** `404 Not Found`
```json
"Agent with ID 999 not found"
```

---

## 3. Get Agent by Code

**Request:**
```http
GET /api/agents/code/AG0001
```

**Response:** `200 OK`
```json
{
  "id": 4,
  "agentCode": "AG0001",
  "agentName": "General Agent 1",
  "hierarchyCode": "A3",
  "rankCode": "AG",
  "parentAgentId": 2,
  "parentAgentCode": "AL0001",
  "isActive": true
}
```

---

## 4. Get Agents by Rank

### Get All AG Agents

**Request:**
```http
GET /api/agents/rank/AG
```

**Response:** `200 OK`
```json
[
  {
    "id": 4,
    "agentCode": "AG0001",
    "agentName": "General Agent 1",
    "hierarchyCode": "A3",
    "rankCode": "AG",
    "parentAgentId": 2,
    "parentAgentCode": "AL0001",
    "isActive": true
  },
  {
    "id": 5,
    "agentCode": "AG0002",
    "agentName": "General Agent 2",
    "hierarchyCode": "A2",
    "rankCode": "AG",
    "parentAgentId": 2,
    "parentAgentCode": "AL0001",
    "isActive": true
  }
]
```

### Get All AL Agents

**Request:**
```http
GET /api/agents/rank/AL
```

**Response:** `200 OK`
```json
[
  {
    "id": 2,
    "agentCode": "AL0001",
    "agentName": "Leader Agent 1",
    "hierarchyCode": "A6",
    "rankCode": "AL",
    "parentAgentId": 1,
    "parentAgentCode": "AE0001",
    "isActive": true
  },
  {
    "id": 3,
    "agentCode": "AL0002",
    "agentName": "Leader Agent 2",
    "hierarchyCode": "A5",
    "rankCode": "AL",
    "parentAgentId": 1,
    "parentAgentCode": "AE0001",
    "isActive": true
  }
]
```

---

## 5. Get Agents by Hierarchy

**Request:**
```http
GET /api/agents/hierarchy/A1
```

**Response:** `200 OK`
```json
[
  {
    "id": 6,
    "agentCode": "AG0003",
    "agentName": "General Agent 3",
    "hierarchyCode": "A1",
    "rankCode": "AG",
    "parentAgentId": 3,
    "parentAgentCode": "AL0002",
    "isActive": true
  }
]
```

---

## 6. Get Hierarchy Tree

### Get Complete Tree

**Request:**
```http
GET /api/agents/hierarchy-tree
```

**Response:** `200 OK`
```json
{
  "id": 1,
  "agentCode": "AE0001",
  "agentName": "Executive Agent 1",
  "hierarchyCode": "A9",
  "rankCode": "AE",
  "children": [
    {
      "id": 2,
      "agentCode": "AL0001",
      "agentName": "Leader Agent 1",
      "hierarchyCode": "A6",
      "rankCode": "AL",
      "children": [
        {
          "id": 4,
          "agentCode": "AG0001",
          "agentName": "General Agent 1",
          "hierarchyCode": "A3",
          "rankCode": "AG",
          "children": []
        },
        {
          "id": 5,
          "agentCode": "AG0002",
          "agentName": "General Agent 2",
          "hierarchyCode": "A2",
          "rankCode": "AG",
          "children": []
        }
      ]
    },
    {
      "id": 3,
      "agentCode": "AL0002",
      "agentName": "Leader Agent 2",
      "hierarchyCode": "A5",
      "rankCode": "AL",
      "children": [
        {
          "id": 6,
          "agentCode": "AG0003",
          "agentName": "General Agent 3",
          "hierarchyCode": "A1",
          "rankCode": "AG",
          "children": []
        }
      ]
    }
  ]
}
```

### Get Tree from Specific Root

**Request:**
```http
GET /api/agents/hierarchy-tree?rootAgentId=2
```

**Response:** `200 OK`
```json
{
  "id": 2,
  "agentCode": "AL0001",
  "agentName": "Leader Agent 1",
  "hierarchyCode": "A6",
  "rankCode": "AL",
  "children": [
    {
      "id": 4,
      "agentCode": "AG0001",
      "agentName": "General Agent 1",
      "hierarchyCode": "A3",
      "rankCode": "AG",
      "children": []
    },
    {
      "id": 5,
      "agentCode": "AG0002",
      "agentName": "General Agent 2",
      "hierarchyCode": "A2",
      "rankCode": "AG",
      "children": []
    }
  ]
}
```

---

## 7. Create Agent

### Create AG Agent (Success)

**Request:**
```http
POST /api/agents
Content-Type: application/json

{
  "agentCode": "AG0010",
  "agentName": "New General Agent",
  "hierarchyCode": "A1",
  "parentAgentId": 2
}
```

**Response:** `201 Created`
```json
{
  "id": 7,
  "agentCode": "AG0010",
  "agentName": "New General Agent",
  "hierarchyCode": "A1",
  "rankCode": "AG",
  "parentAgentId": 2,
  "parentAgentCode": "AL0001",
  "isActive": true
}
```

### Create AL Agent (Success)

**Request:**
```http
POST /api/agents
Content-Type: application/json

{
  "agentCode": "AL0005",
  "agentName": "New Leader Agent",
  "hierarchyCode": "A4",
  "parentAgentId": 1
}
```

**Response:** `201 Created`
```json
{
  "id": 8,
  "agentCode": "AL0005",
  "agentName": "New Leader Agent",
  "hierarchyCode": "A4",
  "rankCode": "AL",
  "parentAgentId": 1,
  "parentAgentCode": "AE0001",
  "isActive": true
}
```

### Create Top-Level AE Agent (Success)

**Request:**
```http
POST /api/agents
Content-Type: application/json

{
  "agentCode": "AE0002",
  "agentName": "New Executive Agent",
  "hierarchyCode": "A8",
  "parentAgentId": null
}
```

**Response:** `201 Created`
```json
{
  "id": 9,
  "agentCode": "AE0002",
  "agentName": "New Executive Agent",
  "hierarchyCode": "A8",
  "rankCode": "AE",
  "parentAgentId": null,
  "parentAgentCode": null,
  "isActive": true
}
```

### Create Agent - Duplicate Code (Error)

**Request:**
```http
POST /api/agents
Content-Type: application/json

{
  "agentCode": "AG0001",
  "agentName": "Duplicate Agent",
  "hierarchyCode": "A1",
  "parentAgentId": 2
}
```

**Response:** `400 Bad Request`
```json
"Agent code AG0001 already exists."
```

### Create Agent - Invalid Hierarchy (Error)

**Request:**
```http
POST /api/agents
Content-Type: application/json

{
  "agentCode": "AL0010",
  "agentName": "Invalid Leader",
  "hierarchyCode": "A4",
  "parentAgentId": 4
}
```

**Response:** `400 Bad Request`
```json
"Invalid hierarchy: AL (level 2) cannot be under AG (level 1). Hierarchy must be: AG < AL < AE"
```

---

## 8. Update Agent

### Update Agent (Success)

**Request:**
```http
PUT /api/agents/4
Content-Type: application/json

{
  "agentName": "Updated General Agent 1",
  "hierarchyCode": "A2",
  "parentAgentId": 2,
  "isActive": true
}
```

**Response:** `200 OK`
```json
{
  "id": 4,
  "agentCode": "AG0001",
  "agentName": "Updated General Agent 1",
  "hierarchyCode": "A2",
  "rankCode": "AG",
  "parentAgentId": 2,
  "parentAgentCode": "AL0001",
  "isActive": true
}
```

### Update Agent - Not Found (Error)

**Request:**
```http
PUT /api/agents/999
Content-Type: application/json

{
  "agentName": "Non-existent Agent",
  "hierarchyCode": "A1",
  "parentAgentId": null,
  "isActive": true
}
```

**Response:** `404 Not Found`
```json
"Agent with ID 999 not found"
```

---

## 9. Delete Agent

### Delete Agent (Success)

**Request:**
```http
DELETE /api/agents/6
```

**Response:** `204 No Content`

(No body returned)

### Delete Agent - Not Found (Error)

**Request:**
```http
DELETE /api/agents/999
```

**Response:** `404 Not Found`
```json
"Agent with ID 999 not found"
```

---

## 10. Get All Ranks

**Request:**
```http
GET /api/ranks
```

**Response:** `200 OK`
```json
[
  {
    "id": 1,
    "rankCode": "AG",
    "rankName": "Agent General",
    "level": 1
  },
  {
    "id": 2,
    "rankCode": "AL",
    "rankName": "Agent Leader",
    "level": 2
  },
  {
    "id": 3,
    "rankCode": "AE",
    "rankName": "Agent Executive",
    "level": 3
  }
]
```

---

## 11. Get All Hierarchies

**Request:**
```http
GET /api/hierarchies
```

**Response:** `200 OK`
```json
[
  {
    "id": 1,
    "hierarchyCode": "A1",
    "hierarchyName": "Hierarchy A1",
    "rankId": 1,
    "level": 1,
    "rank": {
      "id": 1,
      "rankCode": "AG",
      "rankName": "Agent General",
      "level": 1
    }
  },
  {
    "id": 2,
    "hierarchyCode": "A2",
    "hierarchyName": "Hierarchy A2",
    "rankId": 1,
    "level": 2,
    "rank": {
      "id": 1,
      "rankCode": "AG",
      "rankName": "Agent General",
      "level": 1
    }
  },
  {
    "id": 4,
    "hierarchyCode": "A4",
    "hierarchyName": "Hierarchy A4",
    "rankId": 2,
    "level": 4,
    "rank": {
      "id": 2,
      "rankCode": "AL",
      "rankName": "Agent Leader",
      "level": 2
    }
  },
  {
    "id": 7,
    "hierarchyCode": "A7",
    "hierarchyName": "Hierarchy A7",
    "rankId": 3,
    "level": 7,
    "rank": {
      "id": 3,
      "rankCode": "AE",
      "rankName": "Agent Executive",
      "level": 3
    }
  }
]
```

---

## HTTP Status Codes

| Status Code | Description | When It Occurs |
|-------------|-------------|----------------|
| 200 OK | Success | GET, PUT successful |
| 201 Created | Resource created | POST successful |
| 204 No Content | Success, no data | DELETE successful |
| 400 Bad Request | Validation error | Invalid data, business rule violation |
| 404 Not Found | Resource not found | GET, PUT, DELETE non-existent resource |
| 500 Internal Server Error | Server error | Unexpected system error |

---

## Testing with cURL

### Windows PowerShell

```powershell
# Get all agents
Invoke-WebRequest -Uri "https://localhost:5001/api/agents" -Method Get

# Create agent
$body = @{
    agentCode = "AG0020"
    agentName = "Test Agent"
    hierarchyCode = "A1"
    parentAgentId = 2
} | ConvertTo-Json

Invoke-WebRequest -Uri "https://localhost:5001/api/agents" `
    -Method Post `
    -Body $body `
    -ContentType "application/json"
```

### Linux/Mac Bash

```bash
# Get all agents
curl https://localhost:5001/api/agents

# Create agent
curl -X POST https://localhost:5001/api/agents \
  -H "Content-Type: application/json" \
  -d '{
    "agentCode": "AG0020",
    "agentName": "Test Agent",
    "hierarchyCode": "A1",
    "parentAgentId": 2
  }'
```

---

## Common Scenarios

### Scenario 1: Build a Complete Hierarchy

```bash
# 1. Create top-level AE
POST /api/agents
{
  "agentCode": "AE0010",
  "agentName": "Regional Executive",
  "hierarchyCode": "A9"
}

# 2. Create AL under AE (assume AE ID = 10)
POST /api/agents
{
  "agentCode": "AL0010",
  "agentName": "Team Leader",
  "hierarchyCode": "A6",
  "parentAgentId": 10
}

# 3. Create AG under AL (assume AL ID = 11)
POST /api/agents
{
  "agentCode": "AG0020",
  "agentName": "Field Agent",
  "hierarchyCode": "A3",
  "parentAgentId": 11
}

# 4. View the complete tree
GET /api/agents/hierarchy-tree?rootAgentId=10
```

### Scenario 2: Transfer Agent to New Parent

```bash
# Update agent's parent
PUT /api/agents/5
{
  "agentName": "General Agent 2",
  "hierarchyCode": "A2",
  "parentAgentId": 3,
  "isActive": true
}
```

### Scenario 3: Deactivate Agent

```bash
# Soft delete by setting isActive to false
PUT /api/agents/5
{
  "agentName": "General Agent 2",
  "hierarchyCode": "A2",
  "parentAgentId": 2,
  "isActive": false
}

# Or hard delete
DELETE /api/agents/5
```

---

This document provides comprehensive examples of all API endpoints with request/response samples.
