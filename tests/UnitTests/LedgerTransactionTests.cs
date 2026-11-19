using Ledger.Domain;
using PayoutReconciliationEngine.SharedKernel;


namespace UnitTests;

public class LedgerTransactionTests
{
    [Fact]
    public void Constructor_ShouldAcceptBalancedEntries()
    {
        // Arrange
        var account1 = Guid.NewGuid();
        var account2 = Guid.NewGuid();

        // Act
        var entries = new List<LedgerEntry>
        {
            new(Guid.NewGuid(), account1, EntryType.Debit, new Money(500000)),
            new(Guid.NewGuid(), account2, EntryType.Credit, new Money(500000))
        };

        var transaction = new LedgerTransaction(Guid.NewGuid(), entries);
        
        Assert.Equal(2, transaction.Entries.Count);

    }

    [Fact]
    public void Constructor_ShouldRejectUnbalancedEntries()
    {
        var entries = new List<LedgerEntry>
        {
            new(Guid.NewGuid(), Guid.NewGuid(), EntryType.Debit, new Money(500000)),
            new(Guid.NewGuid(), Guid.NewGuid(), EntryType.Credit, new Money(400000))
        };

        Assert.Throws<ArgumentException>(() =>
            new LedgerTransaction(Guid.NewGuid(), entries));
    }

    [Fact]
    public void Constructor_ShouldRejectFewerThanTwoEntries()
    {
        var entries = new List<LedgerEntry>
        {
            new(Guid.NewGuid(), Guid.NewGuid(), EntryType.Debit, new Money(500000))
        };

        Assert.Throws<ArgumentException>(() =>
            new LedgerTransaction(Guid.NewGuid(), entries));
    }
}