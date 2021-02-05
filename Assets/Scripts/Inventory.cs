using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Inventory {

    private List<Item> itemList;

    public event EventHandler OnItemListChanged;

    public Inventory()
    {
        itemList = new List<Item>();
    }

    public void  addItem(Item item)
    {
        if(item.isStackable())
        {
            foreach (Item i in itemList)
            {
                if (i.itemType == item.itemType)
                {
                    i.amount += 1;
                    return;
                } 
            }
            itemList.Add(item);

        }
        else
        {
            itemList.Add(item);
        }

        OnItemListChanged?.Invoke(this, EventArgs.Empty);
    }

    public void removeItem(Item item)
    {
        if (item.isStackable())
        {
            foreach (Item i in itemList)
            {
                Item itemToRemove = null;
                if (i.itemType == item.itemType)
                {
                    i.amount -= 1;
                    if (i.amount <= 0)
                    {
                        itemList.Remove(item);
                        OnItemListChanged?.Invoke(this, EventArgs.Empty);
                        return;
                    }
                }
            }    
        }
        else
        {
            itemList.Remove(item);
        }
        OnItemListChanged?.Invoke(this, EventArgs.Empty);

        Debug.Log(itemList);
    }

    public List<Item> GetItems()
    {
        return itemList; 
    }
}
