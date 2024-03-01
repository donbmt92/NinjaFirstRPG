
using UnityEngine;

[CreateAssetMenu(fileName = "ItemManaPotion", menuName = "Items/Mana Potion")]
public class ItemManaPotion : InventoryItem
{
    [Header("Config")]
    public float manaValue;

    public override bool UseItem()
    {
        if (GameManager.Instance.Player.PlayerMana.CanRecoverMana())
        {
            GameManager.Instance.Player.PlayerMana.RecoverMana(manaValue);
            return true;
        }
        return false;
    }
}
