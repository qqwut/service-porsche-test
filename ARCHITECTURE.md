# Agent Hierarchy API - Visual Architecture

## System Architecture Overview

```
┌─────────────────────────────────────────────────────────────────┐
│                         Client Applications                      │
│              (Browser, Postman, Mobile Apps, etc.)              │
└────────────────────────────┬────────────────────────────────────┘
                             │
                             │ HTTPS/HTTP
                             ▼
┌─────────────────────────────────────────────────────────────────┐
│                        Swagger UI / API                          │
│                    https://localhost:5001                        │
└────────────────────────────┬────────────────────────────────────┘
                             │
                             │ REST API Calls
                             ▼
┌─────────────────────────────────────────────────────────────────┐
│                         Controllers Layer                        │
│  ┌──────────────┐  ┌──────────────┐  ┌────────────────────┐   │
│  │   Agents     │  │    Ranks     │  │   Hierarchies      │   │
│  │ Controller   │  │  Controller  │  │    Controller      │   │
│  └──────────────┘  └──────────────┘  └────────────────────┘   │
└────────────────────────────┬────────────────────────────────────┘
                             │
                             │ Business Logic
                             ▼
┌─────────────────────────────────────────────────────────────────┐
│                         Services Layer                           │
│  ┌────────────────────────────────────────────────────────┐    │
│  │              AgentService (IAgentService)              │    │
│  │  - Validation Logic                                    │    │
│  │  - Hierarchy Tree Building                             │    │
│  │  - Business Rules Enforcement                          │    │
│  └────────────────────────────────────────────────────────┘    │
└────────────────────────────┬────────────────────────────────────┘
                             │
                             │ Data Access
                             ▼
┌─────────────────────────────────────────────────────────────────┐
│                       Repository Layer                           │
│  ┌────────────────────────────────────────────────────────┐    │
│  │         AgentRepository (IAgentRepository)             │    │
│  │  - CRUD Operations                                     │    │
│  │  - Query Methods                                       │    │
│  │  - Data Filtering                                      │    │
│  └────────────────────────────────────────────────────────┘    │
└────────────────────────────┬────────────────────────────────────┘
                             │
                             │ Entity Framework Core
                             ▼
┌─────────────────────────────────────────────────────────────────┐
│                    ApplicationDbContext                          │
│  ┌─────────────┐  ┌──────────────┐  ┌─────────────────┐       │
│  │   DbSet<    │  │   DbSet<     │  │   DbSet<        │       │
│  │   Rank>     │  │   Hierarchy> │  │   Agent>        │       │
│  └─────────────┘  └──────────────┘  └─────────────────┘       │
└────────────────────────────┬────────────────────────────────────┘
                             │
                             │ SQL Queries
                             ▼
┌─────────────────────────────────────────────────────────────────┐
│                      SQL Server Database                         │
│                      AgentHierarchyDB                            │
│  ┌─────────────┐  ┌──────────────┐  ┌─────────────────┐       │
│  │   Ranks     │  │ Hierarchies  │  │    Agents       │       │
│  │   Table     │  │    Table     │  │     Table       │       │
│  └─────────────┘  └──────────────┘  └─────────────────┘       │
└─────────────────────────────────────────────────────────────────┘
```

## Database Schema Diagram

```
┌─────────────────────┐
│       Ranks         │
├─────────────────────┤
│ Id (PK)             │
│ RankCode (UQ)       │
│ RankName            │
│ Level               │
└──────────┬──────────┘
           │
           │ 1:N
           │
           ▼
┌─────────────────────┐
│    Hierarchies      │
├─────────────────────┤
│ Id (PK)             │
│ HierarchyCode (UQ)  │
│ HierarchyName       │
│ RankId (FK)         │────┐
│ Level               │    │
└──────────┬──────────┘    │
           │                │
           │ 1:N            │ Lookup
           │                │
           ▼                │
┌─────────────────────┐    │
│      Agents         │    │
├─────────────────────┤    │
│ Id (PK)             │    │
│ AgentCode (UQ)      │    │
│ AgentName           │    │
│ HierarchyId (FK)    │────┘
│ ParentAgentId (FK)  │───┐
│ RankId (FK)         │───┼────┐
│ IsActive            │   │    │
│ CreatedDate         │   │    │
│ UpdatedDate         │   │    │
└─────────────────────┘   │    │
           ▲               │    │
           └───────────────┘    │
           Self-Reference       │
           (Parent-Child)       │
                                │
                    ┌───────────┘
                    │ Direct Lookup
                    └────────────────────────┐
                                             ▼
                              ┌─────────────────────┐
                              │       Ranks         │
                              │  (Rank Info)        │
                              └─────────────────────┘
```

