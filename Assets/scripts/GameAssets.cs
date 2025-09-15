using UnityEngine;

public class GameAssets : MonoBehaviour
{
    private static GameAssets instance;
    public static GameAssets i
    {
        get { 
            if (instance == null)
                instance = Instantiate(Resources.Load<GameAssets>("GameAssets"));
            return instance;
            }
    }
    private void Awake()
    {
        if (instance == null)
            instance = this;
    }
    public Transform damagePopupPrefab;
}
