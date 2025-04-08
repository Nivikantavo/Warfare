using System;
using UnityEngine;

public abstract class Cell : MonoBehaviour, IClickInteractable
{
    public event Action<Cell> CellOpened;

    public bool IsLocked {  get; protected set; }
    public bool IsClosed { get; protected set; }

    [SerializeField] protected GameObject _lockView;
    [SerializeField] protected GameObject _closedView;

    private void Awake()
    {
        IsLocked = true;
        IsClosed = true;

        _lockView.SetActive(true);
        _closedView.SetActive(false);
    }

    public virtual void UnlockCell()
    {
        IsLocked = false;
        _lockView.gameObject.SetActive(IsLocked);
    }

    public virtual void InteractOnClick()
    {
        if(IsLocked) return;

        Interact();
    }

    protected virtual void Interact()
    {

    }

    protected void OnCellOpened()
    {
        IsClosed = false;
        CellOpened?.Invoke(this);
        _closedView.SetActive(IsClosed);
    }
}
