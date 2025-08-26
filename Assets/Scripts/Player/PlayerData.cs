using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class PlayerData
{
    private const string DefaultDataPath = "DefaultData";

    public Wallet Wallet {  get; private set; }
    public UnitsExpWallet UnitsExpWallet { get; private set; }
    public FuelKeeper FuelKeeper { get; private set; }
    public PurchasedItemsData PurchasedItemsData { get; private set; }
    public UnlockedUnitsData UnlockedUnitsData { get; private set; }
    public CurrentPlayerDeck CurrentPlayerDeck { get; private set; }

    public PlayerData(int goldAmount, int UnitsExpAmount, int maxFuelAmount, int currentFuelAmount, List<string> currentPickedUnits, string startUnlockedUnitID)
    {
        Wallet = new Wallet(goldAmount);
        UnitsExpWallet = new UnitsExpWallet(UnitsExpAmount);
        FuelKeeper = new FuelKeeper(maxFuelAmount, currentFuelAmount);
        CurrentPlayerDeck = new CurrentPlayerDeck(currentPickedUnits);
        PurchasedItemsData = new PurchasedItemsData(startUnlockedUnitID);
        UnlockedUnitsData = new UnlockedUnitsData(startUnlockedUnitID);
        //TODO: добавить загрузку данных прогресса игры
    }

    public PlayerData() 
    {
        Debug.Log("Создан объект PlayerData");
        DefaultData defaultData = Resources.Load<DefaultData>(DefaultDataPath);

        Wallet = new Wallet(defaultData.StartGold);
        UnitsExpWallet = new UnitsExpWallet(defaultData.StartUnitsExpAmount);
        FuelKeeper = new FuelKeeper(defaultData.MaxFuelAmount, defaultData.StartFuelAmount);
        CurrentPlayerDeck = new CurrentPlayerDeck(new List<string> { defaultData.StartPickedUnit });
        PurchasedItemsData = new PurchasedItemsData(defaultData.StartPickedUnit);
        UnlockedUnitsData = new UnlockedUnitsData(defaultData.StartPickedUnit);
    }
}
