# 🗺️ FridgeApp Roadmap

This document outlines the planned evolution of FridgeApp from a simple self-hosted inventory tool to a full-featured hybrid platform.

## Milestone 0: Foundation & Architecture
**Goal:** Establish an extensible codebase and a minimal working self-hosted instance.

- [ ] Modular monolith solution structure (`BuildingBlocks.SharedKernel`, modules `Inventory`, `ShoppingList`, `Notifications`, host `FridgeApp.SelfHosted`).
- [ ] MediatR for commands/queries and cross-module events.
- [ ] Core abstractions: `IFileStorage`, `ITenantProvider`, `IEmailSender`, `IDateTime`.
- [ ] EF Core with SQLite for self-hosted persistence (`TenantId` field in all entities).
- [ ] Basic inventory CRUD (manual product entry, view, delete).
- [ ] Health checks (database, disk).
- [ ] Dockerfile and `docker-compose.yml` for local execution.
- [ ] Initial documentation (`README.md`, `ROADMAP.md`, basic setup guide).

**Target:** `v0.1.0-alpha` – First working self-hosted image with inventory management.

---

## Milestone 1: Self-Hosted Core
**Goal:** A fully functional local product tracker with forecasting and shopping lists.

- [ ] Expiration date tracking and background checks with Quartz.NET.
- [ ] Consumption forecasting (simple moving average).
- [ ] ShoppingList module (manual add + automatic addition on `ProductDepletedEvent`).
- [ ] Configuration via environment variables.
- [ ] User documentation for self-hosted setup and maintenance.

**Target:** `v0.2.0-alpha` – Complete self-hosted product tracking suite.

---

## Milestone 2: Global Product Catalog & Cloud Auth
**Goal:** Introduce a unified product directory and link self-hosted instances to cloud accounts.

- [ ] Cloud service `ProductCatalog` (ASP.NET Core, PostgreSQL) with `ProductConcepts` and `ProductVariants`.
- [ ] Simple admin panel for moderation.
- [ ] Self-hosted: `HttpProductCatalogClient`, local concept cache with delta sync, search with product suggestion (pending mechanism).
- [ ] Device Flow OAuth2 (IdentityServer/Duende) to pair self-hosted instances with cloud accounts.

**Target:** `v0.3.0-beta` – Self-hosted uses global catalog and cloud authentication.

---

## Milestone 3: Social Network & Recipe Sharing
**Goal:** Enable users to publish recipes and discover content from others.

- [ ] Cloud service `Social` (posts, likes, comments, follows).
- [ ] Self-hosted: `Recipes` module (local creation with `ConceptId` binding), "Publish" action, "Community" feed, ingredient deduction when cooking a shared recipe.
- [ ] Optional: SignalR for real-time like/comment notifications.

**Target:** `v0.4.0-beta` – Full recipe exchange between users.

---

## Milestone 4: Store Integrations & Precise Nutrition
**Goal:** Turn shopping lists into actionable orders and provide accurate nutritional info.

- [ ] Extend `ProductCatalog` with `Variant → Store SKU` mapping.
- [ ] Cloud `ShoppingGateway` service (first store integration, e.g., local grocery API).
- [ ] Self-hosted: "Order" button in ShoppingList, recipe nutrition calculation (precise if brand selected, otherwise average per concept).

**Target:** `v0.5.0-rc` – Feature-complete release candidate.

---

## Milestone 5: Full SaaS Transition
**Goal:** Offer a cloud-hosted version that does not require self-hosting.

- [ ] Cloud host `FridgeApp.Cloud` (multi-tenant, cloud implementations for storage, cache, background jobs).
- [ ] Unified web/mobile client consuming cloud API directly.
- [ ] Data migration tool (encrypted backup from self-hosted to cloud).
- [ ] Monetization layer (premium subscriptions for advanced social features).

**Target:** `v1.0.0` – Public SaaS release with continued self-hosted support.
