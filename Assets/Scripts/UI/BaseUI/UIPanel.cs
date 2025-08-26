using UnityEngine;

public class UIPanel : MonoBehaviour, IPanel
{
    public void Hide()
    {
        gameObject.SetActive(false);
    }

    public void Show()
    {
        gameObject.SetActive(true);
    }
}
