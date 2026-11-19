# Development Log 002: Money and Ledger Domain Foundation

**Date:** November 19, 2026

### What I did
- Implemented the `Money` value object using `long` to represent whole kobo.
- Added checked arithmetic for money addition and subtraction.
- Implemented the Ledger domain types: `Account`, `LedgerEntry`, and `LedgerTransaction`.
- Enforced the rule that every ledger transaction must contain at least two entries and have equal total debits and credits.
- Wrote unit tests covering money arithmetic, overflow, zero, mixed signs, and ledger transaction validation.
- Documented the integer kobo decision in ADR-002.
- Merged the implementation into `main` through GitHub Pull Request #1.

### What confused me
- Understanding how C# value types and reference types differ.
- Understanding how `IReadOnlyCollection<T>` works and why it is not the same as a dictionary.
- Understanding how LINQ operates on in-memory collections.
- Understanding how to protect a collection from external modification.

### What I can explain
- Why `Money` is implemented as a `readonly record struct`.
- Why integer kobo is preferable to floating-point arithmetic for this project.
- Why checked arithmetic is important for detecting overflow.
- Why a ledger transaction must balance before it can be accepted.
- Why ledger entries reference accounts through `AccountId`.

### What I cannot yet fully explain
- How EF Core maps domain objects to database tables.
- How database constraints can enforce ledger invariants independently of application code.
- How to make ledger postings atomic and protect against concurrent updates.

### Outcome
The Money and Ledger domain foundation was implemented, tested, and merged into `main` through PR #1.

**Next:** Introduce EF Core and Npgsql to persist the Ledger module in PostgreSQL.