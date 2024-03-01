
using UnityEngine;

[CreateAssetMenu(fileName = "ItemHealthPotion", menuName = "Items/Health Potion")]
public class ItemHealthPotion: InventoryItem
{
    [Header("Config")]
    public float healthValue;


    public override bool UseItem()
    {
        if (GameManager.Instance.Player.PlayerHeath.CanRestoreHealth())
        {
            GameManager.Instance.Player.PlayerHeath.RestoreHealth(healthValue);
            return true;
        }
        return false;
    }
}