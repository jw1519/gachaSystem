using System;
using UnityEngine;
using Inventory;

public class GachaSystem : MonoBehaviour
{
    [SerializeField] GachaRate[] gachaRate;
    [SerializeField] Transform parent, pos;
    [SerializeField] GameObject wishItemPrefab;
    public int wishCost;
    private void Awake()
    {
        //for (int i = 0; i < 10; i++)
        //{
        //    GameObject instance = Instantiate(wishItemPrefab, pos.position, Quaternion.identity);
        //    instance.transform.SetParent(pos);
        //    instance.transform.localScale = Vector3.one;
        //}
    }
    public void OneWish()
    {
        if (wishItemPrefab != null)
        {
            GameObject instance = Instantiate(wishItemPrefab, pos.position, Quaternion.identity);
            instance.transform.SetParent(pos);
            instance.transform.localScale = Vector3.one;

            SetItem item = instance.GetComponent<SetItem>();
            int random = UnityEngine.Random.Range(0, 101);
            for (int i = 0; i < gachaRate.Length; i++)
            {
                if (gachaRate[i].rate <= random)
                {
                    WishItem wishItem = Reward(gachaRate[i].rarety);
                    if (wishItem.itemType == ItemType.Weapon)
                    {
                        Inventory.Inventory.instance.AddItem(wishItem, 1);
                    }
                    return;
                }
            }
        }
    }
    public void TenWish()
    {
        for (int i = 0; i < 10; i++)
        {
            OneWish();
        }
    }
    public WishItem Reward(string rarety)
    {
        GachaRate gr = Array.Find(gachaRate, rt => rt.rarety == rarety);
        WishItem[] reward = gr.reward;

        int rnd = UnityEngine.Random.Range(0, reward.Length);
        parent.gameObject.SetActive(true);
        return reward[rnd];
    }
}
