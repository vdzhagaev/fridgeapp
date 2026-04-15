# 🗺️ FridgeApp Roadmap

This document outlines the planned evolution of FridgeApp from a simple self-hosted inventory tool to a full-featured hybrid platform.

## Milestone 0: Foundation & Architecture
**Goal:** Establish an extensible codebase and a minimal working self-hosted instance.

- [ ] Modular monolith solution structure (`SharedKernel`, modules `Inventory`, `ShoppingList`, `Notifications`, hosts `SelfHosted` and `Cloud`).
- [ ] MediatR for commands/queries and cross-module events.
- [ ] Core abstractions: `IFileStorage`, `ITenantProvider`, `IDateTime`.
- [ ] EF Core with SQLite for self-hosted persistence (`TenantId` field in all entities).
- [ ] Basic inventory CRUD (manual product entry, view, delete).
- [ ] Health checks and Dockerfile.
- [ ] Initial documentation (`README.md`, `ROADMAP.md`, `ARCHITECTURE.md`).

**Target:** `v0.1.0-alpha` – First working self-hosted image with inventory management.

---

## Milestone 1: Self-Hosted Core
**Goal:** A fully functional local product tracker with forecasting and shopping lists.

- [ ] Expiration date tracking and background checks with Quartz.NET.
- [ ] Consumption forecasting (simple moving average).
- [ ] ShoppingList module (manual add + automatic addition on depletion events).
- [ ] Configuration via environment variables.
- [ ] User documentation for self-hosted setup.

**Target:** `v0.2.0-alpha` – Complete self-hosted product tracking suite.

---

## Milestone 2: Global Product Catalog & Cloud Auth
**Goal:** Introduce a unified product directory and link self-hosted instances to cloud accounts.

- [ ] Cloud service `ProductCatalog` (ASP.NET Core, PostgreSQL).
- [ ] Self-hosted: local cache of concepts with delta sync, search with product suggestion.
- [ ] Device Flow OAuth2 to pair self-hosted with cloud accounts.

**Target:** `v0.3.0-beta` – Self-hosted uses global catalog and cloud authentication.

---

## Milestone 3: Social Network & Recipe Sharing
**Goal:** Enable users to publish recipes and discover content from others.

- [ ] Cloud service `Social` (posts, likes, comments, follows).
- [ ] Self-hosted: `Recipes` module, "Publish" action, "Community" feed, ingredient deduction.
- [ ] Optional: SignalR for real-time notifications.

**Target:** `v0.4.0-beta` – Full recipe exchange between users.

---

## Milestone 4: Store Integrations & Precise Nutrition
**Goal:** Turn shopping lists into actionable orders and provide accurate nutritional info.

- [ ] Extend `ProductCatalog` with `Variant → Store SKU` mapping.
- [ ] Cloud `ShoppingGateway` service (first store integration).
- [ ] Self-hosted: "Order" button, recipe nutrition calculation.

**Target:** `v0.5.0-rc` – Feature-complete release candidate.

---

## Milestone 5: Full SaaS with Subscription
**Goal:** Offer a cloud-hosted version with managed infrastructure and optional paid plans.

- [ ] Public `Subscription` module (Stripe integration for recurring payments).
- [ ] Multi-tenant cloud host (`FridgeApp.Cloud`) with PostgreSQL, Redis, S3.
- [ ] Data migration tool from self-hosted to cloud.
- [ ] Official SaaS launch at `app.fridgeapp.cloud`.

**Target:** `v1.0.0` – Public SaaS release with continued self-hosted support.
