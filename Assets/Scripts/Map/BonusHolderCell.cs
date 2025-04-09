using System;
using UnityEngine;

public class BonusHolderCell : Cell
{
    public event Action<BonusCellData> BonusCellInteract;

    [SerializeField] private BonusCellData _bonusData;

    protected override void Interact()
    {
        if (IsClosed)
        {
            GiveBonus();
        }
        else
        {
            OnCellOpened();
        }
    }
    public override void UnlockCell()
    {
        base.UnlockCell();
        _closedView.SetActive(IsClosed);
    }

    private void GiveBonus()
    {
        BonusCellInteract?.Invoke(_bonusData);
    }
}
