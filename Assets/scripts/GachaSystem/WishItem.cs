using UnityEngine;


    [CreateAssetMenu(fileName = "WishItem", menuName = "wishItems")]
    public class WishItem : BaseItem
    {
        public Rarety itemRarety;
    }

    public enum Rarety
    {
        ThreeStar,
        FourStar,
        FiveStar,
    }

