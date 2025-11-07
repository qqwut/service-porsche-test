# Agent Hierarchy Database Design

## Overview
This database design supports a hierarchical agent structure with three ranks (AG, AL, AE) and nine hierarchy levels (A1-A9).

## Hierarchy Structure
```
AE (Executive) -> AL (Leader) -> AG (General)
A7, A8, A9    ->  A4, A5, A6   -> A1, A2, A3
```

## Tables

### 1. Ranks
Stores the three main rank types.

| Column | Type | Description |
|--------|------|-------------|
| Id | int (PK) | Primary key |
| RankCode | varchar(10) | Rank code (AG, AL, AE) |
| RankName | varchar(50) | Rank display name |
| Level | int | Rank level (1=AG, 2=AL, 3=AE) |

**Sample Data:**
- AG, Agent General, Level 1
- AL, Agent Leader, Level 2
- AE, Agent Executive, Level 3

### 2. Hierarchies
Stores the nine hierarchy levels and their relationships.

| Column | Type | Description |
|--------|------|-------------|
| Id | int (PK) | Primary key |
| HierarchyCode | varchar(10) | Hierarchy code (A1-A9) |
| HierarchyName | varchar(50) | Hierarchy display name |
| RankId | int (FK) | Foreign key to Ranks table |
| Level | int | Hierarchy level (1-9) |

**Sample Data:**
- A1, Hierarchy A1, RankId=1 (AG), Level=1
- A2, Hierarchy A2, RankId=1 (AG), Level=2
- A3, Hierarchy A3, RankId=1 (AG), Level=3
- A4, Hierarchy A4, RankId=2 (AL), Level=4
- A5, Hierarchy A5, RankId=2 (AL), Level=5
- A6, Hierarchy A6, RankId=2 (AL), Level=6
- A7, Hierarchy A7, RankId=3 (AE), Level=7
- A8, Hierarchy A8, RankId=3 (AE), Level=8
- A9, Hierarchy A9, RankId=3 (AE), Level=9

### 3. Agents
Stores agent information with hierarchy relationships.

| Column | Type | Description |
|--------|------|-------------|
| Id | int (PK) | Primary key |
| AgentCode | varchar(20) | Agent code (e.g., AG0001) |
| AgentName | varchar(100) | Agent name |
| HierarchyId | int (FK) | Foreign key to Hierarchies table |
| ParentAgentId | int (FK, nullable) | Self-referencing foreign key for hierarchy tree |
| RankId | int (FK) | Foreign key to Ranks table |
| IsActive | bit | Active status |
| CreatedDate | datetime | Creation timestamp |
| UpdatedDate | datetime | Last update timestamp |

**Indexes:**
- Unique index on AgentCode
- Index on HierarchyId
- Index on ParentAgentId
- Index on RankId

## Relationships

1. **Ranks → Hierarchies**: One-to-Many (One Rank has many Hierarchies)
2. **Hierarchies → Agents**: One-to-Many (One Hierarchy has many Agents)
3. **Ranks → Agents**: One-to-Many (One Rank has many Agents)
4. **Agents → Agents**: Self-referencing (Parent-Child hierarchy)

## Hierarchy Tree Logic

The tree structure flows from AE → AL → AG:
- AE agents (A7, A8, A9) can be at the top or have other AE agents as parents
- AL agents (A4, A5, A6) report to AE agents
- AG agents (A1, A2, A3) report to AL agents

Example hierarchy:
```
Agent AE001 (A9)
├── Agent AL001 (A6)
│   ├── Agent AG001 (A3)
│   └── Agent AG002 (A2)
└── Agent AL002 (A5)
    └── Agent AG003 (A1)
```

## Entity Relationship Diagram

```
┌─────────────┐
│   Ranks     │
│─────────────│
│ Id (PK)     │
│ RankCode    │
│ RankName    │
│ Level       │
└──────┬──────┘
       │ 1
       │
       │ N
┌──────┴──────────┐
│   Hierarchies   │
│─────────────────│
│ Id (PK)         │
│ HierarchyCode   │
│ HierarchyName   │
│ RankId (FK)     │
│ Level           │
└──────┬──────────┘
       │ 1
       │
       │ N
┌──────┴──────────────┐
│      Agents         │
│─────────────────────│
│ Id (PK)             │
│ AgentCode           │
│ AgentName           │
│ HierarchyId (FK)    │
│ ParentAgentId (FK)  │◄──┐
│ RankId (FK)         │   │
│ IsActive            │   │
│ CreatedDate         │   │
│ UpdatedDate         │   │
└─────────────────────┘   │
       │                  │
       └──────────────────┘
          (Self-reference)
```
