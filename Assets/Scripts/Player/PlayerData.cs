using System.Collections.Generic;

public class PlayerData
{
    public Wallet Wallet {  get; private set; }
    public UnitsExpWallet UnitsExpWallet { get; private set; }
    public FuelKeeper FuelKeeper { get; private set; }
    public PurchasedItemsData PurchasedItemsData { get; private set; }
    public UnlockedUnitsData UnlockedUnitsData { get; private set; }
    public CurrentPlayerDeck CurrentPlayerDeck { get; private set; }


    public PlayerData(int goldAmount, int UnitsExpAmount, int maxFuelAmount, int currentFuelAmount, List<string> currentPickedUnits)
    {
        Wallet = new Wallet(goldAmount);
        UnitsExpWallet = new UnitsExpWallet(UnitsExpAmount);
        FuelKeeper = new FuelKeeper(maxFuelAmount, currentFuelAmount);
        CurrentPlayerDeck = new CurrentPlayerDeck(currentPickedUnits);
        //—читать PurchasedItemsData и UnlockedUnitsData 
    }
}
