# 📄 Tender Analyzer

> An AI-powered Tender Analysis Platform built with **.NET 10**, **Angular**, **PostgreSQL**, **Semantic AI/Ollama**, and **Clean Architecture**.

Tender Analyzer helps organizations analyze government and private tenders in minutes instead of hours by automatically extracting, processing, summarizing, and answering questions from tender documents using Large Language Models (LLMs).

> 🚧 **Project Status:** Active Development (MVP)

---

# ✨ Features

## Current Features

- ✅ Upload Tender Documents (PDF)
- ✅ Local File Storage
- ✅ PostgreSQL Metadata Storage
- ✅ PDF Text Extraction
- ✅ Page-wise Processing
- ✅ Intelligent Text Chunking
- ✅ AI-powered Tender Summary
- ✅ Hangfire Background Processing
- ✅ Swagger API Documentation
- ✅ Clean Architecture
- ✅ Dependency Injection
- ✅ Repository Pattern
- ✅ Ollama Integration (Local LLM)

---

## Planned Features

- 🔄 Structured Metadata Extraction
- 🔄 Tender Q&A (RAG)
- 🔄 pgvector Integration
- 🔄 Embeddings using nomic-embed-text
- 🔄 AI Risk Analysis
- 🔄 Clause Extraction
- 🔄 Eligibility Analysis
- 🔄 Bid / No Bid Recommendation
- 🔄 Tender Comparison
- 🔄 Multi-Agent Tender Analysis
- 🔄 Angular Dashboard
- 🔄 Authentication & Authorization
- 🔄 Multi-Tenant SaaS Support

---

# 🏗 Architecture

The solution follows **Clean Architecture** principles.

```
                ┌──────────────────────────┐
                │      Angular UI          │
                └────────────┬─────────────┘
                             │
                ┌────────────▼─────────────┐
                │        Web API           │
                └────────────┬─────────────┘
                             │
                ┌────────────▼─────────────┐
                │      Application         │
                │  Use Cases / Interfaces  │
                └────────────┬─────────────┘
                             │
        ┌────────────────────┼───────────────────┐
        │                    │                   │
        ▼                    ▼                   ▼
 Infrastructure          AI Project          Persistence
 Storage                Ollama Client       PostgreSQL
 PDF Processing         Prompting           EF Core
```

---

# 🧱 Solution Structure

```
TenderAnalyzer.sln

src/
│
├── TenderAnalyzer.Api
│
├── TenderAnalyzer.Application
│
├── TenderAnalyzer.Domain
│
├── TenderAnalyzer.Infrastructure
│
└── TenderAnalyzer.AI
```

---

# 🛠 Technology Stack

## Backend

- .NET 10
- ASP.NET Core Web API
- Entity Framework Core
- Clean Architecture
- Repository Pattern
- Dependency Injection

---

## AI

- Ollama
- Phi3 Mini
- Semantic AI Layer
- Prompt Engineering

Future:

- Qwen
- Llama
- Embeddings
- RAG
- Multi-Agent Workflow

---

## Database

- PostgreSQL
- EF Core
- Hangfire Storage

Future:

- pgvector

---

## Frontend

- Angular (Planned)

---

# 🚀 Current Workflow

```
Upload PDF
      │
      ▼
Store Document
      │
      ▼
Extract PDF Text
      │
      ▼
Create Pages
      │
      ▼
Create Text Chunks
      │
      ▼
Generate AI Summary
      │
      ▼
Store Summary
```

---

# 📦 Prerequisites

Install:

- .NET SDK 10
- Docker Desktop
- Git
- Visual Studio Code

---

# 🐳 Run Infrastructure

Start PostgreSQL and pgAdmin.

```bash
docker compose up -d
```

Verify containers

```bash
docker ps
```

Expected:

- PostgreSQL
- pgAdmin

---

# 🤖 Install Ollama

Install Ollama

https://ollama.com

Pull models

```bash
ollama pull phi3:mini
ollama pull nomic-embed-text
```

Verify

```bash
ollama list
```

---

# ⚙ Configuration

Update

```
appsettings.json
```

Connection String

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Host=localhost;Port=5432;Database=tenderdb;Username=postgres;Password=postgres"
  }
}
```

AI Configuration

```json
{
  "AI": {
    "Provider": "Ollama",
    "BaseUrl": "http://localhost:11434",
    "ChatModel": "phi3:mini",
    "EmbeddingModel": "nomic-embed-text:latest"
  }
}
```

---

# 🗄 Database

Create migrations

```bash
dotnet ef migrations add InitialCreate \
--project TenderAnalyzer.Infrastructure \
--startup-project TenderAnalyzer.Api
```

Update database

```bash
dotnet ef database update \
--project TenderAnalyzer.Infrastructure \
--startup-project TenderAnalyzer.Api
```

---

# ▶ Run Application

```bash
dotnet run --project TenderAnalyzer.Api
```

Swagger

```
https://localhost:5001/swagger
```

(or the URL shown in the console)

---

# 📚 Current APIs

## Upload Tender

```
POST /api/tenders/upload
```

---

## Process Tender

```
POST /api/processing/{tenderId}
```

---

## Generate Summary

```
POST /api/tender-summary/{tenderId}
```

---

## Get Summary

```
GET /api/tender-summary/{tenderId}
```

---

## AI Playground

```
POST /api/ai/chat
```

---

# 📊 Current Development Progress

| Module | Status |
|---------|--------|
| Clean Architecture | ✅ |
| Upload API | ✅ |
| PostgreSQL | ✅ |
| EF Core | ✅ |
| File Storage | ✅ |
| PDF Processing | ✅ |
| Text Chunking | ✅ |
| AI Integration | ✅ |
| Summary Generation | ✅ |
| Angular UI | 🚧 |
| Embeddings | 🚧 |
| RAG | 🚧 |
| Tender Q&A | 🚧 |
| Multi-Agent AI | 🚧 |

---

# 📈 Roadmap

## Phase 1

- Upload
- PDF Processing
- Chunking
- AI Summary

## Phase 2

- Metadata Extraction
- AI Playground
- Prompt Management

## Phase 3

- Embeddings
- pgvector
- RAG

## Phase 4

- Tender Q&A
- Clause Analysis
- Compliance Analysis

## Phase 5

- Multi-Agent AI
- Bid Recommendation
- Tender Comparison

## Phase 6

- Angular Dashboard
- Authentication
- SaaS Deployment

---

# 🎯 Vision

The goal is to build a production-ready AI platform that helps organizations:

- Analyze tenders faster
- Reduce manual effort
- Improve bid decision-making
- Extract structured insights
- Ask natural language questions against tender documents
- Compare multiple tenders intelligently

---

# 🤝 Contributing

Contributions, ideas and feedback are always welcome.

Feel free to open an Issue or submit a Pull Request.

---

# 📄 License

MIT License