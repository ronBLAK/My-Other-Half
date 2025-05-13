using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine.UI;

public class InventoryManager : MonoBehaviour
{
    public static InventoryManager instance; // reference to the inventory manager script, making it a singleton type
    public List<Item> items = new List<Item>(); // holds all the items in the inventory, that is picked up

    public Transform itemContent; // reference to the transform of the item content in the inventory UI
    public GameObject inventoryItem; // reference to the prefab of the inventory item UI

    public void Awake()
    {
        instance = this;
    }

    // adds an item to the inventory
    public void Add(Item item)
    {
        items.Add(item);
    }

    // removes an item from the inventory
    public void Remove(Item item)
    {
        items.Remove(item);
    }

    public void ListItems()
    {
        // this first foreach loop is used to clear the item content in the inventory UI, so that the items are not duplicated when list items are called multiple times
        foreach (Transform item in itemContent)
        {
            Destroy(item.gameObject);
        }

        foreach (var item in items)
            {
                GameObject obj = Instantiate(inventoryItem, itemContent); // spawns the item prefab (UI) in the inventory content, when the key is picked up

                var itemName = obj.transform.Find("Item Name").GetComponent<TextMeshProUGUI>(); // gets the name of the item that needs to be printed on the label of the item in inventory
                var itemIcon = obj.transform.Find("Item Icon").GetComponent<Image>(); // gets the icon of the item that needs to be printed on the icon of the item in inventory

                itemName.text = item.itemName;
                itemIcon.sprite = item.icon;
            }
    }
}
