# Agent Hierarchy API

A .NET 6 Web API (EF Core + PostgreSQL) for managing an agent hierarchy with three ranks (AG, AL, AE) and nine hierarchy levels (A1–A9).

## Overview

This API provides a comprehensive system for managing agents in a hierarchical structure where:
- **AE (Agent Executive)** - Top level (A7, A8, A9)
- **AL (Agent Leader)** - Middle level (A4, A5, A6)
- **AG (Agent General)** - Base level (A1, A2, A3)

The hierarchy flows from **AE → AL → AG** (Executive → Leader → General).

## Features

- ✅ Complete CRUD operations for agents
- ✅ Hierarchical tree structure (parent-child relationships)
- ✅ Three ranks: AG, AL, AE
- ✅ Nine hierarchy levels: A1-A9
- ✅ Automatic hierarchy validation
- ✅ Query agents by rank or hierarchy
- ✅ Get complete hierarchy tree visualization
- ✅ Soft delete support
- ✅ Swagger UI documentation

## Prerequisites

- [.NET 6 SDK](https://dotnet.microsoft.com/download/dotnet/6.0)
- PostgreSQL 13+ (or compatible)
- Visual Studio Code / Visual Studio / Rider (optional)

## Database Design

### Tables
1. **Ranks** - Stores rank types (AG, AL, AE)
2. **Hierarchies** - Stores hierarchy levels (A1-A9) with rank relationships
3. **Agents** - Stores agent information with hierarchical relationships

See [DatabaseDesign.md](../DatabaseDesign.md) for detailed schema information.

## Getting Started

### 1. Clone or Download the Project

Navigate to the project directory:
```bash
cd AgentHierarchyApi
```

### 2. Configure Database Connection

Update the PostgreSQL connection string in `appsettings.json`:

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Host=localhost;Port=5432;Database=agent_hierarchy;Username=postgres;Password=yourpassword"
  }
}
```

### 3. Restore Dependencies

```bash
dotnet restore
```

### 4. Run the Application

```bash
dotnet run
```

The API will start and be available at:
- HTTP: `http://localhost:5000`
- Swagger UI: `http://localhost:5000` (root path in Development)

The database will be automatically created and seeded with sample data on first run.

### 5. Using Migrations (Optional)

If you prefer to use migrations instead of EnsureCreated:

```bash
# Create initial migration
dotnet ef migrations add InitialCreate

# Apply migration to database
dotnet ef database update
```

## API Endpoints

### Agents

| Method | Endpoint | Description |
|--------|----------|-------------|
| GET | `/api/agents` | Get all active agents |
| GET | `/api/agents/{id}` | Get agent by ID |
| GET | `/api/agents/code/{agentCode}` | Get agent by code (e.g., AG0001) |
| GET | `/api/agents/rank/{rankCode}` | Get agents by rank (AG, AL, or AE) |
| GET | `/api/agents/hierarchy/{hierarchyCode}` | Get agents by hierarchy (A1-A9) |
| GET | `/api/agents/hierarchy-tree?rootAgentId={id}` | Get hierarchy tree structure (top-down) |
| GET | `/api/agents/hierarchy-tree/code/{agentCode}` | Get hierarchy subtree starting at agent code |
| GET | `/api/agents/upward-tree/code/{agentCode}` | Get upward tree (parent chain) for agent code |
| POST | `/api/agents` | Create new agent |
| PUT | `/api/agents/{id}` | Update agent |
| DELETE | `/api/agents/{id}` | Delete agent (soft delete) |

### Ranks

| Method | Endpoint | Description |
|--------|----------|-------------|
| GET | `/api/ranks` | Get all ranks |
| GET | `/api/ranks/{rankCode}` | Get rank by code |

### Hierarchies

| Method | Endpoint | Description |
|--------|----------|-------------|
| GET | `/api/hierarchies` | Get all hierarchies (projected DTO to avoid cycles) |
| GET | `/api/hierarchies/{hierarchyCode}` | Get hierarchy by code |
| GET | `/api/hierarchies/rank/{rankCode}` | Get hierarchies by rank (AG/AL/AE) |

Hierarchy responses are shaped as:

```json
{
  "id": 4,
  "hierarchyCode": "A4",
  "hierarchyName": "Hierarchy A4",
  "level": 4,
  "rankId": 2,
  "rank": { "id": 2, "rankCode": "AL", "rankName": "Agent Leader", "level": 2 }
}
```

## API Usage Examples

### Create a New Agent

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

