using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public class InventoryPanel : BasePanel
{
    public List<BasePanel> inventPanels;

    public void CloseAll()
    {
        foreach (var panel in inventPanels)
        {
            panel.ClosePanel();
        }
    }

}
