using UnityEngine;

public abstract class BasePanel : MonoBehaviour
{
    private void Start()
    {
        UIManager.instance.RegisterPanel(this);
    }
    public virtual void OpenPanel()
    {
        gameObject.SetActive(true);
    }
    public virtual void ClosePanel()
    {
        gameObject.SetActive(false);
    }
}
