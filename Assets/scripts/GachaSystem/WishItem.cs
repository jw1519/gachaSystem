using UnityEngine;


    [CreateAssetMenu(fileName = "WishItem", menuName = "wishItems")]
    public class WishItem : BaseItem
    {
        public ItemRarety itemRarety;
    }

    public enum ItemRarety
    {
        ThreeStar,
        FourStar,
        FiveStar,
    }

