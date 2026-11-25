using UnityEngine;

public enum ItemType
{
    Food,
    Drink
}

[CreateAssetMenu(fileName = "ItemDataSO", menuName = "Scriptable Objects/ItemDataSO")]
public class ItemDataSO : ScriptableObject
{
    [Header("Item Data")]
    public int itemID;
    public string itemName;
    [TextArea]
    public string itemDescription;
    public int price;
    public ItemType itemType;

    [Header("Consumable Stats")]
    public float hunger;
    public float thirst;

    [Header("Visual")]
    public Sprite itemIcon;
}
