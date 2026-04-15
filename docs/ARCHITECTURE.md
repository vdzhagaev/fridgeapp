# 🏗️ Architecture Overview

> **Note:** This document captures high-level architectural decisions. It is a living document and will be expanded as the project grows.

## 1. Core Principles

- **Modular Monolith first:** All business capabilities (Inventory, ShoppingList, Recipes, Subscription) start as modules within a single deployable unit. This keeps initial complexity low while preparing for future extraction into microservices.
- **Abstraction over Implementation:** External dependencies (database, file storage, payment gateway) are hidden behind interfaces to support both Self-Hosted and Cloud modes from a single codebase.
- **Event-Driven within Modules:** Modules communicate via MediatR `INotification` events. Direct project references between modules are forbidden (except to `SharedKernel`).
- **Open Core / Open Source:** The entire codebase is public under the MIT license. The cloud (SaaS) version is a hosted deployment of the same code with a paid subscription model that is **not** hidden in a private repository.

## 2. Solution Structure

```text
src/
├── BuildingBlocks/
│ └── SharedKernel/ # Interfaces (IFileStorage, ITenantProvider, IPaymentGateway), shared DTOs, domain events
├── Modules/
│ ├── Inventory/ # Domain, Application, Infrastructure, API
│ ├── ShoppingList/
│ ├── Recipes/
│ ├── Notifications/
│ └── Subscription/ # Public module handling Stripe/Paddle payments and tenant subscription status
├── Hosts/
│ ├── FridgeApp.SelfHosted/ # Composition root for self-hosted deployment (local mode)
│ └── FridgeApp.Cloud/ # Composition root for SaaS deployment (cloud mode)
└── Services/ # Future cloud microservices (ProductCatalog, Social)
```

## 3. Key Technical Decisions

| Decision | Rationale |
| :--- | :--- |
| **MediatR for CQRS** | Keeps controllers thin and use-cases explicit. Enables easy cross-module communication. |
| **EF Core + SQLite (Self-Hosted) / PostgreSQL (Cloud)** | Single DbContext abstraction supports both zero-config local storage and scalable cloud DB. |
| **`TenantId` in all tables** | Present from day one (default in self-hosted). Enables multi-tenant SaaS without rewriting data access. |
| **Dependency Inversion** | Host project wires up implementations (`LocalFileStorage` vs `S3FileStorage`) based on `DEPLOYMENT_MODE` env var. |
| **Open Source Subscription Module** | Payment processing (Stripe) is part of the public codebase. Sensitive keys are injected via environment variables. |

## 4. Deployment Modes

| Mode | Host Project | Database | File Storage | Payment |
| :--- | :--- | :--- | :--- | :--- |
| **Self-Hosted** | `FridgeApp.SelfHosted` | SQLite | Local disk | Not available |
| **Cloud (SaaS)** | `FridgeApp.Cloud` | PostgreSQL | S3 / Azure Blob | Stripe (optional, based on tenant subscription) |

## 5. Important Constraints

- Self-hosted container **must not require internet** for core inventory operations (offline-first).
- Cloud API contracts **must be versioned** (`/api/v1/...`) to avoid breaking older self-hosted clients.
- All payment-related code is public; security relies solely on secret keys stored outside the repository.
