using UnityEngine;

public class EmptyCell : Cell
{
    protected override void Interact()
    {
        OnCellOpened();
    }

    public override void UnlockCell()
    {
        base.UnlockCell();
        _closedView.SetActive(IsClosed);
    }
}
