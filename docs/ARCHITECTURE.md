# 🏗️ Architecture Overview (WIP)

> **Note:** This document captures high-level architectural decisions made during early development. It is a living document and will be expanded as the project grows.

## 1. Core Principles

- **Modular Monolith first:** All business capabilities (Inventory, ShoppingList, Recipes) start as modules within a single deployable unit. This keeps initial complexity low while preparing for future extraction into microservices.
- **Abstraction over Implementation:** Any external dependency (database, file storage, cloud services) is hidden behind an interface to support both Self-Hosted and Cloud modes from a single codebase.
- **Event-Driven within Modules:** Modules communicate via MediatR `INotification` events. Direct project references between modules are forbidden (except to `SharedKernel`).

## 2. Solution Structure

```text
src/
├── BuildingBlocks/
│ └── SharedKernel/ # Interfaces (IFileStorage, ITenantProvider), shared DTOs, domain events
├── Modules/
│ ├── Inventory/ # Domain, Application, Infrastructure, API
│ ├── ShoppingList/
│ └── Notifications/
└── Hosts/
└── FridgeApp.SelfHosted/ # Composition root for self-hosted deployment
```

## 3. Key Technical Decisions

| Decision | Rationale |
| :--- | :--- |
| **MediatR for CQRS** | Keeps controllers thin and use-cases explicit. Enables easy cross-module communication via events. |
| **EF Core + SQLite (Self-Hosted)** | Zero-configuration database for home users. Migration path to PostgreSQL kept open via `DbContext` abstraction. |
| **`TenantId` in all tables** | Present from day one, even if always `default` in self-hosted. Ensures a smooth transition to multi-tenant SaaS later. |
| **Dependency Inversion** | Host project wires up implementations (`LocalFileStorage` vs `S3FileStorage`) based on `DEPLOYMENT_MODE` env var. |

## 4. Future Evolution Path

- **Stage 1 (Current):** Pure self-hosted. All modules in-process.
- **Stage 2:** Extract `ProductCatalog` and `Identity` to cloud services. Self-hosted becomes a client.
- **Stage 3:** Extract `Social` to cloud service.
- **Stage 4:** Offer fully managed cloud version by running the same host with cloud-specific adapters (PostgreSQL, Redis, S3).

## 5. Important Constraints

- Self-hosted container **must not require internet** to perform core inventory operations (offline-first).
- Cloud API contracts **must be versioned** (`/api/v1/...`) to avoid breaking older self-hosted clients.
