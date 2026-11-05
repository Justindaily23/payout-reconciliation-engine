# Payout & Reconciliation Engine

A backend that moves money out of a business safely and proves it: every payout happens exactly once, is approved by the right person, and is checked against what the payment provider actually recorded.

> **Status: work in progress.** Started November 2026. The checklist below shows what is built and what is planned. Nothing is listed as done until it has tests.

## The problem

Businesses that pay suppliers, staff or customers must be able to prove that each payout was sent once, was approved by the right person, and matches the bank's records. In practice, retries cause double payments, lost responses hide successful ones, and providers send duplicate or out-of-order webhooks. This project is built to stay correct under exactly those failures, and to show the evidence.

## What it does

- [ ] Payout requests with an approval workflow and a strict state machine
- [ ] Double-entry ledger with balanced, append-only entries
- [ ] Idempotent API: safe retries and duplicate requests
- [ ] Paystack (test mode) transfers with signature-verified webhooks
- [ ] Transactional outbox with a background worker (retries, dead-lettering)
- [ ] Reconciliation of internal records against imported statements
- [ ] Append-only audit log
- [ ] Token-based authentication with role and policy authorization (maker-checker)
- [ ] Structured logs, health checks, Docker deployment

## Failure scenarios this project demonstrates

Each one will have an automated test and a runnable demo, with saved output in `docs/failure-demos/`.

1. Two approvers approve the same payout at once
2. 50 payouts race for a balance that covers 10
3. The same request is sent 20 times
4. The server commits but the client never receives the response
5. The same webhook arrives repeatedly
6. A failure webhook arrives after a success webhook
7. The provider times out
8. The database goes down mid-operation
9. The worker crashes mid-batch
10. An unauthorized user tries to approve
11. An action arrives while the payout is in an invalid state

## Architecture

A modular monolith: one codebase, two processes (API and Worker), PostgreSQL as the only required infrastructure. Modules: Identity, Payouts, Ledger, Reconciliation.

Design decisions are recorded in [`docs/adr`](docs/adr).

## Tech stack

C# / .NET, ASP.NET Core, EF Core, PostgreSQL, Docker, GitHub Actions, xUnit, Testcontainers.

## Running it locally

<!-- Fill this in as soon as docker-compose.yml works. -->
Coming soon.

## Project structure

```
src/        API, Worker, shared kernel and modules
tests/      unit, integration and architecture tests
docs/adr/   architecture decision records
```

## Author
Justin
