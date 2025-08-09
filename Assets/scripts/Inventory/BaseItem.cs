using UnityEngine;

public class BaseItem : ScriptableObject
{
    public Sprite itemSprite;
    public string itemName;
    public Type itemType;
}

public enum Type
{
    Weapon,
    Food,
    QuestItem,
    Character,
}
