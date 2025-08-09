using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Inventory
{
    public class Inventory : MonoBehaviour
    {
        public static Inventory instance;

        public List<BaseItem> itemList;
        public Transform itemContainer;
        public GameObject itemTemplate;

        public InventoryPanel inventoryPanel;

        public TextMeshProUGUI notificationText;

        private void Awake()
        {
            if (instance == null)
            {
                instance = this;
            }
        }
        private void Start()
        {
            inventoryPanel = UIManager.instance.panels.Find(panel => panel.name == "InventoryPanel").gameObject.GetComponent<InventoryPanel>();
        }
        //add and remove Items
        public void AddItem(BaseItem item, int amountToAdd)
        {
            if (item is StackableItem stackable)
            {
                if (itemList.Contains(item))
                {
                    stackable.AddToStack(amountToAdd);
                    UpdateStackAmount(stackable);
                }
                else
                {
                    itemList.Add(item);
                    NewItem(item);
                }
            }
            else
            {
                itemList.Add(item);
                NewItem(item);
            }
        }
        public void RemoveItem(BaseItem item, int amountToSubtract)
        {
            if (item is StackableItem stackable)
            {
                stackable.RemoveFromStack(amountToSubtract);
                UpdateStackAmount(stackable);
            }
            else
            {
                itemList.Remove(item);
            }
        }

        public void NewItem(BaseItem item)
        {
            GameObject gameObject = Instantiate(itemTemplate, itemContainer);

            //setting itemImage
            var itemImage = gameObject.transform.Find("itemImage");
            if (itemImage != null)
            {
                Image image = itemImage.GetComponent<Image>();
                image.sprite = item.itemSprite;
            }

            //setting itemName
            var itemName = gameObject.transform.Find("itemName");
            if (itemName != null)
            {
                TextMeshProUGUI text = itemName.GetComponent<TextMeshProUGUI>();
                text.text = item.itemName;
            }
            //setting itemAmount if its stackable
            if (item is StackableItem stackable)
            {
                UpdateStackAmount(stackable);
            }
            if (inventoryPanel != null)
            {
                if (item.itemType != Type.Character)
                {
                    inventoryPanel.AddItemToPanel(item, gameObject.transform);
                }
            }
            

        }
        public void UpdateStackAmount(StackableItem stackable)
        {
            var itemAmount = gameObject.transform.Find("amountText");
            if (itemAmount != null)
            {
                TextMeshProUGUI amountText = itemAmount.GetComponent<TextMeshProUGUI>();
                amountText.text = stackable.currentAmount.ToString() + "/" + stackable.maxAmount.ToString();
            }
        }
        public void ListItems() // should be called when opening inventory
        {
            //clean the inventory before displaying
            foreach (Transform item in itemContainer)
            {
                Destroy(item.gameObject);
            }

            //going through item list to instatiating them 
            foreach (BaseItem item in itemList)
            {
                GameObject gameObject = Instantiate(itemTemplate, itemContainer);

                //setting itemImage
                var itemImage = gameObject.transform.Find("itemImage");
                if (itemImage != null)
                {
                    Image image = itemImage.GetComponent<Image>();
                    image.sprite = item.itemSprite;
                }

                //setting itemName
                var itemName = gameObject.transform.Find("itemName");
                if (itemName != null)
                {
                    TextMeshProUGUI text = itemName.GetComponent<TextMeshProUGUI>();
                    text.text = item.itemName;
                }

                //setting itemAmount if its stackable
                if (item is StackableItem stackable)
                {
                    var itemAmount = gameObject.transform.Find("amountText");
                    if (itemAmount != null)
                    {
                        TextMeshProUGUI amountText = itemAmount.GetComponent<TextMeshProUGUI>();
                        amountText.text = stackable.currentAmount.ToString() + "/" + stackable.maxAmount.ToString();
                    }
                }
            }
        }
    }
}
