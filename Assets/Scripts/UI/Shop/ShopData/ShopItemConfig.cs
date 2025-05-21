using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ShopItemConfig", menuName = "Shop/Item")]
public class ShopItemConfig : ScriptableObject
{
    [field: SerializeField] public string ID { get; private set; }
    [field: SerializeField] public UnitDataConfig CharacterConfig { get; private set; }
    [field: SerializeField] public int UnlockPrice { get; private set; }
    [field: SerializeField] public Sprite Icon { get; private set; }
    [field: SerializeField] public string DisplayName { get; private set; }
    [field: SerializeField] public bool UnlockedOnStart { get; private set; }

}
