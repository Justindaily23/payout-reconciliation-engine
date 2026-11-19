using PayoutReconciliationEngine.SharedKernel;
using System.Linq;

namespace Ledger.Domain;

public class LedgerTransaction
{
    public Guid Id { get; private set; }
    public IReadOnlyCollection<LedgerEntry> Entries { get; private set; }

    public LedgerTransaction(Guid id, IReadOnlyCollection<LedgerEntry> entries)
    {
        if (id == Guid.Empty)
            throw new ArgumentException("Transaction ID cannot be empty.", nameof(id));

        if (entries is null)
            throw new ArgumentNullException(nameof(entries));

        var copiedEntries = entries.ToArray();

        if (copiedEntries.Length < 2)
            throw new ArgumentException("A ledger transaction must contain at least two entries.", nameof(entries));

        if (copiedEntries.Any(entry => entry is null))
           throw new ArgumentException("Ledger entries cannot contain null.", nameof(entries));

        var totalDebits = copiedEntries
            .Where(entry => entry.Type == EntryType.Debit)
            .Sum(entry => entry.Amount.Kobo);

        var totalCredits = copiedEntries
            .Where(entry => entry.Type == EntryType.Credit)
            .Sum(entry => entry.Amount.Kobo);

        if (totalDebits != totalCredits)
            throw new ArgumentException(
                "Total debits must equal total credits in a ledger transaction.",
                nameof(entries)
            );


        Id = id;
        Entries = Array.AsReadOnly(copiedEntries);
    }
}