using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LootButton : MonoBehaviour
{
    [Header("Config")]
    [SerializeField] private Image itemImage;
    [SerializeField] private TextMeshProUGUI itemName;
    [SerializeField] private TextMeshProUGUI itemQuantity;

    public DropItem ItemLoaded { get; private set; }
    
    public void ConfigLootButton(DropItem dropItem)
    {
        ItemLoaded = dropItem;
        itemImage.sprite = dropItem.Item.Icon;
        itemName.text = dropItem.Item.Name;
        itemQuantity.text = $"x{dropItem.Quantity.ToString()}" ;
    }
    public void CollectItem()
    {
        if (ItemLoaded == null) return;
        Inventory.Instance.AddItem(ItemLoaded.Item, ItemLoaded.Quantity);
        ItemLoaded.PickedItem = true;
        Destroy(gameObject);
    }
}
