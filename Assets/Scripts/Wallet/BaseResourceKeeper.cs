using System;

public abstract class BaseResourceKeeper : IResourceKeeper
{
    protected int _value;
    public int Value => _value;

    public event Action<int> OnChanged;

    protected BaseResourceKeeper(int initialValue)
    {
        if (initialValue < 0)
            throw new ArgumentOutOfRangeException(nameof(initialValue));

        _value = initialValue;
    }

    public virtual void Add(int amount)
    {
        if (amount < 0)
            throw new ArgumentOutOfRangeException(nameof(amount));

        _value += amount;
        OnChanged?.Invoke(_value);
    }

    public virtual bool TrySpend(int amount)
    {
        if (amount < 0)
            throw new ArgumentOutOfRangeException(nameof(amount));

        if (amount > _value)
            return false;

        _value -= amount;
        OnChanged?.Invoke(_value);
        return true;
    }
}
