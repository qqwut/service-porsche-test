# Quick Start Guide - Agent Hierarchy API

## Setup Steps

### 1. Prerequisites
- .NET 6 SDK installed
- PostgreSQL (local or remote)

### 2. Configure Database Connection

Edit `appsettings.json` to set your PostgreSQL connection string:

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Host=localhost;Port=5432;Database=agent_hierarchy;Username=postgres;Password=yourpassword"
  }
}
```

### 3. Run the Application

```bash
cd AgentHierarchyApi
dotnet restore
dotnet run
```

The API will be available at:
- **Swagger UI**: http://localhost:5000 (root)
- **API Base**: http://localhost:5000/api

The database will be automatically created and seeded with sample data on first run.

## Quick Test

### Test 1: Get All Agents
```bash
curl http://localhost:5000/api/agents
```

### Test 2: Get Hierarchy Tree
```bash
curl http://localhost:5000/api/agents/hierarchy-tree
```

### Test 3: Create New Agent
```bash
curl -X POST http://localhost:5000/api/agents \
  -H "Content-Type: application/json" \
  -d '{
    "agentCode": "AG0010",
    "agentName": "Test Agent",
    "hierarchyCode": "A1",
    "parentAgentId": 2
  }'
```

### Test 4: Get Agent by Rank
```bash
curl http://localhost:5000/api/agents/rank/AG
```

## Sample Data

After first run, you'll have:

**Hierarchy Structure:**
```
AE0001 (A9, AE) - Executive Agent 1
├── AL0001 (A6, AL) - Leader Agent 1
│   ├── AG0001 (A3, AG) - General Agent 1
│   └── AG0002 (A2, AG) - General Agent 2
└── AL0002 (A5, AL) - Leader Agent 2
    └── AG0003 (A1, AG) - General Agent 3
```

## Understanding the Hierarchy

### Ranks (3 levels)
- **AE** (Agent Executive) - Level 3 - Top tier
- **AL** (Agent Leader) - Level 2 - Middle tier
- **AG** (Agent General) - Level 1 - Base tier

### Hierarchy Codes (9 levels)
- **A1, A2, A3** → AG rank
- **A4, A5, A6** → AL rank
- **A7, A8, A9** → AE rank

### Rules
1. AG agents report to AL agents
2. AL agents report to AE agents
3. AE agents can be top-level or report to other AE agents
4. Each agent has a unique AgentCode (e.g., AG0001, AL0001, AE0001)
5. Each agent has one hierarchy code (A1-A9)

## API Endpoints Summary

| Endpoint | Method | Description |
|----------|--------|-------------|
| `/api/agents` | GET | Get all agents |
| `/api/agents/{id}` | GET | Get agent by ID |
| `/api/agents/code/{code}` | GET | Get agent by code |
| `/api/agents/rank/{rank}` | GET | Get agents by rank (AG/AL/AE) |
| `/api/agents/hierarchy/{code}` | GET | Get agents by hierarchy (A1-A9) |
| `/api/agents/hierarchy-tree` | GET | Get full hierarchy tree (top-down) |
| `/api/agents/hierarchy-tree/code/{agentCode}` | GET | Get hierarchy subtree by agent code |
| `/api/agents/upward-tree/code/{agentCode}` | GET | Get upward tree (parent chain) |
| `/api/agents` | POST | Create new agent |
| `/api/agents/{id}` | PUT | Update agent |
| `/api/agents/{id}` | DELETE | Delete agent (soft delete) |
| `/api/ranks` | GET | Get all ranks |
| `/api/hierarchies` | GET | Get all hierarchies |

## Troubleshooting

### Issue: Cannot connect to database
**Solution**: Check your SQL Server is running and connection string is correct in `appsettings.json`

### Issue: Port already in use
**Solution**: Stop the application using that port or change ports in `Properties/launchSettings.json`

### Issue: Migration errors
**Solution**: The app uses `EnsureCreated()` which automatically creates the database. If you want to use migrations:
```bash
dotnet ef migrations add InitialCreate
dotnet ef database update
```

## Next Steps

1. Open https://localhost:5001 in your browser to see Swagger UI
2. Try the API endpoints using Swagger's interactive interface
3. Create custom agents with different hierarchy structures
4. Query the hierarchy tree to visualize relationships
5. Customize the code for your specific requirements

## Example: Creating a Full Hierarchy

```bash
# 1. Create top-level AE agent
curl -X POST http://localhost:5000/api/agents \
  -H "Content-Type: application/json" \
  -d '{
    "agentCode": "AE0002",
    "agentName": "Executive Agent 2",
    "hierarchyCode": "A8",
    "parentAgentId": null
  }'

# 2. Create AL agent under AE0002 (assume ID is 7)
curl -X POST http://localhost:5000/api/agents \
  -H "Content-Type: application/json" \
  -d '{
    "agentCode": "AL0003",
    "agentName": "Leader Agent 3",
    "hierarchyCode": "A4",
    "parentAgentId": 7
  }'

# 3. Create AG agent under AL0003 (assume ID is 8)
curl -X POST http://localhost:5000/api/agents \
  -H "Content-Type: application/json" \
  -d '{
    "agentCode": "AG0010",
    "agentName": "General Agent 10",
    "hierarchyCode": "A1",
    "parentAgentId": 8
  }'

# 4. View the complete hierarchy
curl http://localhost:5000/api/agents/hierarchy-tree
```

## Support

For more detailed documentation, see [README.md](README.md)

For database schema details, see [DatabaseDesign.md](../DatabaseDesign.md)
