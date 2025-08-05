using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public static UIManager instance;
    public List<BasePanel> panels;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    public void RegisterPanel(BasePanel panel)
    {
        if (!panels.Contains(panel))
        {
            panels.Add(panel);
        }
    }

    public void CloseAll()
    {
        foreach (BasePanel panel in panels)
        {
            panel.ClosePanel();
        }
    }
}