## Hierarchy Structure Visualization

```
Level:          3 (AE)            2 (AL)            1 (AG)
                   │                  │                 │
Hierarchies:    A7 A8 A9          A4 A5 A6          A1 A2 A3
                   │                  │                 │
Flow:          Executive ────────> Leader ─────────> General
               (Top Tier)        (Mid Tier)       (Base Tier)
```

## Sample Data Hierarchy Tree

```
                    ┌─────────────────────┐
                    │  AE0001 (A9, AE)   │
                    │  Executive Agent 1  │
                    └──────────┬──────────┘
                               │
                ┌──────────────┴──────────────┐
                │                             │
        ┌───────▼────────┐           ┌───────▼────────┐
        │ AL0001 (A6, AL)│           │ AL0002 (A5, AL)│
        │ Leader Agent 1 │           │ Leader Agent 2 │
        └───────┬────────┘           └───────┬────────┘
                │                            │
        ┌───────┴────────┐                   │
        │                │                   │
┌───────▼────────┐ ┌────▼─────────┐  ┌──────▼────────┐
│ AG0001 (A3,AG) │ │AG0002 (A2,AG)│  │AG0003 (A1,AG) │
│General Agent 1 │ │General Agent2│  │General Agent 3│
└────────────────┘ └──────────────┘  └───────────────┘
```

## API Request Flow

### Example: Create Agent

```
1. Client Request
   POST /api/agents
   {
     "agentCode": "AG0010",
     "agentName": "New Agent",
     "hierarchyCode": "A1",
     "parentAgentId": 2
   }
          │
          ▼
2. AgentsController.CreateAgent()
   - Receives request
   - Validates model
          │
          ▼
3. AgentService.CreateAgentAsync()
   - Check agent code uniqueness
   - Validate hierarchy exists
   - Validate parent agent exists
   - Validate hierarchy rules (AG < AL < AE)
   - Create agent entity
          │
          ▼
4. AgentRepository.CreateAgentAsync()
   - Set timestamps
   - Add to DbContext
   - SaveChanges()
          │
          ▼
5. Database
   - Insert into Agents table
   - Return generated Id
          │
          ▼
6. Response
   {
     "id": 7,
     "agentCode": "AG0010",
     "agentName": "New Agent",
     "hierarchyCode": "A1",
     "rankCode": "AG",
     "parentAgentId": 2,
     "parentAgentCode": "AL0001",
     "isActive": true
   }
```

## Validation Rules Flow

```
┌─────────────────────────────────────────────────────────────┐
│                  Create/Update Agent Request                 │
└────────────────────────────┬────────────────────────────────┘
                             │
                             ▼
                 ┌───────────────────────┐
                 │ Agent Code Unique?    │
                 └───────┬───────────────┘
                         │ Yes
                         ▼
                 ┌───────────────────────┐
                 │ Hierarchy Exists?     │
                 └───────┬───────────────┘
                         │ Yes
                         ▼
                 ┌───────────────────────┐
                 │ Parent Agent Exists?  │
                 │ (if specified)        │
                 └───────┬───────────────┘
                         │ Yes
                         ▼
                 ┌───────────────────────┐
                 │ Validate Hierarchy:   │
                 │ Child level < Parent  │
                 │ AG(1) < AL(2) < AE(3) │
                 └───────┬───────────────┘
                         │ Valid
                         ▼
                 ┌───────────────────────┐
                 │   Create Agent        │
                 └───────────────────────┘
```

## Hierarchy Query Process

### Get Hierarchy Tree

