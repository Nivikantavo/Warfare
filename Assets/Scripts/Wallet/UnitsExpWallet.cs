using System;

public class UnitsExpWallet : BaseResourceKeeper
{
    public int UnitsExpAmount { get; private set; }

    public UnitsExpWallet(int unitsExpAmount) : base(unitsExpAmount)
    {
        UnitsExpAmount = unitsExpAmount;
    }
}
