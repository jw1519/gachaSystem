using UnityEngine;

public class GameStateManager : MonoBehaviour
{
    public static GameStateManager instance;
    public GameState currentState { get; private set; }

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }
    private void Start()
    {
        ChangeState(GameState.Play);
    }
    public void ChangeState(GameState newState)
    {
        if (currentState != newState)
        {
            currentState = newState;
        }
    }
    public void HandleStateChange()
    {
        switch (currentState)
        {
            case GameState.Play:
                Time.timeScale = 1;
                break;
            case GameState.Pause:
                Time.timeScale = 0;
                break;
        }
    }
}
public enum GameState
{
    Play,
    Pause,
}