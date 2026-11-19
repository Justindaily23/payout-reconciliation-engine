namespace PayoutReconciliationEngine.SharedKernel;

public readonly record struct Money
{
    public long Kobo { get; }
    public Money(long kobo)
    {
        Kobo = kobo;
    }

    public static Money operator +(Money left, Money right) => 
        new (checked(left.Kobo + right.Kobo));

    public static Money operator -(Money left, Money right) =>
        new (checked(left.Kobo - right.Kobo));

}


