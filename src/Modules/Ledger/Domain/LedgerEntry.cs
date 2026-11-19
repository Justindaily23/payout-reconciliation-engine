using PayoutReconciliationEngine.SharedKernel;

namespace Ledger.Domain;

public class LedgerEntry
{
    public Guid Id { get; private set; }
    public Guid AccountId { get; private set; }
    public EntryType Type { get; private set; }
    public Money Amount { get; private set; }

    public LedgerEntry(Guid id, Guid accountId, EntryType type, Money amount)
    {
        if (id == Guid.Empty)
            throw new ArgumentException("Entry ID cannot be empty.", nameof(id));

        if (accountId == Guid.Empty)
            throw new ArgumentException("Account ID cannot be empty.", nameof(accountId));

        if (!Enum.IsDefined(type))
            throw new ArgumentOutOfRangeException(nameof(type));

        if (amount.Kobo <= 0)
            throw new ArgumentException("Entry amount must be greater than zero.", nameof(amount));

        Id = id;
        AccountId = accountId;
        Type = type;
        Amount = amount;
    }
}