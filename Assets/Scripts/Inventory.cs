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
                    i.amount += item.amount;
                    
                    OnItemListChanged?.Invoke(this, EventArgs.Empty);
                    return;
                }
            }
            Debug.Log(item.amount);
           
            itemList.Add(item);
            Debug.Log("added item");
            foreach (Item j in GetItems())
            {
                Debug.Log(j.itemType + " " + j.amount);
            }

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
                // Item itemToRemove = null;
                if (i.itemType == item.itemType)
                {
                    i.amount -= item.amount;
                    Debug.Log(i.amount);
                    if (i.amount <= 0)
                    {
                        Debug.Log("remove");
                        itemList.Remove(i);
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

    }

    public void clearItems()
    {
        itemList = new List<Item>();
    }

    public List<Item> GetItems()
    {
        return itemList;
    }
}
