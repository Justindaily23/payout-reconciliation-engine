namespace Ledger.Domain;

public class Account
{
    public Guid Id { get; private set; }
    public string Name { get; private set; }
    public AccountType Type { get; private set; }
    public Account(Guid id, string name, AccountType type)
    {
        if (id == Guid.Empty)
            throw new ArgumentException("Id cannot be empty.", nameof(id));

        if (string.IsNullOrWhiteSpace(name)) 
            throw new ArgumentException("Account name is required", nameof(name));

        if (!Enum.IsDefined(type)) 
            throw new ArgumentOutOfRangeException(nameof(type), "Invalid account type");

        Id = id;
        Name = name;
        Type = type;
    }
}