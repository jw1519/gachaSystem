using UnityEngine;

public class GachaRate : MonoBehaviour
{

    public GameObject characterPrefab;

    public string rarety;
    [Range(1, 100)]
    public int rate;

    public WishItem[] reward;
}
