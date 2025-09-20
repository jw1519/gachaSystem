using UnityEngine;

public abstract class BasePanel : MonoBehaviour
{
    public virtual void Start()
    {
        UIManager.instance.RegisterPanel(this);
    }
    public virtual void OpenPanel()
    {
        gameObject.SetActive(true);
        GameStateManager.instance.ChangeState(GameState.Pause);
    }
    public virtual void ClosePanel()
    {
        gameObject.SetActive(false);
        GameStateManager.instance.ChangeState(GameState.Play);
    }
}
