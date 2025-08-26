using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UnitCardView : MonoBehaviour
{
    public string UnitID => _config.ID;
    public Action CardClicked;

    [SerializeField] private Image _unitPreview;
    [SerializeField] private TextMeshProUGUI _unitLevel;
    [SerializeField] private TextMeshProUGUI _unitCost;
    [SerializeField] private Button _interactButton;

    private UnitShopItemConfig _config;

    public void Initialize(UnitShopItemConfig config)
    {
        _config = config;

        _unitPreview.sprite = config.Icon;
        _unitLevel.text = config.CharacterConfig.SpawningData.SpawningCost.ToString();
        _unitCost.text = config.UnlockPrice.ToString();
    }

    private void OnEnable()
    {
        _interactButton.onClick.AddListener(OnCardClicked);
    }

    private void OnDisable()
    {
        _interactButton.onClick.RemoveListener(OnCardClicked);
    }

    private void OnCardClicked()
    {
        CardClicked?.Invoke();
    }
}
