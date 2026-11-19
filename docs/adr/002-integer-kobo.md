# ADR-002: Represent Money Using Integer Kobo

**Status:** Accepted  
**Date:** November 19, 2026

## Context

Financial operations must produce precise monetary values. Floating-point types such as `float` and `double` can introduce precision errors because they represent numbers using binary floating-point approximations.

In a payout and reconciliation system, even small inaccuracies can cause ledger balances to disagree.

## Decision

All monetary amounts is represented as whole kobo using C# `long` (64-bit integer).

- ₦1 = 100 kobo.
- No floating-point types is used for monetary calculations.
- Arithmetic operations uses `checked` to detect overflow.
- The project currently supports NGN only. Multi-currency support is out of scope.

## Alternatives Considered

- **`double` / `float`:** Rejected because floating-point precision is unsuitable for exact financial calculations.
- **`decimal`:** Offers better decimal precision than floating-point types, but introduces major-to-minor unit conversion overhead and rounding ambiguity when integrating with payment providers.

- **Integer kobo (`long`):** Selected because it represents amounts exactly in the smallest unit used by this project, provides predictable arithmetic, and aligns directly with payment providers like Paystack that require monetary amounts in whole integer subunits (kobo for NGN), eliminating decimal conversion at the provider boundary while using 64-bit `long` to avoid 32-bit `int` overflow limits.

## Consequences

- Monetary values must be expressed in kobo, not naira with fractional decimals.
- Amounts are precise and cannot contain fractional kobo.
- Overflow throws an exception instead of silently wrapping.
- API and reporting boundaries must convert kobo into human-readable naira formats where appropriate.
- The domain is restricted to NGN until multi-currency support is deliberately introduced.

## Implementation

The decision is implemented in the `Money` value object in `PayoutReconciliationEngine.SharedKernel`, with checked addition and subtraction and unit tests covering arithmetic, overflow, zero and mixed signs.