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

    public Toggle enableRemove; // reference to the toggle that enables the removal of items from the inventory

    private InventoryItemController[] inventoryItems; // list of items in inventory of type inventoryItemController

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
            var removeButton = obj.transform.Find("Remove Button").GetComponent<Button>();

            itemName.text = item.itemName; // sets the name of the item in inventory to item name from scriptablre object
            itemIcon.sprite = item.icon; // sets the icon of the item in inventory to item icon from scriptable object

            if (enableRemove.isOn)
            {
                removeButton.gameObject.SetActive(true);
            }
        }

        SetInventoryItems();
    }

    public void EnableItemsRemove()
    {
        if (enableRemove.isOn)
        {
            foreach (Transform item in itemContent)
            {
                item.Find("Remove Button").gameObject.SetActive(true);
            }
        }
        else
        {
            foreach (Transform item in itemContent)
            {
                item.Find("Remove Button").gameObject.SetActive(false);
            }
        }
    }

    public void SetInventoryItems()
    {
        inventoryItems = itemContent.GetComponentsInChildren<InventoryItemController>(); // loops through all the items in the list and gets the items' InventoryItemController script attached to them

        for (int i = 0; i < items.Count; i++)
        {
            inventoryItems[i].AddItem(items[i]);
        }
    }
}
