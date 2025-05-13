using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "Item/Create New Item")]
public class Item : ScriptableObject
{
    public int id;
    public string itemName;
    public Sprite icon;
    public GameObject itemObject;
    public ItemType itemType;

    public enum ItemType
    {
        BlueKeyHusband,
        GreenKeyHusband,
        RedKeyHusband,
        BlueKeyWife,
        GreenKeyWife,
        RedKeyWife,
    }
}
