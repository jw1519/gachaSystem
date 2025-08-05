using UnityEngine;

public class WishPanel : BasePanel
{
    Transform wishItemparent;
    private void Awake()
    {
        wishItemparent = transform.GetChild(0);
    }
    public override void ClosePanel()
    {
        Destroy(wishItemparent.GetChild(0).gameObject);
        base.ClosePanel();
    }
}