**Response:**
```json
{
  "id": 7,
  "agentCode": "AG0010",
  "agentName": "New General Agent",
  "hierarchyCode": "A1",
  "rankCode": "AG",
  "parentAgentId": 2,
  "parentAgentCode": "AL0001",
  "leaderCode": "AL0001",
  "isActive": true
}
```

### Get Hierarchy Tree

**Request:**
```http
GET /api/agents/hierarchy-tree
```

**Response:**
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
          "leaderCode": "AL0001",
          "children": []
        }
      ]
    }
  ]
}
```

### Get Agents by Rank

**Request:**
```http
GET /api/agents/rank/AG
```

**Response:**
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
    "leaderCode": "AL0001",
    "isActive": true
  }
]
```

### Update Agent

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

You can also use this endpoint to “promote” an agent by changing `hierarchyCode` (e.g., A7→A4 for AE→AL) and setting an appropriate `parentAgentId` according to the hierarchy rules.

## Hierarchy Rules

The API enforces the following hierarchy rules:

1. **Rank Levels**: AG (1) < AL (2) < AE (3)
2. **Parent-Child Relationships**:
   - AE agents can have no parent (top level) or another AE as parent
   - AL agents must have an AE agent as parent
   - AG agents must have an AL agent as parent
3. **Validation**: The API automatically validates that lower ranks cannot be parents of higher ranks

## Sample Data

The database is seeded with the following sample data:

**Ranks:**
- AG (Agent General) - Level 1
- AL (Agent Leader) - Level 2
- AE (Agent Executive) - Level 3

**Hierarchies:**
- A1, A2, A3 → AG rank
- A4, A5, A6 → AL rank
- A7, A8, A9 → AE rank

**Sample Agents:**
- AE0001 (A9) - Top level
  - AL0001 (A6) - Reports to AE0001
    - AG0001 (A3) - Reports to AL0001
    - AG0002 (A2) - Reports to AL0001
  - AL0002 (A5) - Reports to AE0001
    - AG0003 (A1) - Reports to AL0002

## Project Structure

```
AgentHierarchyApi/
├── Controllers/
│   ├── AgentsController.cs       # Main agent endpoints
│   ├── RanksController.cs        # Rank endpoints
│   └── HierarchiesController.cs  # Hierarchy endpoints
├── Data/
│   └── ApplicationDbContext.cs   # EF Core DbContext
├── DTOs/
│   └── AgentDto.cs              # Data transfer objects
├── Models/
│   ├── Agent.cs                 # Agent entity
│   ├── Rank.cs                  # Rank entity
│   └── Hierarchy.cs             # Hierarchy entity
├── Repositories/
│   ├── IAgentRepository.cs      # Repository interface
│   └── AgentRepository.cs       # Repository implementation
├── Services/
│   ├── IAgentService.cs         # Service interface
│   └── AgentService.cs          # Business logic
├── Program.cs                   # Application entry point
├── appsettings.json            # Configuration
└── AgentHierarchyApi.csproj    # Project file
```

## Technologies Used

- **Framework**: .NET 6
- **ORM**: Entity Framework Core 6
- **Database**: PostgreSQL (Npgsql provider)
- **API Documentation**: Swagger/OpenAPI
- **Architecture**: Repository Pattern + Service Layer

## Error Handling

The API returns appropriate HTTP status codes:

- `200 OK` - Successful GET/PUT requests
- `201 Created` - Successful POST requests
- `204 No Content` - Successful DELETE requests
- `400 Bad Request` - Validation errors
- `404 Not Found` - Resource not found
- `500 Internal Server Error` - Server errors

## Development

### Build the Project

```bash
dotnet build
```

### Run Tests (if implemented)

```bash
dotnet test
```

### Publish the Application

```bash
dotnet publish -c Release -o ./publish
```

## Troubleshooting

### Database Connection Issues

If you encounter database connection errors:

1. Verify SQL Server is running
2. Check the connection string in `appsettings.json`
3. Ensure the database user has appropriate permissions
4. For LocalDB: `Server=(localdb)\\mssqllocaldb;Database=AgentHierarchyDB;Trusted_Connection=True;`

### Port Already in Use

If port 5000/5001 is already in use, modify `launchSettings.json` or set environment variables:

```bash
export ASPNETCORE_URLS="http://localhost:5010;https://localhost:5011"
dotnet run
```

## License

This project is for demonstration purposes.

## Support

For issues or questions, please check the Swagger UI documentation at the root URL when running the application.
