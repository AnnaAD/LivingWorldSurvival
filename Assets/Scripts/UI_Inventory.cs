using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Inventory : MonoBehaviour
{
    private Inventory inventory;
    private Transform itemSlot;
    private Transform itemContainer;
    [SerializeField] private GameObject popUp;
    public InventoryType type = InventoryType.Default;
    public Inventory selectedItems;

    public void setInventory(Inventory inventory)
    {
        this.inventory = inventory;

        inventory.OnItemListChanged += Inventory_OnItemListChanged;
        RefreshInventoryItems();
    }

    private void Awake()
    {
        this.itemContainer = transform.Find("ItemSlotContainer");
        this.itemSlot = itemContainer.Find("ItemSlot");
        itemSlot.gameObject.SetActive(false);
        popUp.SetActive(false);
        selectedItems = new Inventory();

    }

    private void Inventory_OnItemListChanged(object Sender, System.EventArgs e)
    {
        RefreshInventoryItems();
        popUp.SetActive(false);
    }

    private void RefreshInventoryItems()
    {
        foreach (Transform child in itemContainer)
        {
            if (child == itemSlot) continue;
            Destroy(child.gameObject);
        }

        int x = 0;
        int y = 0;
        float itemSlotCellSize = 60f;
        foreach (Item i in inventory.GetItems())
        {
            RectTransform itemSlotRectTransform = Instantiate(itemSlot, itemContainer).GetComponent<RectTransform>();
            itemSlotRectTransform.gameObject.SetActive(true);
            itemSlotRectTransform.anchoredPosition = new Vector2(x * itemSlotCellSize, y * itemSlotCellSize);
            itemSlotRectTransform.GetComponent<event_catcher>().setType(type);
            itemSlotRectTransform.GetComponent<event_catcher>().setItem(new Item(i.itemType, i.amount));
            itemSlotRectTransform.GetComponent<event_catcher>().setInventory(inventory);
            itemSlotRectTransform.GetComponent<event_catcher>().setSelectedItems(selectedItems);

            Image image = itemSlotRectTransform.Find("Image").GetComponent<Image>();
            image.sprite = i.getSprite();
            Text text = itemSlotRectTransform.Find("Text").GetComponent<Text>();
            if(i.amount > 1)
            {
                text.text = i.amount.ToString();
            }
            x++;
            if(x > 6)
            {
                y--;
                x = 0;
            }
        }
    }
}

public enum InventoryType
{
    Exchange,
    Default
}
