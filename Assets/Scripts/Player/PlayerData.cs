public class PlayerData
{
    public Wallet Wallet {  get; private set; }
    public UnitsExpWallet UnitsExpWallet { get; private set; }
    public FuelKeeper FuelKeeper { get; private set; }

    public PlayerData(int goldAmount, int UnitsExpAmount, int maxFuelAmount, int currentFuelAmount)
    {
        Wallet = new Wallet(goldAmount);
        UnitsExpWallet = new UnitsExpWallet(UnitsExpAmount);
        FuelKeeper = new FuelKeeper(maxFuelAmount, currentFuelAmount);
    }
}
