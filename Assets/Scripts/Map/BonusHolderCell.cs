using UnityEngine;

public class BonusHolderCell : Cell
{
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

    }
}
