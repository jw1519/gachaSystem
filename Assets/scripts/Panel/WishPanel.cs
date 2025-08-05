using UnityEngine;

public class WishPanel : BasePanel
{
    Transform wishItemparent;
    private void Awake()
    {
        wishItemparent = GetComponentInChildren<Transform>();
    }
    public override void ClosePanel()
    {
        foreach (Transform transform in wishItemparent)
        {
            transform.gameObject.SetActive(false);
        }
        base.ClosePanel();
    }
}
