using System;

public class UnitsExpWallet : IResourceKeeper
{
    public int UnitsExpAmount { get; private set; }

    public UnitsExpWallet(int unitsExpAmount)
    {
        UnitsExpAmount = unitsExpAmount;
    }

    public bool TrySpend(int spendAmount)
    {
        if (spendAmount < 0)
            throw new ArgumentOutOfRangeException(nameof(spendAmount));

        if (spendAmount > UnitsExpAmount)
            return false;

        UnitsExpAmount -= spendAmount;
        return true;
    }

    public void Add(int amount)
    {
        if (amount < 0)
            throw new ArgumentOutOfRangeException(nameof(amount));

        UnitsExpAmount += amount;
    }
}
