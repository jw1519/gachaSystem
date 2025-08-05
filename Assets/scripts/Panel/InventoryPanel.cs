using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public class InventoryPanel : BasePanel
{
    public List<InventPanels> inventPanels;

    public void CloseAll()
    {
        foreach (InventPanels panel in inventPanels)
        {
            panel.ClosePanel();
        }
    }
    public void AddItemToPanel(BaseItem item, Transform itemGO)
    {
        switch (item.itemType)
        {
            case ItemType.Weapon:
                itemGO.SetParent(inventPanels.Find(panel => panel.name == "WeaponPanel").content);
                break;
            case ItemType.Food:
                itemGO.SetParent(inventPanels.Find(panel => panel.name == "FoodPanel").content);
                break;
            case ItemType.QuestItem:
                itemGO.SetParent(inventPanels.Find(panel => panel.name == "QuestItemPanel").content);
                break;
        }
    }

}
