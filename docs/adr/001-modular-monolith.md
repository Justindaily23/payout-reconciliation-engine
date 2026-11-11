# ADR-001: Adopt a Modular Monolith Architecture

**Status:** Accepted  
**Date:** November 11, 2026

## Context

The Payout & Reconciliation Engine needs a reliable backend architecture that supports multiple business capabilities, including identity management, payouts, ledger management, and reconciliation.

We need clear separation between these capabilities while keeping development, deployment, and infrastructure manageable.

## Decision

I have decided to adopt a **Modular Monolith architecture**.

The application will consist of independently structured business modules within one solution and deployable system.

The initial structure includes:

- **Identity:** User management, roles, and approval limits.
- **Payouts:** Payout processing, state management, and idempotency.
- **Ledger:** Financial accounts, transactions, and entries.
- **Reconciliation:** Statement imports and transaction matching.

Each module will own its domain, application, and infrastructure responsibilities.

Modules will not directly depend on one another. Communication between them will happen through explicitly defined public contracts.

The API and Worker will serve as separate application entry points.

## Alternatives Considered

### Traditional Layered Monolith

A conventional layered monolith was considered. However, organizing the entire application primarily around technical layers could make business capabilities harder to isolate as the system grows.

### Microservices

Microservices were considered but rejected for this stage because they introduce additional operational complexity, infrastructure costs, inter-service network communication, and distributed transaction challenges.

These costs are not justified by the current scope of the project.

## Consequences

**Benefits:**

- Reduced architectural and operational complexity.
- Lower infrastructure and deployment costs.
- In-process communication between modules.
- Simpler transaction coordination.
- Clear business boundaries within one system.

**Accepted trade-offs:**

- Modules cannot be independently deployed.
- Scaling is generally performed at the application level rather than independently per module.
- A shared deployment or infrastructure failure can affect multiple modules.

I accept these trade-offs in exchange for simpler development and operations while maintaining strict modular boundaries.
