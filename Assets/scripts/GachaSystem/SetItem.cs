using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SetItem : MonoBehaviour
{
    public WishItem wishItem;
    [SerializeField] Image image;
    [SerializeField] TextMeshProUGUI itemName;

    void Start()
    {
        if (wishItem != null)
        {
            image.sprite = wishItem.itemSprite;
            itemName.text = wishItem.itemName;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
