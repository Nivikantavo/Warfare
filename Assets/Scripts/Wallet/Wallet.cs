using System;

[Serializable]
public class Wallet : BaseResourceKeeper
{
    public Wallet(int goldAmount) : base(goldAmount){ }
}
