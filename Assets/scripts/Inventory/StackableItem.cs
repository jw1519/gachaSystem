using UnityEngine;

[CreateAssetMenu(fileName = "New item", menuName = "Create item/Stackable items/Stackable item")]
public class StackableItem : BaseItem, IStackable
{
    public int currentAmount;
    public int maxAmount;

    public void AddToStack(int amount)
    {
        if (currentAmount + amount <= maxAmount)
        {
            currentAmount += amount;
        }
    }
    public void RemoveFromStack(int amount)
    {
        if (currentAmount + amount >= 0)
        {
            currentAmount -= amount;
        }
    }
}