```
1. Request: GET /api/agents/hierarchy-tree?rootAgentId=1
          │
          ▼
2. Get Root Agent(s)
   - If rootAgentId specified: get that agent
   - If not specified: get all top-level agents (ParentAgentId = null)
          │
          ▼
3. Get All Agents (with related data)
   - Include Rank
   - Include Hierarchy
   - Filter by IsActive = true
          │
          ▼
4. Build Tree Recursively
   For each root agent:
     - Create tree node
     - Find all children (where ParentAgentId = current agent Id)
     - Recursively build tree for each child
          │
          ▼
5. Return Tree Structure
   {
     "id": 1,
     "agentCode": "AE0001",
     "children": [
       {
         "id": 2,
         "agentCode": "AL0001",
         "children": [...]
       }
     ]
   }
```

## Data Flow Diagram

```
┌──────────┐    ┌──────────┐    ┌──────────┐    ┌──────────┐
│ Controller│───▶│ Service  │───▶│Repository│───▶│ Database │
│          │    │          │    │          │    │          │
│  HTTP    │    │ Business │    │   Data   │    │  SQL     │
│ Requests │    │  Logic   │    │  Access  │    │  Server  │
└──────────┘    └──────────┘    └──────────┘    └──────────┘
     │               │                │                │
     │               │                │                │
     ▼               ▼                ▼                ▼
┌──────────┐    ┌──────────┐    ┌──────────┐    ┌──────────┐
│  DTOs    │    │ Business │    │  Entity  │    │  Tables  │
│          │    │  Rules   │    │  Models  │    │  Rows    │
└──────────┘    └──────────┘    └──────────┘    └──────────┘
```

## Technology Stack

```
┌─────────────────────────────────────────────────────────────┐
│                    Presentation Layer                        │
│              Swagger UI / HTTP Controllers                   │
│                        (.NET 6)                              │
└────────────────────────────┬────────────────────────────────┘
                             │
┌────────────────────────────┴────────────────────────────────┐
│                     Business Layer                           │
│         Services + Repositories + DTOs                       │
│                    (C# Classes)                              │
└────────────────────────────┬────────────────────────────────┘
                             │
┌────────────────────────────┴────────────────────────────────┐
│                      Data Layer                              │
│     Entity Framework Core 6.0 + Entity Models                │
└────────────────────────────┬────────────────────────────────┘
                             │
┌────────────────────────────┴────────────────────────────────┐
│                    Database Layer                            │
│              SQL Server (LocalDB/Express/Full)               │
└─────────────────────────────────────────────────────────────┘
```

## Project File Structure

```
AgentHierarchyApi/
│
├── Controllers/           # HTTP Endpoints
│   ├── AgentsController.cs
│   ├── RanksController.cs
│   └── HierarchiesController.cs
│
├── Services/              # Business Logic
│   ├── IAgentService.cs
│   └── AgentService.cs
│
├── Repositories/          # Data Access
│   ├── IAgentRepository.cs
│   └── AgentRepository.cs
│
├── Models/                # Database Entities
│   ├── Agent.cs
│   ├── Rank.cs
│   └── Hierarchy.cs
│
├── DTOs/                  # Data Transfer Objects
│   └── AgentDto.cs
│
├── Data/                  # Database Context
│   └── ApplicationDbContext.cs
│
├── Properties/            # Launch Settings
│   └── launchSettings.json
│
├── Program.cs            # Application Entry Point
├── appsettings.json      # Configuration
└── AgentHierarchyApi.csproj  # Project File
```

## Deployment Architecture

```
Development Environment:
┌──────────────────────────────────────┐
│  Visual Studio / VS Code / Rider     │
│  ┌────────────────────────────────┐  │
│  │   AgentHierarchyApi Project    │  │
│  │   dotnet run                   │  │
│  │   https://localhost:5001       │  │
│  └────────────┬───────────────────┘  │
└───────────────┼──────────────────────┘
                │
                ▼
┌────────────────────────────────────────┐
│        SQL Server (LocalDB)            │
│        Database: AgentHierarchyDB      │
└────────────────────────────────────────┘

Production Environment (Example):
┌────────────────────────────────────────┐
│         IIS / Kestrel Server           │
│  ┌────────────────────────────────┐    │
│  │   AgentHierarchyApi.dll        │    │
│  │   Published Application        │    │
│  └────────────┬───────────────────┘    │
└───────────────┼────────────────────────┘
                │
                ▼
┌────────────────────────────────────────┐
│     SQL Server (Full/Express)          │
│     Database: AgentHierarchyDB         │
└────────────────────────────────────────┘
```

This visual architecture document provides a comprehensive overview of the system's structure, data flow, and relationships.
