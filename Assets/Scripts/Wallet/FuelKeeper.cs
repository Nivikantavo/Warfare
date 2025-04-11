using System;
using UnityEngine;

public class FuelKeeper : BaseResourceKeeper
{
    private int _maxFuelAmount;

    public FuelKeeper(int maxFuelAmount, int currentFuelAmount) : base(currentFuelAmount)
    {
        if (maxFuelAmount< 0)
            throw new ArgumentOutOfRangeException(nameof(currentFuelAmount));

        _maxFuelAmount = maxFuelAmount;
    }

    public override void Add(int amount)
    {
        base.Add(amount);

        _value = Mathf.Clamp(_value, 0, _maxFuelAmount);
    }
}
