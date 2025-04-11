
using System;

public interface IResourceKeeper
{
    int Value { get; }
    bool TrySpend(int amount);
    void Add(int amount);
    event Action<int> OnChanged;
}

