using UnityEngine;

public class BaseItem : ScriptableObject
{
    public Sprite itemSprite;
    public string itemName;
    public ItemType itemType;
}

public enum ItemType
{
    Weapon,
    Food,
    QuestItem
}
